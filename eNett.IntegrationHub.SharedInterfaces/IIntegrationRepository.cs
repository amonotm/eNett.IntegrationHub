﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNett.IntegrationHub.SharedInterfaces
{
    public interface IIntegrationRepository
    {
        DateTime GetUpdateTimeBySystemAndTableName(string systemName, string tableName);
    }
}
