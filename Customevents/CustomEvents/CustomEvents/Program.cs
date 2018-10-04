using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEvents
{
    namespace test
    {    
       class PriceChangedEventArgs : EventArgs
        {
            public readonly decimal LastPrice;
            public readonly decimal NewPrice;

            public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
            {
                LastPrice = lastPrice;
                NewPrice = newPrice;
            }

            public override string ToString()
            {
                return string.Format("Price is changed: Last {0}, New {1}", this.LastPrice, this.NewPrice);
            }
        }

        class MaxPriceReachedEventArgs : EventArgs
        {
            public readonly decimal LastPrice;
            public readonly decimal NewPrice;

            public MaxPriceReachedEventArgs(decimal lastPrice, decimal newPrice)
            {
                LastPrice = lastPrice;
                NewPrice = newPrice;
            }

            public override string ToString()
            {
                return string.Format("MaxPrice Reached: Last {0}, New {1}", this.LastPrice, this.NewPrice);
            }
        }
        class Stock
        {
            decimal price;
            public decimal Price
            {
                get
                {
                    return price;
                }
                set
                {
                    if (price == value) return;
                    decimal oldPrice = price;
                    price = value;
                    OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
                    if(price>=1000)
                    {
                        OnMaxPriceReached(new MaxPriceReachedEventArgs(oldPrice, price));
                    }
                }
            }
            public event EventHandler<PriceChangedEventArgs> PriceChanged;
            public event EventHandler<MaxPriceReachedEventArgs> MaxPriceReached;
            protected virtual void OnPriceChanged(PriceChangedEventArgs e)
            {
                PriceChanged?.Invoke(this, e);
            }
            protected virtual void OnMaxPriceReached(MaxPriceReachedEventArgs e)
            {
                MaxPriceReached?.Invoke(this, e);
            }
        }

        class TestStock
        {
            public void testStock()
            {
                var stock = new Stock();
                stock.PriceChanged += Stock_PriceChanged;
                stock.MaxPriceReached += Stock_MaxPrice;
                stock.Price = 10;
                stock.Price = 11;
                stock.Price = 13;
                stock.Price = 1000;
                stock.Price = 2000;
                stock.Price = 13;
            }

            void Stock_PriceChanged(object sender, PriceChangedEventArgs e)
            {
                Console.WriteLine(e);
            }
            void Stock_MaxPrice(object sender, MaxPriceReachedEventArgs e)
            {
                Console.WriteLine(e);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                new TestStock().testStock();
                Console.ReadKey();
            }
        }
    }

}
