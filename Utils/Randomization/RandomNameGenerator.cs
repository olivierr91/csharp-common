using CSharpCommon.Extensions.Collections;
using CSharpCommon.Utils.Resources;
using System;
using System.Collections.Generic;

namespace CSharpCommon.Utils.Randomization
{
    public class RandomNameGenerator
    {
        private const string CITY_NAMES_FILE_NAME = "CityNames";
        private const string COMPANY_NAMES_FILE_NAME = "CompanyNames";
        private const string FIRST_NAMES_FILE_NAME = "FirstNames";
        private const string LAST_NAMES_FILE_NAME = "LastNames";
        private const string STREET_NAMES_FILE_NAME = "StreetNames";
        private const string STREET_TYPES_FILE_NAME = "StreetTypes";

        private Dictionary<string, List<string>> wordBags = new Dictionary<string, List<string>>();

        private void Prepare(string bagResourceName) {
            if (!wordBags.ContainsKey(bagResourceName)) {
                var bagContent = ResourceUtils.GetString(this, bagResourceName);
                wordBags.Add(bagResourceName, new List<string>(bagContent.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries)));
            }
        }

        public string RandomCityName() {
            Prepare(CITY_NAMES_FILE_NAME);
            return wordBags[CITY_NAMES_FILE_NAME].RandomElement();
        }

        public string RandomCompanyName() {
            Prepare(COMPANY_NAMES_FILE_NAME);
            return $"{wordBags[COMPANY_NAMES_FILE_NAME].RandomElement()} {wordBags[COMPANY_NAMES_FILE_NAME].RandomElement()}";
        }

        public string RandomFirstName() {
            Prepare(FIRST_NAMES_FILE_NAME);
            return wordBags[FIRST_NAMES_FILE_NAME].RandomElement();
        }

        public string RandomLastName() {
            Prepare(LAST_NAMES_FILE_NAME);
            return wordBags[LAST_NAMES_FILE_NAME].RandomElement();
        }

        public string RandomStreetAddressLine() {
            Prepare(STREET_NAMES_FILE_NAME);
            Prepare(STREET_TYPES_FILE_NAME);
            return $"{RandomUtils.RandomInt(0, 999)} {RandomStreetName()}";
        }

        public string RandomStreetName() {
            Prepare(STREET_NAMES_FILE_NAME);
            Prepare(STREET_TYPES_FILE_NAME);
            return wordBags[STREET_TYPES_FILE_NAME].RandomElement();
        }
    }
}
