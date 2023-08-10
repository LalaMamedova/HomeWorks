using ProjectLib.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectLib.Model.Class
{
    public class UserArt:IWhiteboardcs
    {
        public int Id { get; set; }
        public string ArtName { get; set; } = "Unnamed";
        public byte[] Content { get; set; } 
        public string PicturePath { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public double Width { get; set; }  
        public double Height { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        public override string ToString()
        {
            return $"{Id} {ArtName} {PicturePath} {DateTime}";
        }
    }
}
