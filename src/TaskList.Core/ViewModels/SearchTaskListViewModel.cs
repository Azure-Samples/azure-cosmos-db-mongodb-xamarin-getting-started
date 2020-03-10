using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MongoDB.Bson.IO;
using Xamarin.Forms;

namespace TaskList.Core
{
    public class SearchTaskListViewModel : BaseViewModel
    {
        List<MyTask> myTasks;
        public List<MyTask> MyTasks { get => myTasks; set => SetProperty(ref myTasks, value); }

        DateTime cutoffDate = DateTime.Now.AddDays(14);
        public DateTime CutoffDate
        {
            get => cutoffDate;
            set
            {
                SetProperty(ref cutoffDate, value, () => { 
                    if (OkToRefresh)
                        IsRefreshing = true; 
                }); 
            }
        }

        public ICommand RefreshCommand { get; }

        bool isRefreshing;
        public bool IsRefreshing { get => isRefreshing; set => SetProperty(ref isRefreshing, value); }

        bool okToRefresh;
        public bool OkToRefresh { get => okToRefresh; set => SetProperty(ref okToRefresh, value); }

        public SearchTaskListViewModel()
        {
            MyTasks = new List<MyTask>();
            IsBusy = false;

            Title = "Search Tasks";

            RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
        }

        async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var mongoService = new MongoService();
                MyTasks = await mongoService.GetIncompleteTasksDueBefore(CutoffDate);
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}
