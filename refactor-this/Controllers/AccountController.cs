using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Data;
using System.Windows.Forms;

namespace refactor_this.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet, Route("api/Accounts/{id}")]
        public IHttpActionResult GetById(Guid id)
        {
            using (var connection = Helpers.NewConnection())
            {
                return Ok(Get(id));
            }
        }

        [HttpGet, Route("api/Accounts")]
        public IHttpActionResult Get()
        {
            SqlDataReader reader = null;
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                using (connection = Helpers.NewConnection())
                {
                    string query = $"select Id from Accounts";
                    command = new SqlCommand(query, connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    var accounts = new List<Account>();
                    while (reader.Read())
                    {
                        var id = Guid.Parse(reader["Id"].ToString());
                        var account = Get(id);
                        accounts.Add(account);
                    }
                    return Ok(accounts);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private Account Get(Guid id)
        {
            SqlDataReader reader = null;
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                using (connection = Helpers.NewConnection())
                {
                    string query = $"select * from Accounts where Id = '{id}'";
                    command = new SqlCommand(query, connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    var account=new Account();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            account = new Account(id);
                            account.Name = reader["Name"].ToString();
                            account.Number = reader["Number"].ToString();
                            account.Amount = float.Parse(reader["Amount"].ToString());
                        }
                    }
                    else
                    //if (!reader.Read())
                    { throw new ArgumentException(); }

                    /*var account = new Account(id);
                    account.Name = reader["Name"].ToString();
                    account.Number = reader["Number"].ToString();
                    account.Amount = float.Parse(reader["Amount"].ToString());*/
                    return account;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        [HttpPost, Route("api/Accounts")]
        public IHttpActionResult Add(Account account)
        {
            account.Save();
            return Ok();
        }

        [HttpPut, Route("api/Accounts/{id}")]
        public IHttpActionResult Update(Guid id, Account account)
        {
            var existing = Get(id);
            existing.Name = account.Name;
            existing.Save();
            return Ok();
        }

        [HttpDelete, Route("api/Accounts/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            var existing = Get(id);
            existing.Delete();
            return Ok();
        }
    }
}