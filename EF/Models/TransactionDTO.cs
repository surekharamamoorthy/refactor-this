using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF.Models
{
    public class TransactionDTO
    {
        public float Amount { get; set; }

        public DateTime Date { get; set; }

        //public TransactionDTO(float amount, DateTime date)
        //{
        //    Amount = amount;
        //    Date = date;
        //}

        public TransactionDTO()
        {
           
        }
    }
}