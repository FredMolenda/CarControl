using prjDAL;
using prjDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBLL
{
    public class Bll
    {
        Dal dal = null;

        public Bll()
        {
            dal = new Dal();
        }

        #region Usuario
        public bool Login(string a, string b)
        {
            return dal.LoginUsuario(a, b);
        }
        public List<DtoUsuario> SelectUsuario()
        {
            return dal.SelectUsuario();
        }
        public void InsertUsuario(DtoUsuario objUsuario)
        {
            dal.InsertUsuario(objUsuario);
        }
        public void EditUsuario(DtoUsuario objUsuario)
        {
            dal.EditUsuario(objUsuario);
        }
        public void DeleteUsuario(string LoginUsuario)
        {
            dal.DeleteUsuario(LoginUsuario);
        }
        #endregion Usuario

        #region Cliente
        public List<DtoCliente> SelectCliente()
        {
            return dal.SelectCliente().Where(x=> x.IdCliente != 1).ToList();
        }
        public void InsertCliente(DtoCliente objCliente)
        {
            dal.InsertCliente(objCliente);
        }
        public void EditCliente(DtoCliente objCliente)
        {
            dal.EditCliente(objCliente);
        }
        public void DeleteCliente(int IdCliente)
        {
            dal.DeleteCliente(IdCliente);
        }
        #endregion Cliente
        
        #region Veiculo
        public List<DtoVeiculo> SelectVeiculo()
        {
            return dal.SelectVeiculo().Where(x => x.IdVeiculos != 1).ToList();
        }
        public void InsertVeiculo(DtoVeiculo objVeiculo)
        {
            dal.InsertVeiculo(objVeiculo);
        }
        public void EditVeiculo(DtoVeiculo objVeiculo)
        {
            dal.EditVeiculo(objVeiculo);
        }
        public void DeleteVeiculo(int IdVeiculo)
        {
            dal.DeleteVeiculo(IdVeiculo);
        }
        public List<DtoVeiculo> SelectVeiculoById(int IdCliente)
        {
            return dal.SelectVeiculoById(IdCliente);
        }
        #endregion Veiculo

        #region Tipo Vaga
        public List<DtoTipoVaga> SelectTipoVaga()
        {
            return dal.SelectTipoVaga().Where(x => x.IdTipoVaga != 1).ToList();
        }
        public List<DtoTipoVaga> SelectTipoVaga2()
        {
            return dal.SelectTipoVaga2();
        }
        public List<DtoTipoVaga> SelectHorista(int IdTipoVaga)
        {
            return dal.SelectHorista(IdTipoVaga);
        }
        public List<DtoTipoVaga> SelectMensalista(int IdTipoVaga)
        {
            return dal.SelectMensalista(IdTipoVaga);
        }
        public void InsertTipoVaga(DtoTipoVaga objTipoVaga)
        {
            dal.InsertTipoVaga(objTipoVaga);
        }
        public void EditTipoVaga(DtoTipoVaga objTipoVaga)
        {
            dal.EditTipoVaga(objTipoVaga);
        }
        public void DeleteTipoVaga(int IdTipoVaga)
        {
            dal.DeleteTipoVaga(IdTipoVaga);
        }
        #endregion Tipo Vaga

        #region Vaga
        public List<DtoVaga> SelectVaga()
        {
            return dal.SelectVaga();
        }
        public void InsertVaga(DtoVaga objVaga)
        {
            dal.InsertVaga(objVaga);
        }
        public void OcuparVaga(DtoVaga objVaga)
        {
            dal.OcuparVaga(objVaga);
        }
        public void DesocuparVaga(DtoVaga objVaga)
        {
            dal.DesocuparVaga(objVaga);
        }
        public void DeleteVaga(int IdVaga)
        {
            dal.DeleteVaga(IdVaga);
        }
        #endregion Vaga

        #region Registro
        public List<DtoRegistro> SelectRegistro()
        {
            return dal.SelectRegistro();
        }
        public void InsertRegistro(DtoRegistro objRegistro)
        {
            dal.InsertRegistro(objRegistro);
        }
        #endregion Registro
    }
}
