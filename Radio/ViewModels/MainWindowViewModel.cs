using System;
using System.Reactive.Linq;
using Radio.Models;
using Radio.Services;
using ReactiveUI;

namespace Radio.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    //private RadiosViewModel _radiosViewModel;
    private readonly MongoCRUD _mongoCrud;
    private ViewModelBase _currentViewModel;

    public MainWindowViewModel(MongoCRUD mongoCrud)
    {
        _mongoCrud = mongoCrud;
        CurrentViewModel = new RadiosViewModel(mongoCrud, this);
    }

    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    public void EditFmRadio(FmRadio fmRadio)
    {
        var vm = new EditFmRadioViewModel(fmRadio)
        {
            Frequency = fmRadio.Frequency,
            Name = fmRadio.Name
        };

        vm.Save.Merge(vm.Cancel.Select(_ => (FmRadio)null))
            .Take(1)
            .Subscribe(model =>
            {
                if (model != null) _mongoCrud.UpsertRecord("FmRadios", model.Guid, model);

                CurrentViewModel = new RadiosViewModel(_mongoCrud, this);
            });

        CurrentViewModel = vm;
    }

    public void AddFmRadio()
    {
        var vm = new AddFmRadioViewModel();

        vm.Save.Merge(vm.Cancel.Select(_ => (FmRadio)null))
            .Take(1)
            .Subscribe(model =>
            {
                if (model != null) _mongoCrud.InsertRecord("FmRadios", model);

                CurrentViewModel = new RadiosViewModel(_mongoCrud, this);
            });

        CurrentViewModel = vm;
    }

    public void AddOnlineRadio()
    {
        var vm = new AddOnlineRadioViewModel();

        vm.Save.Merge(vm.Cancel.Select(_ => (OnlineRadio)null))
            .Take(1)
            .Subscribe(model =>
            {
                if (model != null) _mongoCrud.InsertRecord("OnlineRadios", model);

                CurrentViewModel = new RadiosViewModel(_mongoCrud, this);
            });

        CurrentViewModel = vm;
    }

    public void EditOnlineRadio(OnlineRadio onlineRadio)
    {
        var vm = new EditOnlineRadioViewModel(onlineRadio)
        {
            Name = onlineRadio.Name,
            Url = onlineRadio.Url
        };

        vm.Save.Merge(vm.Cancel.Select(_ => (OnlineRadio)null))
            .Take(1)
            .Subscribe(model =>
            {
                if (model != null) _mongoCrud.UpsertRecord("OnlineRadios", model.Guid, model);

                CurrentViewModel = new RadiosViewModel(_mongoCrud, this);
            });

        CurrentViewModel = vm;
    }

    public void DeleteOnlineRadio(OnlineRadio onlineRadio)
    {
        _mongoCrud.DeleteRecord<OnlineRadio>("OnlineRadios", onlineRadio.Guid);
        CurrentViewModel = new RadiosViewModel(_mongoCrud, this);
    }

    public void DeleteFmRadio(FmRadio fmRadio)
    {
        _mongoCrud.DeleteRecord<FmRadio>("FmRadios", fmRadio.Guid);
        CurrentViewModel = new RadiosViewModel(_mongoCrud, this);
    }
}