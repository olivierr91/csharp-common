using CSharpCommon.Utils.Extensions;
using CSharpCommon.Utils;
using System;

namespace CSharpCommon.Utils {
    public class Geolocation {
        private string _addressLine1;
        private string _addressLine2;
        private string _city;
        private string _postCode;
        private string _regionName;
        private string _regionCode;
        private string _countryName;
        private string _twoLetterTwoLetterCountryCode;

        public Geolocation(string twoLetterCountryCode = null, string countryName = null, string regionCode = null, string regionName = null, string city = null, string postCode = null, string addressLine1 = null, string addressLine2 = null) {
            _addressLine1 = addressLine1;
            _addressLine2 = addressLine2;
            _postCode = postCode;
            _city = city;
            _regionName = regionName;
            _regionCode = regionCode;
            _countryName = countryName;
            _twoLetterTwoLetterCountryCode = twoLetterCountryCode;
        }

        public string AddressLine1 { get => _addressLine1; }
        public string AddressLine2 { get => _addressLine2; }
        public string City { get => _city; }
        public string PostCode { get => _postCode; }
        public string RegionName { get => _regionName; }
        public string RegionCode { get => _regionCode; }
        public string CountryName { get => _countryName; }
        public string TwoLetterCountryCode { get => _twoLetterTwoLetterCountryCode; }

        public override bool Equals(Object obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Geolocation _obj = (Geolocation)obj;
            return String.Equals(AddressLine1, _obj.AddressLine1, StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(AddressLine2, _obj.AddressLine2, StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(City, _obj.City, StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(PostCode, _obj.PostCode, StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(RegionName, _obj.RegionName, StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(RegionCode, _obj.RegionCode, StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(CountryName, _obj.CountryName, StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(TwoLetterCountryCode, _obj.TwoLetterCountryCode, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode() {
            return new HashCodeBuilder().Add(AddressLine1.ToLower())
                .Add(AddressLine2?.ToLower())
                .Add(City?.ToLower())
                .Add(PostCode?.ToLower())
                .Add(RegionName?.ToLower())
                .Add(RegionCode?.ToLower())
                .Add(CountryName?.ToLower())
                .Add(TwoLetterCountryCode?.ToLower()).GetHashCode();
        }

        public override string ToString() {
            string str = "";
            if (CountryName != null) {
                str = str.Append(CountryName, ", ");
            } else {
                str = str.Append(TwoLetterCountryCode, ", ");
            }
            if (RegionName != null) {
                str = str.Append(RegionName, ", ");
            } else {
                str = str.Append(RegionCode, ", ");
            }
            str = str.Append(PostCode, ", ");
            str = str.Append(City, ", ");
            str = str.Append(AddressLine2, ", ");
            str = str.Append(AddressLine1, ", ");
            return str;
        }
    }
}
