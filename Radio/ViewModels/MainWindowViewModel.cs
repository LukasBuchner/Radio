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
    //private RadiosViewModel _radiosViewModel;
    private MongoCRUD _mongoCrud;

    public MainWindowViewModel(MongoCRUD mongoCrud)
    {
        _mongoCrud = mongoCrud;
        CurrentViewModel = new RadiosViewModel(mongoCrud);
    }
    
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    public void EditFmRadio(FmRadio fmRadio)
    {
        var vm = new AddFmRadioViewModel();
        vm.Frequency = fmRadio.Frequency;
        vm.Name = fmRadio.Name;
        
        Observable.Merge(
                vm.Save,
                vm.Cancel.Select(_ => (FmRadio)null))
            .Take(1)
            .Subscribe(model =>
            {
                if (model != null)
                {
                    _mongoCrud.InsertRecord("FmRadios", model);
                }

                CurrentViewModel = new RadiosViewModel(_mongoCrud);
            });

        CurrentViewModel = vm;
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
                    _mongoCrud.InsertRecord("FmRadios", model);
                }

                CurrentViewModel = new RadiosViewModel(_mongoCrud);
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
                    _mongoCrud.InsertRecord("OnlineRadio", model);
                }

                CurrentViewModel = new RadiosViewModel(_mongoCrud);
            });

        CurrentViewModel = vm;
    }
}