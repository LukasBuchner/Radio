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
            Id = 0, Frequency = "88.80", Genres = new List<string> { "Pop", "Top40" }, Name = "Hitradio",
            Region = "Austria"
        };
        
        return new[]
        {
            _fmRadio with { Id = 1},
            _fmRadio with { Id = 2}, 
            _fmRadio with { Id = 3},
            _fmRadio with { Id = 4},
            _fmRadio with { Id = 5},
            _fmRadio with { Id = 6},
            _fmRadio with { Id = 7},
            _fmRadio with { Id = 8}
        };
    }

    public IEnumerable<OnlineRadio> GetOnlineRadios()
    {
        _onlineRadio = new OnlineRadio
        {
            Id = 0, Genres = new List<string> { "House", "Alternative" }, Name = "Lounge.music",
            Url = "www.lounge.music"
        };

        return new[]
        {
            _onlineRadio with { Id = 9 },
            _onlineRadio with { Id = 10 },
        };
    }
}