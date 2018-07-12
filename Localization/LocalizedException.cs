using System;

namespace NoNameDev.CSharpCommon.Localization {
    public class LocalizedException : Exception
    {
        public string LocalizedMessage { get; }
        public LocalizedString LocalizedString { get; }

        public LocalizedException(string message) : base(message) {
            
        }

        public LocalizedException(string message, Exception ex) : base(message, ex) {

        }

        public LocalizedException(LocalizedString localizedMessage) : base(localizedMessage.NeutralValue) {
            LocalizedString = localizedMessage;
            LocalizedMessage = localizedMessage.LocalizedValue;
        }

        public LocalizedException(LocalizedString localizedMessage, Exception ex) : base(localizedMessage.NeutralValue, ex) {
            LocalizedString = localizedMessage;
            LocalizedMessage = localizedMessage.LocalizedValue;
        }

        #region Test-Related Definitions

        protected LocalizedException() : base() { }

        #endregion
    }
}
