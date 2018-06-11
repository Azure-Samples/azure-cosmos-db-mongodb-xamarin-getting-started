using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskList.Core
{
    public class App : Application
    {
        public App()
        {
            var tabs = new TabbedPage();
            tabs.Children.Add(new NavigationPage(new TaskListPage()) { Title = "Tasks" });
            tabs.Children.Add(new NavigationPage(new SearchTaskListPage()) { Title = "Search" });

            MainPage = tabs;
        }
    }
}
