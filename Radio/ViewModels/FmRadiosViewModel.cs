using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Radio.Models;

namespace Radio.ViewModels;

public class FmRadiosViewModel
{
    public FmRadiosViewModel(IEnumerable<FmRadio> fmRadios)
    {
        FmRadios = new ObservableCollection<FmRadio>(fmRadios);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<FmRadio> FmRadios { get; }

    private FmRadio _selectedFmRadio;

    public FmRadio SelectedFmRadio
    {
        get => _selectedFmRadio;
        set
        {
            _selectedFmRadio = value;
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(SelectedFmRadio)));
        }
    }
}