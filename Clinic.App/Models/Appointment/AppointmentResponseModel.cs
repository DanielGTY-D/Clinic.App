using Clinic.App.Models.ConsultingRoom;
using Clinic.App.Models.Doctor;
using Clinic.App.Models.Patient;
using System.Text.Json.Serialization;

namespace Clinic.App.Models.Appointment
{
    public class AppointmentResponseModel
    {
        [JsonPropertyName("patient")]
        public PatientResponseModel Patient { get; set; } = null!;

        [JsonPropertyName("doctor")]
        public DoctorResponseModel Doctor { get; set; } = null!;

        [JsonPropertyName("consultingRoom")]
        public ConsultingRoomResponseModel ConsultingRoom { get; set; } = null!;

        [JsonPropertyName("appointmentDate")]
        public DateTime AppointmentDate { get; set; }

        [JsonPropertyName("startTime")]
        public string StartTime { get; set; } // Formato "HH:mm:ss"

        [JsonPropertyName("endTime")]
        public string EndTime { get; set; } // Formato "HH:mm:ss"

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("isPaid")]
        public bool IsPaid { get; set; }

        [JsonPropertyName("paymentMethod")]
        public int PaymentMethod { get; set; } // O usa un enum

        [JsonPropertyName("madeByUserId")]
        public Guid MadeByUserId { get; set; }
    }
}
