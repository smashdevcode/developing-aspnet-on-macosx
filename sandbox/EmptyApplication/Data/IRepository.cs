using System.Collections.Generic;
using EmptyApplication.Models;

namespace EmptyApplication.Data
{
	public interface IRespository
	{
		void Delete(int id);
		Record Get(int id);
		List<Record> GetAll();
		void Post(Record record);
		void Put(int id, Record record);
	}
}
