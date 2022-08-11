using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using ReactiveUI;
using Radio.Models;
using Radio.Services;

namespace Radio.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _currentViewModel;
    private RadiosViewModel _radiosViewModel;

    public MainWindowViewModel(MongoCRUD mongoCrud)
    {
        CurrentViewModel = _radiosViewModel = new RadiosViewModel(mongoCrud);
    }
    
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    public void AddFmRadio()
    {
        var vm = new AddFmRadioViewModel();
        
        Observable.Merge(
                vm.Save,
                vm.Cancel.Select(_ => (FmRadio)null))
            .Take(1)
            .Subscribe(model =>
            {
                if (model != null)
                {
                    _radiosViewModel.FmRadiosViewModel.FmRadios.Add(model);
                }

                CurrentViewModel = _radiosViewModel;
            });

        CurrentViewModel = vm;
    }

    public void AddOnlineRadio()
    {
        var vm = new AddOnlineRadioViewModel();
        
        Observable.Merge(
                vm.Save,
                vm.Cancel.Select(_ => (OnlineRadio)null))
            .Take(1)
            .Subscribe(model =>
            {
                if (model != null)
                {
                    _radiosViewModel.OnlineRadiosViewModel.OnlineRadios.Add(model);
                }

                CurrentViewModel = _radiosViewModel;
            });

        CurrentViewModel = vm;
    }
}