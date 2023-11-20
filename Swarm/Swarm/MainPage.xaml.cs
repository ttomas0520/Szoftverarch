using Models;
using Repositories;

namespace Swarm {
    public partial class MainPage : ContentPage {
        private readonly ISimulationRepository _repository;
        public MainPage(ISimulationRepository repository) {
            InitializeComponent();
            _repository = repository;
        }


        private async void OnStartGameClicked(object sender, EventArgs e) {

            await Navigation.PushAsync(new GamePage(_repository));
        }

        private async void OnLoadGameClicked(object sender, EventArgs e) {

            await Navigation.PushAsync(new LoadPreviousGamePage());
        }

        private void OnExitGameClicked(object sender, EventArgs e) {

            Application.Current?.CloseWindow(Application.Current.MainPage.Window);
        }
    }
}