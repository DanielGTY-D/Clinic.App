using Clinic.App.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Clinic.App.Models.Patient
{
    public class PatientResponseModel
    {
        [JsonPropertyName("patientId")]
        public Guid PatientId { get; set; }

        [JsonPropertyName("user")]
        public UserResponseModel User { get; set; } = null!;

        [JsonPropertyName("curp")]
        public string Curp { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("bloodGroup")]
        public string BloodGroup { get; set; }

        [JsonPropertyName("allergies")]
        public string Allergies { get; set; }

        [JsonPropertyName("emergencyContactNumber")]
        public string EmergencyContactNumber { get; set; }

        [JsonPropertyName("emergencyContactName")]
        public string EmergencyContactName { get; set; }
    }
}
