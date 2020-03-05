using System;

namespace CommandPattern
{
    public enum PriceAction //Kan bara välja mellan Increase och Decrease.
    {
        Increase,
        Decrease
    }
    class Program
    {
        static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("Phone", 500); //Ny telefon med startpris 500kr.

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 50));

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 25));

            Console.WriteLine(product);
            modifyPrice.UndoActions();
            Console.WriteLine(product);
            Console.ReadLine();
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }

}