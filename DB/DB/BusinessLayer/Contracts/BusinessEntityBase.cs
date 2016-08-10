﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.BusinessLayer.Contracts
{
    public class BusinessEntityBase : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get; set;
        }
    }
}
