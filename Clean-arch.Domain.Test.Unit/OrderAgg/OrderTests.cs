using Clean_arch.Domain.OrderAgg.Exceptions;
using Clean_arch.Domain.OrderAgg.Services;
using Clean_arch.Domain.Orders;
using Clean_arch.Domain.Shared.Exceptions;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Clean_arch.Domain.Test.Unit.OrderAgg;

public class OrderTests
{
    [Fact]
    public void Should_Create_Order()
    {
        var order = new Order(1);

        order.UserId.Should().Be(1);
        order.IsFinally.Should().Be(false);
    }

    [Fact]
    public void Should_Finally_Order_And_Add_DomainEvent()
    {
        var order = new Order(1);

        order.Finally();

        order.DomainEvents.Should().HaveCount(1);
    }

    [Fact]
    public void AddItem_Should_Throw_ProductNotFoundException_When_Product_Not_Exist()
    {
        var order = new Order(1);
        var orderDomainService = Substitute.For<IOrderDomainService>();
        orderDomainService.IsProductNotExist(Arg.Any<long>()).Returns(true);

        var res = () => order.AddItem(1, 2, 30000, orderDomainService);

        res.Should().ThrowExactly<ProductNotFoundException>();
    }

    [Fact]
    public void AddItem_Should_Add_New_Item_To_Order()
    {
        var order = new Order(1);
        var orderDomainService = Substitute.For<IOrderDomainService>();
        orderDomainService.IsProductNotExist(Arg.Any<long>()).Returns(false);

        order.AddItem(1, 2, 30000, orderDomainService);

        order.TotalItems.Should().Be(2);
    }

    [Fact]
    public void Should_Not_Add_Item_To_Order_when_Product_Exist_In_Order()
    {
        var order = new Order(1);
        var orderDomainService = Substitute.For<IOrderDomainService>();
        orderDomainService.IsProductNotExist(Arg.Any<long>()).Returns(false);
        order.AddItem(1, 2, 30000, orderDomainService);

        order.AddItem(1, 3, 30000, orderDomainService);

        order.TotalItems.Should().Be(2);
    }

    [Fact]
    public void Remove_item_Should_Throw_InvalidDomainDataException_When_Product_Not_Exist_IN_Order()
    {
        var order = new Order(1);

        var action = () => order.RemoveItem(1);

        action.Should().ThrowExactly<InvalidDomainDataException>();
    }

    [Fact]
    public void Should_Remove_Item_From_Order()
    {
        var order = new Order(1);
        var orderDomainService = Substitute.For<IOrderDomainService>();
        orderDomainService.IsProductNotExist(Arg.Any<long>()).Returns(false);
        order.AddItem(1, 3, 30000, orderDomainService);

        order.RemoveItem(1);

        order.TotalItems.Should().Be(0);
    }
}