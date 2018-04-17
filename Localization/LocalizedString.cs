namespace Common.Utils.Localization {
    public class LocalizedString
    {
        public LocalizedString(string defaultValue, string localizedValue) {
            DefaultValue = defaultValue;
            LocalizedValue = localizedValue;
        }

        public string DefaultValue { get; set; }
        public string LocalizedValue { get; set; }
    }
}
