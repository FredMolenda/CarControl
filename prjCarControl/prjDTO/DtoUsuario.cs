using System;
using System.Data;

namespace prjDTO
{
    public class DtoUsuario
    {
        public string LoginUsuario { get; set; }
        public string SenhaUsuario { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public DtoUsuario(DataRow row)
        {
            try
            {
                this.SenhaUsuario = row["senha_usuario"].ToString();
                this.LoginUsuario = row["login_usuario"].ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_SenhaUsuario"></param>
        /// <param name="p_LoginUsuario"></param>
        public DtoUsuario(string p_LoginUsuario, string p_SenhaUsuario)
        {
            try
            {
                this.LoginUsuario = p_LoginUsuario;
                this.SenhaUsuario = p_SenhaUsuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
