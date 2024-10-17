using System;

namespace ArrayOperations
{
    class IntArrayClass
    {
        // Поле для хранения массива
        private int[] IntArray;

        // Конструктор для создания массива заданной размерности
        public IntArrayClass(int n)
        {
            IntArray = new int[n];
        }

        // Свойство, возвращающее размер массива (только для чтения)
        public int Length
        {
            get { return IntArray.Length; }
        }

        // Свойство, позволяющее домножить все элементы на скаляр (только для записи)
        public int Scalar
        {
            set
            {
                for (int i = 0; i < IntArray.Length; i++)
                {
                    IntArray[i] *= value;
                }
            }
        }

        // Индексатор для доступа к элементам массива по индексу
        public int this[int index]
        {
            get { return IntArray[index]; }
            set { IntArray[index] = value; }
        }

        // Метод для ввода элементов массива с клавиатуры
        public void InputArray()
        {
            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < IntArray.Length; i++)
            {
                Console.Write("Элемент [{0}]: ", i);
                IntArray[i] = int.Parse(Console.ReadLine());
            }
        }

        // Метод для вывода элементов массива на экран
        public void OutputArray()
        {
            Console.WriteLine("Элементы массива:");
            for (int i = 0; i < IntArray.Length; i++)
            {
                Console.Write(IntArray[i] + " ");
            }
            Console.WriteLine();
        }

        // Метод для сортировки массива в порядке возрастания
        public void SortArray()
        {
            Array.Sort(IntArray);
        }

        // Перегрузка операции ++: увеличивает каждый элемент массива на 1
        public static IntArrayClass operator ++(IntArrayClass array)
        {
            for (int i = 0; i < array.IntArray.Length; i++)
            {
                array.IntArray[i]++;
            }
            return array;
        }

        // Перегрузка операции --: уменьшает каждый элемент массива на 1
        public static IntArrayClass operator --(IntArrayClass array)
        {
            for (int i = 0; i < array.IntArray.Length; i++)
            {
                array.IntArray[i]--;
            }
            return array;
        }

        // Перегрузка операции !: возвращает true, если массив не упорядочен по возрастанию
        public static bool operator !(IntArrayClass array)
        {
            for (int i = 1; i < array.IntArray.Length; i++)
            {
                if (array.IntArray[i] < array.IntArray[i - 1])
                {
                    return true;
                }
            }
            return false;
        }

        // Перегрузка бинарной операции *: домножает каждый элемент массива на скаляр
        public static IntArrayClass operator *(IntArrayClass array, int scalar)
        {
            for (int i = 0; i < array.IntArray.Length; i++)
            {
                array.IntArray[i] *= scalar;
            }
            return array;
        }

        // Преобразование массива в одномерный массив int[]
        public static implicit operator int[](IntArrayClass array)
        {
            return array.IntArray;
        }

        // Преобразование одномерного массива int[] в IntArrayClass
        public static implicit operator IntArrayClass(int[] array)
        {
            IntArrayClass newArray = new IntArrayClass(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаём массив размерности 5
            IntArrayClass myArray = new IntArrayClass(5);

            // Вводим элементы массива
            myArray.InputArray();

            // Выводим элементы массива на экран
            myArray.OutputArray();

            // Проверка сортировки
            Console.WriteLine("Массив не отсортирован: " + !myArray);

            // Сортировка массива
            myArray.SortArray();

            // Выводим отсортированный массив
            Console.WriteLine("Отсортированный массив:");
            myArray.OutputArray();

            // Проверка сортировки
            Console.WriteLine("Массив не отсортирован: " + !myArray);

            // Увеличиваем все элементы на 1 (++ оператор)
            myArray++;

            Console.WriteLine("Массив после увеличения всех элементов на 1:");
            myArray.OutputArray();

            // Домножаем все элементы на 3
            myArray = myArray * 3;

            Console.WriteLine("Массив после домножения всех элементов на 3:");
            myArray.OutputArray();

            // Пример использования индексатора
            Console.WriteLine("Элемент с индексом 2: " + myArray[2]);

            // Пример преобразования массива в массив int[]
            int[] simpleArray = myArray;
            Console.WriteLine("Преобразованный массив в int[]:");
            foreach (var elem in simpleArray)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();

            // Пример обратного преобразования
            IntArrayClass newArray = simpleArray;
            Console.WriteLine("Массив после преобразования обратно в IntArrayClass:");
            newArray.OutputArray();
        }
    }
}

