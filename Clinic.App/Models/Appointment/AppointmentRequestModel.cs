using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.App.Models.Appointment
{
    public class AppointmentRequestModel
    {
        public string? Reason { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int PaymentMethod { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid MadeByUserId { get; set; }
        public Guid ConsultingRoomId { get; set; }
    }
}
