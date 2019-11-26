using System;
using System.Collections.Generic;
using System.Linq;

namespace JoinLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var rateList = GetRateList();
            var currencyList = GetCurrencyList();

            var rates = from rate in rateList
                        join baseCurrency in currencyList on rate.BaseCurrencyId equals baseCurrency.Id 
                        join quoteCurrency in currencyList on rate.QuoteCurrencyId  equals quoteCurrency.Id
                        select new Rate(rate.Id, rate.BaseCurrencyId, rate.QuoteCurrencyId, rate.Value)
                        {
                            BaseCurrency = baseCurrency,
                            QuoteCurrency = quoteCurrency
                        };

            Console.WriteLine($"Qty : {rates.Count()}");

            foreach(var rate in rates)
            {
                Console.WriteLine($"{rate.ToString()}");
            }

            Console.WriteLine(new String('*', 100));

            var rates2 = rateList.Join(currencyList,
                            rate => rate.BaseCurrencyId,
                            currency => currency.Id,
                            (rate, currency) => new Rate(rate.Id, rate.BaseCurrencyId, rate.QuoteCurrencyId, rate.Value)
                            {
                                BaseCurrency = currency
                            }
                        ).Join(currencyList,
                            r => r.QuoteCurrencyId,
                            c => c.Id,
                            (r, c) => new  Rate(r.Id, r.BaseCurrencyId, r.QuoteCurrencyId, r.Value)
                            {
                                BaseCurrency = r.BaseCurrency,
                                QuoteCurrency = c
                            }   
                        );
                        
                        
            foreach(var rate in rates2)
            {
                Console.WriteLine($"{rate.ToString()}");
            }

            Console.WriteLine("That's all folk!");
        }

        private static IList<Currency> GetCurrencyList()
        {
            return new List<Currency>()
            {
                new Currency(1,"Euro", "EUR"),
                new Currency(2, "Dollar US", "USD"),
                new Currency(3, "Livre Sterling", "GBP"),
                new Currency(4, "Franc Suisse", "CHF")        
            };
        }

        private static IList<Rate> GetRateList()
        {
            return new List<Rate>()
            {
                new Rate(1, 1, 2, 1.10),
                new Rate(2, 1,3, 0.86),
                new Rate(3, 1,4, 1.10)
            };
        }
    }
}
