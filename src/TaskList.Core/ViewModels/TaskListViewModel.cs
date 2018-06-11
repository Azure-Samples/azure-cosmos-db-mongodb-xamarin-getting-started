using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TaskList.Core
{
    public class TaskListViewModel : BaseViewModel
    {
        List<MyTask> myTasks;
        public List<MyTask> MyTasks { get => myTasks; set => SetProperty(ref myTasks, value); }

        public ICommand RefreshCommand { get; }
        public ICommand DeleteCommand { get; }

        public TaskListViewModel()
        {
            MyTasks = new List<MyTask>();
            IsBusy = false;

            RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
            DeleteCommand = new Command<MyTask>(async (myTask) => await ExecuteDeleteCommand(myTask));
        }

        async Task ExecuteDeleteCommand(MyTask task)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var mongoService = new MongoService();
                await mongoService.DeleteTask(task);

                MyTasks = await mongoService.GetAllTasks();
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var mongoService = new MongoService();
                MyTasks = await mongoService.GetAllTasks();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
