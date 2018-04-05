using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskList.Core
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new TaskListPage());
        }
    }
}
