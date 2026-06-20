using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Clinic.App.Models.Auth
{
    public class LoginResponseModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set;  } = string.Empty;
    }
}
