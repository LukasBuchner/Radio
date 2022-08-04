using System.Collections.ObjectModel;
using System.ComponentModel;
using Radio.Models;
using Radio.Services;
using ReactiveUI;

namespace Radio.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _currentViewModel;

    public MainWindowViewModel(Database database)
    {
        CurrentViewModel = new RadiosViewModel(database);
    }

    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    public void AddFmRadio()
    {
        CurrentViewModel = new AddFmRadioViewModel();
    }

    public void AddOnlineRadio()
    {
        CurrentViewModel = new AddOnlineRadioViewModel();
    }
}