using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using Radio.Models;
using ReactiveUI;

namespace Radio.ViewModels;

public class AddOnlineRadioViewModel : ViewModelBase
{
    private string? _genre;
    private string? _name;
    private Genre? _selectedGenre;
    private string? _url;

    public AddOnlineRadioViewModel(List<Genre> genres)
    {
        Genres = genres;
        var saveEnabled = this.WhenAnyValue<AddOnlineRadioViewModel, bool, string>(
            x => x.Name,
            x => !string.IsNullOrWhiteSpace(x));

        Save = ReactiveCommand.Create(
            () => new OnlineRadio { Name = Name, Url = Url, Genre = SelectedGenre },
            saveEnabled);
        Cancel = ReactiveCommand.Create(() => { });
    }

    public List<Genre> Genres { get; }

    public Genre? SelectedGenre
    {
        get => _selectedGenre;
        set
        {
            _selectedGenre = value;
            this.RaiseAndSetIfChanged(ref _genre, _selectedGenre.Name);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedGenre)));
        }
    }

    public string? Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string? Url
    {
        get => _url;
        set => this.RaiseAndSetIfChanged(ref _url, value);
    }

    public ReactiveCommand<Unit, OnlineRadio> Save { get; }
    public ReactiveCommand<Unit, Unit> Cancel { get; }

    public new event PropertyChangedEventHandler? PropertyChanged;
}