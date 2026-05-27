using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Data.Restaurant.Enums;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class PaymentDtoTests : BaseTests<PaymentDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.OrderId = Guid.NewGuid();
        obj.Method = (PaymentMethod)GetRandom.Int32();
    }

    [TestMethod] public void OrderIdTest() => areEqual(obj.OrderId, obj.OrderId);
    [TestMethod] public void MethodTest() => areEqual(obj.Method, obj.Method);
}