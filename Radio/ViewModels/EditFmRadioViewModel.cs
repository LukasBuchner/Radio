using System.Reactive;
using Radio.Models;
using ReactiveUI;

namespace Radio.ViewModels;

public class EditFmRadioViewModel : ViewModelBase
{
    private string? _frequency;
    private string? _name;

    public EditFmRadioViewModel(FmRadio fmRadio)
    {
        var saveEnabled = this.WhenAnyValue<EditFmRadioViewModel, bool, string>(
            x => x.Name,
            x => !string.IsNullOrWhiteSpace(x));

        Save = ReactiveCommand.Create(
            () => fmRadio with { Name = Name, Frequency = Frequency },
            saveEnabled);
        Cancel = ReactiveCommand.Create(() => { });
    }

    public string? Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string? Frequency
    {
        get => _frequency;
        set => this.RaiseAndSetIfChanged(ref _frequency, value);
    }

    public ReactiveCommand<Unit, FmRadio> Save { get; }
    public ReactiveCommand<Unit, Unit> Cancel { get; }
}