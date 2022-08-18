using Radio.Models;
using Radio.Services;

namespace Radio.ViewModels;

public class RadiosViewModel : ViewModelBase
{
    public RadiosViewModel(MongoCRUD mongoCrud, MainWindowViewModel mainWindowViewModel)
    {
        OnlineRadiosViewModel =
            new OnlineRadiosViewModel(mongoCrud, mainWindowViewModel);
        FmRadiosViewModel = new FmRadiosViewModel(mongoCrud.LoadRecords<FmRadio>("FmRadios"), mainWindowViewModel);
    }

    public OnlineRadiosViewModel OnlineRadiosViewModel { get; }
    public FmRadiosViewModel FmRadiosViewModel { get; }
}