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
            HashPaymentSystem hashPaymentSystem = new HashPaymentSystem();

            IPaymentSystem[] _paymentSystems = { new FirstPaymentSystem(hashPaymentSystem),
                new SecondPaymentSystem(hashPaymentSystem), new ThirdPaymentSystem(hashPaymentSystem) };

            foreach (IPaymentSystem paymentSystem in _paymentSystems)
            {
                Console.WriteLine(paymentSystem.GetPayingLink(order));
            }
        }
    }

    public class Order
    {
        private readonly int _id;
        private readonly int _amount;

        public Order(int id, int amount)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException();

            if (amount <= 0)
                throw new ArgumentOutOfRangeException();

            _id = id;
            _amount = amount;
        }

        public int Id => _id;
        public int Amount => _amount;
    }

    public class FirstPaymentSystem : IPaymentSystem
    {
        private const string LinkPrefix = "pay.system1.ru/order?amount=12000RUB&hash=";

        private HashPaymentSystem _paymentSystem;

        public FirstPaymentSystem(HashPaymentSystem paymentSystem)
        {
            if (paymentSystem == null)
                throw new ArgumentNullException();

            _paymentSystem = paymentSystem;
        }

        public virtual string GetPayingLink(Order order)
        {
            string hash = _paymentSystem.GetMD5Hash(order.Id.ToString());
            return LinkPrefix + hash;
        }
    }

    public class SecondPaymentSystem : IPaymentSystem
    {
        private const string LinkPrefix = "order.system2.ru/pay?hash=";

        private HashPaymentSystem _paymentSystem;

        public SecondPaymentSystem(HashPaymentSystem paymentSystem)
        {
            if (paymentSystem == null)
                throw new ArgumentNullException();

            _paymentSystem = paymentSystem;
        }

        public virtual string GetPayingLink(Order order)
        {
            string hash = _paymentSystem.GetMD5Hash(order.Id.ToString() + order.Amount.ToString());
            return LinkPrefix + hash;
        }
    }

    public class ThirdPaymentSystem : IPaymentSystem
    {
        private const string LinkPrefix = "system3.com/pay?amount=12000&curency=RUB&hash=";
        private const string SecretKey = "74619";

        private HashPaymentSystem _paymentSystem;

        public ThirdPaymentSystem(HashPaymentSystem paymentSystem)
        {
            if (paymentSystem == null)
                throw new ArgumentNullException();

            _paymentSystem = paymentSystem;
        }

        public string GetPayingLink(Order order)
        {
            string hash = _paymentSystem.GetShaHash(order.Id.ToString() + order.Amount.ToString() + SecretKey);
            return LinkPrefix + hash;
        }
    }

    public class HashPaymentSystem : IHash
    {
        public string GetMD5Hash(string orderDetails)
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

        public string GetShaHash(string input)
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

    public interface IHash
    {
        string GetMD5Hash(string orderDetails);
        string GetShaHash(string input);
    }
}
