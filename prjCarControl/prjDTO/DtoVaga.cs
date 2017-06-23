using System;
using System.Data;

namespace prjDTO
{
    public class DtoVaga
    {
        public int IdVaga { get; set; }
        public int NumeroVaga { get; set; }
        public char Ocupado { get; set; }
        public string Andar { get; set; }
        public string Bloco { get; set; }
        public int IdVeiculo { get; set; }
        public string MarcaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public string PlacaVeiculo { get; set; }
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public char Especificacao { get; set; }
        public int IdTipoVaga { get; set; }
        public string NomeTipoVaga { get; set; }
        public DateTime DataEntrada { get; set; }
        //public DateTime EntradaVagas  { get; set; }
        //public DateTime SaidaVagas    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public DtoVaga(DataRow row)
        {
            try
            {
                this.IdVaga = int.Parse(row["id_vaga"].ToString());
                this.NumeroVaga = int.Parse(row["numero_vaga"].ToString());
                this.Ocupado = Convert.ToChar(row["ocupado"].ToString()[0]);
                this.Andar = row["andar"].ToString();
                this.Bloco = row["bloco"].ToString();
                this.IdVeiculo = int.Parse(row["id_veiculos"].ToString());
                this.MarcaVeiculo = row["marca_veiculo"].ToString();
                this.ModeloVeiculo = row["modelo_veiculo"].ToString();
                this.PlacaVeiculo = row["placa_veiculo"].ToString();
                this.IdCliente = int.Parse(row["id_cliente"].ToString());
                this.NomeCliente = row["nome_cliente"].ToString();
                this.Especificacao = Convert.ToChar(row["especificacao_cliente"].ToString());
                this.IdTipoVaga = int.Parse(row["id_tipo_vaga"].ToString());
                this.NomeTipoVaga = row["nome_tipo_vaga"].ToString();
                this.DataEntrada = DateTime.Parse(row["data_entrada"].ToString());
                //this.SaidaVagas = DateTime.Parse(row["saida_vagas"].ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_IdVaga"></param>
        /// <param name="p_NumeroVaga"></param>
        /// <param name="p_Ocupado"></param>
        /// <param name="p_Andar"></param>
        /// <param name="p_Bloco"></param>
        /// <param name="p_IdVeiculo"></param>
        /// <param name="p_MarcaVeiculo"></param>
        /// <param name="p_ModeloVeiculo"></param>
        /// <param name="p_PlacaVeiculo"></param>
        /// <param name="p_IdCliente"></param>
        /// <param name="p_NomeCliente"></param>
        /// <param name="p_IdTipoVaga"></param>
        /// <param name="p_NomeTipoVaga"></param>
        /// 
        public DtoVaga(int p_IdVaga, int p_NumeroVaga, char p_Ocupado, string p_Andar, string p_Bloco, int p_idVeiculo, string p_MarcaVeiculo, string p_ModeloVeiculo, string p_PlacaVeiculo, int p_IdCliente, string p_NomeCliente, char p_Especificacao, string p_CPFCliente, string p_NumeroCliente, int p_IdTipoVaga, string p_NomeTipovaga, DateTime p_DataEntrada)
        {
            try
            {
                this.IdVaga = p_IdVaga;
                this.NumeroVaga = p_NumeroVaga;
                this.Ocupado = p_Ocupado;
                this.Andar = p_Andar;
                this.Bloco = p_Bloco;
                this.IdVeiculo = p_idVeiculo;
                this.MarcaVeiculo = p_MarcaVeiculo;
                this.ModeloVeiculo = p_ModeloVeiculo;
                this.PlacaVeiculo = p_PlacaVeiculo;
                this.IdCliente = p_IdCliente;
                this.NomeCliente = p_NomeCliente;
                this.Especificacao = p_Especificacao;
                this.IdTipoVaga = p_IdTipoVaga;
                this.NomeTipoVaga = p_NomeTipovaga;
                this.DataEntrada = p_DataEntrada;
                //this.SaidaVagas = p_SaidaVagas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DtoVaga(int p_NumeroVaga, char p_Ocupado, string p_Andar, string p_Bloco, int p_idVeiculo, int p_IdCliente, int p_IdTipoVaga)
        {
            try
            {
                this.NumeroVaga = p_NumeroVaga;
                this.Ocupado = p_Ocupado;
                this.Andar = p_Andar;
                this.Bloco = p_Bloco;
                this.IdVeiculo = p_idVeiculo;
                this.IdCliente = p_IdCliente;
                this.IdTipoVaga = p_IdTipoVaga;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DtoVaga(int p_IdVaga, int p_NumeroVaga, char p_Ocupado, string p_Andar, string p_Bloco, int p_idVeiculo, int p_IdCliente, int p_IdTipoVaga)
        {
            try
            {
                this.IdVaga = p_IdVaga;
                this.NumeroVaga = p_NumeroVaga;
                this.Ocupado = p_Ocupado;
                this.Andar = p_Andar;
                this.Bloco = p_Bloco;
                this.IdVeiculo = p_idVeiculo;
                this.IdCliente = p_IdCliente;
                this.IdTipoVaga = p_IdTipoVaga;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
