using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyApp.Models
{
    public class Class1
    {
        public int Idade { get; private set; }
        public int Distancia { get; private set; }
        public string? descricaoIdade { get; private set; }
        public bool FreteGratis => ValidaFrete();
        private bool ValidaFrete()
        {
            if (Distancia > 10)
                return true;

            return false;
        }

        Class1(int idade, int distancia)
        {
            Idade = idade;

            if (idade > 30)
                descricaoIdade = "Pessoa Maior de 30";
            else
                descricaoIdade = "Pessoa Menor de 30";
           
            Distancia = distancia;
        }
        public static Class1 CriarNovaIdade(int idade, int distancia)
            => new Class1(idade, distancia);
    }
}
