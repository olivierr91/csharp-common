using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpCommon.Extensions.Collections {

    public class OrderedSet<T> : ISet<T>, IReadOnlyCollection<T> {
        private readonly IDictionary<T, LinkedListNode<T>> _dictionary;
        private readonly LinkedList<T> _linkedList;

        public OrderedSet()
            : this(EqualityComparer<T>.Default) {
        }

        public OrderedSet(IEnumerable<T> collection) : this(EqualityComparer<T>.Default) {
            foreach (var item in collection) {
                Add(item);
            }
        }

        public OrderedSet(IEqualityComparer<T> comparer) {
            _dictionary = new Dictionary<T, LinkedListNode<T>>(comparer);
            _linkedList = new LinkedList<T>();
        }

        public int Count {
            get { return _dictionary.Count; }
        }

        public virtual bool IsReadOnly {
            get { return _dictionary.IsReadOnly; }
        }

        void ICollection<T>.Add(T item) {
            Add(item);
        }

        public bool Add(T item) {
            if (_dictionary.ContainsKey(item)) {
                return false;
            }
            LinkedListNode<T> node = _linkedList.AddLast(item);
            _dictionary.Add(item, node);
            return true;
        }

        public int AddRange(IEnumerable<T> items) {
            int added = 0;
            foreach (T item in items) {
                if (Add(item)) {
                    added++;
                }
            }
            return added;
        }

        public void Clear() {
            _linkedList.Clear();
            _dictionary.Clear();
        }

        public bool Contains(T item) {
            return _dictionary.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            _linkedList.CopyTo(array, arrayIndex);
        }

        public void ExceptWith(IEnumerable<T> other) {
            foreach (var item in other) {
                Remove(item);
            }
        }

        public IEnumerator<T> GetEnumerator() {
            return _linkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public void IntersectWith(IEnumerable<T> other) {
            throw new NotImplementedException();
        }

        public bool IsProperSubsetOf(IEnumerable<T> other) {
            throw new NotImplementedException();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other) {
            throw new NotImplementedException();
        }

        public bool IsSubsetOf(IEnumerable<T> other) {
            throw new NotImplementedException();
        }

        public bool IsSupersetOf(IEnumerable<T> other) {
            throw new NotImplementedException();
        }

        public bool Overlaps(IEnumerable<T> other) {
            throw new NotImplementedException();
        }

        public bool Remove(T item) {
            LinkedListNode<T> node;
            if (!_dictionary.TryGetValue(item, out node)) {
                return false;
            } else {
                _dictionary.Remove(item);
                _linkedList.Remove(node);
                return true;
            }
        }

        public bool SetEquals(IEnumerable<T> other) {
            int count = 0;
            foreach (var item in other) {
                if (!_dictionary.ContainsKey(item)) {
                    return false;
                }
                count++;
            }
            if (count != _dictionary.Count) {
                return false;
            }
            return true;
        }

        public void SymmetricExceptWith(IEnumerable<T> other) {
            throw new NotImplementedException();
        }

        public void UnionWith(IEnumerable<T> other) {
            foreach (var item in other) {
                Add(item);
            }
        }
    }
}