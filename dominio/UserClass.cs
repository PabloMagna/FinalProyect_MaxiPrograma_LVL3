﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProyect_MaxiPrograma_LVL3.dominio
{
    public enum typeUser
    {
        Admin = 1,
        User = 2
    }
    public class UserClass
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public typeUser TypeUser { get; set; }
        public string UrlImagen { get; set; }

        public UserClass() { }
        public UserClass(string email,string pass, bool type)
        {
            Password = pass;
            TypeUser = type ? typeUser.Admin : typeUser.User;
            Email = email;
        }
    }
}