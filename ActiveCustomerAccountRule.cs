using System;
using NRules.Fluent.Dsl;
using NRules;

namespace simplerules
{
    public class ActiveCustomerAccountRule : Rule
    {
        public override void Define()
        {
            Customer customer = null;
            Account account = null;

            When()
                .Match<Customer>(() => customer, c => c.IsPreferred)
                .Match<Account>(() => account, a => a.Owner == customer, a => a.IsActive);

            Then()
                .Do(ctx =>
                    Console.WriteLine("Customer {0} has active account #{1}",
                        customer.Name, account.AccountNumber));
        }
    }
}