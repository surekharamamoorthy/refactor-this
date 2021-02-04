using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF.Models
{
    public class Account
    {
        private bool isNew;

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public float Amount { get; set; }

        public Account()
        {
            isNew = true;
        }

        public Account(Guid id)
        {
            isNew = false;
            Id = id;
        }
        //public IEnumerable<Account> GetAccounts()
        //{
        //    List<Account> acc = null;
        //    refactorEntities refEntObj = new refactorEntities();
        //    refEntObj.Accounts.Select(s => new Account { Id = s.Id, Name = s.Name, Amount = (float)s.Amount, Number = s.Number }).ToList();            
        //    return acc.ToList();
        //}

        //public void Save()
        //{
        //    SqlDataReader reader = null;
        //    SqlConnection connection = null;
        //    SqlCommand command = null;
        //    try
        //    {
        //        using (connection = Helpers.NewConnection())
        //        {
        //            if (isNew)

        //                command = new SqlCommand($"insert into Accounts (Id, Name, Number, Amount) values ('{Guid.NewGuid()}', '{Name}', {Number}, 0)", connection);
        //            else
        //                command = new SqlCommand($"update Accounts set Name = '{Name}' where Id = '{Id}'", connection);

        //            connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (connection.State == ConnectionState.Open)
        //            connection.Close();
        //    }
        //}

        //public void Delete()
        //{
        //    SqlConnection connection = null;
        //    SqlCommand command = null;
        //    try
        //    {
        //        using (connection = Helpers.NewConnection())
        //        {
        //            string query = $"delete from Accounts where Id = '{Id}'";
        //            command = new SqlCommand(query, connection);
        //            connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (connection.State == ConnectionState.Open)
        //            connection.Close();
        //    }
        //}
    }
}