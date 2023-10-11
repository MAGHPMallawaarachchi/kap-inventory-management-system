﻿using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system_kap.Controllers
{
    public class InvoiceController
    {
        private readonly InvoiceRepository _invoiceRepository;

        public InvoiceController(InvoiceRepository repository)
        {
            this._invoiceRepository = repository;
        }

        public IEnumerable<InvoiceModel> GetAllInvoices()
        {
            return _invoiceRepository.GetAll();
        }

    }
}
