namespace RestaurantManagement.Application.BusinessLogic
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice(SalesHeader salesHeader, int discount);
    }
}
