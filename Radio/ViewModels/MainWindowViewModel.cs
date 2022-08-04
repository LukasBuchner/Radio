using System.Collections.ObjectModel;
using System.ComponentModel;
using Radio.Models;

namespace Radio.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";
        
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<OnlineRadio> OnlineRadios { get; }
            = new ObservableCollection<OnlineRadio>();

        public ObservableCollection<FmRadio> FmRadios { get; }
            = new ObservableCollection<FmRadio>();
        
        private OnlineRadio selectedOnlineRadio;

        public OnlineRadio SelectedOnlineRadio
        {
            get { return selectedOnlineRadio; }
            set
            {
                selectedOnlineRadio = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedOnlineRadio)));
            }
        }
        
        private FmRadio selectedFmRadio;

        public FmRadio SelectedFmRadio
        {
            get { return selectedFmRadio; }
            set
            {
                selectedFmRadio = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedFmRadio)));
            }
        }
    }
}