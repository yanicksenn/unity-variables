using Variables.Bools;

namespace Variables.unity_variables.Runtime
{
    /// <summary>
    /// Definition of all boolean operations.
    /// </summary>
    public interface IBoolOperations : IInvertible
    {
        /// <summary>
        /// Sets the current value to true.
        /// </summary>
        void True();
        
        /// <summary>
        /// Sets the current value to false.
        /// </summary>
        void False();
    }
}