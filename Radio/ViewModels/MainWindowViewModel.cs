using System.Collections.ObjectModel;
using System.ComponentModel;
using Radio.Models;

namespace Radio.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<OnlineRadio> OnlineRadios { get; } = new();

    public ObservableCollection<FmRadio> FmRadios { get; } = new();

    private OnlineRadio selectedOnlineRadio;

    public OnlineRadio SelectedOnlineRadio
    {
        get => selectedOnlineRadio;
        set
        {
            selectedOnlineRadio = value;
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(SelectedOnlineRadio)));
        }
    }

    private FmRadio selectedFmRadio;

    public FmRadio SelectedFmRadio
    {
        get => selectedFmRadio;
        set
        {
            selectedFmRadio = value;
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(SelectedFmRadio)));
        }
    }
}