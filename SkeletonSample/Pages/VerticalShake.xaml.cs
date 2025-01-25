using SkeletonSample.ViewModels;

namespace SkeletonSample.Pages
{
    public partial class VerticalShake : ContentPage
    {
        public VerticalShake()
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