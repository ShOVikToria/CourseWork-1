namespace KursovaRobota
{
    partial class EightQueensInterface
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EightQueensInterface));
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            checkBox1 = new CheckBox();
            label3 = new Label();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            label4 = new Label();
            button9 = new Button();
            saveFileDialog1 = new SaveFileDialog();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.Ivory;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(24, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(603, 603);
            dataGridView1.TabIndex = 0;
            dataGridView1.Click += dataGridView1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Ivory;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(657, 74);
            button1.Name = "button1";
            button1.Size = new Size(163, 31);
            button1.TabIndex = 2;
            button1.Text = "Забрати останнього ферзя";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Ivory;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(657, 111);
            button2.Name = "button2";
            button2.Size = new Size(75, 44);
            button2.TabIndex = 3;
            button2.Text = "Алгоритм А*";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Ivory;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Location = new Point(661, 305);
            button3.Name = "button3";
            button3.Size = new Size(163, 23);
            button3.TabIndex = 4;
            button3.Text = "Почати спочатку";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(24, 633);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(197, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "відображати клітинки під боєм";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(633, 630);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 7;
            // 
            // button4
            // 
            button4.BackColor = Color.Ivory;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Location = new Point(657, 24);
            button4.Name = "button4";
            button4.Size = new Size(163, 44);
            button4.TabIndex = 8;
            button4.Text = "Згенерувати початкову розстановку";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Ivory;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Location = new Point(660, 161);
            button5.Name = "button5";
            button5.Size = new Size(160, 29);
            button5.TabIndex = 9;
            button5.Text = "Записати у файл";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Ivory;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Location = new Point(660, 196);
            button6.Name = "button6";
            button6.Size = new Size(163, 39);
            button6.TabIndex = 10;
            button6.Text = "Почати покроковий перегляд";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.Ivory;
            button7.FlatStyle = FlatStyle.Popup;
            button7.Location = new Point(661, 241);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 11;
            button7.Text = "<<";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.Ivory;
            button8.FlatStyle = FlatStyle.Popup;
            button8.Location = new Point(749, 241);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 12;
            button8.Text = ">>";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(723, 277);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 13;
            // 
            // button9
            // 
            button9.BackColor = Color.Ivory;
            button9.FlatStyle = FlatStyle.Popup;
            button9.Location = new Point(749, 111);
            button9.Name = "button9";
            button9.Size = new Size(71, 44);
            button9.TabIndex = 14;
            button9.Text = "Алгоритм RBFS";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Tag = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(657, 348);
            label1.Name = "label1";
            label1.Size = new Size(172, 15);
            label1.TabIndex = 15;
            label1.Text = "Практична часова складність:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(723, 374);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(684, 403);
            label5.Name = "label5";
            label5.Size = new Size(116, 15);
            label5.TabIndex = 17;
            label5.Text = "Ємнісна складність:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(724, 435);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(353, 633);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 19;
            label7.Text = "label7";
            // 
            // EightQueensInterface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(844, 661);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button9);
            Controls.Add(label4);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(860, 700);
            MinimumSize = new Size(860, 700);
            Name = "EightQueensInterface";
            Text = "Задача про 8 ферзів";
            Load += EightQueensInterface_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Label label4;
        private Label label3;
        private CheckBox checkBox1;
        private DataGridView dataGridView1;
        private Button button9;
        private SaveFileDialog saveFileDialog1;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}
