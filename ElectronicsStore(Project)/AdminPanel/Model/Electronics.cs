﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel.Model
{
    public class Electronics
    {
        private float price;
        private int count;

        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string? ImgPath { get; set; }
        public string? Processor { get; set; }
        public string? Memory { get; set; }

        [Required]
        public float Price
        {
            get => price;

            set
            {
                if (value == Int32.Parse(value.ToString()))
                {
                    price = value;
                    price.ToString();
                }
                else
                    throw new ArgumentException("Неправильные данные");
            }
        }

        [Required]
        public int Count
        {
            get => count;

            set
            {
                if (value == Int32.Parse(value.ToString()))
                {
                    count = value;
                    count.ToString();
                }
                else
                    throw new ArgumentException("Неправильные данные");
            }
        }


        public Electronics(string name, string category, string? imgPath, int count, float price)
        {
            Name = name;
            Category = category;
            ImgPath = imgPath;
            Count = count;
            Price = price;
        }
        public Electronics() { }

        public Electronics CheckNulls()
        {
            if (this.Count != 0 && this.Price != 0 && 
                !string.IsNullOrEmpty(this.Name) && 
                !string.IsNullOrEmpty(this.Category) && 
                !string.IsNullOrEmpty(this.ImgPath))
                return this;

            return null;
        }

        public override string ToString()
        {
            return Name + " " + Category;
        }

    }
}
