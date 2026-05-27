using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

public abstract class BaseTests<T> where T : class, new()
{
    protected T obj = null!;

    public virtual void Initialize()
    {
        obj = new T();
    }

    protected static void areEqual<TValue>(TValue expected, TValue actual)
    {
        Assert.AreEqual(expected, actual);
    }

    protected static void areSame(object? expected, object? actual)
    {
        Assert.AreSame(expected, actual);
    }
}
