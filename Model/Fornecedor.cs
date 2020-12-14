using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiraAPP.Model

{
    class Fornecedor
    {
        int id;
        string inscricaoEstadual;
        string nomeFantasia;
        string uf;
        string numero;
        string complemento;
        string bairro;
        string cidade;
        int cep;
        int statusAtivo;
        string cnpj;
        string rua;

        public int Id { get { return id; } set { id = value; } }
        public string InscricaoEstadual { get { return inscricaoEstadual; } set { inscricaoEstadual = value; } }
        public string NomeFantasia { get { return nomeFantasia; } set { nomeFantasia = value; } }
        public string Uf { get { return uf; } set { uf = value; } }
        public string Rua { get { return rua; } set { rua = value; } }

        public string Numero { get { return numero; } set { numero = value; } }
        public string Complemento { get { return complemento; } set { complemento = value; } }

        public string Bairro { get { return bairro; } set { bairro = value; } }
        public string Cidade { get { return cidade; } set { cidade = value; } }
        public int Cep { get { return cep; } set { cep = value; } }

        public int StatusAtivo { get { return statusAtivo; } set { statusAtivo = value; } }
        public string Cnpj { get { return cnpj; } set { cnpj = value; } }
   

    }
}
