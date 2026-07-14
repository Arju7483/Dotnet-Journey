using System;
using System.Collections.Generic;
using System.Text;

namespace Builder_Pattern
{
    public interface ICarBuilder
    {
        ICarBuilder SetType(string type);
        ICarBuilder SetEngine (string engine);
        ICarBuilder SetWheels(int wheels);
        ICarBuilder AddSunroof();
        ICarBuilder AddGPS();
        ICarBuilder SetColor(string color);
        Car Build();

    }
}
