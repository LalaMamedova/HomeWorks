﻿using GalaSoft.MvvmLight;
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
using System.Threading.Tasks;
using System;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Printing;
using System.Windows.Xps;
using System.Reflection;
using System.Windows.Shapes;
using Humanizer;

namespace WhiteBoardProject.ViewModel
{
    public class DrawViewModel : ViewModelBase, INotifyPropertyChanged
    {
        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly IMessenger _messenger;
        private readonly INavigate _navigate;
        private ArtService saveService =new ArtService();
        private DrawingAttributes drawingAttributes = new();
        private InkCanvasEditingMode inkCanvasEditingMode = InkCanvasEditingMode.Ink;
        private SolidColorBrush selectedBackGround = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
        private List<Stroke> deletedStrokes = new List<Stroke>();
        private double width = 50;
        private double height = 50;
      

        public static bool isRedact = false;
        public double Width { get { return width; }set { width = value; drawingAttributes.Width = width; }}
        public double Height { get { return height; } set { height = value;  drawingAttributes.Height = height; }}
        public ColorList ColorList { get; set; } = new();
        public StrokeCollection Stroke { get; set; } = new();
        public string WhatIsDrawing { get; set; }
        public DrawingAttributes DrawingAttributes { get => drawingAttributes; set { drawingAttributes = value; NotifyPropertyChanged(nameof(DrawingAttributes)); } }
        public SolidColorBrush SelectedBackGround { get => selectedBackGround; set { selectedBackGround = value; NotifyPropertyChanged(nameof(SelectedBackGround)); } }
        public InkCanvasEditingMode InkCanvasEditingMode { get => inkCanvasEditingMode; set { inkCanvasEditingMode = value; NotifyPropertyChanged(nameof(InkCanvasEditingMode)); } }
        public ChangableObject isNightMode { get; set; } = new() { MyData = "Светлый" };
        public UserArt UserArt { get; set; } 
        public User User { get; set; }
  
        public string ArtName { get; set; }


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
                    ArtName = UserArt.ArtName;
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
        public RelayCommand Text { get => new(() => { WhatIsDrawing = "Text"; InkCanvasEditingMode = InkCanvasEditingMode.None;  }); }
        public RelayCommand DrawCircle  { get => new(() =>  {WhatIsDrawing = "Circle"; InkCanvasEditingMode = InkCanvasEditingMode.None; } );}
        public RelayCommand DrawDash { get => new(() => { WhatIsDrawing = "Dash"; InkCanvasEditingMode = InkCanvasEditingMode.None; }); }
        public RelayCommand DrawTriangle { get => new(() => {WhatIsDrawing = "Triangle"; InkCanvasEditingMode = InkCanvasEditingMode.None; });}
        public RelayCommand DrawRectangle { get => new(() => {WhatIsDrawing = "Rectangle"; InkCanvasEditingMode = InkCanvasEditingMode.None; }); }
        public RelayCommand<InkCanvas> Highlighter 
        {
            get => new((canvas)  => 
            {
                if (canvas.DefaultDrawingAttributes.IsHighlighter == true)
                    canvas.DefaultDrawingAttributes.IsHighlighter = false;
                else
                    canvas.DefaultDrawingAttributes.IsHighlighter = true;
                InkCanvasEditingMode = InkCanvasEditingMode.Ink;
            });
        }
        public RelayCommand Back
        {
            get => new(() =>
            {
                if (Stroke.Count > 0)
                {
                    deletedStrokes.Add(Stroke.Last());
                    Stroke.Remove(Stroke.Last());
                }
            });
        }

        public RelayCommand Foward
        {
            get => new(() =>
            {
                if (deletedStrokes.Count > 0)
                {
                    Stroke.Add(deletedStrokes.Last());
                    deletedStrokes.Remove(Stroke.Last());
                }
            });
        }

        public RelayCommand<string> ChoiceColor { get => new(param =>{ DrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(param);});}

        public RelayCommand<InkCanvas> SaveImg
        {
            get => new((ink) => 
            {
                UserArt? isThisNameExist = User.UserArts.Where(x=>x.ArtName == ArtName).FirstOrDefault();
                UserArt.ArtName = ArtName;
                saveService.Save(new object[] { ink,UserArt, User });
                UserArt = saveService.SaveInAllPlace(isThisNameExist,isRedact);
                UserService userService = new UserService();
                userService.SendToServer("Update", User);
                User = (User)userService.Recive();
                
                
            });
        }

        public RelayCommand<InkCanvas> SaveAs
        {
            get => new((ink) =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JPEG Image (.jpeg)|*.jpeg|Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
                saveFileDialog.FileName = ArtName;
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != null)
                {
                    UserArt? isThisNameExist = User.UserArts.Where(x => x.ArtName == ArtName).FirstOrDefault();
                    UserArt.ArtName = ArtName;
                    saveService.Save(new object[] { ink, UserArt, User });
                    UserArt = saveService.SaveInAllPlace(isThisNameExist,isRedact);

                    UserService userService = new UserService();
                    userService.SendToServer("Update", User);
                    User = (User)userService.Recive();

                    
                }
            }); 
        }

        

        public RelayCommand<InkCanvas> MouseMoveCommand
        {
            get => new((inkcanvas) =>
            {
                Point MousePosition = Mouse.GetPosition(inkcanvas);
                if (!string.IsNullOrEmpty(WhatIsDrawing) && WhatIsDrawing != "None")
                {
                    string methodName = WhatIsDrawing;

                    MethodInfo method = typeof(DrawService).GetMethod(methodName, BindingFlags.Static | BindingFlags.Public);
                    if (method != null)
                    {
                        InkCanvasEditingMode = InkCanvasEditingMode.None;

                        object result = method.Invoke(null, new object[] { MousePosition, drawingAttributes, Width, Height });

                        if (result is Stroke shape)
                        {
                            Stroke.Add(shape);
                        }
                        else if (result is UIElement uiElement)
                        {
                            inkcanvas.Children.Add(uiElement);
                        }
                    }
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
                isRedact = false;

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


        public RelayCommand Print
        {
            get => new(() =>
            {
                ArtService artService = new(UserArt);

                Image image = new Image();
                image.Source = artService.FromByteToImage(UserArt);
                image.Width = UserArt.Width; 
                image.Height = UserArt.Height;
        

                PrintDialog printDialog = new PrintDialog();
                if(printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(image, UserArt.ArtName);
                }

            });
        }
   
        public RelayCommand<InkCanvas> ZoomIn
        {
            get => new((inkCanvas) =>
            {
                if (inkCanvas.Background is ImageBrush imageBrush && imageBrush.ImageSource is BitmapImage bitmapImage)
                {
                    ScaleTransform transform = new ScaleTransform(1.5, 0.5);
                    imageBrush.Transform = transform;

                    inkCanvas.LayoutTransform = new ScaleTransform(1.5, 0.5);
                }

            });
        }

        public RelayCommand<InkCanvas> ZoomOut
        {
            get => new((inkCanvas) =>
            {
                if (inkCanvas.Background is ImageBrush imageBrush && imageBrush.ImageSource is BitmapImage bitmapImage)
                {
                    ScaleTransform transform = new ScaleTransform(0.5, 0.5);
                    imageBrush.Transform = transform;

                    inkCanvas.LayoutTransform = new ScaleTransform(0.5, 0.5);
                }

            });
        }

    
        public void Zoom(double zoomFactor, InkCanvas inkCanvas)
        {
            if (inkCanvas.Background is ImageBrush imageBrush && imageBrush.ImageSource is BitmapImage bitmapImage)
            {
                ScaleTransform transform = new ScaleTransform(0.5, 0.5);
                imageBrush.Transform = transform;

                inkCanvas.LayoutTransform = new ScaleTransform(0.5, 0.5);
            }

        }



    }



}
