namespace Data.Restaurant.Tests;

public abstract class BaseTests<T> : TestAids where T : class, new()
{
    protected T obj = null!;

    public virtual void Initialize()
    {
        type = typeof(T);
        obj = new T();
    }
}
