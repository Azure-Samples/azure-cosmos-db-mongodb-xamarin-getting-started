using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TaskList.Core
{
    public class SearchTaskListViewModel : BaseViewModel
    {
        List<MyTask> myTasks;
        public List<MyTask> MyTasks { get => myTasks; set => SetProperty(ref myTasks, value); }

        DateTime cutoffDate;
        public DateTime CutoffDate { get => cutoffDate; set => SetProperty(ref cutoffDate, value); }

        public ICommand RefreshCommand { get; }

        public SearchTaskListViewModel()
        {
            MyTasks = new List<MyTask>();
            IsBusy = false;

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
            }
        }
    }
}
