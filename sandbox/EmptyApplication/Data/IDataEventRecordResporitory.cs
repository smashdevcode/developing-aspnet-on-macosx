using System.Collections.Generic;
using EmptyApplication.Models;

namespace EmptyApplication.Data
{
	public interface IDataEventRecordResporitory
	{
		void Delete(int id);
		DataEventRecord Get(int id);
		List<DataEventRecord> GetAll();
		void Post(DataEventRecord dataEventRecord);
		void Put(int id, DataEventRecord dataEventRecord);
	}	
}
