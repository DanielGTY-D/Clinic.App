using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Clinic.App.Models.Speciality
{
    public class SpecialityResponseModel
    {
        [JsonPropertyName("specialityId")]
        public Guid SpecialityId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
