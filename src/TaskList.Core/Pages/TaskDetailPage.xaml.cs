using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace TaskList.Core
{
    public partial class TaskDetailPage : ContentPage
    {
        bool _isNew;
        TaskDetailViewModel _viewModel;

        public TaskDetailPage(MyTask task, bool isNew)
        {
            InitializeComponent();

            _isNew = isNew;

            _viewModel = new TaskDetailViewModel(task, isNew);
            _viewModel.SaveComplete += Handle_SaveComplete;

            BindingContext = _viewModel;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _viewModel.SaveComplete -= Handle_SaveComplete;
        }

        async void Handle_SaveComplete(object sender, EventArgs eventArgs)
        {
            await DismissPage();
        }

        protected async void Handle_CancelClicked(object sender, EventArgs e)
        {
            await DismissPage();
        }

        async Task DismissPage()
        {
            if (_isNew)
                await Navigation.PopModalAsync();
            else
                await Navigation.PopAsync();
        }
    }
}