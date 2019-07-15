using System;

namespace StrangerThings
{
    public class UpsideDown<T>
    {
        public T Value { get; }

        private UpsideDown(T value)
        {
            Value = value;
        }

        public static UpsideDown<T> PortalToUpsideDown(T value)
        => new UpsideDown<T>(value);

        public T PortalFromUpsideDown()
        => this.Value;

        public static UpsideDown<TResult> Apply<TResult>(
            UpsideDown<T> upsideDownValue, 
            UpsideDown<Func<T, TResult>> upsideDownFunction)
        {
            var normalValue = upsideDownValue.PortalFromUpsideDown();
            var normalFunction = upsideDownFunction.PortalFromUpsideDown();
            var normalResult = normalFunction(normalValue);
            return normalResult.PortalToUpsideDown();
        }

        public static UpsideDown<TResult> Map1<TResult>(
            UpsideDown<T> upsideDownValue,
            Func<T, TResult> normalFunction)
        {
            var normalValue = upsideDownValue.PortalFromUpsideDown();
            var normalResult = normalFunction(normalValue);
            return normalResult.PortalToUpsideDown();
        }

        public static UpsideDown<TResult> Map<TResult>(
            UpsideDown<T> upsideDownValue,
            Func<T, TResult> normalFunction)
        => Apply(upsideDownValue, normalFunction.PortalToUpsideDown());
        
    }

    public static class UpsideDownExtensions
    {
        public static UpsideDown<T> PortalToUpsideDown<T>(this T value)
        => UpsideDown<T>.PortalToUpsideDown(value);

        public static UpsideDown<TResult> Apply<T, TResult>(this UpsideDown<T> value, UpsideDown<Func<T, TResult>> upsideDownFunction)
            => UpsideDown<T>.Apply(value, upsideDownFunction);

        public static UpsideDown<TResult> Map<T, TResult>(this UpsideDown<T> value, Func<T, TResult> projection)
            => UpsideDown<T>.Map(value, projection);
    }
}
