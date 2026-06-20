using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Clinic.App.Models.Patient
{
    public class PatientRequestModel
    {
        [JsonPropertyName("userId")]
        [Required(ErrorMessage = "El ID de usuario es requerido")]
        public Guid? UserId { get; set; }

        [JsonPropertyName("curp")]
        [Required(ErrorMessage = "El CURP es requerido")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "El CURP debe tener exactamente 18 caracteres")]
        [RegularExpression(@"^[A-Z]{4}\d{6}[HM][A-Z]{5}[A-Z\d]\d$",
            ErrorMessage = "Formato de CURP inválido")]
        public string CURP { get; set; } = string.Empty;

        [JsonPropertyName("birthdate")]
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DataType(DataType.Date, ErrorMessage = "Debe ser una fecha válida")]
        public DateTime? BirthDate { get; set; }

        [JsonPropertyName("gender")]
        [Required(ErrorMessage = "El género es requerido")]
        [RegularExpression("^(Male|Female)$", ErrorMessage = "El género debe ser Male o Female")]
        public string Gender { get; set; } = string.Empty;

        [JsonPropertyName("bloodGroup")]
        [Required(ErrorMessage = "El tipo de sangre es requerido")]
        [RegularExpression(@"^(A|B|AB|O)[+-]$",
            ErrorMessage = "El tipo de sangre debe ser A+, A-, B+, B-, AB+, AB-, O+ u O-")]
        public string BloodGroup { get; set; } = string.Empty;

        [JsonPropertyName("allergies")]
        public string? Allergies { get; set; }

        [JsonPropertyName("emergencyContactNumber")]
        [Required(ErrorMessage = "El número de contacto de emergencia es requerido")]
        [Phone(ErrorMessage = "Número de teléfono inválido")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El número debe tener 10 dígitos")]
        public string EmergencyContactNumber { get; set; } = string.Empty;

        [JsonPropertyName("EmergencyContactName")]
        [Required(ErrorMessage = "El nombre del contacto de emergencia es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string EmergencyContactName { get; set; } = string.Empty;
    }
}
