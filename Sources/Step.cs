using System;

namespace Darkit
{
    public class Step<D>
    {
        public D Data { get; private set; }

        public Step(D data)
        {
            Data = data;
        }

        public Step<D> then(Action<D> action)
        {
            action(Data);
            return this;
        }

        public Step<R> then<R>(Func<D, R> function)
        {
            R result = function(Data);
            return new Step<R>(result);
        }
    }
}