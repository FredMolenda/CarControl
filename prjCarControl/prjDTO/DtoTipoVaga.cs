using System;
using System.Data;

namespace prjDTO
{
    public class DtoTipoVaga
    {
        public int IdTipoVaga { get; set; }
        public string NomeTipoVaga { get; set; }
        public decimal PrecoMensalista { get; set; }
        public decimal PrecoHorista { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public DtoTipoVaga(DataRow row, int x)
        {
            try
            {
                if (x == 0)
                {
                    this.PrecoMensalista = decimal.Parse(row["preco_mensalista"].ToString());
                    this.PrecoHorista = decimal.Parse(row["preco_horista"].ToString());
                }
                this.IdTipoVaga = int.Parse(row["id_tipo_vaga"].ToString());
                this.NomeTipoVaga = row["nome_tipo_vaga"].ToString();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DtoTipoVaga(DataRow row, bool x)
        {
            try
            {
                //this.IdTipoVaga = int.Parse(row["id_tipo_vaga"].ToString());
                if (x == true)
                {
                    this.PrecoHorista = decimal.Parse(row["preco_horista"].ToString());
                }
                if (x == false)
                {
                    this.PrecoMensalista = decimal.Parse(row["preco_mensalista"].ToString());
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_IdTipoVaga"></param>
        /// <param name="p_TipoVaga"></param>
        public DtoTipoVaga(int p_IdTipoVaga, string p_NomeTipoVaga, decimal p_PrecoMensalista, decimal p_PrecoHorista)
        {
            try
            {
                this.IdTipoVaga = p_IdTipoVaga;
                this.NomeTipoVaga = p_NomeTipoVaga;
                this.PrecoMensalista = p_PrecoMensalista;
                this.PrecoHorista = p_PrecoHorista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
