using Clinic.App.Models;
using Clinic.App.Models.Appointment;
using Clinic.App.Models.Auth;
using Clinic.App.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

namespace Clinic.App.Services
{
    public class ClinicService
    {
        // Asegúrate de que este puerto sea el correcto donde corre tu API
        private string baseUrl = "http://10.0.2.2:5076/api";


        public async Task<(bool IsSucces, string message, LoginResponseModel? Data)> LoginUser(LoginModel model)
        {
            try
            {
                var client = new HttpClient();
                var json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // 3. Enviar request
                var response = await client.PostAsync($"{baseUrl}/users/login", content);
                var responseBody = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
                    var data = JsonSerializer.Deserialize<LoginResponseModel>(responseBody);
                    return (true, "Login Exitoso", data);
                }
                else
                {
                    var error = JsonSerializer.Deserialize<HTTPErrorResponse>(responseBody);
                    var errorMessage = error.Message;
                    return (false, errorMessage, null);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el servidor al loguear");
            }
        }

        public async Task<(bool IsSuccess, string message, IEnumerable<AppointmentResponseModel>? data)> GetAppointmentsByUserId(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            if (!handler.CanReadToken(token))
                return (false, "Token no valido", null);

            var jwtToken = handler.ReadJwtToken(token);

            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            if (string.IsNullOrEmpty(userId))
                return (false, "No se encontró el userId en el token", null);

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/appointments/my-appointments/{userId}");
            request.Headers.Add("Authorization", $"Bearer {token}");
            var response = await client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var data = JsonSerializer.Deserialize<IEnumerable<AppointmentResponseModel>>(responseBody);

                    return (true, "request success", data);
                }
                catch (Exception ex)
                {
                    return (false, $"Error al deserializar: {ex.Message}", null);
                }
            }
            else
            {
                return (false, "Request failed", null);
            }
        }

        public async Task<(bool IsSucces, string message, UserResponseModel? Data)> RegisterUserAsync(UserRequestModel model)
        {
            var client = new HttpClient();
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            // 3. Enviar request
            var response = await client.PostAsync($"{baseUrl}/users", content);
            var responseBody = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                var data = JsonSerializer.Deserialize<UserResponseModel>(responseBody);
                return (true, "Login Exitoso", data);
            }
            else
            {
                var error = JsonSerializer.Deserialize<HTTPErrorResponse>(responseBody);
                var errorMessage = error.Message;
                return (false, errorMessage, null);
            }
        }
    }
}