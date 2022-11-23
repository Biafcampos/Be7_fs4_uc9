using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Be7_fs4_uc9.Interfaces;

namespace Be7_fs4_uc9.Classes
{
    public class PessoaFisica : Pessoa, IPessoaF
    {
        public string ?cpf { get; set; }
        public string ?dataNascimento { get; set; }

        public string caminho { get; private set; } = "Database/PessoaFi.csv";

        public override float PagarImposto(float rendimento)
        {
            
            if (rendimento <= 1500)
            {
                return 0;
            }
            else if(rendimento > 1500 && rendimento <= 3500){
                return (rendimento / 100) * 2;    
            }
            else if(rendimento > 3500 && rendimento <= 6000){
                return (rendimento / 100) * 3.5f;
            }
            else{
                return (rendimento / 100) * 5;
            }
        }
        

        public bool ValidarDataNascimento(DateTime dataNasc)
        {
            DateTime dataAtual= DateTime.Today;
            double anos = (dataAtual - dataNasc).TotalDays /365;
            if(anos >= 18){
                return true;
            }
            return false;
        }
        

        public bool ValidarDataNascimento(string dataNasc)
        {
            DateTime dataConvertida;
            
            if(DateTime.TryParse(dataNasc, out dataConvertida)){
                DateTime dataAtual = DateTime.Today;
                double anos = (dataAtual - dataConvertida).TotalDays /365;
                if(anos >= 18){
                    return true;
                }
                return false;
            }
            return false;  
        }

        public void Inserir(PessoaFisica pf)
        {
            VerificarPastaArquivo(caminho);

            string[] pjString = {$"{pf.nome},{pf.cpf},{pf.dataNascimento},{pf.rendimento},{pf.endereco.logradouro},{pf.endereco.numero},{pf.endereco.complemento},{pf.endereco.endComercial}"};

            File.AppendAllLines(caminho, pjString);
        }

        public List<PessoaFisica> Ler()
        {
            VerificarPastaArquivo(caminho);

            List<PessoaFisica> listaPf = new List<PessoaFisica>();

            string[] linhas = File.ReadAllLines(caminho);


            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaFisica cadaPf = new PessoaFisica();
                Endereco cadaEnd = new Endereco();

                cadaPf.nome = atributos[0];
                cadaPf.cpf = atributos[1];
                cadaPf.dataNascimento = atributos[2];
                cadaPf.rendimento = float.Parse(atributos[3]);
                cadaEnd.logradouro = atributos[4];
                cadaEnd.numero = int.Parse(atributos[5]);
                cadaEnd.complemento = atributos[6];
                cadaEnd.endComercial = bool.Parse(atributos[7]);
                cadaPf.endereco = cadaEnd;
                listaPf.Add(cadaPf);
            }
            return listaPf;
        }
        
    }
}
