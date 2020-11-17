using System;
namespace DataStructureAndAlgorithms.DelegateAndEvent
{
    public class PriceChangedEventArgs : EventArgs
    {
        public readonly decimal lastPrice;
        public readonly decimal newPrice;

        public PriceChangedEventArgs(decimal _lastPrice, decimal _newPrice)
        {
            lastPrice = _lastPrice;
            newPrice = _newPrice;
        }
    }

    public class Stock
    {
        string symbol;
        decimal price;

        public Stock(string _symbol)
        {
            symbol = _symbol;
        }

        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                decimal oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
        }
    }
}
