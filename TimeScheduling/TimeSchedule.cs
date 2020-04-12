using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCommon.TimeScheduling {

    public class TimeSchedule {
        private static List<(int MinValue, int MaxValue)> _componentParameters = new List<(int MinValue, int MaxValue)>();
        private ITimeScheduleComponent _days = null;
        private ITimeScheduleComponent _hours = null;
        private ITimeScheduleComponent _milliseconds = null;
        private ITimeScheduleComponent _minutes = null;
        private ITimeScheduleComponent _seconds = null;

        static TimeSchedule() {
            _componentParameters.Add((1, 31));
            _componentParameters.Add((0, 23));
            _componentParameters.Add((0, 59));
            _componentParameters.Add((0, 59));
            _componentParameters.Add((0, 999));
        }

        public TimeSchedule(ITimeScheduleComponent days, ITimeScheduleComponent hours, ITimeScheduleComponent minutes, ITimeScheduleComponent seconds, ITimeScheduleComponent milliseconds) {
            _days = days;
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            _milliseconds = milliseconds;
        }

        public static TimeSchedule Parse(string value) {
            TimeSchedule scheduleTime = TryParseOrNull(value);
            if (scheduleTime == null) {
                throw new FormatException($"'{value}' cannot be parsed to {typeof(TimeSchedule).Name}.");
            }
            return scheduleTime;
        }

        public static TimeSchedule TryParseOrNull(string value) {
            string[] strComponents = value.Split(';');
            if (strComponents.Length == 5) {
                var components = new ITimeScheduleComponent[5];
                for (int i = 0; i < 5; i++) {
                    AnyTimeComponent anyTimeComponent;
                    if (AnyTimeComponent.TryParse(strComponents[i], _componentParameters[i].MinValue, _componentParameters[i].MaxValue, out anyTimeComponent)) {
                        components[i] = anyTimeComponent;
                        continue;
                    }
                    FixedTimeComponent fixedTimeComponent;
                    if (FixedTimeComponent.TryParse(strComponents[i], _componentParameters[i].MinValue, _componentParameters[i].MaxValue, out fixedTimeComponent)) {
                        components[i] = fixedTimeComponent;
                        continue;
                    }
                    IntervalTimeComponent intervalTimeComponent;
                    if (IntervalTimeComponent.TryParse(strComponents[i], _componentParameters[i].MinValue, _componentParameters[i].MaxValue, out intervalTimeComponent)) {
                        components[i] = intervalTimeComponent;
                        continue;
                    }
                }
                return new TimeSchedule(components[0], components[1], components[2], components[3], components[4]);
            }
            return null;
        }

        public List<ITimeScheduleComponent> GetComponents() {
            return new List<ITimeScheduleComponent>() { _days, _hours, _minutes, _seconds, _milliseconds };
        }

        public TimeSpan GetMinInterval() {
            IEnumerable<ITimeScheduleComponent> components = GetComponents();
            foreach (ITimeScheduleComponent component in components.Reverse()) {
                int minInterval = component.MinInterval();
                if (minInterval < component.ValueRange) {
                    if (component == _days) {
                        return TimeSpan.FromDays(minInterval);
                    } else if (component == _hours) {
                        return TimeSpan.FromHours(minInterval);
                    } else if (component == _minutes) {
                        return TimeSpan.FromMinutes(minInterval);
                    } else if (component == _seconds) {
                        return TimeSpan.FromSeconds(minInterval);
                    } else if (component == _milliseconds) {
                        return TimeSpan.FromMilliseconds(minInterval);
                    }
                } else if (minInterval == component.ValueRange && component == _days) {
                    return TimeSpan.FromDays(28);
                }
            }
            throw new Exception("Could not get the minimum interval.");
        }

        public DateTimeOffset GetNextSchedule() {
            return GetNextSchedule(DateTimeOffset.UtcNow);
        }

        public DateTimeOffset GetNextSchedule(DateTimeOffset current) {
            var next = new DateTimeOffset(current.DateTime, current.Offset);
            IList<ITimeScheduleComponent> components = GetComponents();
            foreach (ITimeScheduleComponent component in components.Reverse()) {
                int nextMatch;
                if (component == _days) {
                    nextMatch = component.NextMatchInclusive(next.Day);
                    if (nextMatch < next.Day) {
                        next = next.AddMonths(1);
                    }
                    if (nextMatch != current.Day) {
                        next = next.AddHours(components[1].NextMatchInclusive(0) - next.Hour);
                        next = next.AddMinutes(components[2].NextMatchInclusive(0) - next.Minute);
                        next = next.AddSeconds(components[3].NextMatchInclusive(0) - next.Second);
                        next = next.AddMilliseconds(components[4].NextMatchInclusive(0) - next.Millisecond);
                    }
                    next = next.AddDays(nextMatch - next.Day);
                } else if (component == _hours) {
                    nextMatch = component.NextMatchInclusive(next.Hour);
                    if (nextMatch < next.Hour) {
                        next = next.AddDays(1);
                    }
                    if (nextMatch != current.Hour) {
                        next = next.AddMinutes(components[2].NextMatchInclusive(0) - next.Minute);
                        next = next.AddSeconds(components[3].NextMatchInclusive(0) - next.Second);
                        next = next.AddMilliseconds(components[4].NextMatchInclusive(0) - next.Millisecond);
                    }
                    next = next.AddHours(nextMatch - next.Hour);
                } else if (component == _minutes) {
                    nextMatch = component.NextMatchInclusive(next.Minute);
                    if (nextMatch < next.Minute) {
                        next = next.AddHours(1);
                    }
                    if (nextMatch != current.Minute) {
                        next = next.AddSeconds(components[3].NextMatchInclusive(0) - next.Second);
                        next = next.AddMilliseconds(components[4].NextMatchInclusive(0) - next.Millisecond);
                    }
                    next = next.AddMinutes(nextMatch - next.Minute);
                } else if (component == _seconds) {
                    nextMatch = component.NextMatchInclusive(next.Second);
                    if (nextMatch < next.Second) {
                        next = next.AddMinutes(1);
                    }
                    if (nextMatch != current.Second) {
                        next = next.AddMilliseconds(components[4].NextMatchInclusive(0) - next.Millisecond);
                    }
                    next = next.AddSeconds(nextMatch - next.Second);
                } else if (component == _milliseconds) {
                    nextMatch = component.NextMatchExclusive(next.Millisecond);
                    if (nextMatch <= next.Millisecond) {
                        next = next.AddSeconds(1);
                    }
                    next = next.AddMilliseconds(nextMatch - next.Millisecond);
                }
            }
            return next;
        }

        public List<ITimeScheduleComponent> GetReverseComponents() {
            return new List<ITimeScheduleComponent>() { _milliseconds, _seconds, _minutes, _hours, _days };
        }

        public TimeSpan GetTimeSpanToNextSchedule() {
            return GetNextSchedule() - DateTimeOffset.UtcNow;
        }

        public bool Matches(DateTimeOffset value) {
            return _days.Matches(value.Day) && _hours.Matches(value.Hour) && _minutes.Matches(value.Minute) && _seconds.Matches(value.Second) && _milliseconds.Matches(value.Millisecond);
        }

        public override string ToString() {
            return $"{_days};{_hours};{_minutes};{_seconds};{_milliseconds}";
        }
    }
}