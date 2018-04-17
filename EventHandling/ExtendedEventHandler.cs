using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Utils.EventHandling {
    public class ExtendedEventHandler<T> where T : EventArgs {
        private List<ExtendedEventHandlerSubscriber<T>> _subscribers;
        private List<ExtendedEventHandler<T>> _forwardedHandlers;
        private SemaphoreSlim _waitToken;
        private int _waitCount = 0;

        public void AddHandler(Action<object, T> action) {
            if (_subscribers == null) {
                _subscribers = new List<ExtendedEventHandlerSubscriber<T>>();
            }
            if (!_subscribers.Any(s => s.Action == action)) {
                _subscribers.Add(new ExtendedEventHandlerSubscriber<T>(action));
            }
        }

        public void AddAsyncHandler(Func<object, T, Task> task) {
            if (_subscribers == null) {
                _subscribers = new List<ExtendedEventHandlerSubscriber<T>>();
            }
            if (!_subscribers.Any(s => s.Task == task)) {
                _subscribers.Add(new ExtendedEventHandlerSubscriber<T>(task));
            }
        }

        public async Task Wait(Action<object, T> action, CancellationToken cancellationToken) {
            if (_waitToken == null) {
                _waitToken = new SemaphoreSlim(0);
            }
            _waitCount++;
            AddHandler(action);
            await _waitToken.WaitAsync(cancellationToken);
            RemoveHandler(action);
            _waitCount--;
        }

        public void RemoveHandler(Action<object, T> action) {
            if (_subscribers == null) {
                return;
            }
            _subscribers.RemoveAll(s => s.Action == action);
            if (_subscribers.Count == 0) {
                _subscribers = null;
            }
        }

        public void RemoveAsyncHandler(Func<object, T, Task> task) {
            if (_subscribers == null) {
                return;
            }
            _subscribers.RemoveAll(s => s.Task == task);
            if (_subscribers.Count == 0) {
                _subscribers = null;
            }
        }

        public void Forward(ExtendedEventHandler<T> target) {
            if (_forwardedHandlers == null) {
                _forwardedHandlers = new List<ExtendedEventHandler<T>>();
            }
            _forwardedHandlers.Add(target);
        }

        public void CancelForward(ExtendedEventHandler<T> target) {
            if (_forwardedHandlers == null) {
                return;
            }
            _forwardedHandlers.Remove(target);
            if (_forwardedHandlers.Count == 0) {
                _forwardedHandlers = null;
            }
        }

        public void Invoke(object sender, T eventArgs) {
            if (_subscribers != null) {
                foreach (ExtendedEventHandlerSubscriber<T> subscriber in new List<ExtendedEventHandlerSubscriber<T>>(_subscribers)) {
                    if (subscriber.Action != null) {
                        subscriber.Action.Invoke(sender, eventArgs);
                    } else if (subscriber.Task != null) {
                        subscriber.Task.Invoke(sender, eventArgs).Wait();
                    }
                }
            }
            if (_forwardedHandlers != null) {
                foreach (ExtendedEventHandler<T> forwardedHandler in new List<ExtendedEventHandler<T>>(_forwardedHandlers)) {
                    forwardedHandler.Invoke(sender, eventArgs);
                }
            }
            if (_waitToken != null) {
                _waitToken.Release(_waitCount);
            }
        }

        public async Task InvokeAsync(object sender, T eventArgs) {
            if (_subscribers != null) {
                foreach (ExtendedEventHandlerSubscriber<T> subscriber in new List<ExtendedEventHandlerSubscriber<T>>(_subscribers)) {
                    if (subscriber.Action != null) {
                        subscriber.Action.Invoke(sender, eventArgs);
                    } else if (subscriber.Task != null) {
                        await subscriber.Task.Invoke(sender, eventArgs);
                    }
                }
            }
            if (_forwardedHandlers != null) {
                foreach (ExtendedEventHandler<T> forwardedHandler in new List<ExtendedEventHandler<T>>(_forwardedHandlers)) {
                    await forwardedHandler.InvokeAsync(sender, eventArgs);
                }
            }
            if (_waitToken != null) {
                _waitToken.Release(_waitCount);
            }
        }
    }
}
