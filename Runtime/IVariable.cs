namespace Variables
{
    public interface IVariable<T>
    {
        T Value { get; set; }

        void SetValue(T value);
        T GetValue();
    }
}