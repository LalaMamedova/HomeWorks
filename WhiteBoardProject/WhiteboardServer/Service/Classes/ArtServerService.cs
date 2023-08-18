using Microsoft.EntityFrameworkCore;
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
            var olduserArt = whiteboardContext.UserArts.FirstOrDefault(ua => ua.Id == userArt.Id);
            if (olduserArt != null)
            {
                whiteboardContext.Entry(userArt).State = EntityState.Deleted;
                whiteboardContext.Set<UserArt>().Remove(olduserArt);
                whiteboardContext.SaveChanges();
                return olduserArt;
            }
            Console.WriteLine("Произошла ошибка");
            return null;
        }

        public object? Exist(object? entity, WhiteboardContext whiteboardContext){ return null; }

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

        public object? Update(object? entity,ref WhiteboardContext whiteboardContext)
        {
            UserArt userArt = entity as UserArt;
            if (userArt != null)
            {
                whiteboardContext.Entry(userArt).State = EntityState.Modified;
                whiteboardContext.Set<UserArt>().Update(userArt);
                whiteboardContext.SaveChanges();
                return userArt;
            }
            throw new NotImplementedException("Произошла ошибка");
        }
    }
}
