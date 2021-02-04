using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Windows.Forms;
using System.Data;

namespace refactor_this.Controllers
{
    public class TransactionController : ApiController
    {
        [HttpGet, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult GetTransactions(Guid id)
        {
            SqlDataReader reader = null;
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                using (connection = Helpers.NewConnection())
                {
                    string query = $"select Amount, Date from Transactions where AccountId = '{id}'";
                    command = new SqlCommand(query, connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    var transactions = new List<Transaction>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var amount = (float)reader.GetDouble(0);
                            var date = reader.GetDateTime(1);
                            transactions.Add(new Transaction(amount, date));
                        }
                    }
                    return Ok(transactions);
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

        [HttpPost, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult AddTransaction(Guid id, Transaction transaction)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                using (connection = Helpers.NewConnection())
                {
                    string updateQuery = $"update Accounts set Amount = Amount + {transaction.Amount} where Id = '{id}'";
                    command = new SqlCommand(updateQuery, connection);
                    connection.Open();
                    if (command.ExecuteNonQuery() != 1)
                        return BadRequest("Could not update account amount");

                    string insertQuery = $"INSERT INTO Transactions (Id, Amount, Date, AccountId) VALUES ('{Guid.NewGuid()}', {transaction.Amount}, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{id}')";
                    command = new SqlCommand(insertQuery, connection);
                    if (command.ExecuteNonQuery() != 1)
                        return BadRequest("Could not insert the transaction");

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        
    }
}