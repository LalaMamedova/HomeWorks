using Microsoft.EntityFrameworkCore.Metadata;
using ProjectLib.Model.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib.Model.Class
{
    public class User : IUser,IWhiteboardcs,INotifyPropertyChanged
    {
        [NonSerialized]
        private ICollection<UserArt> userArts;
        private IPEndPoint _ipEndPoint;
        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler? PropertyChanged;
        public IPEndPoint IPEndPoint
        {
            get => _ipEndPoint;
            set => _ipEndPoint = value;
        }
        public int Id {get;set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserArt UserArt { get; set; }
        public ICollection<UserArt> UserArts
        {
            get { return userArts; }
            set { userArts = value; NotifyPropertyChanged(nameof(UserArts)); }
        }


        public override string ToString()
        {
            return $"{Id} {Username} {Email}";
        }
    }
}
