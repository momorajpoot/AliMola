using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace momii.Models
{
    public class Student
    {
        public int Roll_Num { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String Address { get; set; }
        public string Email { get; set; }
        public String imagePath { get; set; }
        public String cvPath { get; set; }

    }
}