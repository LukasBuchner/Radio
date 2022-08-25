using System.Collections.Generic;
using System.Reactive;
using Radio.Models;
using ReactiveUI;

namespace Radio.ViewModels;

public class EditOnlineRadioViewModel : ViewModelBase
{
    private string? _genre;
    private string? _name;
    private Genre? _selectedGenre;
    private string? _url;

    public EditOnlineRadioViewModel(OnlineRadio? onlineRadio, List<Genre> genres)
    {
        Genres = genres;
        var saveEnabled = this.WhenAnyValue<EditOnlineRadioViewModel, bool, string>(
            x => x.Name,
            x => !string.IsNullOrWhiteSpace(x));

        Save = ReactiveCommand.Create(
            () => onlineRadio with { Name = Name, Url = Url, Genre = SelectedGenre },
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
}