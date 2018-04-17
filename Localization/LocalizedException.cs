using System;

namespace Common.Utils.Localization {
    public class LocalizedException : Exception
    {
        public string LocalizedMessage { get; }
        public LocalizedString LocalizedString { get; }

        public LocalizedException(string message) : base(message) {
            
        }

        public LocalizedException(string message, Exception ex) : base(message, ex) {

        }

        public LocalizedException(LocalizedString localizedMessage) : base(localizedMessage.DefaultValue) {
            LocalizedString = localizedMessage;
            LocalizedMessage = localizedMessage.LocalizedValue;
        }

        public LocalizedException(LocalizedString localizedMessage, Exception ex) : base(localizedMessage.DefaultValue, ex) {
            LocalizedString = localizedMessage;
            LocalizedMessage = localizedMessage.LocalizedValue;
        }

        #region Test-related members

        protected LocalizedException() : base() { }

        #endregion
    }
}
