using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjDil;
using prjDTO;
using System.Data;

namespace prjDAL
{
    public class Dal
    {
        private Dil ObjDil = null;
        public Dal()
        {
            ObjDil = new Dil();
        }
        #region Usuario

        public List<DtoUsuario> SelectUsuario()
        {
            try
            {
                DataTable dtUsuarios = ObjDil.ExecuteStoredProcedureQuery("sp_select_usuario");

                DtoUsuario objUsuario = null;

                List<DtoUsuario> lstUsuarios = new List<DtoUsuario>();

                foreach (DataRow row in dtUsuarios.Rows)
                {
                    objUsuario = new DtoUsuario(row);
                    lstUsuarios.Add(objUsuario);
                    objUsuario = null;
                }

                return lstUsuarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool LoginUsuario(string LoginUsuario, string SenhaUsuario)
        {
            try
            {
                ObjDil.AddParameter("@p_login", LoginUsuario);
                ObjDil.AddParameter("@p_senha", SenhaUsuario);

                DataTable dtUsuarios = ObjDil.ExecuteStoredProcedureQuery("sp_login");

                bool logar = false;

                if (dtUsuarios.Rows.Count > 0)
                {
                    logar = true;
                }
                return logar;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertUsuario(DtoUsuario ObjUsuario)
        {
            try
            {
                ObjDil.AddParameter("@p_login", ObjUsuario.LoginUsuario);
                ObjDil.AddParameter("@p_senha", ObjUsuario.SenhaUsuario);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_insert_usuario");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EditUsuario(DtoUsuario ObjUsuario)
        {
            try
            {
                ObjDil.AddParameter("@p_login", ObjUsuario.LoginUsuario);
                ObjDil.AddParameter("@p_senha", ObjUsuario.SenhaUsuario);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_update_usuario");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUsuario(string LoginUsuario)
        {
            try
            {
                ObjDil.AddParameter("@p_login", LoginUsuario);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_delete_usuario");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Usuario

        #region Cliente
        public List<DtoCliente> SelectCliente()
        {
            try
            {
                DataTable dtCliente = ObjDil.ExecuteStoredProcedureQuery("sp_select_Cliente");

                DtoCliente objCliente = null;

                List<DtoCliente> lstCliente = new List<DtoCliente>();

                foreach (DataRow row in dtCliente.Rows)
                {
                    objCliente = new DtoCliente(row);
                    lstCliente.Add(objCliente);
                    objCliente = null;
                }

                return lstCliente;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertCliente(DtoCliente objCliente)
        {
            try
            {
                ObjDil.AddParameter("@p_nome_cliente", objCliente.NomeCliente);
                ObjDil.AddParameter("@p_CPF_cliente", objCliente.CPFCliente);
                ObjDil.AddParameter("@p_telefone_cliente", objCliente.TelefoneCliente);
                ObjDil.AddParameter("@p_especificacao_cliente", objCliente.EspecificacaoCliente);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_insert_cliente");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EditCliente(DtoCliente objCliente)
        {
            try
            {
                ObjDil.AddParameter("@p_id_cliente", objCliente.IdCliente);
                ObjDil.AddParameter("@p_nome_cliente", objCliente.NomeCliente);
                ObjDil.AddParameter("@p_CPF_cliente", objCliente.CPFCliente);
                ObjDil.AddParameter("@p_telefone_cliente", objCliente.TelefoneCliente);
                ObjDil.AddParameter("@p_especificacao_cliente", objCliente.EspecificacaoCliente);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_update_cliente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCliente(int IdCliente)
        {
            try
            {
                ObjDil.AddParameter("@id_cliente", IdCliente);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_Delete_Cliente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Cliente

        #region Veiculo
        public List<DtoVeiculo> SelectVeiculo()
        {
            try
            {
                DataTable dtVeiculo = ObjDil.ExecuteStoredProcedureQuery("sp_select_Veiculo");

                DtoVeiculo objVeiculo = null;

                List<DtoVeiculo> lstVeiculo = new List<DtoVeiculo>();

                foreach (DataRow row in dtVeiculo.Rows)
                {
                    objVeiculo = new DtoVeiculo(row, 0);
                    lstVeiculo.Add(objVeiculo);
                    objVeiculo = null;
                }

                return lstVeiculo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DtoVeiculo> SelectVeiculoById(int IdCliente)
        {
            try
            {
                ObjDil.AddParameter("@p_id_cliente", IdCliente);

                DataTable dtVeiculo = ObjDil.ExecuteStoredProcedureQuery("sp_select_Veiculo_by_id");

                DtoVeiculo objVeiculo = null;

                List<DtoVeiculo> lstVeiculo = new List<DtoVeiculo>();

                foreach (DataRow row in dtVeiculo.Rows)
                {
                    objVeiculo = new DtoVeiculo(row, 1);
                    lstVeiculo.Add(objVeiculo);
                    objVeiculo = null;
                }

                return lstVeiculo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertVeiculo(DtoVeiculo objVeiculo)
        {
            try
            {

                ObjDil.AddParameter("@p_marca_veiculo", objVeiculo.MarcaVeiculo);
                ObjDil.AddParameter("@p_modelo_veiculo", objVeiculo.ModeloVeiculo);
                ObjDil.AddParameter("@p_placa_veiculo", objVeiculo.PlacaVeiculo);
                ObjDil.AddParameter("@p_id_cliente", objVeiculo.IdCliente);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_insert_veiculo");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EditVeiculo(DtoVeiculo objVeiculo)
        {
            try
            {
                ObjDil.AddParameter("@p_id_veiculos", objVeiculo.IdVeiculos);
                ObjDil.AddParameter("@p_marca_veiculo", objVeiculo.MarcaVeiculo);
                ObjDil.AddParameter("@p_modelo_veiculo", objVeiculo.ModeloVeiculo);
                ObjDil.AddParameter("@p_placa_veiculo", objVeiculo.PlacaVeiculo);
                ObjDil.AddParameter("@p_id_cliente", objVeiculo.IdCliente);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_update_Veiculo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteVeiculo(int IdVeiculo)
        {
            try
            {
                ObjDil.AddParameter("@p_id_veiculos", IdVeiculo);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_Delete_Veiculo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Veiculo

        #region Tipo Vaga
        public List<DtoTipoVaga> SelectTipoVaga()
        {
            try
            {
                DataTable dtTipoVaga = ObjDil.ExecuteStoredProcedureQuery("sp_select_Tipo_vaga");

                DtoTipoVaga objTipoVaga = null;

                List<DtoTipoVaga> lstTipoVaga = new List<DtoTipoVaga>();

                foreach (DataRow row in dtTipoVaga.Rows)
                {
                    objTipoVaga = new DtoTipoVaga(row, 0);
                    lstTipoVaga.Add(objTipoVaga);
                    objTipoVaga = null;
                }

                return lstTipoVaga;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DtoTipoVaga> SelectTipoVaga2()
        {
            try
            {
                DataTable dtTipoVaga = ObjDil.ExecuteStoredProcedureQuery("sp_select_Tipo_vaga2");

                DtoTipoVaga objTipoVaga = null;

                List<DtoTipoVaga> lstTipoVaga = new List<DtoTipoVaga>();

                foreach (DataRow row in dtTipoVaga.Rows)
                {
                    objTipoVaga = new DtoTipoVaga(row, 1);
                    lstTipoVaga.Add(objTipoVaga);
                    objTipoVaga = null;
                }

                return lstTipoVaga;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DtoTipoVaga> SelectHorista(int IdTipoVaga)
        {
            try
            {
                ObjDil.AddParameter("@p_id_tipo_vaga", IdTipoVaga);

                DataTable dtTipoVaga = ObjDil.ExecuteStoredProcedureQuery("sp_select_horista");

                DtoTipoVaga objTipoVaga = null;

                List<DtoTipoVaga> lstTipoVaga = new List<DtoTipoVaga>();

                foreach (DataRow row in dtTipoVaga.Rows)
                {
                    objTipoVaga = new DtoTipoVaga(row, true);
                    lstTipoVaga.Add(objTipoVaga);
                    objTipoVaga = null;
                }

                return lstTipoVaga;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DtoTipoVaga> SelectMensalista(int IdTipoVaga)
        {
            try
            {
                ObjDil.AddParameter("@p_id_tipo_vaga", IdTipoVaga);

                DataTable dtTipoVaga = ObjDil.ExecuteStoredProcedureQuery("sp_select_mensalista");

                DtoTipoVaga objTipoVaga = null;

                List<DtoTipoVaga> lstTipoVaga = new List<DtoTipoVaga>();

                foreach (DataRow row in dtTipoVaga.Rows)
                {
                    objTipoVaga = new DtoTipoVaga(row, false);
                    lstTipoVaga.Add(objTipoVaga);
                    objTipoVaga = null;
                }

                return lstTipoVaga;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertTipoVaga(DtoTipoVaga objTipoVaga)
        {
            try
            {
                ObjDil.AddParameter("@p_nome_tipo_vaga", objTipoVaga.NomeTipoVaga);
                ObjDil.AddParameter("@p_preco_mensalista", objTipoVaga.PrecoMensalista);
                ObjDil.AddParameter("@p_preco_horista", objTipoVaga.PrecoHorista);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_insert_Tipo_Vaga");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EditTipoVaga(DtoTipoVaga objTipoVaga)
        {
            try
            {
                ObjDil.AddParameter("@p_id_tipo_vaga", objTipoVaga.IdTipoVaga);
                ObjDil.AddParameter("@p_nome_tipo_vaga", objTipoVaga.NomeTipoVaga);
                ObjDil.AddParameter("@p_preco_mensalista", objTipoVaga.PrecoMensalista);
                ObjDil.AddParameter("@p_preco_horista", objTipoVaga.PrecoHorista);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_update_Tipo_Vaga");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteTipoVaga(int IdTipoVaga)
        {
            try
            {
                ObjDil.AddParameter("@p_id_Tipo_Vaga", IdTipoVaga);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_Delete_Tipo_Vaga");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Tipo Vaga

        #region Vaga
        public List<DtoVaga> SelectVaga()
        {
            try
            {
                DataTable dtVaga = ObjDil.ExecuteStoredProcedureQuery("sp_select_Vaga");

                DtoVaga objVaga = null;

                List<DtoVaga> lstVaga = new List<DtoVaga>();

                foreach (DataRow row in dtVaga.Rows)
                {
                    objVaga = new DtoVaga(row);
                    lstVaga.Add(objVaga);
                    objVaga = null;
                }

                return lstVaga;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertVaga(DtoVaga objVaga)
        {
            try
            {
                ObjDil.AddParameter("@p_numero_vaga", objVaga.NumeroVaga);
                ObjDil.AddParameter("@p_bloco", objVaga.Bloco);
                ObjDil.AddParameter("@p_andar", objVaga.Andar);
                ObjDil.AddParameter("p_ocupado", objVaga.Ocupado);
                ObjDil.AddParameter("@p_id_cliente", objVaga.IdCliente);
                ObjDil.AddParameter("@p_id_veiculos", objVaga.IdVeiculo);
                ObjDil.AddParameter("@p_id_tipo_vaga", objVaga.IdTipoVaga);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_insert_vaga");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void OcuparVaga(DtoVaga objVaga)
        {
            try
            {
                ObjDil.AddParameter("@p_id_vaga", objVaga.IdVaga);
                ObjDil.AddParameter("@p_numero_vaga", objVaga.NumeroVaga);
                ObjDil.AddParameter("@p_bloco", objVaga.Bloco);
                ObjDil.AddParameter("@p_andar", objVaga.Andar);
                ObjDil.AddParameter("@p_id_cliente", objVaga.IdCliente);
                ObjDil.AddParameter("@p_id_veiculos", objVaga.IdVeiculo);
                ObjDil.AddParameter("@p_id_tipo_vaga", objVaga.IdTipoVaga);
                ObjDil.AddParameter("@p_ocupado", objVaga.Ocupado);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_ocupar_vaga");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DesocuparVaga(DtoVaga objVaga)
        {
            try
            {
                ObjDil.AddParameter("@p_id_vaga", objVaga.IdVaga);
                ObjDil.AddParameter("@p_numero_vaga", objVaga.NumeroVaga);
                ObjDil.AddParameter("@p_bloco", objVaga.Bloco);
                ObjDil.AddParameter("@p_andar", objVaga.Andar);
                ObjDil.AddParameter("@p_id_cliente", objVaga.IdCliente);
                ObjDil.AddParameter("@p_id_veiculos", objVaga.IdVeiculo);
                ObjDil.AddParameter("@p_id_tipo_vaga", objVaga.IdTipoVaga);
                ObjDil.AddParameter("@p_ocupado", objVaga.Ocupado);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_desocupar_vaga");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteVaga(int IdVaga)
        {
            try
            {
                ObjDil.AddParameter("@p_id_Vaga", IdVaga);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_Delete_vaga");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Vaga

        #region Registro
        public List<DtoRegistro> SelectRegistro()
        {
            try
            {
                DataTable dtRegistro = ObjDil.ExecuteStoredProcedureQuery("sp_select_registro");

                DtoRegistro objRegistro = null;

                List<DtoRegistro> lstRegistro = new List<DtoRegistro>();

                foreach (DataRow row in dtRegistro.Rows)
                {
                    objRegistro = new DtoRegistro(row);
                    lstRegistro.Add(objRegistro);
                    objRegistro = null;
                }

                return lstRegistro;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertRegistro(DtoRegistro objRegistro)
        {
            try
            {
                ObjDil.AddParameter("@p_entrada_registro", objRegistro.EntradaVagasRegistro);
                ObjDil.AddParameter("@p_saida_registro", objRegistro.SaidaVagasRegistro);
                ObjDil.AddParameter("@p_id_cliente", objRegistro.IdCliente);
                ObjDil.AddParameter("@p_id_veiculos", objRegistro.IdVeiculo);
                ObjDil.AddParameter("@p_id_tipo_vaga", objRegistro.IdTipoVaga);
                ObjDil.AddParameter("@p_id_vaga", objRegistro.IdVaga);
                ObjDil.AddParameter("@p_preco", objRegistro.ValorPrecoRegistro);

                ObjDil.ExecuteStoredProcedureNonQuery("sp_insert_registro");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion Registro
    }
}
