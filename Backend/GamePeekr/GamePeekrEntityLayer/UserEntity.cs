﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePeekrEntities
{
    public class UserEntity
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<ReviewEntity>? Reviews { get; set; }
    }
}
