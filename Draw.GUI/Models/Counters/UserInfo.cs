﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.GUIMVP.Models
{
    class UserInfo
    {
        static string theme = "";
        static string root = "";
        static string recentfile = "";

        public string Recentfile { get => recentfile; set => recentfile = value; }
        public string Root { get => root; set => root = value; }
        public string Theme { get => theme; set => theme = value; }


    }
}
