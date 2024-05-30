using EightQueensSolver;
using EightQueensSolver.Entities;

namespace KursovaRobota
{
    public partial class EightQueensInterface : Form
    {
        Solver Solver;
        public EightQueensInterface()
        {
            Solver = new Solver();
            InitializeComponent();
        }
                
        private void EightQueensInterface_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ColumnCount = 10;
            dataGridView1.RowCount = 10;
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 38);
            dataGridView1.Rows[0].Height = 60;
            dataGridView1.Rows[9].Height = 60;
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[9].Width = 60;
            for (int i = 1; i < 9; i++)
            {
                dataGridView1.Columns[i].Width = 60;
                dataGridView1.Rows[i].Height = 60;
                dataGridView1.Rows[0].Cells[i].Value = char.ConvertFromUtf32(i + 96);
                dataGridView1.Rows[i].Cells[0].Value = (9 - i);
                dataGridView1.Rows[9].Cells[i].Value = char.ConvertFromUtf32(i + 96);
                dataGridView1.Rows[i].Cells[9].Value = (9 - i);
                dataGridView1.Rows[i].Cells[0].Style.ForeColor = Color.Gray;
                dataGridView1.Rows[i].Cells[9].Style.ForeColor = Color.Gray;
                dataGridView1.Rows[0].Cells[i].Style.ForeColor = Color.Gray;
                dataGridView1.Rows[9].Cells[i].Style.ForeColor = Color.Gray;
            }


            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.White;
                    }
                }
            }

            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.MultiSelect = false;
            label1.Visible = false;
            label5.Visible = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button6.Enabled = false;
            button5.Enabled = false;
        }

        //Клік по клітинці дошки
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int x = dataGridView1.CurrentCell.RowIndex;
            int y = dataGridView1.CurrentCell.ColumnIndex;
            if (x != 0 && x != 9 && y != 0 && y != 9 && dataGridView1.Rows[x].Cells[y].Value != "♕" && Solver.Queens.Count < 8)
            {
                Solver.Queens.Add(new Queen(x, y));
            }
            else if(dataGridView1.Rows[x].Cells[y].Value == "♕")
            {
                MessageBox.Show("У цій клітинці уже стоїть ферзь.");
            }
            else if (x == 0 || x == 9 || y == 0 || y == 9)
            {
                MessageBox.Show("Ця клітинка не належить ігровому полю дошки, оберіть іншу.");
            }
            else if (Solver.Queens.Count == 8) MessageBox.Show("На дошці вже є 8 ферзів.");

            UpdateGrid();
            dataGridView1.ClearSelection();
        }

        public void UpdateGrid()
        {
            for (int i = 1; i <= Solver.N; i++)
            {
                for (int j = 1; j <= Solver.N; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }
            foreach (Queen queen in Solver.Queens)
            {
                dataGridView1.Rows[queen.row].Cells[queen.column].Value = "♕";
            }

            bool[,] underBattle = new bool[9, 9];
            for (int i = 1; i <= Solver.N; i++)
            {
                for (int j = 1; j <= Solver.N; j++)
                {
                    underBattle[i, j] = false;
                }
            }

            if (checkBox1.Checked == true)
            {
                for (int k = 0; k < Solver.Queens.Count; k++)
                {
                    for (int i = 1; i <= Solver.N; i++)
                    {
                        for (int j = 1; j <= Solver.N; j++)
                        {
                            if (!(Solver.Queens[k].row == i && Solver.Queens[k].column == j))
                            {
                                if (Solver.Queens[k].row == i || Solver.Queens[k].column == j 
                                    || Math.Abs(Solver.Queens[k].row - i) == Math.Abs(Solver.Queens[k].column - j))
                                {
                                    underBattle[i, j] = true;
                                }
                            }
                        }
                    }
                }

                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if ((i + j) % 2 != 0)
                        {
                            if (underBattle[i, j])
                            {
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Black;
                            }
                        }
                        else
                        {
                            if (underBattle[i, j])
                            {
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightBlue;
                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if ((i + j) % 2 != 0)
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        // Забрати останнього ферзя
        private void button1_Click(object sender, EventArgs e)
        {
            if (Solver.Queens.Count != 0)
            {
                Queen lastQueen = Solver.Queens.Last();
                Solver.Queens.Remove(lastQueen);
                UpdateGrid();
            }
            else { MessageBox.Show("На полі немає ферзів"); }

        }

        //Виклик алгоритму А*
        private void button2_Click(object sender, EventArgs e)
        {
            if (Solver.Queens.Count == 8)
            {
                Solver.CountTimeComplexity = 0;
                Solver.CountCapacitiveComplexity = 0;
                Solver.AllStates.Clear();
                List<Queen> start = new List<Queen>();
                for (int t = 0; t < Solver.N; t++)
                {
                    int x = Solver.Queens[t].row;
                    int y = Solver.Queens[t].column;
                    start.Add(new Queen(x, y));
                }
                Solver.AllStates.Add(start);

                Solver.AStar();
                UpdateGrid();
                label1.Visible = true;
                label5.Visible = true;
                
                label2.Text = Solver.CountTimeComplexity.ToString();
                label6.Text = Solver.CountCapacitiveComplexity.ToString();
                button1.Enabled = false;
                button4.Enabled = false;
                button9.Enabled = false;
                button6.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                MessageBox.Show("На дошці менше 8 ферзів.");
            }
        }

        //Почати спочатку
        private void button3_Click(object sender, EventArgs e)
        {
            Solver.Queens.Clear();
            Solver.AllStates.Clear();
            UpdateGrid();
            label1.Visible = false;
            label5.Visible = false;
            label2.Text = string.Empty;
            label3.Text = string.Empty;
            label4.Text = string.Empty;
            label6.Text = string.Empty;
            button6.Enabled = false;
            button5.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button1.Enabled = true;
            button4.Enabled = true;
            button9.Enabled = true;
            button2.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        //Генерація початкової перестановки
        private void button4_Click(object sender, EventArgs e)
        {
            if (Solver.Queens.Count > 0)
            {
                MessageBox.Show("На полі є ферзі. Очистіть поле для генерації. Це можна зробити за допомогою кнопки \"Почати спочатку\".");
            }
            else
            {
                button1.Enabled = false;
                Random random = new Random();
                for (int i = 0; i < Solver.N; i++)
                {
                    int x = random.Next(1, Solver.N + 1);
                    int y = random.Next(1, Solver.N + 1);
                    while (dataGridView1.Rows[x].Cells[y].Value == "♕")
                    {
                        x = random.Next(1, Solver.N + 1);
                        y = random.Next(1, Solver.N + 1);
                    }
                    dataGridView1.Rows[x].Cells[y].Value = "♕";
                    Solver.Queens.Add(new Queen(x, y));
                }
                UpdateGrid();
            }
        }

        //Записати результат у файл
        private void button5_Click(object sender, EventArgs e)
        {
            string name = "name.txt";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовий файл(*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                name = saveFileDialog.FileName;
            }

            StreamWriter sw = new StreamWriter(name);
            for (int i = 0; i < Solver.AllStates.Count; i++)
            {
                for (int k = 1; k <= Solver.N; k++)
                {
                    for (int l = 1; l <= Solver.N; l++)
                    {
                        bool flag = false;
                        for (int j = 0; j < Solver.N; j++)
                        {
                            if (Solver.AllStates[i][j].row == k && Solver.AllStates[i][j].column == l)
                            {
                                flag = true;
                            }
                        }
                        if (flag)
                        {
                            sw.Write("Q ");
                        }
                        else { sw.Write(". "); }
                    }
                    sw.WriteLine();
                }
                sw.WriteLine();
            }
            sw.Close();
        }

        private int number = 1;
        private int n;

        // Кнопка "Назад"
        private void button7_Click(object sender, EventArgs e)
        {
            button8.Enabled = true;
            number--;
            Solver.Queens.Clear();
            for (int i = 0; i < Solver.N; i++)
            {
                int x = Solver.AllStates[number - 1][i].row;
                int y = Solver.AllStates[number - 1][i].column;
                Solver.Queens.Add(new Queen(x, y));
            }
            UpdateGrid();
            label4.Text = number.ToString() + " з " + n.ToString();
            if (number == 1)
            {
                button7.Enabled = false;
            }
        }

        //Почати покроковий перегляд
        private void button6_Click(object sender, EventArgs e)
        {
            Solver.Queens.Clear();
            number = 1;
            n = Solver.AllStates.Count;
            button7.Enabled = false;
            if (n == 1) button8.Enabled = false;
            else button8.Enabled = true;
            for (int i = 0; i < Solver.N; i++)
            {
                int x = Solver.AllStates[0][i].row;
                int y = Solver.AllStates[0][i].column;
                Solver.Queens.Add(new Queen(x, y));
            }
            UpdateGrid();
            label4.Text = "1 з " + n.ToString();
        }

        // Кнопка "Вперед"
        private void button8_Click(object sender, EventArgs e)
        {
            button7.Enabled = true;
            number++;
            Solver.Queens.Clear();
            for (int i = 0; i < Solver.N; i++)
            {
                int x = Solver.AllStates[number - 1][i].row;
                int y = Solver.AllStates[number - 1][i].column;
                Solver.Queens.Add(new Queen(x, y));
            }
            UpdateGrid();
            label4.Text = number.ToString() + " з " + n.ToString();
            if (n == number)
            {
                button8.Enabled = false;
            }
        }

        //Виклик алгоритму RBFS
        private void button9_Click(object sender, EventArgs e)
        {
            if (Solver.Queens.Count == 8)
            {
                Solver.SolveWithRBFS();
                UpdateGrid();
                label1.Visible = true;
                label5.Visible = true;
                label2.Text = Solver.CountTimeComplexity.ToString();
                label6.Text = Solver.CountCapacitiveComplexity.ToString();
                button1.Enabled = false;
                button4.Enabled = false;
                button2.Enabled = false;
                button6.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                MessageBox.Show("На полі менше 8 ферзів.");
            }
        }
    }
}
