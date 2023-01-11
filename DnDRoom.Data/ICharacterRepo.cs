﻿using DnDRoom.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Data
{
    public interface ICharacterRepo
    {
        Task Create(Character chaacter);
    }
}
