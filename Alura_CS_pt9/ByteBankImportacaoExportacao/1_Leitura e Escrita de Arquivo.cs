using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; // IO = Input e Output

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void LidandoComFileStreamDiretamente()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024]; // 1 kb
                var numeroDeBytesLidos = -1;

                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}");
                    EscreverBuffer(buffer, numeroDeBytesLidos);
                }
            }
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = Encoding.Default;

            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);

            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }

        static void LerArquivo(string nome, char separator = ';')
        {
            var enderecoDoArquivo = nome;

            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    ContaCorrente conta = ConverterStringParaContaCorrente(linha, separator);
                    
                    string msg = $"Agência : {conta.Agencia} número: {conta.Numero} saldo: {conta.Saldo} nome do titular: {conta.Titular.Nome} ";
                    Console.WriteLine(msg);
                }
            }

        }
        static void CriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "contasexportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.Write("123;456123789;12.35;Wanderson Silva");
            }
        }
        static void CriarArquivo(string nome = "contasExportadas.csv")
        {
            using (var fluxoDeArquivo = new FileStream(nome, FileMode.Create))
            {
                var contaComoString = "456;78945;4785.50;Gustavo Santos";
                var bytes = Encoding.Unicode.GetBytes(contaComoString);
                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        /// <summary>Converte usando ; (ponto e vígula) como separador padrão.</summary>
        static ContaCorrente ConverterStringParaContaCorrente(string linha, char separator = ';')
        {
            var campos = linha.Split(separator);

            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var quantia = double.Parse(campos[2]);
            var nome = campos[3];

            ContaCorrente conta = new ContaCorrente(agencia, numero);
            Cliente cliente = new Cliente();
            cliente.Nome = nome;
            conta.Titular = cliente;
            conta.Depositar(quantia);
            return conta;
        }

    }
}