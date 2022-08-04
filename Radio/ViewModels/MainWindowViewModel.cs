using System.Collections.ObjectModel;
using System.ComponentModel;
using Radio.Models;
using Radio.Services;

namespace Radio.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(Database database)
    {
        RadiosViewModel = new RadiosViewModel(database);
    }
    
    public RadiosViewModel RadiosViewModel { get; }
}