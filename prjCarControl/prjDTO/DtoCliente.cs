using System;
using System.Data;

namespace prjDTO
{
    public class DtoCliente
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string CPFCliente { get; set; }
        public string TelefoneCliente { get; set; }

        /// <summary>
        public char EspecificacaoCliente { get; set; }

        /// 
        /// </summary>
        /// <param name="row"></param>
        public DtoCliente(DataRow row)
        {
            try
            {
                this.IdCliente = int.Parse(row["id_cliente"].ToString());
                this.NomeCliente = row["nome_cliente"].ToString();
                this.CPFCliente = row["CPF_cliente"].ToString();
                this.TelefoneCliente = row["telefone_cliente"].ToString();
                this.EspecificacaoCliente = Convert.ToChar(row["especificacao_cliente"].ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_IdCliente"></param>
        /// <param name="p_NomeCliente"></param>
        /// <param name="p_CPFCliente"></param>
        /// <param name="p_TelefoneCliente"></param>
        /// /// <param name="p_EspecificacaoCliente"></param>
        public DtoCliente(int p_IdCliente , string p_NomeCliente, string p_CPFCliente, string p_TelefoneCliente, char p_EspecificacaoCliente)
        {
            try
            {
                this.IdCliente = p_IdCliente;
                this.NomeCliente = p_NomeCliente;
                this.CPFCliente = p_CPFCliente;
                this.TelefoneCliente = p_TelefoneCliente;
                this.EspecificacaoCliente = p_EspecificacaoCliente;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DtoCliente()
        {
            // TODO: Complete member initialization
        }
    }
}
