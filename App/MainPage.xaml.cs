using App.ViewModels;

namespace App
{
    public partial class MainPage : ContentPage
    {
        HomeViewModel vm = new();

        public MainPage()
        {
            InitializeComponent();

            BindingContext = vm;
            LogCarousel.Position = 30;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LogCarousel.Position = 30;
        }
    }
}