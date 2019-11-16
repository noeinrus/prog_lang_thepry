using System;
using System.IO;
using System.Windows.Forms;

namespace progMois
{
    public partial class Form1 : Form
    {    
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.ResultBlock = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ResultBlock
            // 
            this.ResultBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultBlock.Location = new System.Drawing.Point(12, 12);
            this.ResultBlock.Multiline = true;
            this.ResultBlock.Name = "ResultBlock";
            this.ResultBlock.Size = new System.Drawing.Size(446, 273);
            this.ResultBlock.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.Location = new System.Drawing.Point(12, 291);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(446, 23);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Старт";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(470, 326);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ResultBlock);
            this.Name = "Form1";
            this.Text = "ТЯП";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        const string file_name = "о";

        private enum c_state { H, CS, VS, ER };

        string analyze_file()
        {
            string res_str = "";
            if (file_name == "")
                res_str += "Задано пустое имя файла.";
            else
            try
            {
                using (StreamReader sr = new StreamReader(file_name))
                {
                    string line = sr.ReadToEnd();
                    c_state CS = c_state.H;
                    int i = 0;
                    do
                    {
                        char simb = line[i];
                        switch (CS)
                        {
                            case c_state.H:{
                                if (simb == '1' || simb == '0')
                                    CS = c_state.CS;
                                else
                                    CS = c_state.ER;
                                res_str += "H; ";
                                break;
                            }
                        }
                        i++;
                    } while (/*CS != c_state.S &&*/ CS != c_state.ER);
                    if (CS == c_state.ER)
                        res_str += "ERROR! ";
                }
            }
            catch (FileNotFoundException ex)
            {
                res_str += "\r\n" + ex.Message;
            }
            return res_str;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ResultBlock.Text = analyze_file();
        }
    }
}
