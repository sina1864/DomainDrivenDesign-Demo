using Clean_arch.Domain.Shared;
using Clean_arch.Domain.Shared.Exceptions;
using Clean_arch.Domain.Test.Unit.Builders;
using FluentAssertions;
using System;
using Xunit;

namespace Clean_arch.Domain.Test.Unit.ProductAgg;

public class ProductTests
{
    private ProductBuilder _productBuilder;
    public ProductTests()
    {
        _productBuilder = new ProductBuilder();
    }

    [Fact]
    public void Constructor_Should_Create_Product_when_Data_Is_Ok()
    {
        _productBuilder.SetTitle("test2").SetMoney(1000);

        var product = _productBuilder.Build();

        product.Title.Should().Be("test2");
    }

    [Fact]
    public void Constructor_Should_Throw_NullOrEmptyException_when_Title_isNull()
    {
        var action = new Action(() =>
        {
            _productBuilder.SetTitle("").Build();
        });

        action.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("title is null or empty");
    }

    [Fact]
    public void Edit_Should_Update_Product_when_Data_Is_Ok()
    {
        var product = _productBuilder.SetTitle("test2").SetMoney(1000).Build();

        product.Edit("edited", new Money(10000000), "das");

        product.Title.Should().Be("edited");
        product.Money.RialValue.Should().Be(10000000);
    }

    [Fact]
    public void Edit_Should_Throw_NullOrEmptyException_when_Title_isNull()
    {
        var product = _productBuilder.SetTitle("test2").SetMoney(1000).Build();

        var action = () =>
        {
            product.Edit("", new Money(10000000), "ads");
        };

        action.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("title is null or empty");
    }

    [Fact]
    public void AddImage_Should_Add_New_Image_To_Product()
    {
        var product = _productBuilder.SetTitle("test2").SetMoney(1000).Build();

        product.AddImage("test.png");

        product.Images.Should().HaveCount(1);
    }

    [Fact]
    public void RemoveImage_Should_Remove_Image_When_Image_Is_Exist()
    {
        var product = _productBuilder.SetTitle("test2").SetMoney(1000).Build();
        product.AddImage("test.png");

        product.RemoveImage(0);

        product.Images.Should().HaveCount(0);
    }

    [Fact]
    public void RemoveImage_Should_Throw_NullOrEmptyException_When_Image_Is_Not_Exist()
    {
        var product = _productBuilder.SetTitle("test2").SetMoney(1000).Build();

        var action = () => product.RemoveImage(0);

        action.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("Image not found");
    }
}