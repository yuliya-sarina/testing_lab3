using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpLab2_4
{
	class ювелирное_изделие
	{
		private int вес;
		private int цена_за_грам;
		public void Init(int вес1, int цена1)
		{
			вес = вес1;
			цена_за_грам = цена1;
		}
		void Read()
		{
			Console.Write("введите вес изделия:");
			вес = Convert.ToInt32(Console.ReadLine());
			Console.Write("введите цену изделия:");
			цена_за_грам = Convert.ToInt32(Console.ReadLine());
		}
		public void Display()
		{
			Console.Write("вес изделия= {0} ,цена изделия за грамм= {1} \n", вес, цена_за_грам);
		}
		public int цена_изделия()
		{
			int цена = вес * цена_за_грам;
			return цена;
		}
		public int общая_стоимость()
		{
			return цена_за_грам = цена_за_грам * вес;
		}

	}
	class ювелирный_магазин
	{

		private ювелирное_изделие a = new ювелирное_изделие();
		private ювелирное_изделие b = new ювелирное_изделие();
		private int x;
		private int y;
		public void Init(int v1, int c1, int v2, int c2, int x1, int y1)
		{

			a.Init(v1, c1);
			b.Init(v2, c2);
			x = x1;
			y = y1;
		}
		void Read()
		{
			Console.Write("введите количество 1 изделия:");
			x = Convert.ToInt32(Console.ReadLine());
			Console.Write("введите количество 2 изделия:");
			y = Convert.ToInt32(Console.ReadLine());
		}
		public void Display()
		{
			Console.WriteLine("информация о 1 изделии: количество= {0} ", x);
			a.Display();
			Console.WriteLine("информация о 2 изделии: количество= {0} ", y);
			b.Display();
		}
		public int общая_стоимость()
		{
			return a.цена_изделия() * x + b.цена_изделия() * y;
		}
		public ювелирное_изделие наибольшая_стоимость()
		{
			if (a.цена_изделия() > b.цена_изделия())
			{
				return a;
			}
			else
			{
				return b;
			}
		}
	}
	public abstract class абстрактный_класс
	{
		protected String Fam;
		protected int Year;
		public абстрактный_класс(String f, int y)
		{
			Fam = f;
			Year = y;
		}
		public abstract int Totalобща();
	}
	class производный_абстрактный_класс_one : абстрактный_класс
	{
		protected ювелирный_магазин R1 = new ювелирный_магазин();
		protected ювелирный_магазин R2 = new ювелирный_магазин();
		public производный_абстрактный_класс_one(String f, int y, int v1, int c1, int v2, int c2, int x1, int y1, int v12, int c12, int v22, int c22, int x12, int y12) : base(f, y)
		{
			R1.Init(v1, c1, v2, c2, x1, y1);
			R2.Init(v12, c12, v22, c22, x12, y12);
		}
		public override int Totalобща()  // перегрузка чабстрактной функции
		{
			return R1.общая_стоимость() + R2.общая_стоимость();
		}
	}
	class производный_абстрактный_класс_two : абстрактный_класс
	{
		protected ювелирное_изделие R1 = new ювелирное_изделие();
		protected ювелирное_изделие R2 = new ювелирное_изделие();
		public производный_абстрактный_класс_two(String f, int y, int вес1, int цена1, int вес2, int цена2) : base(f, y)
		{
			R1.Init(вес1, цена1);
			R2.Init(вес2, цена2);
		}
		public override int Totalобща()  // перегрузка чабстрактной функции
		{
			return R1.общая_стоимость() + R2.общая_стоимость();
		}
	}

	class производный_абстрактный_класс_three : абстрактный_класс
	{
		protected ювелирный_магазин R1 = new ювелирный_магазин();
		protected ювелирное_изделие R2 = new ювелирное_изделие();
		public производный_абстрактный_класс_three(String f, int y, int v1, int c1, int v2, int c2, int x1, int y1, int вес1, int цена1) : base(f, y)
		{
			R1.Init(v1, c1, v2, c2, x1, y1);
			R2.Init(вес1, цена1);
		}
		public override int Totalобща()  // перегрузка чабстрактной функции
		{
			return R1.общая_стоимость() + R2.общая_стоимость();
		}
	}
	public abstract class абстрактный_классFactory
	{
		public abstract абстрактный_класс Create(String f, int y);
	}
	public class производный_абстрактный_класс_oneFactory : абстрактный_классFactory
	{
		public override абстрактный_класс Create(String f, int y)
		{
			return new производный_абстрактный_класс_one(f, y, 123, 764, 1265, 1, 634, 12, 123, 764, 1265, 1, 634, 12); // теперь объекты через new создаются здесь, а не в main
		}
	}
	public class производный_абстрактный_класс_twoFactory : абстрактный_классFactory
	{
		public override абстрактный_класс Create(String f, int y)
		{
			return new производный_абстрактный_класс_two(f, y, 634, 12, 5, 12);
		}
	}
	public class производный_абстрактный_класс_threeFactory : абстрактный_классFactory
	{
		public override абстрактный_класс Create(String f, int y)
		{
			return new производный_абстрактный_класс_three(f, y, 123, 764, 1265, 1, 634, 12, 2, 56);
		}
	}


	public class Mavenproject1
	{
		static void Main(string[] args)
		{
			int k, m, n;

			абстрактный_классFactory squareFactory = new производный_абстрактный_класс_oneFactory(); // объект фабричного метода
			абстрактный_класс a = squareFactory.Create("Иванов", 2000); // задание объекта класса Square 

			squareFactory = new производный_абстрактный_класс_twoFactory(); // объект фабричного метода
			абстрактный_класс b = squareFactory.Create("Иванов", 2000); // задание объекта класса Square 

			squareFactory = new производный_абстрактный_класс_threeFactory(); // объект фабричного метода
			абстрактный_класс c = squareFactory.Create("Иванов", 2000); // задание объекта класса Square 
			k = a.Totalобща(); // k=119186856

			m = b.Totalобща(); // m=7668

			n = c.Totalобща(); // n=59593540
			Console.Write("Общая стоимость производных абстрактных классов\n" + k + "\n" + m + "\n" + n + "\n");
		}
	}
}


