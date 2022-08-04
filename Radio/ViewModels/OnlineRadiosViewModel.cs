using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Radio.Models;

namespace Radio.ViewModels;

public class OnlineRadiosViewModel
{
    public OnlineRadiosViewModel(IEnumerable<OnlineRadio> onlineRadios)
    {
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
}