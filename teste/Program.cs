using System;
using System.Diagnostics;

namespace teste
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = new string[]
            {
               "wmic cpu get name",
               "wmic memorychip get capacity",
               "wmic diskdrive get mediatype",
               "wmic diskdrive get size",
               "wmic diskdrive get status",
               "wmic bios get serialnumber",
               "wmic csproduct get name",
               "wmic csproduct get vendor",
            };
            //Instancia o cmd
            Process cmd = new Process();
            //Abre o cmd
            cmd.StartInfo.FileName = "cmd.exe";            
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            //Cria a janela
            cmd.StartInfo.CreateNoWindow = true;
            //Não esecuta no power shell
            cmd.StartInfo.UseShellExecute = false;            
            cmd.Start();
            //Executa o comando dentro do cmd aberto
            foreach(string comando in array)
            {
                cmd.StandardInput.WriteLine(comando);
            }
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            string teste = cmd.StandardInput.ToString();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            //Necessário para o cmd não fechar após executar a requisição            
            Console.ReadKey();
        }
    }
}