﻿using System;

namespace ManufacturerManagerTS.DataAccess
{
    public interface IAuditableObject
    {
        DateTime Created { get; set; }

        int CreatedById { get; set; }

        DateTime LastUpdated { get; set; }

        int LastUpdatedById { get; set; }
    }
}
