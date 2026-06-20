using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.App.Models.User
{
    public class UserRequestModel
    {
        public string Email { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
    }
}
