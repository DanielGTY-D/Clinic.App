using Clinic.App.Services;

namespace Clinic.App
{
    public partial class MainPage : ContentPage
    {
        private readonly ClinicService _clinicService;
        private readonly string _token;

        public MainPage(ClinicService clinicService, string token)
        {
            InitializeComponent();
            _clinicService = clinicService;
            _token = token;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            GetAppointmentsByUserId();
        }

        public async void GetAppointmentsByUserId()
        {
           var appointments = await _clinicService.GetAppointmentsByUserId(_token);
            try
            {
                AppointmentsCollection.ItemsSource = appointments.data;
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
