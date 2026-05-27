using Domain.Restaurant.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Interfaces;

[TestClass]
public class IInventoryServiceTests : TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(IInventoryService);

    [TestMethod] public void IsInterfaceTest() => areEqual(true, type.IsInterface);
    [TestMethod] public void NameTest() => areEqual("IInventoryService", type.Name);
    [TestMethod] public void NamespaceTest() => areEqual("Domain.Restaurant.Interfaces", type.Namespace);
    [TestMethod] public void MethodCountTest() => areEqual(4, type.GetMethods().Length);

    [TestMethod] public void GetIngredientsAsyncTest() => areEqual(true, hasMethod("GetIngredientsAsync"));
    [TestMethod] public void AddIngredientAsyncTest() => areEqual(true, hasMethod("AddIngredientAsync"));
    [TestMethod] public void UpdateIngredientAsyncTest() => areEqual(true, hasMethod("UpdateIngredientAsync"));
    [TestMethod] public void DeleteIngredientAsyncTest() => areEqual(true, hasMethod("DeleteIngredientAsync"));

    private bool hasMethod(string name)
    {
        var methods = type.GetMethods();
        for (var i = 0; i < methods.Length; i++)
            if (methods[i].Name == name) return true;
        return false;
    }
}
