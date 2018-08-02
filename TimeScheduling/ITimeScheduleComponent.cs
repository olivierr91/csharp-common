namespace NoNameDev.CSharpCommon.TimeScheduling {

    public interface ITimeScheduleComponent {
        int MaxValue { get; }
        int MinValue { get; }
        int ValueRange { get; }

        bool Matches(int timeComponentValue);

        int MinInterval();

        int NextMatchExclusive(int timeComponentValue);

        int NextMatchInclusive(int timeComponentValue);

        string ToString();
    }
}