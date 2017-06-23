using System;
using System.Data;

namespace prjDTO
{
    public class DtoVeiculo
    {
        public int IdVeiculos { get; set; }
        public string MarcaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public string PlacaVeiculo { get; set; }
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public DtoVeiculo(DataRow row, int? x)
        {
            try
            {
                if (x == 0)
                {
                    this.MarcaVeiculo = row["marca_veiculo"].ToString();
                    this.ModeloVeiculo = row["modelo_veiculo"].ToString();
                    this.IdCliente = int.Parse(row["id_cliente"].ToString());
                    this.NomeCliente = row["nome_cliente"].ToString();
                }
                this.IdVeiculos = int.Parse(row["id_veiculos"].ToString());
                this.PlacaVeiculo = row["placa_veiculo"].ToString();
            }
            catch (Exception ex)
            { 

                throw ex;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_IdVeiculos"></param>
        /// <param name="p_MarcaVeiculo"></param>
        /// <param name="p_ModeloVeiculo"></param>
        /// <param name="p_PlacaVeiculo"></param>
        public DtoVeiculo(int p_IdVeiculos, string p_MarcaVeiculo, string p_ModeloVeiculo, string p_PlacaVeiculo, int p_IdCliente)
        {
            try
            {
                this.IdVeiculos = p_IdVeiculos;
                this.MarcaVeiculo = p_MarcaVeiculo;
                this.ModeloVeiculo = p_ModeloVeiculo;
                this.PlacaVeiculo = p_PlacaVeiculo;
                this.IdCliente = p_IdCliente;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
