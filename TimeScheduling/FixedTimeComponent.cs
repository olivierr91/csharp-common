using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCommon.Utils.TimeScheduling {
    public class FixedTimeComponent : ITimeScheduleComponent {

        private HashSet<int> _values = new HashSet<int>();
        private int _minValue;
        private int _maxValue;

        public FixedTimeComponent(HashSet<int> values, int minValue, int maxValue) {
            if (values.Count == 0) {
                throw new ArgumentException("At least one value must be provided.");
            } else if (values.Any(v => v < minValue || v > maxValue)) {
                throw new ArgumentException("Values must be within the range of minValue and maxValue.");
            }
            _values = values;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public int MinValue { get => _minValue; }
        public int MaxValue { get => _maxValue; }
        public int ValueRange { get => _maxValue - _minValue + 1; }

        public bool Matches(int value) {
            return _values.Contains(value);
        }

        public override string ToString() {
            return String.Join(",", _values);
        }

        public static bool TryParse(string value, int minValue, int maxValue, out FixedTimeComponent result) {
            var values = new HashSet<int>();
            string[] strValues = value.Split(',');
            if (strValues.Length == 0) {
                throw new ArgumentException("At least one value must be provided.");
            }
            foreach (string strValue in strValues) {
                int intValue;
                if (!Int32.TryParse(strValue, out intValue)) {
                    result = null;
                    return false;
                }
                values.Add(intValue);
            }
            result = new FixedTimeComponent(values, minValue, maxValue);
            return true;
        }

        public int MinInterval() {
            if (_values.Count > 1) {
                int minInterval = GetIntervals().Min(i => Math.Abs(i.UpperBound - i.LowerBound));
                return Math.Min(minInterval, (_values.First() - _minValue) + (_maxValue + 1 - _values.Last()));
            } else {
                return _maxValue - _minValue + 1;
            }
        }

        public List<(int LowerBound, int UpperBound)> GetIntervals() {
            var intervals = new List<(int LowerBound, int UpperBound)>(); ;
            List<int> orderedValues = _values.OrderBy(v => v).ToList();
            int? previousValue = null;
            foreach (int value in orderedValues) {
                if (previousValue.HasValue) {
                    intervals.Add((previousValue.Value, value));
                }
                previousValue = value;
            }
            return intervals;
        }

        public int NextMatchExclusive(int timeComponentValue) {
            return NextMatchInclusive(timeComponentValue + 1);
        }

        public int NextMatchInclusive(int timeComponentValue) {
            if (_values.Count == 1) {
                return _values.First();
            }
            IOrderedEnumerable<int> orderedValues = _values.OrderBy(v => v);
            if (orderedValues.Any(v => v >= timeComponentValue)) {
                return orderedValues.Where(v => v >= timeComponentValue).First();
            } else {
                return orderedValues.First();
            }
        }
    }
}
