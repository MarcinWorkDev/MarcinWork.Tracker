using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarcinWorkTracker.Logic.Services.Providers
{
    interface ITrackProvider
    {
        void Track(string number);
        string ToJson();
    }
}
