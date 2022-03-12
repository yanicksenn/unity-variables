namespace Variables
{
    /// <summary>
    /// Value container holding a generic value.
    /// </summary>
    /// <typeparam name="T">Type of value</typeparam>
    public interface IValueContainer<T>
    {
        /// <summary>
        /// Sets the current value.
        /// </summary>
        /// <param name="newValue">New value</param>
        void SetValue(T newValue);
        
        /// <summary>
        /// Returns the current value.
        /// </summary>
        /// <returns>Current value</returns>
        T GetValue();
    }
}