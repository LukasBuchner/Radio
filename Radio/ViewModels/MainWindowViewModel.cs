using System.Collections.ObjectModel;
using System.ComponentModel;
using Radio.Models;
using Radio.Services;

namespace Radio.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(Database database)
    {
        CurrentViewModel = RadiosViewModel = new RadiosViewModel(database);
    }
    
    public ViewModelBase CurrentViewModel { get; }
    public RadiosViewModel RadiosViewModel { get; }
}