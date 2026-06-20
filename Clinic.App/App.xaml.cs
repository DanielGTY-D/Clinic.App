using Microsoft.Extensions.DependencyInjection;
using Clinic.App.Pages;
using Clinic.App.Services;


namespace Clinic.App
{
    public partial class App : Application
    {
        private readonly ClinicService _clinicService;

        public App(ClinicService clinicService, IServiceProvider _service)
        {
            InitializeComponent();
            _clinicService = clinicService;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new Login(_clinicService)));
        }
    }
}