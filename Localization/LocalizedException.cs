using System;

namespace CSharpCommon.Localization {

    public class LocalizedException : Exception {

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

        public string LocalizedMessage { get; }
        public LocalizedString LocalizedString { get; }

        #region Test-Related Definitions

        protected LocalizedException() : base() {
        }

        #endregion Test-Related Definitions
    }
}