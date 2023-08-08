using ProjectLib.Model.Class;
using ProjectLib.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteboardServer.Service.Interface;

namespace WhiteboardServer.Service.Classes
{
    internal class UserSaveService : ISaveService
    {
        bool ISaveService.Save(object? entity, WhiteboardContext whiteboardContext)
        {
            User user = entity as User;
            if (user != null)
            {
                whiteboardContext.Add(user);
                whiteboardContext.SaveChanges();
                return true; 
            }
            return false;
        }
    }
}
