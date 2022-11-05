using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeLib
{
    /// <summary>
    /// Класс для отрисовки вершинки дерева в виде кружочка с данными
    /// </summary>
    public partial class MyNode : UserControl
    {
        
        Tree.Node _node;
        /// <summary>
        /// Цвет, которым будем раскрашивать нашу вершинку
        /// </summary>
        Color mainColor;

        /// <summary>
        /// Вершинка, данные которой будем брать
        /// </summary>
        public Tree.Node Node 
        { 
            get { return _node; } 
            set 
            { 
                _node = value;
                if (value != null)
                {
                    ///Определяем тип вершины и её цвет
                    if (value.Prev == null) mainColor = Color.RosyBrown;
                    else if (!value.Next.Any()) mainColor = Color.LawnGreen;
                    else mainColor = Color.Brown;
                }
                ///Перерисовываем вершинку
                MainPanel.Refresh();
                SetData();
                
            }
        }
        public MyNode(Tree.Node node = null)
        {
            InitializeComponent();
            Node = node;
        }
        /// <summary>
        /// Заливаем кружочек и делаем обводку
        /// </summary>
        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            if (Node == null) return;
            
            SolidBrush brush = new SolidBrush(mainColor);
            e.Graphics.FillEllipse(brush, 0, 0, this.Width - 1, this.Height - 1);

            Pen pen = new Pen(Color.Black, 2f);
            e.Graphics.DrawEllipse(pen, 0, 0, this.Width-1, this.Height - 1);
        }
        /// <summary>
        /// Устанавливаем данные, любезно предоставленные нам вершинкой
        /// </summary>
        private void SetData() 
        {
            if (Node == null) return;
            NodeId.Text = Node.Id.ToString();
            NodeBounds.Text = $"{Node.A}_{Node.B}";
            CLabel.Text = Node.C.ToString();
            ValueLabel.Text = Node.Value.ToString();
            NodeId.BackColor = NodeBounds.BackColor = CLabel.BackColor = ValueLabel.BackColor = mainColor;

            ///Подстраиваем цвет текста под цвет вершины, чтоб глазки не болели
            Color color = Color.Black;
            if (Node.Prev != null && Node.Next.Any()) color = Color.White;
            NodeId.ForeColor = NodeBounds.ForeColor = CLabel.ForeColor = ValueLabel.ForeColor = color;


            
        }
    }
}
