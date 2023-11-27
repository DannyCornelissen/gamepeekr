using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePeekrEntities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public Guid ApiKey { get; set; }
        public string UserName { get; set; }
        public List<ReviewEntity>? Reviews { get; set; }
    }
}
