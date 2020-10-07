using System;
using System.Collections.Generic;
using System.Text;

namespace Shape_Library
{
    public abstract class Shape3D : Shape
    {
        public abstract float Volume { get; }
    }
}
