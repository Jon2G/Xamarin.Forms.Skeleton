using SkeletonSample.ViewModels;

namespace SkeletonSample.Pages
{
    public partial class Beat : ContentPage
    {
        public Beat()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is BaseViewModel viewModel)
                viewModel.LoadCommand.Execute(null);
        }
    }
}