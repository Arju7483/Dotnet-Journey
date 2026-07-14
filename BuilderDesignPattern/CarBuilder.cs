using System;
using System.Collections.Generic;
using System.Text;

namespace Builder_Pattern
{
    
    public class CarBuilder : ICarBuilder
    {
        private readonly Car _car = new Car();
        public ICarBuilder AddGPS()
        {
            _car.HasGPS = true;
            return this;
        }

        public ICarBuilder AddSunroof()
        {
            _car.HasSunroof = true;
            return this;
        }

        public ICarBuilder SetColor(string color)
        {
            _car.Color = color;
            return this;
        }

        public ICarBuilder SetEngine(string engine)
        {
            _car.Engine = engine;
            return this;
        }

        public ICarBuilder SetType(string type)
        {
            _car.Type = type;
            return this;
        }

        public ICarBuilder SetWheels(int wheels)
        {
            _car.Wheels = wheels;
            return this;
        }
        public Car Build()
        {
            return _car;
        }
    }
}
