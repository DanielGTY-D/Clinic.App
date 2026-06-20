using Clinic.App.Pages;
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
                if (appointments.data.Count() == 0)
                {
                    EmptyState.IsVisible = true;
                    AppointmentsCollection.IsVisible = false;
                }
                else
                {
                    EmptyState.IsVisible = false;
                    AppointmentsCollection.IsVisible = true;
                AppointmentsCollection.ItemsSource = appointments.data;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async void OnAgendarClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MakeAppointmentPage());
        }
    }
}
