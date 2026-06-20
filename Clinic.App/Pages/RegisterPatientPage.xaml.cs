using Clinic.App.Models.Patient;
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

        // ✅ Suscribir eventos para limpiar errores en tiempo real
        CurpEntry.TextChanged += (s, e) => HideError(CurpError);
        BirthDatePicker.DateSelected += (s, e) => HideError(BirthDateError);
        GenderPicker.SelectedIndexChanged += (s, e) => HideError(GenderError);
        BloodGroupPicker.SelectedIndexChanged += (s, e) => HideError(BloodGroupError);
        EmergencyContactNameEntry.TextChanged += (s, e) => HideError(EmergencyContactNameError);
        EmergencyContactNumberEntry.TextChanged += (s, e) => HideError(EmergencyContactNumberError);
    }

    // ✅ Método helper para ocultar errores
    private void HideError(Label errorLabel)
    {
        errorLabel.IsVisible = false;
        errorLabel.Text = string.Empty;
    }

    // ✅ Método helper para mostrar errores
    private void ShowError(Label errorLabel, string message)
    {
        errorLabel.Text = message;
        errorLabel.IsVisible = true;
    }

    private void OnCancelarClicked(object sender, EventArgs e)
    {
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        var curp = CurpEntry.Text;
        var birthDate = BirthDatePicker.Date;
        var gender = GenderPicker.SelectedItem as string;
        var bloodType = BloodGroupPicker.SelectedItem as string;
        var allergies = AllergiesEditor.Text;
        var emergencyContactNumber = EmergencyContactNumberEntry.Text;
        var emergencyContactName = EmergencyContactNameEntry.Text;

        // ✅ Limpiar TODOS los errores antes de revalidar
        HideError(CurpError);
        HideError(BirthDateError);
        HideError(GenderError);
        HideError(BloodGroupError);
        HideError(EmergencyContactNameError);
        HideError(EmergencyContactNumberError);

        bool isError = false;

        // Validar CURP
        if (string.IsNullOrWhiteSpace(curp))
        {
            ShowError(CurpError, "El CURP es requerido");
            isError = true;
        }
        else if (curp.Length != 18)
        {
            ShowError(CurpError, "El CURP debe tener exactamente 18 caracteres");
            isError = true;
        }

        // Validar Fecha de Nacimiento
        if (birthDate > DateTime.Today)
        {
            ShowError(BirthDateError, "La fecha de nacimiento no puede ser futura");
            isError = true;
        }
        else if (birthDate < DateTime.Today.AddYears(-120))
        {
            ShowError(BirthDateError, "La fecha de nacimiento no es válida");
            isError = true;
        }

        // Validar Género
        if (string.IsNullOrEmpty(gender))
        {
            ShowError(GenderError, "Debes seleccionar un género");
            isError = true;
        }

        // Validar Tipo de Sangre
        if (string.IsNullOrEmpty(bloodType))
        {
            ShowError(BloodGroupError, "Debes seleccionar un tipo de sangre");
            isError = true;
        }

        // Validar Nombre del Contacto de Emergencia
        if (string.IsNullOrWhiteSpace(emergencyContactName))
        {
            ShowError(EmergencyContactNameError, "El nombre del contacto es requerido");
            isError = true;
        }

        // Validar Número del Contacto de Emergencia
        if (string.IsNullOrWhiteSpace(emergencyContactNumber))
        {
            ShowError(EmergencyContactNumberError, "El número de teléfono es requerido");
            isError = true;
        }
        else if (emergencyContactNumber.Length != 10)
        {
            ShowError(EmergencyContactNumberError, "El número debe tener exactamente 10 dígitos");
            isError = true;
        }
        else if (!emergencyContactNumber.All(char.IsDigit))
        {
            ShowError(EmergencyContactNumberError, "El número solo debe contener dígitos");
            isError = true;
        }

        if (isError)
        {
            await DisplayAlertAsync("Error", "Por favor corrige los campos marcados en rojo.", "OK");
            return;
        }

        var patientRequestModel = new PatientRequestModel
        {
            UserId = _user.Id,
            CURP = curp.ToUpper(),
            BirthDate = birthDate,
            Gender = gender,
            BloodGroup = bloodType,
            Allergies = string.IsNullOrWhiteSpace(allergies) ? "No tengo" : allergies,
            EmergencyContactNumber = emergencyContactNumber,
            EmergencyContactName = emergencyContactName
        };

        var result = await _clinicService.RegisterPatientProfile(patientRequestModel);

        if (!result.IsSucces)
        {
            await DisplayAlertAsync("Error", "Error al crear el paciente", "Aceptar");
            return;
        }

        Application.Current.Windows.FirstOrDefault().Page = new NavigationPage(new Login(_clinicService));
    }
}