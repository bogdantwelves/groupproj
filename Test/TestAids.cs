using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests;

public abstract class TestAids
{
    protected Type type = null!;

    protected static void areEqual<TValue>(TValue expected, TValue actual)
    {
        Assert.AreEqual(expected, actual);
    }

    protected static void areSame(object? expected, object? actual)
    {
        Assert.AreSame(expected, actual);
    }

    protected bool hasMethod(string name)
    {
        var methods = type.GetMethods();
        for (var i = 0; i < methods.Length; i++)
            if (methods[i].Name == name) return true;
        return false;
    }
}
