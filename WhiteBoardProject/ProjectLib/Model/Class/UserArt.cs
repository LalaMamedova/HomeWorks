using ProjectLib.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectLib.Model.Class
{
    [Serializable]
    public class UserArt:IWhiteboardcs,ICloneable
    {
        public int Id { get; set; }
        public string ArtName { get; set; } = "Unnamed";
        public double Width { get; set; }  
        public double Height { get; set; }
        public string PicturePath { get; set; }
        public byte[] Content { get; set; } 
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        public object Clone()
        {
            return new UserArt
            {
                ArtName = this.ArtName,
                Width = this.Width,
                Height = this.Height,
                PicturePath = this.PicturePath,
                Content = (byte[])this.Content.Clone(),
                DateTime = this.DateTime,
                UserId = this.UserId,
            };
        }

        public override string ToString()
        {
            return $"{Id} {ArtName} {PicturePath} {DateTime}";
        }
    }
}
