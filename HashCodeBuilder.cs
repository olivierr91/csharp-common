namespace NoNameDev.CSharpCommon {

    public sealed class HashCodeBuilder {
        private int _hash = 17;

        public HashCodeBuilder Add(int value) {
            unchecked {
                _hash = _hash * 31 + value;
            }
            return this;
        }

        public HashCodeBuilder Add(object value) {
            return Add(value?.GetHashCode() ?? 0);
        }

        public override int GetHashCode() {
            return _hash;
        }
    }
}