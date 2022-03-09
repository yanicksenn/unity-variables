namespace Variables
{
    public interface IVariable<T>
    {
        void SetValue(T value);
        T GetValue();
    }
}