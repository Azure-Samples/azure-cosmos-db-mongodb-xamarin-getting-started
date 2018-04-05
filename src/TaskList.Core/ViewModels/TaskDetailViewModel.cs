using System;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TaskList.Core
{
    public class TaskDetailViewModel : BaseViewModel
    {
        public MyTask TheTask { get; set; }
        public ICommand SaveCommand { get; }

        bool _isNew;

        public event EventHandler SaveComplete;

        public TaskDetailViewModel(MyTask theTask, bool isNew)
        {
            _isNew = isNew;

            TheTask = theTask;

            Title = isNew ? "New Task" : TheTask.Name;

            SaveCommand = new Command(async () => await ExecuteSaveCommand());
        }

        async Task ExecuteSaveCommand()
        {
            var mongoService = new MongoService();

            if (_isNew)
                await mongoService.CreateTask(TheTask);
            else
                await mongoService.UpdateTask(TheTask);

            SaveComplete?.Invoke(this, new EventArgs());
        }
    }
}
