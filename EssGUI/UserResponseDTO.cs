﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    public class UserResponseDTO
    {
        String displayName;
        String id;
        String login;
        String name;
        String surname;
        Boolean removed;
        String username;
        UserType userType;

        public string DisplayName { get => displayName; set => displayName = value; }
        public string Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Name { get => name; set => name = value; }
        public bool Removed { get => removed; set => removed = value; }
        public string Username { get => username; set => username = value; }
        public string Surname { get => surname; set => surname = value; }
        internal UserType UserType { get => userType; set => userType = value; }
    }
}
