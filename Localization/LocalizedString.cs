namespace CSharpCommon.Localization {
    public class LocalizedString
    {
        public LocalizedString(string neutralValue, string localizedValue) {
            NeutralValue = neutralValue;
            LocalizedValue = localizedValue;
        }

        public string NeutralValue { get; set; }
        public string LocalizedValue { get; set; }
    }
}
