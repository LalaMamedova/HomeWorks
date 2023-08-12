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
    internal class UserServerService : IModelService
    {
        public object? Delete(object? entity, WhiteboardContext whiteboardContext)
        {
            throw new NotImplementedException();

        }

        public object? Update(object? entity, ref WhiteboardContext whiteboardContext)
        {
            User? user = entity as User;
            var olduser = whiteboardContext.Users.Where(x=> x.Id == user.Id).FirstOrDefault();
            if (user != null)
            {
                olduser = user;
                whiteboardContext.SaveChanges();
                return user;
            }

            throw new NotImplementedException("Произошла ошибка");
        }

        public object? Add(object? entity, WhiteboardContext whiteboardContext)
        {
            User? user = entity as User;
            User? existUser = whiteboardContext.Users.Where(x => x.Email == user.Email).FirstOrDefault();

            if (user != null && existUser == null)
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
            User? existUser = whiteboardContext.Users.Where(x => x.Email.Equals(user.Email)).First();

            if (existUser != null)
            {
                var usersWithArts = whiteboardContext.Users.Include(user => user.UserArts).Where(x=>x.Id == existUser.Id);

                foreach (var loginuser in usersWithArts)
                    return loginuser;
           
            }
            
            throw new ArgumentNullException("Такого пользователя не существует");
        }
    }
}
