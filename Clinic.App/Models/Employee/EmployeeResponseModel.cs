using Clinic.App.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Clinic.App.Models.Employee
{
    public class EmployeeResponseModel
    {
        [JsonPropertyName("employeeId")]
        public Guid EmployeeId { get; set; }

        [JsonPropertyName("user")]
        public UserResponseModel User { get; set; } = null!;

        [JsonPropertyName("rfc")]
        public string Rfc { get; set; }

        [JsonPropertyName("curp")]
        public string Curp { get; set; }

        [JsonPropertyName("nss")]
        public string Nss { get; set; }

        [JsonPropertyName("contractType")]
        public int ContractType { get; set; } // O usa un enum

        [JsonPropertyName("baseSalary")]
        public decimal BaseSalary { get; set; }

        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; set; } // Nullable porque puede ser null
    }
}
