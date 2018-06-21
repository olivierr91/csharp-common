using CSharpCommon.Utils.Text;
using System;

namespace CSharpCommon.Utils.TimeScheduling {
    public class IntervalTimeComponent : ITimeScheduleComponent {

        private int _interval;
        private int _minValue;
        private int _maxValue;

        public IntervalTimeComponent(int interval, int minValue, int maxValue) {
            if (_interval > (_maxValue - _minValue) + 1) {
                throw new ArgumentException("Interval must be within the range of minValue and maxValue.");
            }
            _interval = interval;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public int MinValue { get => _minValue; }
        public int MaxValue { get => _maxValue; }
        public int ValueRange { get => _maxValue - _minValue + 1; }

        public int Interval {
            get => _interval;
            set => _interval = value;
        }

        public bool Matches(int value) {
            return (value - _minValue) % _interval == 0;
        }

        public override string ToString() {
            return $"*/{_interval}";
        }

        public static bool TryParse(string value, int minValue, int maxValue, out IntervalTimeComponent result) {
            string strInterval = RegExUtils.MatchSingleGroupOrNull(@"\*\/([0-9]+)", value);
            if (strInterval == null) {
                result = null;
                return false;
            }
            int interval = Int32.Parse(strInterval);
            result = new IntervalTimeComponent(interval, minValue, maxValue);
            return true;
        }

        public int MinInterval() {
            return Interval;
        }

        public int NextMatchExclusive(int timeComponentValue) {
            return NextMatchInclusive(timeComponentValue + 1);
        }

        public int NextMatchInclusive(int timeComponentValue) {
            int mod = ((timeComponentValue - _minValue) % _interval);
            if (mod > 0) {
                int next = timeComponentValue + (_interval - mod);
                if (next > _maxValue) {
                    return _interval + _minValue;
                } else {
                    return next;
                }
            } else {
                return timeComponentValue;
            }
        }
    }
}
