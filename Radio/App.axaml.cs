using System.Collections.Generic;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Radio.Models;
using Radio.ViewModels;
using Radio.Views;

namespace Radio
{
    public partial class App : Application
    {
        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var vm = new MainWindowViewModel();
                vm.FmRadios.Add(new FmRadio { Id = 1, Frequency = "88.80", Genres = new List<string> {"Pop", "Top40"}, Name = "Hitradio", Region = "Austria"});
                vm.FmRadios.Add(new FmRadio { Id = 2, Frequency = "88.80", Genres = new List<string> {"Pop", "Top40"}, Name = "Hitradio", Region = "Austria"});
                vm.FmRadios.Add(new FmRadio { Id = 3, Frequency = "88.80", Genres = new List<string> {"Pop", "Top40"}, Name = "Hitradio", Region = "Austria"});
                vm.FmRadios.Add(new FmRadio { Id = 4, Frequency = "88.80", Genres = new List<string> {"Pop", "Top40"}, Name = "Hitradio", Region = "Austria"});
                vm.FmRadios.Add(new FmRadio { Id = 5, Frequency = "88.80", Genres = new List<string> {"Pop", "Top40"}, Name = "Hitradio", Region = "Austria"});
                vm.FmRadios.Add(new FmRadio { Id = 6, Frequency = "88.80", Genres = new List<string> {"Pop", "Top40"}, Name = "Hitradio", Region = "Austria"});
                vm.FmRadios.Add(new FmRadio { Id = 7, Frequency = "88.80", Genres = new List<string> {"Pop", "Top40"}, Name = "Hitradio", Region = "Austria"});
                vm.FmRadios.Add(new FmRadio { Id = 8, Frequency = "88.80", Genres = new List<string> {"Pop", "Top40"}, Name = "Hitradio", Region = "Austria"});
                vm.OnlineRadios.Add(new OnlineRadio{ Id = 5, Genres = new List<string>{"House", "Alternative"}, Name = "Lounge.music", Url = "www.lounge.music"});
                vm.OnlineRadios.Add(new OnlineRadio{ Id = 6, Genres = new List<string>{"House", "Alternative"}, Name = "Lounge.music", Url = "www.lounge.music"});
                vm.OnlineRadios.Add(new OnlineRadio{ Id = 7, Genres = new List<string>{"House", "Alternative"}, Name = "Lounge.music", Url = "www.lounge.music"});
                vm.OnlineRadios.Add(new OnlineRadio{ Id = 8, Genres = new List<string>{"House", "Alternative"}, Name = "Lounge.music", Url = "www.lounge.music"});
                
                desktop.MainWindow = new MainWindow
                {
                    DataContext = vm,
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}