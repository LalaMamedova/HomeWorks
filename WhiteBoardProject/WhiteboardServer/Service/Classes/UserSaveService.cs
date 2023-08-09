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
    internal class UserSaveService : IModelService
    {
        public object? Delete(object? entity, WhiteboardContext whiteboardContext)
        {
            throw new NotImplementedException();
        }

        public object? Update(object? entity, WhiteboardContext whiteboardContext)
        {
            User? user = entity as User;
            if(user != null) 
            {
                whiteboardContext.Users.Update(user);
                whiteboardContext.SaveChanges();
                return user;
            }
            throw new NotImplementedException("Произошла ошибка");
        }

        public object? Add(object? entity, WhiteboardContext whiteboardContext)
        {
            User? user = entity as User;
            User? existUser = whiteboardContext.Users.Where(x => x.Email.Equals(user.Email)).FirstOrDefault();

            if (user != null && existUser== null)
            {
                whiteboardContext.Users.Add(user);
                whiteboardContext.SaveChanges();
                return user; 
            }
            throw new Exception("Такой пользователь уже существует");
        }

        public object? Exist(object? entity, WhiteboardContext whiteboardContext)
        {
            User? user = entity as User;
            User? existUser = whiteboardContext.Users.Where(x => x.Email.Equals(user.Email)).FirstOrDefault();

            if (existUser!=null)
                return existUser;
            
            throw new ArgumentNullException("Такого пользователя не существует");
        }
    }
}
