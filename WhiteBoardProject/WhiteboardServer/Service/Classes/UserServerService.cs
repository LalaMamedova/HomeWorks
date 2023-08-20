using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectLib.Model.Class;
using ProjectLib.Model.Context;
using ProjectLib.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            User? updatedUser = entity as User;
            var oldUser = whiteboardContext.Users.Where(x=> x.Id == updatedUser.Id).FirstOrDefault();
            if (updatedUser != null)
            {
                var usersWithArts = whiteboardContext.Users.Include(user => user.UserArts).Where(x => x.Id == updatedUser.Id);
                return usersWithArts.First();
            }
            throw new NotImplementedException("Произошла при обновление пользователя ошибка");
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
            IUser userDTO = entity as UserDTO;
            User? existUser = whiteboardContext.Users.Where(x => x.Email.Equals(userDTO.Email) && x.Password == userDTO.Password).FirstOrDefault();

            if (existUser != null)
            {
                var usersWithArts = whiteboardContext.Users.Include(user => user.UserArts).Where(x => x.Id == existUser.Id);
                return usersWithArts.First();
            }
            return new User();
        }

        public object? IsRegistred(object? entity, WhiteboardContext whiteboardContext)
        {
            User registredUser = entity as User;
            User? existUser = whiteboardContext.Users.Where(x => x.Email.Equals(registredUser.Email)).FirstOrDefault();

            if (existUser != null)
            {
                return existUser;
            }
            return new User();
        }
    }
}
