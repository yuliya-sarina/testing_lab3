using System;

namespace sharpLab3
{
    /// <summary>
    /// Класс Полезное ископаемое
    /// </summary>
    class Fossil
    {
        /// <summary>
        /// Переменная - вес в граммах
        /// </summary>
        private int Weight;
        /// <summary>
        /// Переменная - цена за грамм
        /// </summary>
        private int Price;
        /// <summary>
        /// Иницилизируем класс Fossil
        /// </ummary>
        /// <param name="Weight">Вес в гр.</param>
        /// <param name="Price">Цена за гр.</param>
        public void Init(int W, int P)
        {
            Weight = W;
            Price = P;
        }
        /// <summary>
        /// Метод для ввода веса и цены за грамм
        /// </summary>
        public void Read()
        {
            Console.Write("Введите вес: ");
            Weight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите цену за грамм: ");
            Price = Convert.ToInt32(Console.ReadLine());
        }
        /// <summary>
        /// Метод, демонстрирующий вес ископаемого и цену за гр.
        /// </summary>
        public void Display()
        {
            Console.Write("Вес ископаемого = " + Weight + "\nЦена за грамм: " + Price);
        }
        /// <summary>
        /// Метод, возвращающий общую стоимость ископаемого
        /// </summary>
        /// \f$Cost = Weight * Price \f$
        /// <returns>Возвращает стоимость ископаемого</returns>
        public int Cost()
        {
            int cost = Weight * Price;
            return cost;
        }
    }
    /// <summary>
    /// Примеси в ископаемом. Класс наследуется от Fossil
    /// inherit Fossil
    /// </summary>
    class Admixture : Fossil
    {
        /// <summary>
        /// Переменная - процент примесей
        /// </summary>
        private int percent;
        /// <summary>
        /// Иницилизируем класс Admixture
        /// </summary>
        /// <param name="percent">Процент примесей</param>
        /// <param name="price">Цена за гр.</param>
        /// <param name="weight">Вес</param>
        public void Init(int percent, int weight, int price)
        {
            base.Init(weight, price);
            this.percent = percent;
        }
        /// <summary>
        /// Метод, Демонстрирующий процент примесей в ископаемом
        /// </summary>
        public void DisplayCost()
        {
            System.Console.WriteLine("Процент примесей в ископаемом равен: " + percent);
        }
        /// <summary>
        /// Метод, расчитывающий стоимость ископаемого с примесями
        /// </summary>
        public double TotalCost()
        {
            int cost = Cost();
            return cost - percent;
        }

    }
/// <summary>
/// Класс Рудник с полезными ископаемыми
/// </summary>
class Mine
    {
        /// <summary>
        /// Первое ископаемое
        /// </summary>
        private Fossil M1 = new Fossil();
        /// <summary>
        /// Второе ископаемое
        /// </summary>
        private Fossil M2 = new Fossil();
        /// <summary>
        /// Третье ископаемое
        /// </summary>
        private Fossil M3 = new Fossil();
        /// <summary>
        /// Затраты
        /// </summary>
        private int Expenses;

        /// <summary>
        /// Инициализация класса Mine
        /// </summary>
        /// <param name="W1">Вес(Полезное ископаемое 1)</param>
        /// <param name="P1">Цена(Полезное ископаемое 1)</param>
        /// ![Image](../images/Fossil.jpg)
        /// 
        /// <param name="W2">Вес(Полезное ископаемое 2)</param>
        /// <param name="P2">Цена(Полезное ископаемое 2)</param>
        /// <param name="W3">Вес(Полезное ископаемое 3)</param>
        /// <param name="P3">Цена(Полезное ископаемое 3)</param>
        public void Init(int W1, int P1, int W2, int P2, int W3, int P3, int E)
        {
            M1.Init(W1, P1);
            M2.Init(W2, P2);
            M3.Init(W3, P3);
            Expenses = E;
        }
        /// <summary>
        /// Метод для ввода веса и цены за грамм для искомаемых и общих затрат
        /// </summary>
        public void Read()
        {
            Console.WriteLine("Заполните данные о первом ископаемом.");
            M1.Read();
            Console.WriteLine("Заполните данные о втором ископаемом.");
            M2.Read();
            Console.WriteLine("Заполните данные о третьем ископаемом.");
            M3.Read();
            Console.Write("Введите количество затрат: ");
            Expenses = Convert.ToInt32(Console.ReadLine());
        }
        /// <summary>
        /// Метод, демонстрирующий  данные об искомаемых и общие затраты
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Данные о первом ископаемом:");
            M1.Display();
            Console.WriteLine("Данные о втором ископаемом:");
            M2.Display();
            Console.WriteLine("Данные о третьем ископаемом:");
            M3.Display();
            Console.WriteLine("Затраты на добычу: " + Expenses);
        }
        /// <summary>
        /// Метод, возвращающий доходность рудника, равную стоимости всего добытого минус затраты 
        /// </summary>
        public int Cost()
        {
            return M1.Cost() + M2.Cost() + M3.Cost() - Expenses;
        }
        /// <summary>
        /// Метод, возвращающий самое ценное полезное ископаемое из трех 
        /// </summary>
        public Fossil Expensive()
        {
            if (M1.Cost() > M2.Cost())
                return M1;
            else if (M2.Cost() > M3.Cost())
                return M2;
            else return M3;
        }
    }
     
    /// <summary>
    /// класс Program Иницилизация проекта
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Публичный метод Main иницилизирующий программу
        /// </summary>
        static void Main(string[] args)
        {
            //три полезных ископаемых
            Fossil fos1, fos2, fos3;
            Console.WriteLine("\nFossil 1");
            fos1 = new Fossil();
            fos1.Init(0, 0);
            fos1.Read();
            Console.WriteLine("\nFossil 2");
            fos2 = new Fossil();
            fos2.Init(0, 0);
            fos2.Read();
            Console.WriteLine("\nFossil 3");
            fos3 = new Fossil();
            fos3.Init(0, 0);
            fos3.Read();

            Console.WriteLine("\nFossil 1");
            fos1.Display();
            Console.WriteLine("Cost: " + fos1.Cost());
            Console.WriteLine("\nFossil 2");
            fos2.Display();
            Console.WriteLine("Cost: " + fos2.Cost());
            Console.WriteLine("\nFossil 3");
            fos3.Display();
            Console.WriteLine("Cost: " + fos3.Cost());

            Console.WriteLine("\n- Mine -\n");//Рудник с новыми ископаемыми
            Mine mine1 = new Mine();

            mine1.Init(0, 0, 0, 0, 0, 0, 0);
            mine1.Read();
            mine1.Display();
            
            Console.WriteLine("\nMine profitability: " + mine1.Cost());
            Console.WriteLine("\nMost expensive fossil of mine: " + mine1.Expensive());

        }
    }
}
