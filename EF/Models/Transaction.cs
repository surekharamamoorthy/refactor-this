﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF.Models
{
    public class Transaction
    {
        public float Amount { get; set; }

        public DateTime Date { get; set; }

        public Transaction(float amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }
    }
}