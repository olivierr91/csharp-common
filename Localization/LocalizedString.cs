﻿namespace NoNameDev.CSharpCommon.Localization {

    public class LocalizedString {

        public LocalizedString(string neutralValue, string localizedValue) {
            NeutralValue = neutralValue;
            LocalizedValue = localizedValue;
        }

        public string LocalizedValue { get; set; }
        public string NeutralValue { get; set; }
    }
}