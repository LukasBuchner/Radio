using System.Reactive;
using Radio.Models;
using Radio.Services;
using ReactiveUI;

namespace Radio.ViewModels;

public class EditOnlineRadioViewModel : ViewModelBase
{
    private readonly OnlineRadio _onlineRadio;
    private string _name;
    private string _url;

    public EditOnlineRadioViewModel(OnlineRadio onlineRadio)
    {
        _onlineRadio = onlineRadio;
        
        var saveEnabled = this.WhenAnyValue(
            x => x.Name,
            x => !string.IsNullOrWhiteSpace(x));

        Save = ReactiveCommand.Create(
            () => _onlineRadio with {Name = Name, Url = Url}, 
            saveEnabled);
        Cancel = ReactiveCommand.Create(() => { });
    }
    
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string Url
    {
        get => _url;
        set => this.RaiseAndSetIfChanged(ref _url, value);
    }
    
    public ReactiveCommand<Unit, OnlineRadio> Save { get; }
    public ReactiveCommand<Unit, Unit> Cancel { get; }
}