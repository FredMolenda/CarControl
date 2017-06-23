using System;
using System.Data;

namespace prjDTO
{
    public class DtoRegistro
    {
        public int IdRegistro { get; set; }
        public DateTime EntradaVagasRegistro { get; set; }
        public DateTime SaidaVagasRegistro { get; set; }
        public string MarcaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public string PlacaVeiculo { get; set; }
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string CPFCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public char EspecificacaoCliente { get; set; }
        public int IdVeiculo { get; set; }
        public string NomeTipoVaga { get; set; }
        public int IdTipoVaga { get; set; }
        public int IdVaga { get; set; }
        public int NumeroVaga { get; set; }
        public decimal ValorPrecoRegistro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public DtoRegistro(DataRow row)
        {
            try
            {
                this.IdRegistro = int.Parse(row["id_registro"].ToString());
                this.EntradaVagasRegistro = DateTime.Parse(row["entrada_registro"].ToString());
                this.SaidaVagasRegistro = DateTime.Parse(row["saida_registro"].ToString());
                this.MarcaVeiculo = row["marca_veiculo"].ToString();
                this.ModeloVeiculo = row["modelo_veiculo"].ToString();
                this.PlacaVeiculo = row["placa_veiculo"].ToString();
                this.NomeCliente = row["nome_cliente"].ToString();
                this.CPFCliente = row["CPF_cliente"].ToString();
                this.TelefoneCliente = row["telefone_cliente"].ToString();
                this.EspecificacaoCliente = Convert.ToChar(row["especificacao_cliente"].ToString());
                this.NomeTipoVaga = row["nome_tipo_vaga"].ToString();
                this.NumeroVaga = int.Parse(row["numero_vaga"].ToString());
                this.ValorPrecoRegistro = decimal.Parse(row["preco"].ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_NumeroRegistro"></param>
        /// <param name="p_MarcaVeiculoRegistro"></param>
        /// <param name="p_ModeloVeiculoRegistro"></param>
        /// <param name="p_PlacaVeiculoRegistro"></param>
        /// <param name="p_NomeClienteRegistro"></param>
        /// <param name="p_CPFClienteRegistro"></param>
        /// <param name="p_NumeroClienteRegistro"></param>
        /// <param name="p_EntradaVagaRegistro"></param>
        /// <param name="p_SaidaVagaRegitsro"></param>
        /// <param name="p_TipoVagaRegistro"></param>
        /// <param name="p_ValorPrecoRegistro"></param>
        /// 
        public DtoRegistro(DateTime p_EntradaVagasRegistro, DateTime p_SaidaVagasRegistro, int p_IdCliente, int p_IdVeiculo, int p_IdTipoVaga, int p_IdVaga, decimal p_ValorPrecoRegistro)
        {
            try
            {
                this.EntradaVagasRegistro = p_EntradaVagasRegistro;
                this.SaidaVagasRegistro = p_SaidaVagasRegistro;
                this.IdCliente = p_IdCliente;
                this.IdVeiculo = p_IdVeiculo;
                this.IdTipoVaga = p_IdTipoVaga;
                this.IdVaga = p_IdVaga;
                this.ValorPrecoRegistro = p_ValorPrecoRegistro;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
