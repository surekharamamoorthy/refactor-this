using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EF.Models;

namespace EF.Controllers
{
    public class TransactionController : ApiController
    {
        private refactorEntities db = new refactorEntities();

        [HttpGet, Route("api/Accounts/{id}/Transactions")]
        public List<TransactionDTO> GetTransactions(Guid id)      
        
        {
            Transaction trans = db.Transactions.Find(id);
            if(trans == null)
            {
             //   return NotFound();
            }

            return (from p in db.Transactions
                    where p.Id == id
                    select new TransactionDTO { Amount = (float)p.Amount, Date = (DateTime)p.Date }).ToList();

        }

        [HttpPost, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult AddTransaction(Guid id, Transaction transaction)
        {
            Transaction trans = new Transaction();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id !=null)
            {
                db.Entry(trans).State = EntityState.Modified;
            }
            else
                db.Transactions.Add(transaction);
            

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TransactionExists(trans.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return Ok();

        }
        private bool TransactionExists(Guid id)
        {
            return db.Transactions.Count(e => e.Id == id) > 0;
        }

    }
}
    
