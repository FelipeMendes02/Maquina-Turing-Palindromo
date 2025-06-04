using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Exercicio2_prova2
{
    public partial class Form1 : Form
    {
        // declarando os atributos da classe Form
        private string stringEntrada = string.Empty;
        private int quantidadeCaracteresEntrada;
        private char[] charEntrada;

        public Form1()
        {
            InitializeComponent(); // Chamando o método para inicializar os controles
        }

        private void buttonTestar_Click(object sender, EventArgs e)
        {
            // 1. lê a entrada digitada
            stringEntrada = textBoxEntrada.Text;

            // 2. quantos caracteres ela tem
            quantidadeCaracteresEntrada = stringEntrada.Length;

            // 3. converte (se precisar)
            charEntrada = stringEntrada.ToCharArray();

            // 4. limpa o log
            listBoxLog.Items.Clear();

            // 5. exibe a “fita” (igual ao *** Fita = ) no log
            listBoxLog.Items.Add("*** Fita = " + stringEntrada);

            // 6. limpa o TextBox para próxima entrada
            textBoxEntrada.Text = "";

            // 7. instancia a Máquina de Turing e processa a entrada
            var maquina = new MaquinaTuringPalindromo();

            // antes de chamar, opcionalmente verifique se há símbolos inválidos:
            if (stringEntrada.Any(c => c < '0' || c > '3'))
            {
                MessageBox.Show(
                    "Entrada inválida. Use apenas os caracteres 0, 1, 2 ou 3.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 8. Processa e obtém (Item1 = bool aceita/rejeita; Item2 = string da fita final)
            var resultado = maquina.ProcessarEntrada(stringEntrada);
            bool ehPalindromo = resultado.Item1;
            string fitaFinal = resultado.Item2;

            // 9. exibe cada passo em listBoxLog
            foreach (string passo in maquina.passosExecucao)
            {
                listBoxLog.Items.Add(passo);
            }

            // 10. exibe a fita final (opcional)
            listBoxLog.Items.Add($"Fita Final: {fitaFinal}");

            // 11. coloca “PALÍNDROMO” ou “NÃO É PALÍNDROMO” em labelResposta
            labelResposta.Text = ehPalindromo ? "PALÍNDROMO" : "NÃO É PALÍNDROMO";
        }

        private void groupBoxCabecalho_Enter(object sender, EventArgs e)
        {
            // (permanece vazio, conforme Designer)
        }
    }
}
