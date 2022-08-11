using Radio.Models;
using Radio.Services;

namespace Radio.ViewModels;

public class RadiosViewModel : ViewModelBase
{
    public RadiosViewModel(MongoCRUD mongoCrud)
    {
        OnlineRadiosViewModel = new OnlineRadiosViewModel(mongoCrud.LoadRecords<OnlineRadio>("OnlineRadios"));
        FmRadiosViewModel = new FmRadiosViewModel(mongoCrud.LoadRecords<FmRadio>("FmRadios"));
    }
    
    public OnlineRadiosViewModel OnlineRadiosViewModel { get; }
    public FmRadiosViewModel FmRadiosViewModel { get; }
}