using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Clinic.App.Models.Role
{
    public class RoleResponseModel
    {
        [JsonPropertyName("roleId")]
        public string RoleId { get; set; } = string.Empty;

        [JsonPropertyName("roleName")]
        public string RoleName { get; set; } = string.Empty;

        [JsonPropertyName("writeAndReadPermission")]
        public bool WriteAndReadPermission { get; set; }
    }
}
