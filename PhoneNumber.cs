using Common.Utils.Extensions;
using Common.Utils;
using System;

namespace SitkaWebApp.Server.Core.Domain.Contact {
    public class PhoneNumber
    {
        public PhoneNumber(string number, string extension = null) {
            Number = number;
            Extension = extension;
        }
        public string Number { get; set; }
        public string Extension { get; set; }

        public override bool Equals(Object obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;

            PhoneNumber _obj = (PhoneNumber)obj;
            return String.Equals(Number, _obj.Number, StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(Extension, _obj.Extension, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode() {
            return new HashCodeBuilder()
                .Add(Number?.ToLower())
                .Add(Extension?.ToLower()).GetHashCode();
        }

        public override string ToString() {
            string str = "";
            str = str.Append(Number);
            str = str.Append(Extension, " ");
            return str;
        }
    }
}
