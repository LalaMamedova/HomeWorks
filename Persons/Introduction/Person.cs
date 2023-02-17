﻿using Introduction.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    public class Person : MySerializable
    {
        private int age;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImagePath { get; set; }
        public int Age
        { 
            get => age;
            set  
            {
                if (value > 0 && value <= 100)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("Age must be between 1 and 100");
                }
            }
        }
        public override string ToString()
        {
            return $"{Name}   {Surname}  {Age.ToString()}";
        }
    }
}
