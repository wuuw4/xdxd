﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTest2.DataBase
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }   
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


    }
}
