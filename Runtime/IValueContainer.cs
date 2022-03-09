namespace Variables
{
    public interface IValueContainer<T>
    {
        void SetValue(T value);
        T GetValue();
    }
}