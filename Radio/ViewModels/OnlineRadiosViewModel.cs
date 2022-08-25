using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Radio.Models;
using Radio.Services;

namespace Radio.ViewModels;

public class OnlineRadiosViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _mainWindowViewModel;
    private readonly MongoCRUD _mongoCrud;
    private ObservableCollection<OnlineRadio> _onlineRadios;
    private Genre? _selectedGenre;

    private OnlineRadio? _selectedOnlineRadio;

    public OnlineRadiosViewModel(MongoCRUD mongoCrud, MainWindowViewModel mainWindowViewModel)
    {
        _mongoCrud = mongoCrud;
        var onlineRadios = _mongoCrud.LoadRecords<OnlineRadio>("OnlineRadios");
        var genres = _mongoCrud.LoadRecords<Genre>("Genres");
        _mainWindowViewModel = mainWindowViewModel;
        OnlineRadios = new ObservableCollection<OnlineRadio>(onlineRadios);
        Genres = new ObservableCollection<Genre>(genres) { new Genre() };
    }

    public ObservableCollection<OnlineRadio> OnlineRadios
    {
        get => _onlineRadios;
        set
        {
            _onlineRadios = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OnlineRadios)));
        }
    }

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
            SelectedGenreChanged();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedGenre)));
        }
    }

    private void SelectedGenreChanged()
    {
        var onlineRadios = new List<OnlineRadio>();
        onlineRadios = _selectedGenre.Guid == Guid.Empty
            ? _mongoCrud.LoadRecords<OnlineRadio>("OnlineRadios")
            : _mongoCrud.Find<OnlineRadio, Genre>("OnlineRadios",
                "Genre",
                _selectedGenre);

        OnlineRadios.Clear();
        foreach (var onlineRadio in onlineRadios)
        {
            OnlineRadios.Add(onlineRadio);
        }
        // The next step does not work this way!!! 
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