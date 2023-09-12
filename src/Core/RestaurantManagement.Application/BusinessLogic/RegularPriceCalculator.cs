using RestaurantManagement.Domain.Constants;

namespace RestaurantManagement.Application.BusinessLogic
{
    public class RegularPriceCalculator : IPriceCalculator
    {
        #region Fields and Properties
        private readonly IRecipeRepository _recipeRepository;
        #endregion

        #region Constructors
        public RegularPriceCalculator(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
        }
        #endregion

        #region Interface Implementation
        public decimal CalculatePrice(SalesHeader salesHeader, int discount)
        {
            var finalPrice = CalculateSubtotal(salesHeader);
            finalPrice -= discount;
            finalPrice += ApplyVAT(finalPrice);
            return finalPrice;
        }
        #endregion

        #region Helper Methods
        private decimal CalculateSubtotal(SalesHeader salesHeader)
        {
            decimal subtotal = 0;

            foreach (var line in salesHeader.SalesLines!)
            {
                var recipe = GetRecipe(line.RecipeId);

                if (recipe is null)
                    throw new NotFoundException($"Recipe with ID", line.RecipeId);

                decimal basePrice = recipe.InitialPrice;
                decimal sizePrice = GetSizePrice(recipe.Id, (int)line.SizeId!);
                decimal lineDiscount = recipe.Discount ?? 0;

                decimal lineTotal = (basePrice - lineDiscount + sizePrice) * line.Quantity;
                subtotal += lineTotal;
            }

            return subtotal;
        }

        private Recipe? GetRecipe(int recipeId)
        {
            var recipe = _recipeRepository
                .GetAll()
                .Where(r => r.Id == recipeId)
                .SingleOrDefault();
            return recipe;
        }

        private decimal GetSizePrice(int recipeId, int sizeId)
        {
            var sizePrice = _recipeRepository
                    .GetSizesForRecipe(recipeId)
                    .Where(s => s.Id == sizeId)
                    .Select(s => s.Price)
                    .SingleOrDefault();

            return sizePrice;
        }

        private decimal ApplyVAT(decimal amount)
        {
            decimal vatRate = Constants.VAT;
            return amount * vatRate;
        }
        #endregion
    }
}
