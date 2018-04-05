using System;

using Xamarin.Forms;

namespace TaskList.Core
{
    public partial class TaskListPage : ContentPage
    {
        TaskListViewModel viewModel;

        public TaskListPage()
        {
            InitializeComponent();

            viewModel = new TaskListViewModel();
            BindingContext = viewModel;

            myTasksList.ItemSelected += MyTasksList_ItemSelected;
            myTasksList.ItemTapped += (sender, args) => myTasksList.SelectedItem = null;

            viewModel.Title = "My Tasks";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.RefreshCommand.Execute(null);
        }

        protected async void AddNewClicked(object sender, EventArgs e)
        {
            var myTask = new MyTask();
            var detailPage = new TaskDetailPage(myTask, true);

            await Navigation.PushModalAsync(new NavigationPage(detailPage));
        }

        protected async void MyTasksList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var myTask = e.SelectedItem as MyTask;

            if (myTask == null)
                return;

            await Navigation.PushAsync(new TaskDetailPage(myTask, false));
        }
    }
}
