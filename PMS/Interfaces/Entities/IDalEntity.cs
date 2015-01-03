using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Entities
{
    interface IDalEntity
    {
        Guid Id { get; set; }
    }
}
