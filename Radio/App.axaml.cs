using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Radio.Models;
using Radio.Services;
using Radio.ViewModels;
using Radio.Views;

namespace Radio;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var radios = new MongoCRUD("Radios");
            PopulateIfEmpty(radios);

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(radios)
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static void PopulateIfEmpty(MongoCRUD radios)
    {
        var fmRadios = radios.LoadRecords<FmRadio>("FmRadios");
        var onlineRadios = radios.LoadRecords<OnlineRadio>("OnlineRadios");
        var genre = radios.LoadRecords<Genre>("Genre");
        if (fmRadios.Count == 0 && onlineRadios.Count == 0 && genre.Count == 0) PopulateWithSampleData(radios);
    }

    private static void PopulateWithSampleData(MongoCRUD radios)
    {
        var fmRadio = new FmRadio
        {
            Frequency = "88.80", Genres = new List<string> { "Pop", "Top40" }, Name = "Hitradio",
            Region = "Austria"
        };

        radios.InsertRecord("FmRadios", fmRadio);
        radios.InsertRecord("FmRadios", fmRadio with { Guid = Guid.NewGuid(), Frequency = "99.90" });

        var onlineRadio = new OnlineRadio
        {
            Genres = new List<string> { "House", "Alternative" }, Name = "Lounge.music",
            Url = "www.lounge.music"
        };

        radios.InsertRecord("OnlineRadios", onlineRadio);
        radios.InsertRecord("OnlineRadios", onlineRadio with { Guid = Guid.NewGuid(), Url = "www.st.com" });

        radios.InsertRecord("Genres", new Genre { Name = "Classical" });
        radios.InsertRecord("Genres", new Genre { Name = "Pop" });
        radios.InsertRecord("Genres", new Genre { Name = "Rock" });
        radios.InsertRecord("Genres", new Genre { Name = "Indy" });
    }
}