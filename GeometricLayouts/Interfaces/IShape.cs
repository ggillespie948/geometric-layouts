using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeometricLayouts.Interfaces
{
    public interface IShape
    {
        string Id { get;  }

        string VerticesToString { get; }
    }
}
