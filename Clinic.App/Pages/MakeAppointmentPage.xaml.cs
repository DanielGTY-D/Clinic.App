using Clinic.App.Services;

namespace Clinic.App.Pages;

public partial class MakeAppointmentPage : ContentPage
{
    private readonly ClinicService _clinicService;
    private readonly string _token;

    public MakeAppointmentPage(
        ClinicService clinicService, 
        string token)
	{
		InitializeComponent();
        GetDoctorsAsync();
        GetConsultingRoomsAsync();
        _clinicService = clinicService;
        _token = token;
    }

    private async void GetDoctorsAsync()
    {

    }

    private async void GetConsultingRoomsAsync() 
    {
        
    }
}