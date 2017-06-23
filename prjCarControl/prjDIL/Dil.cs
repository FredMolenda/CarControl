using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace prjDil
{
    /// <summary>
    /// =======================================================================
    /// Author:             Trevisan, Gilmar
    /// Author adapter:     Passos, Lucas
    /// Create date:        27/05/2016
    /// Adapter date:       14/02/2017
    /// Description:        Database Interface Layer
    /// Methods:            StartConnection(),
    ///                     AddParameter(string parameterName, object parameterValue),
    ///                     PrepareSqlCommand(CommandType commandtype, string command),
    ///                     ExecuteStoredProcedureQuery(string storedProcedureName),
    ///                     ExecuteStoredProcedureNonQuery(string storedProcedureName),
    ///                     ClearParameterCollection(),
    ///                     CloseConnection()
    /// Dependencies:       System.Configuraton,
    ///                     System.Data.SqlClient,
    ///                     System.Configuration,
    ///                     System.Data
    /// =======================================================================
    /// </summary>
    public class Dil
    {
        #region PROPERTIES
        /// <summary>
        /// connectionSql representa uma conexão com um SQL Server banco de dados.
        /// </summary>
        private SqlConnection connectionSql = null;

        /// <summary>
        /// SqlParameterCollection representa uma coleção de parâmetros associados a um SqlCommand
        /// e seus respectivos mapeamentos para colunas em um DataSet.
        /// DataSet representa dados em um cache de memória.
        /// </summary>
        private SqlParameterCollection parameterCollection = new SqlCommand().Parameters;
        #endregion PROPERTIES

        #region METHODS
        /// <summary>
        /// Método que abre uma conexão com o banco de dados.
        /// </summary>
        /// <returns>
        /// Retorna uma nova Instâcia da classe SqlConnection com as configurações 
        /// de propriedade especificadas pelo ConnectionString.
        /// </returns>
        private SqlConnection StartConnection()
        {
            try
            {
                //Cria o objeto de conexão com o banco de dados passando no construtor a string de conexão vinda do App.config.
                this.connectionSql = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaStringDeConexao"].ConnectionString);

                //Abre uma conexão de banco de dados usando as configurações de propriedade.
                connectionSql.Open();

                return connectionSql;

            }
            catch (Exception err)
            {
                //Retorna o erro para quem chamou o método
                throw err;
            }
        }

        /// <summary>
        /// Método que adiciona parametros
        /// </summary>
        /// <param name="parameterName">nome do parâmetro armazenado no arquivo App.config</param>
        /// <param name="parameterValue">valor do parâmetro armazenado no arquivo App.config</param>
        public void AddParameter(string parameterName, object parameterValue)
        {
            this.parameterCollection.Add(new SqlParameter(parameterName, parameterValue));
        }

        /// <summary>
        /// Prepara a stored procedure ou comando T-SQL para ser executado.
        /// </summary>
        /// <param name="commandtype">
        ///     Tipo do comando.
        ///     Os valores permitidos são: CommandType.StoredProcedure ou CommandType.Text.
        /// </param>
        /// <param name="command">Instrução Transact-SQL ou procedimento armazenado a ser executado.</param>
        /// <returns>Uma conexão com o database</returns>
        private SqlCommand PrepareSqlCommand(CommandType commandtype, string command)
        {
            try
            {
                // Abre uma conexão com o database
                this.connectionSql = this.StartConnection();

                // SqlCommand representa uma instrução Transact-SQL ou procedimento armazenado
                // para executar contra um banco de dados do SQL Server. Essa classe não pode ser herdada.
                SqlCommand sqlCommand = new SqlCommand()
                {
                    // Associa o sqlCommand à conexão existente.
                    Connection = this.connectionSql,

                    // Define comando do tipo instrução Transact-SQL ou procedimento armazenado.
                    CommandType = commandtype,

                    // Define a instrução Transact-SQL ou o nome do procedimento armazenado.
                    CommandText = command,

                    // Tempo em segundos que o sistema aguarda pela execução da procedure.
                    CommandTimeout = int.Parse(ConfigurationManager.AppSettings["SqlTimeout"]),
                };

                // Adicionar os parametros no comando
                foreach (SqlParameter sqlParameter in parameterCollection)
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));

                return sqlCommand;
            }
            // Captura um erro genérico
            catch (Exception ex)
            {
                // Envia a exceção para a o método chamador providenciar uma mensagem para o usuário.
                throw ex;
            }
        }

        /// <summary>
        /// Executa uma stored procedure e retorna um datatable
        /// </summary>
        /// <param name="storedProcedureName">string storedProcedureName - nome da stored procedure</param>
        /// <returns>datatable contendo um conjunto de registros</returns>
        public DataTable ExecuteStoredProcedureQuery(string storedProcedureName)
        {
            try
            {
                // Preapara a stored procedure para execução
                SqlCommand sqlCommand = PrepareSqlCommand(CommandType.StoredProcedure, storedProcedureName);

                // SqlDataAdapter representa um conjunto de comandos de dados e uma conexão de banco de
                // dados que são usados para preencher o DataSet e atualizar um banco de dados do SQL Server.
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // Representa uma tabela de dados na Memória.
                DataTable dataTable = new DataTable();

                // Manda o comando ir até o banco buscar os dados e o adaptador
                // preencher o dataTable
                sqlDataAdapter.Fill(dataTable);

                return dataTable;
            }
            // Captura um erro genérico
            catch (Exception ex)
            {

                // Envia a exceção para a o método chamador providenciar uma mensagem para o usuário.
                throw ex;
            }
            finally
            {
                //Limpa a coleção de parametros
                this.ClearParameterCollection();

                // Fecha a conexão se estiver aberta
                CloseConnection();
            }
        }

        /// <summary>
        /// Executa uma stored procedure que retorna um escalar
        /// </summary>
        /// <param name="storedProcedureName">Nome da stored procedure</param>
        /// <returns>Um valor inteiro</returns>
        public int ExecuteStoredProcedureNonQuery(string storedProcedureName)
        {
            try
            {
                // Preapara a stored procedure para execução
                SqlCommand sqlCommand = PrepareSqlCommand(CommandType.StoredProcedure, storedProcedureName);

                // Retorna o numero de registro afetados pela execução da stored procedure
                return sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                // Envia a exceção para a o método chamador providenciar uma mensagem para o usuário.
                throw ex;
            }
            finally
            {
                //Limpa a coleção de parametros
                this.ClearParameterCollection();

                // Fecha a conexão se estiver aberta
                CloseConnection();
            }
        }

        /// <summary>
        /// Método que limpa a coleção de parametros.
        /// </summary>
        private void ClearParameterCollection()
        {
            //Limpa a coleção de parametros.
            parameterCollection.Clear();
        }

        /// <summary>
        /// Método que fecha a conexão com o banco de dados.
        /// </summary>
        private void CloseConnection()
        {
            // Verifica se a conexão foi aberta, se foi ele fecha a conexão.
            if (this.connectionSql.State == ConnectionState.Open)
            {
                this.connectionSql.Close();
            }
        }
        #endregion METHODS
    }
}