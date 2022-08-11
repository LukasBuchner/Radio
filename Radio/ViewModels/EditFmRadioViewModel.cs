using System.Reactive;
using Radio.Models;
using ReactiveUI;

namespace Radio.ViewModels;

public class EditFmRadioViewModel : ViewModelBase
{
    private readonly FmRadio _fmRadio;
    private string _name;
    private string _frequency;

    public EditFmRadioViewModel(FmRadio fmRadio)
    {
        _fmRadio = fmRadio;
        
        var saveEnabled = this.WhenAnyValue(
            x => x.Name,
            x => !string.IsNullOrWhiteSpace(x));

        Save = ReactiveCommand.Create(
            () => _fmRadio with { Name = Name, Frequency = Frequency}, 
            saveEnabled);
        Cancel = ReactiveCommand.Create(() => { });
    }
    
    public string Name
    {
        get => _name; 
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string Frequency
    {
        get => _frequency; 
        set => this.RaiseAndSetIfChanged(ref _frequency, value);
    }

    public ReactiveCommand<Unit, FmRadio> Save { get; }
    public ReactiveCommand<Unit, Unit> Cancel { get; }
}