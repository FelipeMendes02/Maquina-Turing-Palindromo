using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace Exercicio2_prova2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private GroupBox groupBoxCabecalho;
        private Label labelTitulo;
        private GroupBox groupBoxEntrada;
        private TextBox textBoxEntrada;
        private Button buttonTestar;
        private Label labelResposta;
        private ListBox listBoxLog;
        private PictureBox pictureBoxAutomato;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBoxCabecalho = new GroupBox();
            labelTitulo = new Label();
            groupBoxEntrada = new GroupBox();
            textBoxEntrada = new TextBox();
            buttonTestar = new Button();
            labelResposta = new Label();
            listBoxLog = new ListBox();
            pictureBoxAutomato = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAutomato).BeginInit();
            SuspendLayout();
            // 
            // groupBoxCabecalho
            // 
            groupBoxCabecalho.Location = new Point(12, 12);
            groupBoxCabecalho.Name = "groupBoxCabecalho";
            groupBoxCabecalho.Size = new Size(760, 60);
            groupBoxCabecalho.TabIndex = 0;
            groupBoxCabecalho.TabStop = false;
            groupBoxCabecalho.Enter += groupBoxCabecalho_Enter;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTitulo.Location = new Point(10, 20);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(373, 20);
            labelTitulo.TabIndex = 1;
            labelTitulo.Text = "RECONHECIMENTO DE PALINDROMOS NUMERICOS";
            // 
            // groupBoxEntrada
            // 
            groupBoxEntrada.Location = new Point(12, 80);
            groupBoxEntrada.Name = "groupBoxEntrada";
            groupBoxEntrada.Size = new Size(760, 60);
            groupBoxEntrada.TabIndex = 2;
            groupBoxEntrada.TabStop = false;
            groupBoxEntrada.Text = "Entrada do Autômato";
            // 
            // textBoxEntrada
            // 
            textBoxEntrada.Location = new Point(25, 105);
            textBoxEntrada.Name = "textBoxEntrada";
            textBoxEntrada.Size = new Size(200, 27);
            textBoxEntrada.TabIndex = 3;
            // 
            // buttonTestar
            // 
            buttonTestar.Location = new Point(240, 104);
            buttonTestar.Name = "buttonTestar";
            buttonTestar.Size = new Size(75, 25);
            buttonTestar.TabIndex = 4;
            buttonTestar.Text = "Reconhecer";
            buttonTestar.UseVisualStyleBackColor = true;
            buttonTestar.Click += buttonTestar_Click;
            // 
            // labelResposta
            // 
            labelResposta.AutoSize = true;
            labelResposta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelResposta.Location = new Point(330, 110);
            labelResposta.Name = "labelResposta";
            labelResposta.Size = new Size(27, 20);
            labelResposta.TabIndex = 5;
            labelResposta.Text = "---";
            // 
            // listBoxLog
            // 
            listBoxLog.FormattingEnabled = true;
            listBoxLog.Location = new Point(12, 150);
            listBoxLog.Name = "listBoxLog";
            listBoxLog.Size = new Size(760, 84);
            listBoxLog.TabIndex = 6;
            // 
            // pictureBoxAutomato
            // 
            pictureBoxAutomato.Image = (Image)resources.GetObject("pictureBoxAutomato.Image");
            pictureBoxAutomato.Location = new Point(12, 260);
            pictureBoxAutomato.Name = "pictureBoxAutomato";
            pictureBoxAutomato.Size = new Size(760, 280);
            pictureBoxAutomato.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAutomato.TabIndex = 0;
            pictureBoxAutomato.TabStop = false;
            // 
            // Form1
            // 
            ClientSize = new Size(784, 561);
            Controls.Add(pictureBoxAutomato);
            Controls.Add(listBoxLog);
            Controls.Add(labelResposta);
            Controls.Add(buttonTestar);
            Controls.Add(textBoxEntrada);
            Controls.Add(groupBoxEntrada);
            Controls.Add(labelTitulo);
            Controls.Add(groupBoxCabecalho);
            Name = "Form1";
            Text = "Autômato Finito Determinístico";
            ((System.ComponentModel.ISupportInitialize)pictureBoxAutomato).EndInit();
            ResumeLayout(false);
            PerformLayout();


        }

        #endregion
    }
}
