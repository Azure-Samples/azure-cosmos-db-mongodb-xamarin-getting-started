using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TaskList.Core
{
    public partial class SearchTaskListPage : ContentPage
    {
        SearchTaskListViewModel viewModel;

        public SearchTaskListPage()
        {
            InitializeComponent();

            viewModel = new SearchTaskListViewModel();
            viewModel.CutoffDate = DateTime.Now.AddDays(14);

            BindingContext = viewModel;

            myTasksList.ItemTapped += (sender, e) => myTasksList.SelectedItem = null;
            Title = "Search For Due Tasks";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.RefreshCommand.Execute(null);
        }

        void Handle_DateSelected(object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            viewModel?.RefreshCommand.Execute(null);
        }
    }
}
