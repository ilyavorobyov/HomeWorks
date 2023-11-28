
namespace ConsoleApp72
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orderForm = new OrderForm();
            var identifier = new PaymentSystemIdentifier();
            var paySystem = orderForm.ShowForm();
            IPay paymented = identifier.Define(paySystem);
            paymented.Request();
            paymented.ShowResult(paySystem);
        }
    }

    public class OrderForm
    {
        public string ShowForm()
        {
            Console.WriteLine("Мы принимаем: QIWI, WebMoney, Card");
            Console.WriteLine("Какое системой вы хотите совершить оплату?");
            return Console.ReadLine();
        }
    }

    public interface IPay
    {
        public void Request();

        public void ShowResult(string paySystem)
        {
            Console.WriteLine($"Проверка платежа через {paySystem}...");
            Console.WriteLine($"Вы оплатили с помощью {paySystem}");
            Console.WriteLine("Оплата прошла успешно!");
        }
    }

    public class QIWI : IPay
    {
        public void Request()
        {
            Console.WriteLine("Проверка платежа через QIWI...");
        }
    }

    public class WebMoney : IPay
    {
        public void Request()
        {
            Console.WriteLine("Проверка платежа через WebMoney...");
        }
    }

    public class Card : IPay
    {
        public void Request()
        {
            Console.WriteLine("Проверка платежа через Card...");
        }
    }

    public class PaymentSystemIdentifier
    {
        public IPay Define(string paySystem)
        {
            if (paySystem == "QIWI")
                return new QIWI();
            else if (paySystem == "WebMoney")
                return new WebMoney();
            else if (paySystem == "Card")
                return new Card();
            return null;
        }
    }
}
