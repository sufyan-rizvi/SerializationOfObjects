﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo.Models
{
    internal class Person
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email {  get; set; }


        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nEmail: {Email}\n";
        }
    }
}
