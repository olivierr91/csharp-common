using System;
using System.Threading.Tasks;

namespace Common.Utils.EventHandling {
    public class ExtendedEventHandlerSubscriber<T> where T : EventArgs {

        public ExtendedEventHandlerSubscriber(Action<object, T> action) {
            Action = action;
        }

        public ExtendedEventHandlerSubscriber(Func<object, T, Task> task) {
            Task = task;
        }

        public Action<object, T> Action { get; set; }
        public Func<object, T, Task> Task { get; set; }

        public override bool Equals(Object obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ExtendedEventHandlerSubscriber<T> e = (ExtendedEventHandlerSubscriber<T>)obj;
            return Action == e.Action && Task == e.Task;
        }

        public override int GetHashCode() {
            if (Action != null) {
                return Action.GetHashCode();
            } else {
                return Task.GetHashCode();
            }
        }
    }
}
