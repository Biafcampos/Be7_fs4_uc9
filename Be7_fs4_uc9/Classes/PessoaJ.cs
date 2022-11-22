using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Be7_fs4_uc9.Interfaces;

namespace Be7_fs4_uc9.Classes
{
     public class PessoaJ : Pessoa, IPessoaJ
    {
        public string ?cnpj { get; set; }
        public string ?razaoSocial { get; set; }
        
        public string caminho { get; private set; } = "Database/PessoaJu.csv";
        
        public override float PagarImposto(float rendimento)
        {
          
            if (rendimento <= 1500)
            {
                return (rendimento / 100) * 3; 
            }
            else if(rendimento > 1500 && rendimento <= 3500){
                return (rendimento / 100) * 5; 
            }
            else if(rendimento > 3500 && rendimento <= 6000){
                return (rendimento / 100) * 7;
            }
            else{
                return (rendimento / 100) * 9;
            }
        }

   

    public bool ValidarCnpj(string cnpj)
        {
            if(Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {
                if(cnpj.Length == 18)
                {
                    if(cnpj.Substring(11,4) == "0001"){
                        return true;
                    }
                }
                else if(cnpj.Length == 14)
                {
                    if(cnpj.Substring(8,4) == "0001"){
                        return true;
                    }
                }
            }
        return false;
        }   

        public void Inserir(PessoaJ pj)
        {
            VerificarPastaArquivo(caminho);

            string[] pjString = {$"{pj.nome},{pj.cnpj},{pj.razaoSocial}"};

            File.AppendAllLines(caminho, pjString);
        }

        public List<PessoaJ> Ler()
        {
            List<PessoaJ> listaPj = new List<PessoaJ>();

            string[] linhas = File.ReadAllLines(caminho);


            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaJ cadaPj = new PessoaJ();
                
                cadaPj.nome = atributos[0];
                cadaPj.cnpj = atributos[1];
                cadaPj.razaoSocial = atributos[2];

                listaPj.Add(cadaPj);
            }
            return listaPj;
        }
    }

    
}