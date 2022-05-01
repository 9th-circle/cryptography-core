namespace Cryptography.Interfaces
{
    public interface IPrimitive
    {
        public string primitiveName { get; }
        public string primitiveVariation { get; }
        public string implementationName { get; }
    }
}