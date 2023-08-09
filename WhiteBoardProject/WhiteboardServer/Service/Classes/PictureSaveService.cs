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
    public class PictureSaveService : IModelService
    {
        public object? Delete(object? entity, WhiteboardContext whiteboardContext)
        {
            throw new NotImplementedException();
        }

        public object? Exist(object? entity, WhiteboardContext whiteboardContext)
        {
            throw new NotImplementedException();
        }

        public object? Add(object? entity, WhiteboardContext whiteboardContext)
        {
            UserArt UserArt = (UserArt)entity;
            if (UserArt != null)
            {
                whiteboardContext.UserArts.Add(UserArt);
                whiteboardContext.SaveChanges();
                return UserArt;
            }
            return null;
        }

        public object? Update(object? entity, WhiteboardContext whiteboardContext)
        {
            throw new NotImplementedException();
        }
    }
}
