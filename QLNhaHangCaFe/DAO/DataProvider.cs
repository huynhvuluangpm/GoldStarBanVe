using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace DAO
{
    public class DataProvider : DataTable
    {
         private string _ConnectionString = "Data Source=.\\SQLSERVER2008; Initial Catalog=quanlibanhang; User Id=sa; Password=sql2008";
        private SqlConnection _connection;
        private SqlCommand _Command;
        private SqlDataAdapter _DataAdapter;
        public string conn()
        {
            return _ConnectionString;
        }
        public DataProvider()
        {
            OpenConnect();
        }
        public bool OpenConnect()
        {
            try
            {
                _connection = new SqlConnection(_ConnectionString);
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void Load(SqlCommand command)
        {
            _Command = command;
            try
            {
                OpenConnect();
                _Command.Connection = _connection;
                _DataAdapter = new SqlDataAdapter();
                _DataAdapter.SelectCommand = _Command;
                this.Clear();
                _DataAdapter.Fill(this);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnect();
            }
        }
        public void Update()
        {
            SqlCommandBuilder buider = new SqlCommandBuilder(_DataAdapter);
            _DataAdapter.Update(this);
        }
        public void CloseConnect()
        {
            _connection.Close();
        }
        public int ExecuteNoneQuery(SqlCommand command)
        {
            int result = 0;
            SqlTransaction tr = null;
            try
            {
                OpenConnect();
                tr = _connection.BeginTransaction();
                command.Connection = _connection;
                command.Transaction = tr;
                result = command.ExecuteNonQuery();
                this.AcceptChanges();
                tr.Commit();
            }
            catch (Exception E)
            {
                if (tr != null) tr.Rollback();
                throw E;
            }
            return result;
        }
    }
}
