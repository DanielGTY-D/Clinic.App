using Clinic.App.Models.Doctor;
using Clinic.App.Models.Speciality;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Clinic.App.Models.ConsultingRoom
{
    public class ConsultingRoomResponseModel
    {
        [JsonPropertyName("consultingRoomId")]
        public Guid ConsultingRoomId { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("floor")]
        public int Floor { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; } // O usa un enum

        [JsonPropertyName("speciality")]
        public SpecialityResponseModel Speciality { get; set; } = null!;

        [JsonPropertyName("inMaintenance")]
        public bool InMaintenance { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("doctors")]
        public IEnumerable<DoctorResponseModel> Doctors { get; set; } = null!;
    }
}
