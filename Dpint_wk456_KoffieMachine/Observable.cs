using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dpint_wk456_KoffieMachine
{
    public abstract class Observable<T> : IObservable<T>, IDisposable
    {
        private List<IObserver<T>> _oberservers;
        public List<IObserver<T>> ObserverList
        {
            get { return _oberservers; }
            set { _oberservers = value; }
        }

        public Observable()
        {
            _oberservers = new List<IObserver<T>>();
        }

        private struct Unsubscriber : IDisposable
        {
            private Action _unsubscribe;
            public Unsubscriber(Action unsubscribe)
            {
                _unsubscribe = unsubscribe;
            }
            public void Dispose()
            {
                _unsubscribe();
            }
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            _oberservers.Add(observer);
            return new Unsubscriber(() => _oberservers.Remove(observer));
        }

        protected virtual void Notify(T subject)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
