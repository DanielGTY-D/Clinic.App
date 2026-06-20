using Clinic.App.Models.Employee;
using Clinic.App.Models.Speciality;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Clinic.App.Models.Doctor
{
    public class DoctorResponseModel
    {
        [JsonPropertyName("doctorId")]
        public Guid DoctorId { get; set; }

        [JsonPropertyName("employeeDto")]
        public EmployeeResponseModel Employee { get; set; } = null!;

        [JsonPropertyName("specialityDto")]
        public SpecialityResponseModel Speciality { get; set; } = null!;

        [JsonPropertyName("cedula")]
        public string Cedula { get; set; }
    }
}
