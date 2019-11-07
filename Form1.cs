using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace progMois
{
    public partial class Form1 : Form
    {    
        const string file_name = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.ResultBlock = new System.Windows.Forms.TextBox();
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
            this.ResultBlock.Size = new System.Drawing.Size(446, 302);
            this.ResultBlock.TabIndex = 0;
            this.ResultBlock.TextChanged += new System.EventHandler(this.ResultBlock_TextChanged);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(470, 326);
            this.Controls.Add(this.ResultBlock);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private enum c_state { H, CS, VS, ER };

        void analyze_file()
        {
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
                                if (simb == '1' || simb == '0'){
                                    CS = c_state.CS;
                                }
                                break;
                            }

                        }
                        i++;
                    } while (/*CS != c_state.S &&*/ CS != c_state.ER);

                }
            }
            catch (FileNotFoundException ex)
            {
                ResultBlock.Text = ex.Message;
            }
        }

        private void ResultBlock_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
