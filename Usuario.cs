using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SisLog
{
    public class Usuario
    {
        public string Id { get; set; }
        public string SenhaOriginal { get; set; }
                
        // public Usuario(string id, string senhaOriginal) 
        // {
        //     this.Id = id;
        //     this.SenhaOriginal = senhaOriginal;
               
        // }

        public bool Cadastro()
        {
            bool efetuado = false;
            StreamWriter arquivo = null;
            
            try{
                string senhaModificada = encripSenha(this.SenhaOriginal);

                arquivo = new StreamWriter("cadUsuario.csv", true);
                arquivo.WriteLine(Id + ";" + senhaModificada);

                efetuado = true;
            }
            catch(Exception ex){
                throw new Exception("Erro ao tentar cadastrar." + ex.Message);
            }
            finally{
                arquivo.Close();
            }
            return efetuado;
        }

        public string Login()
        {
            Console.Write("Digite o seu ID: ");
            string id = Console.ReadLine();
            Console.Write("Digite a senha: ");
            string senhaOriginal = Console.ReadLine();


            string efetuado = "Login efetuado";
            StreamReader cadUsuario = null;

            try
            {
                cadUsuario = new StreamReader("cadUsuario.csv", Encoding.Default);
                string linha = "";
                while((linha = cadUsuario.ReadLine()) != null){
                    string[] dados = linha.Split(';');
                    if(dados[0] == id && dados[1] == encripSenha(this.SenhaOriginal)){
                        
                        
                        Console.WriteLine("Login efetuado");

                        break;
                    }
                }
            }
            catch(Exception ex){
                throw new Exception("Erro ao tentar cadastrar." + ex.Message);
            }
            finally{
                cadUsuario.Close();
            }
            return efetuado;
        }

        static string encripSenha(string senha){
            byte[] senhaOriginal;
            byte[] senhaModificada;
            SHA512 md5;

            senhaOriginal = Encoding.Default.GetBytes(senha);
            md5 = SHA512.Create();
            senhaModificada = md5.ComputeHash(senhaOriginal);
            return Convert.ToBase64String(senhaModificada);
        
        }
    }
}