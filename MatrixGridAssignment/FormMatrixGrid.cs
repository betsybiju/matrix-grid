using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MatrixGridAssignment
{
    public partial class FormMatrixGrid : Form
    {
        public int m_width;
        public int m_height;
        public int m_noofrows;
        public int m_noofcols;
        public int m_xoffset;
        public int m_yoffset;
        public int m_size;
        public int size = 8;
        public const int DEFAULT_X_OFFSET = 100;
        public const int DEFAULT_Y_OFFSET = 50;
        public const int DEFAULT_NO_ROWS = 2;
        public const int DEFAULT_NO_COLS = 2;
        public const int DEFAULT_WIDTH = 50;
        public const int DEFAULT_HEIGHT = 50;
        public FormMatrixGrid()
        {
            Initialize();
            InitializeComponent();
            bThreadStatus = false;
        }
        public void Initialize()
        {
            m_noofrows = DEFAULT_NO_ROWS;
            m_noofcols = DEFAULT_NO_COLS;
            m_xoffset = DEFAULT_X_OFFSET;
            m_yoffset = DEFAULT_X_OFFSET;
            m_width = DEFAULT_WIDTH;
            m_height = DEFAULT_HEIGHT;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CounterThread = new Thread(new ThreadStart(ThreadCounter));
            CounterThread.Start();
            bThreadStatus = true;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CounterThread.Suspend();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CounterThread.Resume();
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_size = 4; 
        }

        private void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_size = 5;
        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            m_size = 6;
        }

        private void x6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_size = 7;
        }
        private void x7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_size = 8;
        }
        public void ThreadCounter()
        {
            Graphics boardLayout = this.CreateGraphics();
            Pen layoutPen = new Pen(color: Color.DarkBlue);
            layoutPen.Width = 5;
            long m_icounter = 1;
            while (true)
            {
                if (m_noofrows == m_size)//(m_noofcols==m_size)
                {
                    boardLayout.Clear(color: Color.White);
                    m_noofrows = 2;
                    m_noofcols = 2;
                }
                if (m_noofrows == size)//(m_noofcols==size)
                {
                    boardLayout.Clear(color: Color.White);
                    m_noofrows = 2;
                    m_noofcols = 2;
                }
                int x = DEFAULT_X_OFFSET;
                int y = DEFAULT_Y_OFFSET;
                for (int i = 0; i <= m_noofrows; i++)
                {
                    boardLayout.DrawLine(layoutPen, x, y, x + this.m_width * this.m_noofcols, y);
                    y = y + m_height;
                }
                x = DEFAULT_X_OFFSET;
                y = DEFAULT_Y_OFFSET;
                for (int j = 0; j <= m_noofcols; j++)
                {
                    boardLayout.DrawLine(layoutPen, x, y, x, y + this.m_height * this.m_noofrows);
                    x = x + this.m_width;
                }
                m_icounter++;
                m_noofrows++;
                m_noofcols++;
                Thread.Sleep(500);
            }
            
        }

        
    }
}
