using App.ViewModels;

namespace App
{
    public partial class MainPage : ContentPage
    {
        public MainPage(EventsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
        
    }
}