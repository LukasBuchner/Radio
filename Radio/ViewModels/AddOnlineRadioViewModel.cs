using System.Reactive;
using Radio.Models;
using ReactiveUI;

namespace Radio.ViewModels;

public class AddOnlineRadioViewModel : ViewModelBase
{
    private string? _name;
    private string? _url;

    public AddOnlineRadioViewModel()
    {
        var saveEnabled = this.WhenAnyValue<AddOnlineRadioViewModel, bool, string>(
            x => x.Name,
            x => !string.IsNullOrWhiteSpace(x));

        Save = ReactiveCommand.Create(
            () => new OnlineRadio { Name = Name, Url = Url },
            saveEnabled);
        Cancel = ReactiveCommand.Create(() => { });
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