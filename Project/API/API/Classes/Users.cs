﻿namespace API.Classes
{
    public class Users
    {
        public int Id { get; set; } 
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Technology> likedTechnology { get; set; } = new List<Technology>();
    }
}
