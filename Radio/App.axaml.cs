using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Radio.Models;
using Radio.Services;
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
                var database = new Database();
                var radios = new MongoCRUD("Radios");
                radios.InsertRecord("FmRadios", new FmRadio
                {
                    Frequency = "88.80", Genres = new List<string> { "Pop", "Top40" }, Name = "Hitradio",
                    Region = "Austria"
                });
                radios.InsertRecord("OnlineRadios", new OnlineRadio
                {
                    Guid = new Guid(), Genres = new List<string> { "House", "Alternative" }, Name = "Lounge.music",
                    Url = "www.lounge.music"
                });

                desktop.MainWindow = new MainWindow
                {
                    DataContext =  new MainWindowViewModel(database),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}