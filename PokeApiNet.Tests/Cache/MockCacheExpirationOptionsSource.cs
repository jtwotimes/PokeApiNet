using System;
using System.Collections.Generic;

namespace PokeApiNet.Tests.Cache
{
    internal sealed class MockCacheExpirationOptionsSource : IObservable<CacheExpirationOptions>
    {
        private readonly List<IObserver<CacheExpirationOptions>> observers;

        public MockCacheExpirationOptionsSource()
        {
            this.observers = new List<IObserver<CacheExpirationOptions>>();
        }

        public IDisposable Subscribe(IObserver<CacheExpirationOptions> observer)
        {
            if (!this.observers.Contains(observer))
            {
                this.observers.Add(observer);
            }
            return new Unsubscriber(this.observers, observer);
        }

        public void Emit(CacheExpirationOptions value)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(value);
            }
        }

        public void Close()
        {
            foreach (var observer in observers.ToArray())
            {
                observer.OnCompleted();
            }
            observers.Clear();
        }

        public class Unsubscriber : IDisposable
        {
            public readonly IList<IObserver<CacheExpirationOptions>> _observers;
            public readonly IObserver<CacheExpirationOptions> _observer;

            public Unsubscriber(IList<IObserver<CacheExpirationOptions>> observers, IObserver<CacheExpirationOptions> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (this._observer != null && this._observers.Contains(_observer))
                    this._observers.Remove(_observer);
            }
        }
    }
}
