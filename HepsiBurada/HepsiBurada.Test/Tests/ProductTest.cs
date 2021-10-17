﻿using HepsiBurada.Contract.Contracts.Product;
using HepsiBurada.Test.Moqs;
using System.Threading.Tasks;
using Xunit;

namespace HepsiBurada.Test.Tests
{
    public class ProductTest
    {
        [Fact]
        public async Task CREATE_PRODUCT_SUCCES_CASE()
        {
            var result = await ProductMoq.GetProductService()
                .CreateProduct(new ProductContract { ProductCode = "P1", Price = 100, Stock = 1000 });

            Assert.True(result);
        }

        [Fact]
        public async Task CREATE_PRODUCT_NULL_BODY_FAIL_CASE()
        {
            var result = await ProductMoq.GetProductService()
                .CreateProduct(null);

            Assert.False(result);
        }

        [Fact]
        public async Task CREATE_PRODUCT_NULL_PRODUCT_CODE_FAIL_CASE()
        {
            var result = await ProductMoq.GetProductService()
                .CreateProduct(new ProductContract { ProductCode = "", Price = 0, Stock = 0 });

            Assert.False(result);
        }

        [Fact]
        public async Task GET_PRODUCT_INFO_SUCCES_CASE()
        {
            var result = await ProductMoq.GetProductService()
                .GetProductInfo("P1");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GET_PRODUCT_INFO_NULL_PRODUCT_CODE_FAIL_CASE()
        {
            var result = await ProductMoq.GetProductService()
                .GetProductInfo(null);

            Assert.Null(result);
        }

        [Fact]
        public async Task GET_PRODUCT_INFO_EMPTY_PRODUCT_CODE_FAIL_CASE()
        {
            var result = await ProductMoq.GetProductService()
                .GetProductInfo("");

            Assert.Null(result);
        }
    }
}
