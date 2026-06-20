namespace Clinic.App.Models.Auth
{
    public class LoginModel
    {
        private string _email = string.Empty;
        private string _password = string.Empty;

        public string Email
        {
            get { return _email; }
            set { _email = value.Trim(); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value.Trim().ToLower(); }
        }
    }
}
