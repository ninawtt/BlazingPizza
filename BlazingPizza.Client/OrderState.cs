using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza.Client
{
    public class OrderState
    {
        public bool ShowingConfigureDialog { get; private set; }
        public Pizza ConfiguringPizza { get; private set; }
        public Order Order { get; private set; } = new Order();
        private ConfigurePizzaAction action = ConfigurePizzaAction.Add;

        public void ShowConfigurePizzaDialog(PizzaSpecial special)
        {
            ConfiguringPizza = new Pizza()
            {
                Special = special,
                SpecialId = special.Id,
                Size = Pizza.DefaultSize,
                Toppings = new List<PizzaTopping>(),
            };

            ShowingConfigureDialog = true;
        }

        public void CancelConfigurePizzaDialog()
        {
            ConfiguringPizza = null;
            ShowingConfigureDialog = false;
        }

        public void ConfirmConfigurePizzaDialog()
        {
            if (action == ConfigurePizzaAction.Add)
            {
                Order.Pizzas.Add(ConfiguringPizza);
            }

            ConfiguringPizza = null;
            ShowingConfigureDialog = false;
            action = ConfigurePizzaAction.Add; // Reset to the default value (Add)
        }

        public void RemoveConfiguredPizza(Pizza pizza)
        {
            Order.Pizzas.Remove(pizza);
        }

        public void EditConfiguredPizza(Pizza pizza)
        {
            action = ConfigurePizzaAction.Edit;

            ConfiguringPizza = new Pizza()
            {
                Special = pizza.Special,
                SpecialId = pizza.Id,
                Size = pizza.Size,
                Toppings = pizza.Toppings,
            };

            ShowingConfigureDialog = true;
        }

        public void ResetOrder()
        {
            Order = new Order();
        }

        public void ReplaceOrder(Order order)
        {
            Order = order;
        }

    }

    enum ConfigurePizzaAction
    {
        Add,
        Edit
    }
}
