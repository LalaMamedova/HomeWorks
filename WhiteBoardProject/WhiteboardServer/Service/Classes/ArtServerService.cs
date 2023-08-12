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
    public class ArtServerService : IModelService
    {
        public object? Delete(object? entity, WhiteboardContext whiteboardContext)
        {
            UserArt? userArt = entity as UserArt;
            
            if (userArt != null)
            {
                whiteboardContext.UserArts.Remove(userArt);
                whiteboardContext.SaveChanges();
                return userArt;
            }

            throw new NotImplementedException("Произошла ошибка");
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
                try
                {
                    whiteboardContext.UserArts.Add(UserArt);
                    whiteboardContext.SaveChanges();
                    return UserArt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }

        public object? Update(object? entity,ref WhiteboardContext whiteboardContext)
        {
            UserArt? userArt = entity as UserArt;
            var oldArt = whiteboardContext.UserArts.Where(x => x.Id == userArt.Id).FirstOrDefault();
            if (userArt != null)
            {
                oldArt = userArt;
                whiteboardContext.UserArts.Update(userArt);
                whiteboardContext.SaveChanges();
                return userArt;
            }

            throw new NotImplementedException("Произошла ошибка");
        }
    }
}
