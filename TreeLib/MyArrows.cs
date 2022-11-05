using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TreeLib
{
    /// <summary>
    /// Отображает стрелочки от вершины-родителя к вершинам-детям;
    /// Рассчитан на применение в TableLayoutPanel с одинаковыми по размеру ячейками
    /// </summary>
    public partial class MyArrows : UserControl
    {
        
        Tree.Node _parent;

        int _columnCount, _cellWidth;
        /// <summary>
        /// Вершина-родитель, из которой будут идти стрелки
        /// </summary>
        public Tree.Node ParentNode { get { return _parent; } set { _parent = value; MainPanel.Refresh(); } }
        /// <summary>
        /// Количество столбцов в TableLayoutPanel, которые будет занимать данный элемент
        /// </summary>
        public int ColumnCount { get { return _columnCount; } set { _columnCount = value; MainPanel.Refresh(); } }
        /// <summary>
        /// Ширина одной ячейки в TableLayoutPanel
        /// </summary>
        public int CellWidth { get { return _cellWidth; } set { _cellWidth = value; MainPanel.Refresh(); } }
        public MyArrows(Tree.Node parent = null, int columnCount = 1, int cellWidth = 100)
        {
            InitializeComponent();
            ///Установка размеров области исходя из входных данных
            this.MinimumSize = new Size(cellWidth * columnCount, cellWidth);
            this.MaximumSize = this.MinimumSize;
            MainPanel.MinimumSize = this.MinimumSize;
            MainPanel.MaximumSize = this.MaximumSize;
            ///Сохранение входных данных
            ParentNode = parent;
            ColumnCount = columnCount;
            CellWidth = cellWidth;
            
        }
        /// <summary>
        /// Отрисовка стрелочек
        /// </summary>
        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            ///Прозрачная панель
            MainPanel.BackColor = Color.Empty;
            ///Карандаш для рисования стрелочек
            Pen pen = new Pen(Color.Black, 5) 
            {
                EndCap = LineCap.ArrowAnchor
            };

            ///Стартовая точка для всех стрелок
            ///Предполагается, что вершина-родитель находится посередине
            Point start = new Point(this.Width / 2,0);

            ///Для каждого ребёнка вычисляем конечную точку и рисуем линию
            ///Предполагается, что вершины-дети расположены посередине своих ячеек
            int currentStart = 0;
            foreach (Tree.Node child in ParentNode.Next) 
            {
                int leaves = child.LeavesCount();
                Point end = new Point(currentStart + CellWidth / 2 * leaves, MainPanel.Height);
                e.Graphics.DrawLine(pen, start, end);
                currentStart += CellWidth * leaves;
            }

        }
    }
}
