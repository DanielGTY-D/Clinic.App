using Clinic.App.Models.Patient;
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
            GetMyProfileInfo();
            GetAppointmentsByUserId();
        }

        public async void GetAppointmentsByUserId()
        {
           var appointments = await _clinicService.GetAppointmentsByUserId(_token);
            try
            {
                if (appointments.data?.Count() == 0)
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

        private async void GetMyProfileInfo()
        {
            var patientProfile = await _clinicService.GetMyPatientProfile(_token);
            
            if (!patientProfile.IsSuccess)
            {
                await DisplayAlertAsync("Error", "No se pudieron obtener los datos del perfil, se regresara al incio de sesion", "Aceptar");
                return;
            }

            var firstName = patientProfile.data?.User.FirstName;
            var lastName = patientProfile.data?.User.LastName;

            // Iniciales para el avatar
            var initials = "";
            if (firstName.Length > 0) initials += firstName[0];
            if(lastName.Length > 0) initials += lastName[0];
            AvatarLabel.Text = initials.ToUpper();

            UserNameLabel.Text = $"{firstName} {lastName}".Trim();
            BloodGroupLabel.Text = $"🩸 {patientProfile.data?.BloodGroup}";
            PhoneLabel.Text = patientProfile.data?.User.PhoneNumber;
        }

        private async void OnAgendarClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MakeAppointmentPage(_clinicService, _token));
        }

        private void OnPerfilTapped(object sender, TappedEventArgs e)
        {

        }
    }
}
