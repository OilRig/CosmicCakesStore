﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicCakes.DAL.Entities;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IEmailTemplateRepository:IRepository<EmailTemplate>
    {
        EmailTemplate GetTemplateByName(string templateName);
        IEnumerable<string> GetTemplateNamesOnly();
    }
}
