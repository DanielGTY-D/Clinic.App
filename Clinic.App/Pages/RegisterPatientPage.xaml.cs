using Clinic.App.Models.User;
using Clinic.App.Services;

namespace Clinic.App.Pages;

public partial class RegisterPatientPage : ContentPage
{
    private readonly ClinicService _clinicService;
    private readonly UserResponseModel _user;

    public RegisterPatientPage(
        ClinicService clinicService,
        UserResponseModel user)
	{
		InitializeComponent();
        _clinicService = clinicService;
        _user = user;
    }
}