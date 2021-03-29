using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Database : IEntity
	{
		public int Id { get; set; }
		public int CompanyId { get; set; }
		public int LocalId { get; set; }
		public string DbName { get; set; }
		public string DbPass { get; set; }
		public string Sunucu { get; set; }
		public string DbUser { get; set; }

	}
}
