using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio2_prova2
{
    internal class MaquinaTuringPalindromo
    {
        // Estados (mantendo nomes “teóricos” traduzidos)
        private enum Estado
        {
            q0, q_m0, q_m1, q_m2, q_m3,
            q_se0, q_se1, q_se2, q_se3,
            q_c0, q_c1, q_c2, q_c3,
            q_ret, q_sm, q_nc,
            q_acc, q_rej
        }

        private const char BRANCO = 'B';
        private const char MARCA = 'X';

        private List<char> fita;
        private int posicaoCabecote;
        private Estado estadoAtual;

        // Aqui guardaremos cada passo (para exibir em listBoxLog)
        public List<string> passosExecucao;

        public MaquinaTuringPalindromo()
        {
            fita = new List<char>();
            passosExecucao = new List<string>();
        }

        private char LerFita()
        {
            if (posicaoCabecote < 0 || posicaoCabecote >= fita.Count)
                return BRANCO;
            return fita[posicaoCabecote];
        }

        private void EscreverFita(char simbolo)
        {
            // Garante que a fita seja grande o suficiente
            while (posicaoCabecote >= fita.Count)
            {
                fita.Add(BRANCO);
            }
            // Se posicaoCabecote < 0, inserimos no índice 0 e ajustamos o cabeçote
            if (posicaoCabecote < 0)
            {
                fita.Insert(0, simbolo);
                posicaoCabecote = 0;
            }
            else
            {
                fita[posicaoCabecote] = simbolo;
            }
        }

        private void MoverCabecote(char direcao)
        {
            if (direcao == 'R') posicaoCabecote++;
            else if (direcao == 'L') posicaoCabecote--;
            // 'S' = sem mover
        }

        private string ObterStringFita()
        {
            string strFita = "";
            for (int i = 0; i < fita.Count; i++)
            {
                if (i == posicaoCabecote) strFita += "[";
                strFita += fita[i];
                if (i == posicaoCabecote) strFita += "]";
                strFita += " ";
            }
            if (posicaoCabecote >= fita.Count) strFita += "[B]"; // cabeça sobre branco no fim
            if (posicaoCabecote < 0) strFita = "[B] " + strFita; // cabeça sobre branco no início
            return strFita.Trim();
        }

        /// <summary>
        /// Processa a string de entrada (apenas dígitos '0','1','2','3') e devolve:
        ///   Item1 = true se aceitou (é palíndromo), false em caso contrário
        ///   Item2 = representação final da fita (para exibir)
        /// </summary>
        public Tuple<bool, string> ProcessarEntrada(string entrada)
        {
            // 1. Inicializa fita, posição do cabeçote e estado
            fita = entrada.ToList();
            posicaoCabecote = 0;
            estadoAtual = Estado.q0;
            passosExecucao.Clear();
            passosExecucao.Add($"Início: Estado={estadoAtual}, Fita: {ObterStringFita()}");

            int contadorPassos = 0;
            const int maximoPassos = 1000;

            while (estadoAtual != Estado.q_acc
                   && estadoAtual != Estado.q_rej
                   && contadorPassos < maximoPassos)
            {
                char simboloAtual = LerFita();
                char simboloEscrita = simboloAtual;
                char direcaoMovimento = 'S';
                Estado proximoEstado = estadoAtual;

                // 2. Transição δ (simplificada para o alfabeto {0,1,2,3})
                switch (estadoAtual)
                {
                    case Estado.q0:
                        if (simboloAtual == BRANCO)
                        {
                            proximoEstado = Estado.q_acc; // aceita fita vazia ou toda marcada
                        }
                        else if (simboloAtual == MARCA)
                        {
                            direcaoMovimento = 'R'; // pula marca
                        }
                        else if (simboloAtual == '0')
                        {
                            proximoEstado = Estado.q_m0;
                            simboloEscrita = MARCA;
                            direcaoMovimento = 'R';
                        }
                        else if (simboloAtual == '1')
                        {
                            proximoEstado = Estado.q_m1;
                            simboloEscrita = MARCA;
                            direcaoMovimento = 'R';
                        }
                        else if (simboloAtual == '2')
                        {
                            proximoEstado = Estado.q_m2;
                            simboloEscrita = MARCA;
                            direcaoMovimento = 'R';
                        }
                        else if (simboloAtual == '3')
                        {
                            proximoEstado = Estado.q_m3;
                            simboloEscrita = MARCA;
                            direcaoMovimento = 'R';
                        }
                        else
                        {
                            proximoEstado = Estado.q_rej; // símbolo inválido
                        }
                        break;

                    case Estado.q_m0:
                    case Estado.q_m1:
                    case Estado.q_m2:
                    case Estado.q_m3:
                        // Avança até encontrar branco (fim da parte útil)
                        if (simboloAtual != BRANCO && simboloAtual != MARCA)
                        {
                            direcaoMovimento = 'R';
                        }
                        else if (simboloAtual == MARCA)
                        {
                            direcaoMovimento = 'R'; // pula X
                        }
                        else /* branco */
                        {
                            direcaoMovimento = 'L';
                            if (estadoAtual == Estado.q_m0) proximoEstado = Estado.q_c0;
                            else if (estadoAtual == Estado.q_m1) proximoEstado = Estado.q_c1;
                            else if (estadoAtual == Estado.q_m2) proximoEstado = Estado.q_c2;
                            else if (estadoAtual == Estado.q_m3) proximoEstado = Estado.q_c3;
                        }
                        break;

                    case Estado.q_c0:
                        // comparar último símbolo não marcado com '0'
                        if (simboloAtual == MARCA)
                        {
                            direcaoMovimento = 'L';
                        }
                        else if (simboloAtual == '0')
                        {
                            proximoEstado = Estado.q_ret;
                            simboloEscrita = MARCA;
                            direcaoMovimento = 'L';
                        }
                        else if (simboloAtual == BRANCO)
                        {
                            proximoEstado = Estado.q_acc; // só havia um caractere
                        }
                        else
                        {
                            proximoEstado = Estado.q_rej;
                        }
                        break;
                    case Estado.q_c1:
                        if (simboloAtual == MARCA)
                        {
                            direcaoMovimento = 'L';
                        }
                        else if (simboloAtual == '1')
                        {
                            proximoEstado = Estado.q_ret;
                            simboloEscrita = MARCA;
                            direcaoMovimento = 'L';
                        }
                        else if (simboloAtual == BRANCO)
                        {
                            proximoEstado = Estado.q_acc;
                        }
                        else
                        {
                            proximoEstado = Estado.q_rej;
                        }
                        break;
                    case Estado.q_c2:
                        if (simboloAtual == MARCA)
                        {
                            direcaoMovimento = 'L';
                        }
                        else if (simboloAtual == '2')
                        {
                            proximoEstado = Estado.q_ret;
                            simboloEscrita = MARCA;
                            direcaoMovimento = 'L';
                        }
                        else if (simboloAtual == BRANCO)
                        {
                            proximoEstado = Estado.q_acc;
                        }
                        else
                        {
                            proximoEstado = Estado.q_rej;
                        }
                        break;
                    case Estado.q_c3:
                        if (simboloAtual == MARCA)
                        {
                            direcaoMovimento = 'L';
                        }
                        else if (simboloAtual == '3')
                        {
                            proximoEstado = Estado.q_ret;
                            simboloEscrita = MARCA;
                            direcaoMovimento = 'L';
                        }
                        else if (simboloAtual == BRANCO)
                        {
                            proximoEstado = Estado.q_acc;
                        }
                        else
                        {
                            proximoEstado = Estado.q_rej;
                        }
                        break;

                    case Estado.q_ret:
                        // volta à esquerda até encontrar a marca inicial (X)
                        if (simboloAtual != MARCA)
                        {
                            direcaoMovimento = 'L';
                        }
                        else
                        {
                            proximoEstado = Estado.q_nc;
                            direcaoMovimento = 'R';
                        }
                        break;

                    case Estado.q_nc:
                        // procura próximo símbolo não marcado à direita
                        if (simboloAtual == MARCA)
                        {
                            direcaoMovimento = 'R';
                        }
                        else if (simboloAtual == BRANCO)
                        {
                            proximoEstado = Estado.q_acc;
                        }
                        else
                        {
                            proximoEstado = Estado.q0;
                            direcaoMovimento = 'S';
                        }
                        break;
                }

                // 3. Registra o passo antes de efetuar escrita/movimento
                string detalhePasso = $"Passo {contadorPassos + 1}: " +
                                      $"Estado={estadoAtual}, Lido='{simboloAtual}', " +
                                      $"Escreve='{simboloEscrita}', Move='{direcaoMovimento}', " +
                                      $"PróxEstado={proximoEstado}";
                passosExecucao.Add(detalhePasso);

                // 4. Executa escrita (se necessário) e move o cabeçote
                if (simboloEscrita != simboloAtual
                    || posicaoCabecote < 0
                    || posicaoCabecote >= fita.Count)
                {
                    EscreverFita(simboloEscrita);
                }
                MoverCabecote(direcaoMovimento);

                // 5. Atualiza estado e registra conteúdo da fita
                estadoAtual = proximoEstado;
                passosExecucao.Add($"   -> Estado Atual={estadoAtual}, Fita: {ObterStringFita()}");

                contadorPassos++;
            }

            if (contadorPassos >= maximoPassos)
            {
                passosExecucao.Add("Limite máximo de passos atingido.");
                return Tuple.Create(false, ObterStringFita());
            }

            bool ehPalindromo = (estadoAtual == Estado.q_acc);
            passosExecucao.Add(
                $"Fim: EstadoFinal={estadoAtual}. Resultado: " +
                (ehPalindromo ? "PALÍNDROMO" : "NÃO É PALÍNDROMO")
            );

            return Tuple.Create(ehPalindromo, ObterStringFita());
        }
    }
}
