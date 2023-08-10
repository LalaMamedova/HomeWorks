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

namespace WhiteBoardProject.ViewModel
{
    public class DrawViewModel : ViewModelBase, INotifyPropertyChanged
    {
        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler? PropertyChanged;

        private IClientService saveService;
        private readonly IMessenger _messenger;
        private DrawingAttributes drawingAttributes = new();
        private InkCanvasEditingMode inkCanvasEditingMode = InkCanvasEditingMode.Ink;
        private SolidColorBrush selectedBackGround = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
        private double width = 50;
        private double height = 50;
        private InkCanvas _inkCanvas;


        public ColorList ColorList { get; set; } = new();
        public StrokeCollection Stroke { get; set; } = new();
        public string WhatIsDrawing { get; set; }
        public double Width { get => width; set { width = value; drawingAttributes.Width = Width; NotifyPropertyChanged(nameof(Width)); } }
        public double Height { get => height; set { height = value; NotifyPropertyChanged(nameof(Height)); } }
        public DrawingAttributes DrawingAttributes { get => drawingAttributes; set { drawingAttributes = value; NotifyPropertyChanged(nameof(DrawingAttributes)); } }
        public SolidColorBrush SelectedBackGround { get => selectedBackGround; set { selectedBackGround = value; NotifyPropertyChanged(nameof(SelectedBackGround)); } }
        public InkCanvasEditingMode InkCanvasEditingMode { get => inkCanvasEditingMode; set { inkCanvasEditingMode = value; NotifyPropertyChanged(nameof(InkCanvasEditingMode)); } }
        public ChangableObject isNightMode { get; set; } = new() { MyData = "Светлый" };
        public Point MousePosition { get; set; } = new();
        public UserArt UserArt { get; set; } = new();
        public User User { get; set; } = new() ;
        public InkCanvas MyInkCanvas
        {
            get { return _inkCanvas; }
            set { _inkCanvas = value; NotifyPropertyChanged(nameof(MyInkCanvas)); }
        }
       
        public DrawViewModel(IMessenger messenger)
        {
            _messenger = messenger;
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
        public RelayCommand<string> ChoiceColor { get => new(param =>{ DrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(param);});}

        public RelayCommand<InkCanvas> SaveImg
        {
            get => new((param) => 
            {
                saveService = new PictureService(new object[] { param, UserArt,User});
                UserArt.ArtName += ".png";
                saveService.SendToServer("Add");

                User.UserArts.Add(UserArt);
                saveService = new UserService(User);
                saveService.SendToServer("Update");
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

                saveService = new PictureService(new object[] { param, UserArt, User });
                saveService.SendToServer("Update");

                User.UserArts.Add(UserArt);
                saveService = new UserService(User);
                saveService.SendToServer("Update");

            });
        }

        

        public RelayCommand<InkCanvas> MouseMoveCommand
        {
            get => new((inkcanvas) =>
            {
                MousePosition = Mouse.GetPosition(inkcanvas);
                MyInkCanvas = inkcanvas;
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

       
    }

    

}
