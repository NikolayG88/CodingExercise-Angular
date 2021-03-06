﻿using System;

namespace Application.Interfaces
{
    public interface IToDoItem
    {
        int? Id { get; set; }
        string Name { get; set; }
        int StatusId { get; set; }
        DateTime DueIn { get; set; }
        string Description { get; set; }

    }
}
