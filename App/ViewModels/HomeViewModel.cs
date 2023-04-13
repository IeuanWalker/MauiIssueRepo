using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace App.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            DateTime end = DateTime.Now.AddDays(1);
            DateTime start = DateTime.Now.AddDays(-30);
            Logs = new ObservableCollection<TestModel>(Enumerable.Range(0, 1 + end.Subtract(start).Days)
                .Select(offset => start.AddDays(offset))
                .Select(x => new TestModel
                {
                    Date = x
                }));

            SelectedLog = Logs.Last();
        }

        [ObservableProperty]
        ObservableCollection<TestModel> _logs = new();

        [ObservableProperty]
        TestModel _selectedLog = null!;
    }

    public class TestModel
    {
        public DateTime Date { get; set; }
        public string DateDisplayTest
        {
            get {
                if (Date.Date.Equals(DateTime.Now.Date))
                {
                    return "Today";
                }
                else if (Date.Date.Equals(DateTime.Now.AddDays(-1).Date))
                {
                    return "Yesterday";
                }

                return Date.ToString("d, MMMM yyyy");
            }
        }
    }
}
