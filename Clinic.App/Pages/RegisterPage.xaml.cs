using Clinic.App.Models.User;
using Clinic.App.Services;

namespace Clinic.App.Pages;

public partial class RegisterPage : ContentPage
{
    private readonly ClinicService _clinicService;

    public RegisterPage(ClinicService clinicService)
	{
		InitializeComponent();
        _clinicService = clinicService;
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
		var firstName = EntryFirstName.Text;
		var lastName = EntryLastName.Text;
		var email = EntryEmail.Text;
		var phone = EntryPhoneNumber.Text;
		var password = EntryPassword.Text;

		if (
			string.IsNullOrEmpty(firstName) || 
			string.IsNullOrEmpty(lastName)  || 
			string.IsNullOrEmpty(email)  ||
            string.IsNullOrEmpty(phone)  ||
            string.IsNullOrEmpty(password)
            )
		{
			await DisplayAlertAsync("Error campos invalidos", "Todos los campos son requeridos", "Aceptar");
			return;
		}

		var userRequestModel = new UserRequestModel
		{
			Email = email,
			LastName = lastName,
			FirstName = firstName,
			Password = password,
			phoneNumber = phone,
		};

		var result = await _clinicService.RegisterUserAsync(userRequestModel);

		if (!result.IsSucces)
		{
			await DisplayAlertAsync("Error request failed", result.message, "Aceptar");
			return;
		}

		await Navigation.PushAsync(new RegisterPatientPage(_clinicService, result.Data!));
    }
}