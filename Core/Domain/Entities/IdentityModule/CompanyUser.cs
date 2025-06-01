using Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.IdentityModule
{
	public class CompanyUser : AppUser
	{
		#region Properties
		public string CompanyName { get; set; } = default!;
		public string Size { get; set; } = default!;
		public string Industry { get; set; } = default!;
		public string WebsiteUrl { get; set; } = default!;
        #endregion
    }
}
