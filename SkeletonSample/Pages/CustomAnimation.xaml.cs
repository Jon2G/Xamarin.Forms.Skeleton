﻿using SkeletonSample.ViewModels;

namespace SkeletonSample.Pages
{
    public partial class CustomAnimation : ContentPage
    {
        public CustomAnimation()
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