using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using System.Windows.Media;
using WhiteBoardProject.Class;
using System.Windows.Ink;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using WhiteBoardProject.Service.Classes;
using ProjectLib.Model.Class;
using System.IO;
using System.Windows.Media.Imaging;
using WhiteBoardProject.Converters;
using Microsoft.Win32;
using WhiteBoardProject.Service.Interface;
using WhiteBoardProject.Service.ClientService;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Linq;
using WhiteBoardProject.View;

namespace WhiteBoardProject.ViewModel
{
    public class DrawViewModel : ViewModelBase, INotifyPropertyChanged
    {
        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly IMessenger _messenger;
        private readonly INavigate _navigate;
        private IWhiteboardtService saveService;
        private DrawingAttributes drawingAttributes = new();
        private InkCanvasEditingMode inkCanvasEditingMode = InkCanvasEditingMode.Ink;
        private SolidColorBrush selectedBackGround = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
        private List<Stroke> deletedStrokes = new List<Stroke>();




        public static bool isRedact = false;
        public double Width { get; set; } = 50;
        public double Height { get; set; } = 50;
        public ColorList ColorList { get; set; } = new();
        public StrokeCollection Stroke { get; set; } = new();
        public string WhatIsDrawing { get; set; }
        public DrawingAttributes DrawingAttributes { get => drawingAttributes; set { drawingAttributes = value; NotifyPropertyChanged(nameof(DrawingAttributes)); } }
        public SolidColorBrush SelectedBackGround { get => selectedBackGround; set { selectedBackGround = value; NotifyPropertyChanged(nameof(SelectedBackGround)); } }
        public InkCanvasEditingMode InkCanvasEditingMode { get => inkCanvasEditingMode; set { inkCanvasEditingMode = value; NotifyPropertyChanged(nameof(InkCanvasEditingMode)); } }
        public ChangableObject isNightMode { get; set; } = new() { MyData = "Светлый" };
        public UserArt UserArt { get; set; } = new();
        public User User { get; set; } 
       
       
        public DrawViewModel(IMessenger messenger, INavigate navigate)
        {
            _messenger = messenger;
            _navigate = navigate;

            DrawingAttributes.Color = (Color)ColorConverter.ConvertFromString("White");
            _messenger.Register<DataMessager>(this, message =>
            {
                if (message.Data.GetType().Name == nameof(User))
                {
                    User = message.Data as User;
                }
                else if (message.Data.GetType().Name == nameof(UserArt))
                {
                    UserArt = message.Data as UserArt;
                }
            });
        }
    
        public RelayCommand Erase
        {
            get => new(() =>
            {
                WhatIsDrawing = "None";
                InkCanvasEditingMode = InkCanvasEditingMode.EraseByPoint;
            });
        }
        public RelayCommand Select
        {
            get => new(() =>
            {
                WhatIsDrawing = "None";
                InkCanvasEditingMode = InkCanvasEditingMode.Select;
            });
        }

        public RelayCommand DrawWithPen
        {
            get => new(() =>
            {
                InkCanvasEditingMode = InkCanvasEditingMode.Ink;
                WhatIsDrawing = "None";
            });
        }

        public RelayCommand ChangeMode
        {
            get => new(() =>
            {
                if ((string)isNightMode.MyData == "Темный")
                {
                    SelectedBackGround.Color = ((Color)ColorConverter.ConvertFromString("White"));
                    DrawingAttributes.Color = (Color)ColorConverter.ConvertFromString("Black");
                    isNightMode.MyData = "Светлый";
                }
                else
                {
                    SelectedBackGround.Color = ((Color)ColorConverter.ConvertFromString("Black"));
                    DrawingAttributes.Color = (Color)ColorConverter.ConvertFromString("White");
                    isNightMode.MyData = "Темный";
                }
            });
        }
        public RelayCommand Text { get => new(() => { WhatIsDrawing = "Text"; }); }
        public RelayCommand DrawCircle  { get => new(() => {WhatIsDrawing = "Circle";});}
        public RelayCommand DrawDash { get => new(() => { WhatIsDrawing = "Dash";}); }
        public RelayCommand DrawTriangle { get => new(() => {WhatIsDrawing = "Triangle";});}
        public RelayCommand DrawRectangle { get => new(() => {WhatIsDrawing = "Rectangle";}); }
        public RelayCommand<InkCanvas> Highlighter 
        {
            get => new((canvas)  => 
            {
                if (canvas.DefaultDrawingAttributes.IsHighlighter == true)
                    canvas.DefaultDrawingAttributes.IsHighlighter = false;
                else
                    canvas.DefaultDrawingAttributes.IsHighlighter = true;
            });
        }
        public RelayCommand Back
        {
            get => new(() =>
            {
                deletedStrokes.Add(Stroke.Last());
                Stroke.Remove(Stroke.Last());
            });
        }

        public RelayCommand Foward
        {
            get => new(() =>
            {
                Stroke.Add(deletedStrokes.Last());
                deletedStrokes.Remove(Stroke.Last());

            });
        }

        public RelayCommand<string> ChoiceColor { get => new(param =>{ DrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(param);});}

        public RelayCommand<InkCanvas> SaveImg
        {
            get => new((param) => 
            {
                saveService = new ArtService();
                saveService.Save(new object[] { param, UserArt, User });

                if (isRedact == false)
                {
                    User.UserArts.Add(UserArt);
                    saveService.SendToServer("Add");
                }
                else
                {
                    saveService.SendToServer("Update");
                    isRedact = false;
                }

                saveService = new UserService(User);
                saveService.SendToServer("Update");
                RememberMeService.RememberMe(User);
            });
        }

        public RelayCommand<InkCanvas> SaveAs
        {
            get => new((param) =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JPEG Image (.jpeg)|*.jpeg|Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
                saveFileDialog.FileName = UserArt.ArtName;
                saveFileDialog.ShowDialog();
                UserArt.ArtName = saveFileDialog.FileName;

                saveService = new ArtService();
                saveService.Save(new object[] { param, UserArt, User });

                if (isRedact == false)
                {
                    User.UserArts.Add(UserArt);
                    saveService.SendToServer("Add");
                }
                else
                {
                    saveService.SendToServer("Update");
                    isRedact = false;
                }

                saveService = new UserService(User);
                saveService.SendToServer("Update");
                RememberMeService.RememberMe(User);

            });
        }

        

        public RelayCommand<InkCanvas> MouseMoveCommand
        {
            get => new((inkcanvas) =>
            {
                Point MousePosition = Mouse.GetPosition(inkcanvas);
                if (WhatIsDrawing == "Circle")
                {
                    InkCanvasEditingMode = InkCanvasEditingMode.None;
                    Stroke.Add(DrawService.Circle(MousePosition, drawingAttributes, Width, Height));
                }
                else if (WhatIsDrawing == "Rectangle")
                {
                    InkCanvasEditingMode = InkCanvasEditingMode.None;
                    Stroke.Add(DrawService.Rectangle(MousePosition, drawingAttributes, Width, Height));

                }
                else if (WhatIsDrawing == "Triangle")
                {
                    Stroke.Add(DrawService.Triangle(MousePosition, drawingAttributes, Width, Height));
                }
                else if (WhatIsDrawing == "Dash")
                {
                    InkCanvasEditingMode = InkCanvasEditingMode.None;
                    Stroke.Add(DrawService.Dash(MousePosition, drawingAttributes, Width, Height));
                }
                else if(WhatIsDrawing == "Text")
                {
                    InkCanvasEditingMode = InkCanvasEditingMode.None;
                    inkcanvas.Children.Add(DrawService.Text(MousePosition, drawingAttributes, Width));
                }
            });
        }

        public RelayCommand<InkCanvas> MouseMoveDownCommand
        {
            get => new((param) =>
            {
            });
        }

        public RelayCommand ToMainMenu
        {
            get => new(() =>
            {
                _navigate.NavigateTo<HomeViewModel>(User);
            });
        }

        public RelayCommand ToEmail
        {
            get => new(() =>
            {
                _navigate.NavigateTo<SendEmailViewModel>(UserArt);
                _messenger.Send(new DataMessager() { Data = User});
            });
        }



    }



}
