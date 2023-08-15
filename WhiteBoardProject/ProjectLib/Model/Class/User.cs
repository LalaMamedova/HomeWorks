using Microsoft.EntityFrameworkCore.Metadata;
using ProjectLib.Model.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib.Model.Class
{
    [Serializable]
    public class User : IUser,IWhiteboardcs
    {
        //[NonSerialized]
        //private IPEndPoint _ipEndPoint;
        //public IPEndPoint IPEndPoint
        //{
        //    get => _ipEndPoint;
        //    set => _ipEndPoint = value;
        //}

        public int Id {get;set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int UserArtId { get; set; }
        //[NonSerialized]
        private ObservableCollection<UserArt> userArts;

        public ObservableCollection<UserArt> UserArts
        {
            get { return userArts; }
            set { userArts = value; }
        }


        public override string ToString()
        {
            return $"{Id} {Username} {Email}";
        }
    }
}
