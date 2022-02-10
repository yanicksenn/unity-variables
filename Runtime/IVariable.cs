namespace CraipaiGames.Variables
{
    public interface IVariable<T>
    {
        T Value { get; set; }
    }
}