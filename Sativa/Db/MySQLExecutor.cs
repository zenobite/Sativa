using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Sativa.Db.MySQL
{
    /// <summary>
    /// Sativa MySQL Executor Class
    /// </summary>
    public class MySQLExecutor
    {
        public string ConnectionString;
        MySqlConnection _connection;
        MySqlCommand _command;
        MySqlDataAdapter _dataAdapter;

        public MySQLExecutor(string conString)
        {
            this.ConnectionString = conString;
        }

        public DataTable Read(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                _connection = new MySqlConnection(this.ConnectionString);
                _command = new MySqlCommand(sql);
                _command.Connection = _connection;
                _connection.Open();
                DataAdapter.SelectCommand = _command;
                DataAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.Close();
            }

            return dt;
        }

        public DataTable ReadAlive(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                Command.CommandText = sql;
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(dt);
            }
            finally
            { }

            return dt;
        }

        public Int32 ExecuteNonQuery(string sql)
        {
            try
            {
                _connection = new MySqlConnection(this.ConnectionString);
                _command = new MySqlCommand(sql);
                _command.Connection = _connection;
                if (_connection.State == ConnectionState.Closed) _connection.Open();

                return _command.ExecuteNonQuery();
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            finally
            {
                this.Close();
            }
        }

        public MySqlDataReader ExecuteReader(string sql)
        {
            try
            {
                _connection = new MySqlConnection(this.ConnectionString);
                _command = new MySqlCommand(sql);
                _command.Connection = _connection;
                _connection.Open();

                return _command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            finally
            {
                this.Close();
            }
        }

        public Int32 ExecuteNonQueryAlive(string sql)
        {
            try
            {
                Command.CommandText = sql;
                return Command.ExecuteNonQuery();
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            finally
            { }
        }

        public void Close()
        {
            if (_connection != null)
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
                _connection = null;
            }
            if (_command != null)
            {
                _command.Dispose();
                _command = null;
            }
            if (_dataAdapter != null)
            {
                _dataAdapter.Dispose();
                _dataAdapter = null;
            }
        }

        public MySqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    if (ConnectionString == "")
                        throw new Exception("Connection string must be defined before using connection, command or data adapter");

                    _connection = new MySqlConnection(ConnectionString);
                    _connection.Open();
                }

                return _connection;
            }
            set
            {
                _connection = value;
            }
        }

        public MySqlCommand Command
        {
            get
            {
                if (_command == null)
                {
                    _command = new MySqlCommand();
                    _command.Connection = Connection;
                }
                if (_command.Connection.ConnectionString == string.Empty)
                {
                    _command.Connection.ConnectionString = this.ConnectionString;
                }

                return _command;
            }
            set
            {
                _command = value;
            }
        }

        protected MySqlDataAdapter DataAdapter
        {
            get
            {
                if (_dataAdapter == null)
                {
                    _dataAdapter = new MySqlDataAdapter();
                }

                return _dataAdapter;
            }
            set
            {
                _dataAdapter = value;
            }
        }

        public Object ExecuteScalar(String sql)
        {
            try
            {
                _connection = new MySqlConnection(this.ConnectionString);
                _command = new MySqlCommand(sql);
                _command.Connection = _connection;
                if (_connection.State == ConnectionState.Closed) _connection.Open();

                return _command.ExecuteScalar();
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            finally
            {
                this.Close();
            }
        }

        public Object ExecuteScalarAlive(String sql)
        {
            try
            {
                Command.CommandText = sql;
                return Command.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            { }
        }
    }
}