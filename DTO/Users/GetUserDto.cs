﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_test.DTO
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
