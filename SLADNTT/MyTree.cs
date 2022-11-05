using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TreeLib;

namespace SLADNTT
{
    public partial class MyTree : Form
    {
        /// <summary>
        /// Дерево
        /// </summary>
        Tree _tree;
        delegate int Algorythm();
        public MyTree()
        {
            InitializeComponent();
            _tree = new Tree();
        }
        /// <summary>
        /// Событие для получения пути к файлу
        /// </summary>
        private void FilePathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt) | *.txt";
            openFileDialog.Title = "Открыть";
            if (openFileDialog.ShowDialog() == DialogResult.OK) 
            {
                FilePathBox.Text = openFileDialog.FileName;
                try 
                {
                    ///Выращиваем дерево и показываем наше творение миру
                    _tree.GrowUp(FilePathBox.Text);
                    TreePaint();
                    ResultBox.Visible = false;

                    
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Дерево не было создано, проверьте расположение файла", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    FilePathBox.Text = "";
                }
                catch
                {
                    MessageBox.Show("Дерево не было создано, проверьте корретность данных в файле", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    FilePathBox.Text = "";
                }
            }
        }
        /// <summary>
        /// Отрисовка дерева. Увы, не может передать всей красоты нашего деревца
        /// </summary>
        private void TreePaint() 
        {
            if (_tree == null) return;

            ///Скрываем наше дерево от посторонних глаз, пока оно не вырастет
            TreeLayout.Visible = false;
            ///Устанавливаем начальное количество строк и столбцов
            TreeLayout.Controls.Clear();
            TreeLayout.RowCount = 5;
            TreeLayout.ColumnCount = _tree.Leaves + 1;
            ///Устанавливаем нужный нам размер столбцов
            TreeLayout.ColumnStyles.Clear();
            for (int i = 0; i < TreeLayout.ColumnCount; i++) TreeLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));

            ///Вызываем локальную рекурсивную функцию
            Nodes(_tree.Root, 0, _tree.Leaves - 1);

            ///Устанавливаем нужный нам размер строк
            TreeLayout.RowStyles.Clear();
            for (int i = 0; i < TreeLayout.RowCount; i++) TreeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));

            ///Локальная рекурсивная функция отрисовки деревца
            void Nodes(Tree.Node node, int columnIdMin, int columnIdMax) 
            {
                ///Это нам понадобится дальше
                int currentMin = columnIdMin, height = _tree.Height(node);
                ///Создаём красивый кружочек-вершину с данными
                ///Свойство Anchor нужно, что вершинка была посередине всех своих потомков
                MyNode myNode = new MyNode(node) { Size = new Size(100,100), Anchor = AnchorStyles.None};
                ///Даём, если нужно, больше простора нашему деревцу, чтоб ему не было тесно
                if(TreeLayout.RowCount < (height + 1) * 2 ) TreeLayout.RowCount = (height + 1) * 2;

                ///Добавляем вершину в сетку и выделяем для неё столько столбцов, сколько нужно многодетной вершинке
                TreeLayout.Controls.Add(myNode, columnIdMin, height * 2);
                TreeLayout.SetColumnSpan(myNode, columnIdMax - columnIdMin + 1);
                ///Если у вершинки есть дети, показываем, где они, чтоб не потерялись
                if (node.Next.Any())
                {
                    ///Создаём стрелочки
                    MyArrows arrows = new MyArrows(node, columnIdMax - columnIdMin + 1);
                    ///Выделяем под стрелочки все столбцы, занимаемые детями вершинки
                    TreeLayout.Controls.Add(arrows, columnIdMin, height * 2 + 1);
                    TreeLayout.SetColumnSpan(arrows, columnIdMax - columnIdMin + 1);
                }
                ///Проходим по деткам и отрисовываем их
                foreach (Tree.Node child in node.Next) 
                {
                    int currentMax = child.LeavesCount() - 1;
                    Nodes(child, currentMin, currentMin + currentMax);
                    currentMin += currentMax + 1;
                }
            }
            ///Показываем наше деревце, ведь оно уже взрослое
            TreeLayout.Visible = true;

        }
        /// <summary>
        /// Блокировка кнопок при отсутствии корректного файла
        /// </summary>
        private void FilePathBox_TextChanged(object sender, EventArgs e)
        {
            if (FilePathBox.Text != "") {
                TreeCheckButton.Enabled = true;
                IncomeButton.Enabled = ExpenseButton.Enabled = ProfitButton.Enabled = true;

            }
            else
            {
                TreeCheckButton.Enabled = false;
                IncomeButton.Enabled = ExpenseButton.Enabled = ProfitButton.Enabled = false;
                ResultBox.Visible = false;
                
            }
        }
        /// <summary>
        /// Проверка нашего деревца
        /// </summary>
        private void TreeCheckButton_Click(object sender, EventArgs e)
        {
            
            try 
            {
                _tree.Compatibility();
                TreePaint();
                MessageBox.Show("Система совместна", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }
        private string StartAlgorithm(Algorythm algorythm) 
        {
            try
            {
                int result = algorythm();
                TreePaint();
                ResultBox.Visible = true;   
                return result.ToString();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            catch
            {
                MessageBox.Show("Проверьте корретность данных в файле", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                
            }
            ResultBox.Visible = false;
            return "";
        }
        
        private void IncomeButton_Click(object sender, EventArgs e)
        {
            Algorythm algorythm = _tree.MaxIncome;
            //IncomeLabel.Text = StartAlgorithm(algorythm);
            string result = StartAlgorithm(algorythm);
            ResultBox.Text = $"{_tree.Solution()}Доход: {result}";
            
        }

        private void ExpenseButton_Click(object sender, EventArgs e)
        {
            Algorythm algorythm = _tree.MinExpense;
            //ExpenseLabel.Text = StartAlgorithm(algorythm);
            string result = StartAlgorithm(algorythm);
            ResultBox.Text = $"{_tree.Solution()}Расход: {result}";
        }

        private void ProfitButton_Click(object sender, EventArgs e)
        {
            Algorythm algorythm = _tree.MaxProfit;
            //ProfitLabel.Text = StartAlgorithm(algorythm);
            string result = StartAlgorithm(algorythm);
            ResultBox.Text = $"{_tree.Solution()}Прибыль: {result}";
        }

        private void TopMostButton_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = TopMostButton.Checked;
        }
    }
}
