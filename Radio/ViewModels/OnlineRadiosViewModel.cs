using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Radio.Models;

namespace Radio.ViewModels;

public class OnlineRadiosViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainWindowViewModel;
    private Genre? _selectedGenre;

    private OnlineRadio? _selectedOnlineRadio;

    public OnlineRadiosViewModel(IEnumerable<OnlineRadio> onlineRadios, IEnumerable<Genre> genres,
        MainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
        OnlineRadios = new ObservableCollection<OnlineRadio>(onlineRadios);
        Genres = new ObservableCollection<Genre>(genres) { new Genre() };
    }

    public ObservableCollection<OnlineRadio> OnlineRadios { get; }
    public ObservableCollection<Genre> Genres { get; }

    public OnlineRadio? SelectedOnlineRadio
    {
        get => _selectedOnlineRadio;
        set
        {
            _selectedOnlineRadio = value;
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(SelectedOnlineRadio)));
        }
    }

    public Genre? SelectedGenre
    {
        get => _selectedGenre;
        set
        {
            _selectedGenre = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedGenre)));
        }
    }

    public new event PropertyChangedEventHandler? PropertyChanged;

    public void EditSelectedRadio()
    {
        if (_selectedOnlineRadio != null) _mainWindowViewModel.EditOnlineRadio(_selectedOnlineRadio);
    }

    public void DeleteSelectedRadio()
    {
        if (_selectedOnlineRadio != null) _mainWindowViewModel.DeleteOnlineRadio(_selectedOnlineRadio);
    }

    public void PlaySelectedRadio()
    {
        //PlayMp3FromUrl(_selectedOnlineRadio.Url); Wanted to get it to work with audio locally but only really works on Windows
        if (_selectedOnlineRadio == null) return;
        var uri = _selectedOnlineRadio.Url;
        var psi = new ProcessStartInfo
        {
            UseShellExecute = true,
            FileName = uri
        };

        Process.Start(psi);
    }
}