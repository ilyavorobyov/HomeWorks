internal class Program
{
    static void Main(string[] args)
    {
        var orderForm = new OrderForm();
        IPay[] paymentSystems = { new QIWI(), new WebMoney(), new Card() };
        orderForm.ShowForm(paymentSystems);
    }
}

public class OrderForm
{
    public void ShowForm(IPay[] paymentSystems)
    {
        Console.WriteLine("Мы принимаем:");

        foreach (var paymentSystem in paymentSystems)
        {
            Console.WriteLine(paymentSystem.ToString());
        }

        Console.WriteLine("Какой системой вы хотите совершить оплату?");
        string userInput = Console.ReadLine();

        foreach (var paymentSystem in paymentSystems)
        {
            if (userInput == paymentSystem.ToString())
            {
                paymentSystem.Request();
                paymentSystem.ShowResult(paymentSystem.ToString());
            }
        }
    }
}

public interface IPay
{
    public void Request();

    public void ShowResult(string paySystem)
    {
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