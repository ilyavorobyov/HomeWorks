using System;
using System.Security.Cryptography;
using System.Text;

namespace PaymentSystemsNapilnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order(250, 5);
            IPaymentSystem firstPaymentSystem = new FirstPaymentSystem();
            IPaymentSystem secondPaymentSystem = new SecondPaymentSystem();
            IPaymentSystem thirdPaymentSystem = new ThirdPaymentSystem();
            string firstLink = firstPaymentSystem.GetPayingLink(order);
            string secondLink = secondPaymentSystem.GetPayingLink(order);
            string thirdLink = thirdPaymentSystem.GetPayingLink(order);
            Console.WriteLine(firstLink);
            Console.WriteLine(secondLink);
            Console.WriteLine(thirdLink);
        }
    }

    public class Order
    {
        public readonly int Id;
        public readonly int Amount;

        public Order(int id, int amount) => (Id, Amount) = (id, amount);
    }

    public class FirstPaymentSystem : IPaymentSystem
    {
        private const string LinkPrefix = "pay.system1.ru/order?amount=12000RUB&hash=";

        public virtual string GetPayingLink(Order order)
        {
            string hash = GetHash(order.Id.ToString());
            return LinkPrefix + hash;
        }

        protected string GetHash(string orderDetails)
        {
            using (MD5 md5 = MD5.Create())
            {
                StringBuilder hashText = new StringBuilder();
                byte[] inputBytes = Encoding.UTF8.GetBytes(orderDetails);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    hashText.Append(hashBytes[i].ToString("X2"));
                }

                return hashText.ToString();
            }
        }
    }

    public class SecondPaymentSystem : FirstPaymentSystem
    {
        private const string LinkPrefix = "order.system2.ru/pay?hash=";

        public override string GetPayingLink(Order order)
        {
            string hash = GetHash(order.Id.ToString() + order.Amount.ToString());
            return LinkPrefix + hash;
        }
    }

    public class ThirdPaymentSystem : IPaymentSystem
    {
        private const string LinkPrefix = "system3.com/pay?amount=12000&curency=RUB&hash=";
        private const string SecretKey = "74619";

        public string GetPayingLink(Order order)
        {
            string hash = GetShaHash(order.Id.ToString() + order.Amount.ToString() + SecretKey);
            return LinkPrefix + hash;
        }

        private string GetShaHash(string input)
        {
            using (SHA1 sha = SHA1.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha.ComputeHash(inputBytes);

                StringBuilder shaText = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    shaText.Append(hashBytes[i].ToString("x2"));
                }

                return shaText.ToString();
            }
        }
    }

    public interface IPaymentSystem
    {
        string GetPayingLink(Order order);
    }
}