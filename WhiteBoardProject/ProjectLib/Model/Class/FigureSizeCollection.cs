using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib.Model.Class
{
    public class FigureSizeCollection
    {
        public ObservableCollection<FigureSize> FigureSizes { get; set; } = new()
        {
            new FigureSize(){Size = 15, IconPath = @"/Img/Size1.png"},
            new FigureSize(){Size = 25, IconPath = @"/Img/Size2.png"},
            new FigureSize(){Size = 35, IconPath = @"/Img/Size3.png"}

        };

    }
}
