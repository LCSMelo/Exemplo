using System;
using System.Security.Cryptography;
using System.Text;

namespace SisLog
{
    class Program
    {
        static void Main(string[] args)
        {
            string sistema = "";
            do{
                Console.WriteLine("Bem vindo ao Sistema de Login");
                Console.WriteLine("1 - Cadastrar.");
                Console.WriteLine("2 - LogIn.");
                Console.WriteLine("3 - LogOut.");
                Console.WriteLine("9 - Sair do sistema.");

                sistema = Console.ReadLine();
                
                switch (sistema)
                {
                    case "1": 
                    {
                        Console.WriteLine("Cadastro de usuário.");
                        Console.Write("Digite o ID:");
                        string id = Console.ReadLine();
                        Console.Write("Digite a senha:");
                        string senhaOriginal = Console.ReadLine();

                        Usuario usuario = new Usuario();

                        usuario.Cadastro();

                        bool cadastrosucesso = usuario.Cadastro();
                        if(cadastrosucesso)
                            Console.WriteLine("Cadastro realizado com sucesso!");
                        else
                            Console.WriteLine("Ocorreu um erro, contate o administrador do sitema.");
                        break;

                    }
                    
                    case "2":
                    {
                        Usuario usuario = new Usuario();

                        usuario.Login();

                        bool cadastrosucesso = usuario.Cadastro();
                        if(cadastrosucesso)
                            Console.WriteLine("Login realizado com sucesso!");
                        else
                            Console.WriteLine("Ocorreu um erro, contate o administrador do sitema.");
                        break;

                    }

                    case "3":
                    {   
                        Console.Write("Digite o seu Id: ");
                        string Id = Console.ReadLine();
                        Console.Write("Digite a senha: ");
                        string senhaOriginal = Console.ReadLine();
                    }
                        break;      
                }
            
            }while (sistema != "9");
                   
        }
    }
}
