namespace CSharpCommon.Utils.TimeScheduling {
    public interface ITimeScheduleComponent
    {
        int MinValue { get; }
        int MaxValue { get; }
        int ValueRange { get; }
        bool Matches(int timeComponentValue);
        int MinInterval();
        int NextMatchExclusive(int timeComponentValue);
        int NextMatchInclusive(int timeComponentValue);
        string ToString();
    }
}
