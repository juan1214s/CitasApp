﻿using System.ComponentModel.DataAnnotations;

namespace CitasApp.Dto.UserDto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Role { get; set; }

    }
}
