using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.Class
{
    public class DB
    {
        public SqlConnection Conn;
        public string SqlConnectionString;
        public DB(string StringConnect)
        {
            Conn = new SqlConnection(StringConnect);
            Conn.Open();
            SqlConnectionString = StringConnect;
        }

        public DataTable GetData(string StringSql)
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlConnectionString, CommandType.Text, StringSql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return (new DataTable());
            }
        }

        public decimal GetOneDecimalField(string StringSql)
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlConnectionString, CommandType.Text, StringSql).Tables[0];
                if (dt.Rows.Count > 0)
                    return decimal.Parse(dt.Rows[0][0].ToString());
                else
                    return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public string GetOneStringField(string StringSql)
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlConnectionString, CommandType.Text, StringSql).Tables[0];
                if (dt.Rows.Count > 0)
                    return dt.Rows[0][0].ToString();
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool GetOneBoolField(string StringSql)
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlConnectionString, CommandType.Text, StringSql).Tables[0];
                if (dt.Rows.Count > 0)
                    return bool.Parse(dt.Rows[0][0].ToString());
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DateTime GetOneDateTimeField(string StringSql)
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlConnectionString, CommandType.Text, StringSql).Tables[0];
                if (dt.Rows.Count > 0)
                    return DateTime.Parse(dt.Rows[0][0].ToString());
                else
                    return new DateTime();
            }
            catch (Exception ex)
            {
                return new DateTime();
            }
        }

        public bool CheckExistsRecord(string StringSql)
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlConnectionString, CommandType.Text, StringSql).Tables[0];
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        ~DB()
        {
            if (Conn == null)
            {
                Conn.Close();
            }
        }
    }
}
