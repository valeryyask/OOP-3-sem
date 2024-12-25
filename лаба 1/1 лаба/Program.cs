using System;
using System.Text;
using System.Transactions;

namespace ConsoleApplication1
{
    class FirstLab
    {
        static void Main()
        {

            // Объявление переменных примитивных типов с их инициализацией
            int intValue = 25;                // Целое число
            long longValue = 99999999999999;   // Длинное целое число
            short shortValue = 12000;          // Короткое целое число
            byte byteValue = 255;              // Байтовое значение (0 до 255)

            float floatValue = 3.14f;          // Число с плавающей точкой одинарной точности
            double doubleValue = 3.1458979;    // Число с плавающей точкой двойной точности
            decimal decimalValue = 348564392.89m; // Десятичное число, используется для точных вычислений

            bool boolValue = true;             // Логическое значение

            char charValue = 'V';              // Один символ

            string stringValue = "Hello World"; // Строка

            // Вывод значений переменных в консоль с использованием строковой интерполяции
            Console.WriteLine("Значения переменных:");
            Console.WriteLine($"int: {intValue}");
            Console.WriteLine($"long: {longValue}");
            Console.WriteLine($"short: {shortValue}");
            Console.WriteLine($"byte: {byteValue}");
            Console.WriteLine($"float: {floatValue}");
            Console.WriteLine($"double: {doubleValue}");
            Console.WriteLine($"decimal: {decimalValue}");
            Console.WriteLine($"bool: {boolValue}");
            Console.WriteLine($"char: {charValue}");
            Console.WriteLine($"string: {stringValue}");

            Console.WriteLine("\nВведите значения переменных:"); 

            // Ввод новых значений для переменных с использованием методов преобразования данных

            Console.Write("Введите int: ");
            intValue = int.Parse(Console.ReadLine());

            Console.Write("Введите float: ");
            floatValue = float.Parse(Console.ReadLine()); 

            Console.Write("Введите bool (true/false): ");
            boolValue = bool.Parse(Console.ReadLine()); 

            Console.Write("Введите char: ");
            charValue = char.Parse(Console.ReadLine()); 

            Console.Write("Введите string: ");
            stringValue = Console.ReadLine(); // Чтение строки 

            // Вывод введенных пользователем значений переменных
            Console.WriteLine("\nВведенные значения:");
            Console.WriteLine($"int: {intValue}");
            Console.WriteLine($"float: {floatValue}");
            Console.WriteLine($"bool: {boolValue}");
            Console.WriteLine($"char: {charValue}");
            Console.WriteLine($"string: {stringValue}");

            Console.WriteLine("\n_______________________________________\n");

            // Явные и неявные преобразования

            Console.WriteLine("Явное приведение");

            // Преобразование числа с плавающей точкой (double) в целое (int), дробная часть теряется
            double dValue = 6.78;
            int iValue = (int)dValue;
            Console.WriteLine("double -> int = " + iValue); // 6

            // Преобразование большого числа (long) в маленькое (short), данные могут потеряться из-за переполнения
            long lValue = 50000;
            short sValue = (short)lValue;
            Console.WriteLine("long -> short = " + sValue); // -15536

            // Преобразование числа с плавающей точкой (float) в целое (int), дробная часть отбрасывается
            float fValue = 8.99f;
            int inValue = (int)fValue;
            Console.WriteLine("float -> int = " + inValue); // 8

            // Преобразование целого числа (int) в байт (byte), если число больше 255, оно обрезается
            int bigInt = 255;
            byte byValue = (byte)bigInt;
            Console.WriteLine("int -> byte = " + byValue); // 255

            // Преобразование строки в число с помощью int.Parse
            string str = "999";
            int numValue = int.Parse(str);
            Console.WriteLine("string -> int = " + numValue); // 999

            Console.WriteLine(" ");
            Console.WriteLine("Неявное приведение");

            // Неявное приведение 

            // Преобразование целого числа (int) в большое целое (long), данные не теряются
            int iNum = 100;
            long lNum = iNum;
            Console.WriteLine("int -> long = " + lNum); // 100

            // Преобразование маленького числа (short) в целое (int), данные не теряются
            short sNum = 32000;
            int inNum = sNum;
            Console.WriteLine("short -> int = " + inNum); // 32000

            // Преобразование числа с плавающей точкой (float) в число с большей точностью (double)
            float fNum = 3.14f;
            double dNum = fNum;
            Console.WriteLine("float -> double = " + dNum); // 3.14

            // Преобразование символа (char) в его числовой код (int)
            char charNum = 'A';
            int charToInt = charNum;
            Console.WriteLine("char -> int = " + charToInt); // 65 (код символа 'A')

            // Преобразование байта (byte) в целое число (int), данные не теряются
            byte byteNum = 255;
            int newIntValue = byteNum;
            Console.WriteLine("byte -> int = " + newIntValue); // 255

            Console.WriteLine("\n_______________________________________\n");

            // Упаковка и распаковка значимых тпиов

            Console.WriteLine(" ");
            Console.WriteLine("Упаковка и распаковка значимых тпиов");

            int i = 123;
            object obj = i;
            Console.WriteLine("Упаковка (Boxing): " + obj);

            int j = (int)obj;
            Console.WriteLine("Распаковка (Unboxing): " + j);

            Console.WriteLine("\n_______________________________________\n");

            // Неявно типизированная переменная

            Console.WriteLine(" ");
            Console.WriteLine("Неявно типизированная переменная");

            var dateValue = DateTime.Now;
            Console.WriteLine("dateValue (тип DateTime): " + dateValue);

            Console.WriteLine("\n_______________________________________\n");


            // Пример работы с Nullable переменной 

            Console.WriteLine(" ");
            Console.WriteLine("Nullable");

            int? variableIntNullabel = null; // Объявление переменной типа int? (Nullable<int>), которая может принимать значение null
            variableIntNullabel = 5;
            Console.WriteLine("работа с Nullable переменной " + variableIntNullabel);



            Console.WriteLine("\n_______________________________________\n");

            // Объявление строковых литералов. Их сравнение

            string string1 = "Hello!";
            string string2 = "Hello!";
            string string3 = "hello!";

            bool areEqual1 = string1 == string2;  // true
            bool areEqual2 = string1 == string3;  // false

            Console.WriteLine($"string1 == string2: {areEqual1}");
            Console.WriteLine($"string1 == string3: {areEqual2}");

            Console.WriteLine("\n_______________________________________\n");

            // Работа со строками

            string str1 = "Hello";
            string str2 = "World";
            string str3 = "programming programm";

            // Сцепление строк
            string concatenated = string.Concat(str1, " ", str2);
            Console.WriteLine($"Сцепление строк: {concatenated}");

            // Копирование строки 
            string copied = str3;
            Console.WriteLine($"Копирование строки: {copied}");

            // Выделение подстроки
            string substring = str3.Substring(1, 8);
            Console.WriteLine($"Выделение подстроки: {substring}");  // "rogrammi"

            // Разделение строки на слова
            string[] words = str3.Split(' ');
            Console.WriteLine("Слова:");
            foreach (var word in words)  
            {
                Console.WriteLine(word);
            }

            // Вставка подстроки
            string inserted = str3.Insert(11, " cool ");
            Console.WriteLine($"Вставка подстроки: {inserted}");

            // Удаление подстроки
            string removed = str3.Remove(12, 8);
            Console.WriteLine($"Удаление подстроки: {removed}");

            // Интерполяция строк
            string interpolated = $"Интерполяция подстроки: {str1} {str2} is great for {str3}";
            Console.WriteLine(interpolated);

            Console.WriteLine("\n_______________________________________\n");

            /*c. Создайте пустую и null строку. Продемонстрируйте использование метода string.IsNullOrEmpty.
            * Продемонстрируйте что еще можно выполнить с такими строками*/

            string str7 = "";          // Пустая строка, не содержит символов, но не является null
            string str8 = null;
            string str9 = "   \t   ";  // Строка, состоящая только из пробелов и символов табуляции

            if (String.IsNullOrEmpty(str7))
                Console.WriteLine("Str7 пустая или null-строка");
            else
                Console.WriteLine("Str7 не null-строка или не пустая"); // Вывод: Str7 пустая или null-строка


            if (String.IsNullOrEmpty(str8))
                Console.WriteLine("Str8 пустая или null-строка");  // Вывод: Str8 пустая или null-строка

            if (String.IsNullOrEmpty(str9))
                Console.WriteLine("Str9 пустая или null-строка");
            else
                Console.WriteLine("Str9 не null-строка или не пустая"); // Вывод: Str9 не null-строка или не пустая

            if (String.IsNullOrWhiteSpace(str7))
                Console.WriteLine("Str7 пустая или null-строка или строка из пробелов");  


            if (String.IsNullOrWhiteSpace(str8))
                Console.WriteLine("Str8 пустая или null-строка или строка из пробелов"); 

            if (String.IsNullOrWhiteSpace(str9))
                Console.WriteLine("Str9 пустая или null-строка или строка из пробелов"); 

            Console.WriteLine("\n_______________________________________\n");

            /*d. Создайте строку на основе StringBuilder. Удалите определенные позиции и добавьте 
             * новые символы в начало и конец строки. */

            StringBuilder str10 = new StringBuilder(" an old");
            str10.Remove(2, 5);
            str10.Insert(0, "This is");
            str10.Append(" new string");
            Console.WriteLine(str10);

            // Создание и инициализация целого двумерного массива
            int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

            // Вывод массива на консоль в отформатированном виде
            Console.WriteLine("Matrix:");
            int rows = matrix.GetLength(0);  // Получение количества строк в двумерном массиве matrix
            int cols = matrix.GetLength(1);  // Получение количества столбцов в двумерном массиве matrix

            for (int R = 0; R < rows; R++)   
            {
                for (int J = 0; J < cols; J++) 
                {
                    Console.Write($"{matrix[R, J],4}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n_______________________________________\n");

            // Одномерный массив строк, состоящий из 3 элементов


            string[] stringArray = { "Vvv", "Aaa", "Nnn" };

            Console.WriteLine("Содержимое массива:");     
            foreach (string stringMatrix in stringArray)
            {
                Console.WriteLine(stringMatrix);          
            }

            Console.WriteLine($"Длина массива: {stringArray.Length}"); 

            // Запрос у пользователя индекса элемента для изменения
            Console.Write("Введите индекс элемента, который требуется изменить (от 0 до {0}):", stringArray.Length - 1);

            int index = int.Parse(Console.ReadLine());  

            if (index >= 0 && index < stringArray.Length)  
            {
                Console.Write("Введите новое значение: "); 

                string newValue = Console.ReadLine();

                stringArray[index] = newValue; 

                Console.WriteLine("Обновленное содержимое массива:");
                foreach (string stringMatrix in stringArray)
                {
                    Console.WriteLine(stringMatrix);  
                }
            }
            else
            {
                Console.WriteLine("Неверный индекс.");
            }

            Console.WriteLine("\n_______________________________________\n");

            // Создание ступенчатого массива (массив массивов) с 3 строками
            double[][] jaggedArray = new double[3][];

            // Инициализация строк массива
            jaggedArray[0] = new double[2]; 
            jaggedArray[1] = new double[3];
            jaggedArray[2] = new double[4];

            // Ввод значений с консоли
            Console.WriteLine("Введите значения для ступенчатого массива:");

            // Проход по всем строкам ступенчатого массива
            for (int ir = 0; ir < jaggedArray.Length; ir++)
            {
                // Запрос значений для текущей строки
                Console.WriteLine($"Введите значения для строки {ir + 1} (длина {jaggedArray[ir].Length}):");
                for (int jr = 0; jr < jaggedArray[ir].Length; jr++)
                {
                    // Запрос значения для текущей позиции в строке
                    Console.Write($"Значение на позиции [{ir},{jr}]: ");
                    jaggedArray[ir][jr] = double.Parse(Console.ReadLine()); // Считывание и преобразование значения из строки в double
                }
            }

            // Вывод значений
            Console.WriteLine("Содержимое ступенчатого массива:");
            for (int ik = 0; ik < jaggedArray.Length; ik++)
            {
                // Вывод строки массива
                Console.Write($"Строка {ik + 1}: ");
                for (int jk = 0; jk < jaggedArray[ik].Length; jk++)
                {
                    // Вывод значения в текущей позиции строки
                    Console.Write($"{jaggedArray[ik][jk]} ");
                }
                // Переход на следующую строку
                Console.WriteLine();
            }

            Console.WriteLine("\n_______________________________________\n");

            // Неявно типизированная переменная для строки
            var stValue = "Это строка"; // Переменная stValue автоматически получает тип string
            Console.WriteLine($"Содержание строки: {stValue}");

            Console.WriteLine("\n_______________________________________\n");

            // Неявно типизированная переменная для массива строк
            var stArray = new[] { "Apple", "Banana", "Cherry" };
            Console.WriteLine("Содержимое массива:");
            foreach (var item in stArray) 
            {
                Console.WriteLine(item); 
            }

            Console.WriteLine("\n_______________________________________\n");

            // a. Кортеж
            var myTuple = (25, "uuuuu", 'S', "llll");
            Console.WriteLine($"Весь кортеж: {myTuple}");
            Console.WriteLine($"1-ый элемент: {myTuple.Item1}");
            Console.WriteLine($"3-ий элемент: {myTuple.Item3}");
            Console.WriteLine($"4-ый элемент: {myTuple.Item4}");

            // Распаковка кортежа
            var (intAlue, stringValue1, charAlue, stringValue2) = myTuple;
            Console.WriteLine($"Число: {intAlue}, Первоя строка: {stringValue1}, Символ: {charAlue}, Втоорая строка: {stringValue2}");

            // Распаковка с использованием _
            var (_, _, _, secondString) = myTuple;
            Console.WriteLine($"Вторая строка (используем _): {secondString}");

            // d. Сравнение кортежей
            var anotherTuple = (06, "fff", 'B', "yyyy");
            Console.WriteLine($"Второй кортеж: {anotherTuple}");
            Console.WriteLine($"Кортеж равен другому кортежу: {myTuple.Equals(anotherTuple)}");

            Console.WriteLine("\n_______________________________________\n");

            // Локальная функция AnalyzeArray, которая принимает массив чисел и строку.
            // Возвращает кортеж с максимальным и минимальным элементами массива, суммой элементов и первым символом строки.
            (int max, int min, int sum, char firstChar) AnalyzeArray(int[] numbers, string text)
            {
                // Проверка на наличие элементов в массиве.
                // Если массив пустой, выбрасывается исключение.
                if (numbers.Length == 0)
                    throw new ArgumentException("Массив не может быть пустым");

                // Инициализация переменных: max и min присваивается первое значение массива, 
                // sum (сумма элементов) инициализируется нулем.
                int max = numbers[0];
                int min = numbers[0];
                int sum = 0;

                // Цикл проходит по каждому числу в массиве numbers.
                foreach (int num in numbers)
                {
                    if (num > max) max = num;
                    if (num < min) min = num;
                    sum += num;
                }

                // Проверка, содержит ли строка хотя бы один символ.
                // Если да, то берется первый символ строки, иначе устанавливается нулевой символ '\0'.
                char firstChar = text.Length > 0 ? text[0] : '\0';

                // максимальный элемент массива, минимальный элемент, сумма элементов массива и первый символ строки.
                return (max, min, sum, firstChar);
            }

            // Пример вызова функции AnalyzeArray:
            // Создание массива чисел и строки
            int[] numbers = { 1, 2, 3, 4, 5 };
            string text = "privet,spish?";

            // Вызов функции и получение результата
            var result = AnalyzeArray(numbers, text);

            Console.WriteLine($"Строка массва: {text}");

            // Вывод результатов на консоль: максимальный элемент, минимальный, сумма и первый символ строки.
            Console.WriteLine($"Максимальный элемент: {result.max}, Минимальный элемент: {result.min}, Сумма: {result.sum}, Первый символ: {result.firstChar}");

            Console.WriteLine("\n_______________________________________\n");

            // 6. Работа с checked/unchecked

            void CheckedOperation()
            {
                checked
                {
                    try
                    {
                        // Присваиваем максимальное значение типа int
                        int maxValue = int.MaxValue;
                        int result = maxValue + 1; // Вызовет переполнение
                    }
                    catch (OverflowException)
                    {
                        // Если переполнение происходит, выбрасывается исключение OverflowException
                        Console.WriteLine("Checked: Переполнение.");
                    }
                }
            }

            void UncheckedOperation()
            {
                unchecked
                {
                    // Присваиваем максимальное значение типа int
                    int maxValue = int.MaxValue;
                    // Результат будет отрицательным числом (переполнение)
                    int result = maxValue + 1; // Не вызовет исключение
                    Console.WriteLine($"Unchecked: Результат переполнения {result}");
                }
            }

            // Вызов функций для демонстрации работы checked и unchecked
            CheckedOperation();
            UncheckedOperation();

        }
    }
}
