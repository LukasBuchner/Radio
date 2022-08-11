using System;
using System.Collections.Generic;
using Radio.Models;
using Radio.Views;

namespace Radio.Services;

public class Database
{
    private FmRadio _fmRadio;
    private OnlineRadio _onlineRadio;

    public IEnumerable<FmRadio> GetFmRadios()
    {
        _fmRadio = new FmRadio
        {
            Guid = new Guid(), Frequency = "88.80", Genres = new List<string> { "Pop", "Top40" }, Name = "Hitradio",
            Region = "Austria"
        };
        
        return new[]
        {
            _fmRadio with { Guid = new Guid()},
            _fmRadio with { Guid = new Guid()}, 
            _fmRadio with { Guid = new Guid()},
            _fmRadio with { Guid = new Guid()},
            _fmRadio with { Guid = new Guid()},
            _fmRadio with { Guid = new Guid()},
            _fmRadio with { Guid = new Guid()},
            _fmRadio with { Guid = new Guid()}
        };
    }

    public IEnumerable<OnlineRadio> GetOnlineRadios()
    {
        _onlineRadio = new OnlineRadio
        {
            Guid = new Guid(), Genres = new List<string> { "House", "Alternative" }, Name = "Lounge.music",
            Url = "www.lounge.music"
        };

        return new[]
        {
            _onlineRadio with { Guid = new Guid() },
            _onlineRadio with { Guid = new Guid() },
        };
    }
}