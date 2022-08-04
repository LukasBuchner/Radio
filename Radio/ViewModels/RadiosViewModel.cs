using Radio.Services;

namespace Radio.ViewModels;

public class RadiosViewModel : ViewModelBase
{
    public RadiosViewModel(Database database)
    {
        OnlineRadiosViewModel = new OnlineRadiosViewModel(database.GetOnlineRadios());
        FmRadiosViewModel = new FmRadiosViewModel(database.GetFmRadios());
    }
    
    public OnlineRadiosViewModel OnlineRadiosViewModel { get; }
    public FmRadiosViewModel FmRadiosViewModel { get; }
}