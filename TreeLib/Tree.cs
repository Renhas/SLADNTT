using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace TreeLib
{
    /// <summary>
    /// Дерево для решения СЛАДНТТ
    /// </summary>
    public class Tree
    {
        /// <summary>
        /// Узел дерева
        /// </summary>
        public class Node
        {
            int _a, _b;
            /// <summary>
            /// Родитель
            /// </summary>
            public Node Prev { get; set; }
            /// <summary>
            /// Дети
            /// </summary>
            public List<Node> Next { get; set; }
            /// <summary>
            /// Номер
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// Изначальная нижняя граница; После проверки на совместность становится приведённой
            /// </summary>
            public int A { get { return _a; } set { _a = value; Ap = value; } }
            /// <summary>
            /// Изначальная верхняя граница; После проверки на совместность становится приведённой
            /// </summary>
            public int B { get { return _b; } set { _b = value; Bp = value; } }
            /// <summary>
            /// НЕ приведённая нижняя граница; Меняется в ходе алгоритма
            /// </summary>
            public int Ap { get; set; }
            /// <summary>
            /// НЕ приведённая верхняя граница; Меняется в ходе алгоритма
            /// </summary>
            public int Bp { get; set; }
            /// <summary>
            /// Найденное в ходе алгоритма значение
            /// </summary>
            public int Value { get; set; }
            /// <summary>
            /// Ценность вершины
            /// </summary>
            public int C { get; set; }
            /// <summary>
            /// Состояние
            /// </summary>
            public bool Active { get; set; }

            public Node(int id, Node prev = null, int A = 0, int B = 0, int C = 0, int value = 0)
            {
                Id = id;
                Prev = prev;
                Next = new List<Node>();
                this.A = A;
                this.B = B;
                this.C = C;
                Value = value;
                Active = true;
            }
            /// <summary>
            /// Подсчёт количества листьев в поддереве, корнем которого явялется данная вершина
            /// </summary>
            /// <returns>Количество листьев</returns>
            public int LeavesCount(Node node = null)
            {
                if (node == null) node = this;
                if (!node.Next.Any()) return 1;
                int count = 0;
                foreach (Node child in node.Next)
                {
                    count += LeavesCount(child);
                }
                return count;
            }
        }
        /// <summary>
        /// Корень дерева
        /// </summary>
        public Node Root { get; private set; }
        int leaves, vertex;
        int[] Income, Expense, Profit;
        /// <summary>
        /// Количество листьев
        /// </summary>
        public int Leaves { get { return leaves;} }

        /// <summary>
        /// Создаёт пустое дерево; Индекс корня = 1
        /// </summary>
        public Tree() 
        {
            Root = new Node(1);
            leaves = vertex = 1;
            Income = Expense = Profit = null;
        }
        
        /// <summary>
        /// Получение конкретной вершины дерева
        /// </summary>
        /// <returns>Найденная вершина или null, если вершины с заданным индексом нет</returns>
        /// <exception cref="ArgumentException"></exception>
        private Node GetNode(int id, Node startNode = null) 
        {
            if (id < 0) throw new ArgumentException("Некорректный индекс");
            if (startNode == null) startNode = Root;
            if (startNode.Id == id) return startNode;
            foreach (Node node in startNode.Next) 
            {
                Node buf = GetNode(id, node);
                if (buf != null && buf.Id == id) return buf;
            }
            return null;
        }
        /// <summary>
        /// Определение высоты конкретной вершины
        /// </summary>
        /// <returns>Высота вершины; У корня высота 0</returns>
        public int Height(Node node) 
        {
            if (node.Prev == null) return 0;
            else return 1 + Height(node.Prev);
        }
        /// <summary>
        /// Проверка системы на совместность; Если несовместна, выдаёт соответствующую ошибку
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public void Compatibility(Node node = null) 
        {
            if (node == null) node = Root;
            int sumA = 0, sumB = 0;
            foreach (Node child in node.Next) 
            {
                Compatibility(child);
                sumA += child.A;
                sumB += child.B;
            }
            if (node.Next.Any())
            {
                if (sumA > node.A) node.A = sumA;
                if (sumB < node.B) node.B = sumB;
            }
            if (node.A > node.B) throw new ArgumentException("Система несовместна");
        }

        /// <summary>
        /// Пересчёт количества листьев дерева
        /// </summary>
        private void LeavesCheck() => leaves = Root.LeavesCount();
        /// <summary>
        /// Очистка дерева
        /// </summary>
        private void Clear() 
        {
            this.Root = new Node(1);
            leaves = vertex = 1;
            Income = Expense = Profit = null;
        }
        /// <summary>
        /// Вырастить дерево из заданного файла
        /// </summary>
        public void GrowUp(string file) 
        {
            Clear();
            char[] badChars = { ' ', '(', ')', ',', '.', '|', '/', '\\', '\t', ';', ':', '\'', '\"', '-', '+', '{', '}', '[', ']', '=', '_', '!', '?', '`', '~', '@'};
            //Считывание всех строк из файлика
            string[] strings = File.ReadAllLines(file);
            //Разбиение списка рёбер на одиночные строки "0", "1", etc.
            string[] vertices = strings[0].Split(badChars, StringSplitOptions.RemoveEmptyEntries);
            //Аналогичное разбиение строк-границ
            string[] A, B; 
            A = strings[1].Split(badChars, StringSplitOptions.RemoveEmptyEntries);
            B = strings[2].Split(badChars, StringSplitOptions.RemoveEmptyEntries);
            Root.A = int.Parse(A[0]);
            Root.B = int.Parse(B[0]);
            //Если нумерация начинается с 0, меняем индекс корня
            Root.Id = int.Parse(vertices[0]);
            
            //Считывание пар и создание необходимой вершины
            for (int i = 0; i < vertices.Length; i+=2) 
            {
                Node parent = GetNode(int.Parse(vertices[i]));
                int childId = int.Parse(vertices[i + 1]);
                parent.Next.Add(new Node(childId, parent, int.Parse(A[i/2 + 1]), int.Parse(B[i/2 + 1])));
                vertex++;
            }
            //Подсчёт листьев
            LeavesCheck();

            //Создание массивов дохода, расхода и прибыли
            Income = new int[vertex];
            Expense = new int[vertex];
            Profit = new int[vertex];

            A = strings[3].Split(badChars, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < vertex; i++) Income[i] = int.Parse(A[i]);
            A = strings[4].Split(badChars, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < vertex; i++) Expense[i] = int.Parse(A[i]);
            A = strings[5].Split(badChars, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < vertex; i++) Profit[i] = int.Parse(A[i]);

        }
        /// <summary>
        /// Устанавливает изначальные значения C для вершин; Применяется обход в ширину
        /// </summary>
        /// <param name="arr">Массив значений</param>
        /// <exception cref="ArgumentException"></exception>
        private void SetOriginC(int[] arr) 
        {
            if (arr.Length != vertex) throw new ArgumentException("Некорректный размер массива");
            int i = 0;
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(Root);
            while (nodes.Any())
            {
                nodes.Peek().C = arr[i];
                i++;
                foreach (Node child in nodes.Peek().Next)
                {
                    nodes.Enqueue(child);
                }
                nodes.Dequeue();
            }
        }
        /// <summary>
        /// Перерасчёт значений C для листьев исходя из значений их предков; Рекурсивный обход в глубину
        /// </summary>
        /// <param name="node"></param>
        /// <param name="sum"></param>
        private void SetRealC(Node node = null, int sum = 0)
        {
            if (node == null) node = Root;
            if (!node.Next.Any())
            {
                node.C -= sum;
                return;
            }
            foreach (Node child in node.Next) SetRealC(child, sum + node.C);
        }
        /// <summary>
        /// Подсчёт максимума дохода
        /// </summary>
        /// <returns>Доход</returns>
        public int MaxIncome() => AlgorithmLaunch(Income);
        /// <summary>
        /// Подсчёт минимума расходов
        /// </summary>
        /// <returns>Расход</returns>
        public int MinExpense() => AlgorithmLaunch(Expense);
        /// <summary>
        /// Подсчёт максимума прибыли
        /// </summary>
        /// <returns>Прибыль</returns>
        public int MaxProfit() => AlgorithmLaunch(Profit);
        /// <summary>
        /// Установка значений для вершин и запуск алгоритма
        /// </summary>
        /// <param name="arr">Массив изначальный значений</param>
        /// <returns>Значение критерия</returns>
        private int AlgorithmLaunch(int[] arr) 
        {
            Reset();
            SetOriginC(arr);
            SetRealC();
            return MaxMinАlgorithm();
        }
        /// <summary>
        /// Сброс значений, которые были изменены в ходе алгоритма, до изначальных
        /// </summary>
        private void Reset(Node node = null) 
        {
            if (node == null) node = Root;
            node.Active = true;
            node.Ap = node.A;
            node.Bp = node.B;
            foreach (Node child in node.Next) Reset(child);
        }
        /// <summary>
        /// Обход дерева в ширину и считывание вычисленных в ходе алгоритма значений
        /// </summary>
        /// <returns>Строка с найденными значениями переменных</returns>
        public string Solution() 
        {
            string str = "";
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(Root);
            while (nodes.Any()) 
            {
                str += $"x{nodes.Peek().Id} = {nodes.Peek().Value}; ";
                foreach (Node child in nodes.Peek().Next) 
                {
                    nodes.Enqueue(child);
                }
                nodes.Dequeue();
            }
            return str;
        }
        /// <summary>
        /// Универсальный алгоритм для вычисления максимума доходов и прибыли и минимума расходов;
        /// </summary>
        /// <returns>Значение критерия</returns>
        /// <exception cref="ArgumentException"></exception>
        private int MaxMinАlgorithm() 
        {
            ///Проверка на соввместность
            Compatibility();
            ///Значеник критерия
            int sum = 0;
            ///Проходим по листьям
            for (int i = 0; i < leaves; i++)
            {
                ///Обходом в ширину находим лист с максимальным значением C (по абсолютному значению)
                Node startNode = null;
                Queue<Node> nodes = new Queue<Node>();
                nodes.Enqueue(Root);
                while (nodes.Any())
                {
                    Node currentNode = nodes.Peek();
                    if (!currentNode.Next.Any() && currentNode.Active)
                    {
                        if (startNode == null) startNode = currentNode;
                        else if (Math.Abs(currentNode.C) > Math.Abs(startNode.C)) startNode = currentNode;
                    }
                    foreach (Node child in currentNode.Next)
                    {
                        nodes.Enqueue(child);
                    }
                    nodes.Dequeue();
                }

                ///Применяем алгоритм для найденного листа

                ///Изначальные параметры, которые будут меняться в ходе алгоритма
                int count = startNode.C > 0 ? startNode.Bp : startNode.Ap, tempSum = 0, currentId = startNode.Id;
                ///Проходим по предкам
                Node parent = startNode.Prev;
                while (parent != null)
                {
                    foreach (Node node in parent.Next)
                    {
                        ///Рассчитываем сумму, которую потом вычтем
                        if (node.Id == currentId || !node.Active) continue;
                        tempSum += startNode.C > 0 ? node.Ap : node.Bp;

                    }
                    ///Сравниваем на минимум/максимум
                    if (startNode.C > 0 ? parent.Bp - tempSum < count : parent.Ap - tempSum > count)
                        count = (startNode.C > 0 ? parent.Bp : parent.Ap) - tempSum;
                    ///Переходим к следующему предку
                    currentId = parent.Id;
                    parent = parent.Prev;
                }
                ///Присваиваем найденное значение листу
                startNode.Value = count;
                ///Помечаем вершину рассмотренной
                startNode.Active = false;

                ///Изменяем границы с учётом найденого значения
                parent = startNode.Prev;
                while (parent != null)
                {
                    parent.Ap -= count;
                    parent.Bp -= count;
                    int ASum = 0, BSum = 0;
                    foreach (Node child in parent.Next) 
                    {
                        if (child.Active) 
                        {
                            ASum += child.Ap;
                            BSum += child.Bp;
                        }
                    }
                    if (parent.Ap < ASum) parent.Ap = ASum;
                    if (parent.Bp > BSum) parent.Bp = BSum;
                    parent = parent.Prev;
                }
                
                ///Изменяем критерий
                sum += count * startNode.C;
            }


            ///Локальная рекурсивная функция для вычисления значений всех узлов исходя из значений листьев
            int Subtotal(Node node = null) 
            {
                if (node == null) node = Root;
                if (!node.Next.Any()) return node.Value;
                int value = 0;
                foreach (Node child in node.Next) 
                {
                    value += Subtotal(child);
                }
                node.Value = value;
                return value;
            }
            Subtotal();

            return sum;
        }
    }
}
