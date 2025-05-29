using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.IdentityModule;

namespace Domain.Entities
{
    public class CompanyJobs : BaseEntity<int>
    {
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public ICollection<Job> Jobs { get; set; } = [];

    }
}
