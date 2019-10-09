using Domain.Repositories;
using System.Threading.Tasks;

namespace Domain.PizzaCompany
{
    internal sealed class PizzaMenuBekijkenInteractor : IPizzaMenuBekijkenUseCase
    {
        private readonly IReadRepository<Pizza> pizzasReposiory;

        public PizzaMenuBekijkenInteractor(IReadRepository<Pizza> pizzasReposiory)
        {
            this.pizzasReposiory = pizzasReposiory;
        }

        public async Task<PizzaMenuBekijkenOutput> ExecuteAsync(PizzaMenuBekijkenInput input)
        {
            var pizzas = await pizzasReposiory.GetAllAsync();

            return new PizzaMenuBekijkenOutput(pizzas);
        }
    }
}
