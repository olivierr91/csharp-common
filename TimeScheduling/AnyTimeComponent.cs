using CSharpCommon.Utils;
using System;

namespace CSharpCommon.TimeScheduling {

    public class AnyTimeComponent : ITimeScheduleComponent {
        private int _maxValue;
        private int _minValue;

        public AnyTimeComponent(int minValue, int maxValue) {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public int MaxValue { get => _maxValue; }
        public int MinValue { get => _minValue; }
        public int ValueRange { get => _maxValue - _minValue + 1; }

        public static bool TryParse(string value, int minValue, int maxValue, out AnyTimeComponent result) {
            if (String.IsNullOrEmpty(value) || value.Trim() == "*") {
                result = new AnyTimeComponent(minValue, maxValue);
                return true;
            } else {
                result = null;
                return false;
            }
        }

        public bool Matches(int value) {
            return true;
        }

        public int MinInterval() {
            return 1;
        }

        public int NextMatchExclusive(int timeComponentValue) {
            return NextMatchInclusive(timeComponentValue + 1);
        }

        public int NextMatchInclusive(int timeComponentValue) {
            return MathUtils.Wrap(timeComponentValue, _minValue, _maxValue);
        }

        public override string ToString() {
            return "*";
        }
    }
}