using Clinic.App.Models.Auth;
using Clinic.App.Services;
using System.Net;
using System.Text.Json;

namespace Clinic.App.Pages;

public partial class Login : ContentPage
{
    private readonly ClinicService _clinicService;

    public Login(ClinicService clinicService)
    {
        InitializeComponent();
        _clinicService = clinicService;
    }

    private async void OnClickedLogin(object sender, EventArgs e)
    {
        var email = EntryEmail.Text;
        var password = EntryPassword.Text;

        if (string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(password)
            )
        {
            ErrorMessageContainer.IsVisible = true;
            ErrorMessageLabel.Text = "Ambos campos son requeridos";
        }
        else
        {
            var result = await _clinicService.LoginUser(
            new LoginModel
            {
                Email = email,
                Password = password
            });

            if(!result.IsSucces)
            {
                ErrorMessageContainer.IsVisible = true;
                ErrorMessageLabel.Text = result.message;
                return;
            }

            var mainPage = new MainPage(_clinicService, result.Data!.Token);

            await Navigation.PushAsync(mainPage);
        }
    }

    private async void OnClickedRegister(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage(_clinicService));
    }
}