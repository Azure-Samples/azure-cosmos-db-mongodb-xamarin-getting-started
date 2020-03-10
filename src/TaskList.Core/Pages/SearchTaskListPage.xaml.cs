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

            BindingContext = viewModel;
           
            Title = "Search For Due Tasks";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.OkToRefresh = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            viewModel.OkToRefresh = false;
        }

        void Handle_DateSelected(object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            //if (viewModel != null)
            //    viewModel.IsRefreshing = true;
        }
    }
}
