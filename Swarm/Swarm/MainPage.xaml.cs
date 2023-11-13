namespace Swarm {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }


        private async void OnStartGameClicked(object sender, EventArgs e) {

            await Navigation.PushAsync(new GamePage());
        }

        private async void OnLoadGameClicked(object sender, EventArgs e) {

            await Navigation.PushAsync(new LoadPreviousGamePage());
        }

        private void OnExitGameClicked(object sender, EventArgs e) {

            Application.Current?.CloseWindow(Application.Current.MainPage.Window);
        }
    }
}