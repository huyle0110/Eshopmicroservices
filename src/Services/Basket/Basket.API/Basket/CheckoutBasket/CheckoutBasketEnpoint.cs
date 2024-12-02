
namespace Basket.API.Basket.CheckoutBasket
{
    public record CheckoutBasketRequest(BasketCheckoutDto BasketCheckoutDto);
    public record CheckoutBasketResponse(bool IsSuccess);
    public class CheckoutBasketEnpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<CheckoutBasketCommand>();
                var result = await sender.Send(command);
                var reponse = result.Adapt<CheckoutBasketResponse>();

                return Results.Ok(reponse);
            })
            .WithName("CheckoutBasket")
            .Produces<CheckoutBasketResponse>(StatusCodes.Status201Created)
            .WithSummary("Checkout Basket")
            .WithDescription("Checkout basket")
            ;

        }
    }
}
