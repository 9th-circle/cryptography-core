namespace Cryptography.Interfaces.Primitives
{
    /// <summary>
    /// Interface to any cryptographic primitive or a construction that uses them.
    /// </summary>
    public interface IPrimitive
    {
        /// <summary> What is the common name of the cryptographic primitive? </summary>
        public string primitiveName { get; }
        /// <summary> Which version of the cryptographic primitive are we using? </summary>
        public string primitiveVariation { get; }
        /// <summary> Where did we get the implementation from? Which library? </summary>
        public string implementationName { get; }
    }
}