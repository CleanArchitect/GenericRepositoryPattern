using Data.EntityFrameworkCore;
using Domain.PizzaCompany;
using Microsoft.EntityFrameworkCore;

namespace Data.PizzaCompany
{
    internal sealed class PizzaCompanyDataContext : BaseEfDbContext
    {
        internal DbSet<Klant> Klanten { get; private set; }
        internal DbSet<Pizza> Pizzas { get; private set; }
        internal DbSet<Bestelling> Bestellingen { get; private set; }

        public PizzaCompanyDataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
