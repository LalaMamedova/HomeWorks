﻿using ProjectLib.Model.Class;
using ProjectLib.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteboardServer.Service.Interface;

namespace WhiteboardServer.Service.Classes
{
    public class PictureSaveService : ISaveService
    {

        bool ISaveService.Save(object? entity, WhiteboardContext whiteboardContext)
        {
            UserArt UserArt = (UserArt)entity;
            if (UserArt != null)
            {
                whiteboardContext.UserArts.Add(UserArt);
                return true;
            }
            return false;
        }
    }
}
