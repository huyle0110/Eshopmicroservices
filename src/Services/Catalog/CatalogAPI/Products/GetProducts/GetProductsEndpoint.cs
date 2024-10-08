﻿using CatalogAPI.Models;

namespace CatalogAPI.Products.GetProducts
{

    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result  = await sender.Send(new GetProductsQuery());

                var response = result.Adapt<GetProductsResponse>();
            })
            .WithName("GetProducts");
        }
    }
}
