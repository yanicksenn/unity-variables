using Variables.Bools;

namespace Variables.unity_variables.Runtime
{
    /// <summary>
    /// Definition of an math operations.
    /// </summary>
    public interface IMathOperations<T> : IInvertible, IVariable<T>
    {
        /// <summary>
        /// Increments the current value.
        /// </summary>
        void Inc();

        /// <summary>
        /// Decrements the current value.
        /// </summary>
        void Dec();

        /// <summary>
        /// Adds the provided value to the current value.
        /// </summary>
        /// <param name="value">Value</param>
        void Add(T value);

        /// <summary>
        /// Subtracts the provided value from the current value.
        /// </summary>
        /// <param name="value">Value</param>
        void Sub(T value);

        /// <summary>
        /// Multiplies the current value with the provided value.
        /// </summary>
        /// <param name="value">Value</param>
        void Mul(T value);

        /// <summary>
        /// Divides the current value by the provided value.
        /// </summary>
        /// <param name="value">Value</param>
        void Div(T value);
    }
}