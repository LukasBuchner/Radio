using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Radio.Models;

namespace Radio.ViewModels;

public class OnlineRadiosViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainWindowViewModel;

    public OnlineRadiosViewModel(IEnumerable<OnlineRadio> onlineRadios, MainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
        OnlineRadios = new ObservableCollection<OnlineRadio>(onlineRadios);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<OnlineRadio> OnlineRadios { get; }

    private OnlineRadio _selectedOnlineRadio;

    public OnlineRadio SelectedOnlineRadio
    {
        get => _selectedOnlineRadio;
        set
        {
            _selectedOnlineRadio = value;
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(SelectedOnlineRadio)));
        }
    }

    public void EditSelectedRadio()
    {
        _mainWindowViewModel.EditOnlineRadio(_selectedOnlineRadio);
    }
}