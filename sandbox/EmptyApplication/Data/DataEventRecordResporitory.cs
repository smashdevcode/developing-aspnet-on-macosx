using System.Collections.Generic;
using EmptyApplication.Models;
using Microsoft.Framework.Logging;
using System.Linq;

namespace EmptyApplication.Data
{
	public class DataEventRecordResporitory : IDataEventRecordResporitory
    {
        private readonly DataEventRecordContext _context;

        private readonly ILogger _logger;

        public DataEventRecordResporitory(DataEventRecordContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("IDataEventRecordResporitory");          
        }

        public List<DataEventRecord> GetAll()
        {
            _logger.LogCritical("Getting a the existing records");
            return _context.DataEventRecords.ToList();
        }

        public DataEventRecord Get(int id)
        {
            return _context.DataEventRecords.First(t => t.Id == id);
        }

        public void Post(DataEventRecord dataEventRecord )
        {
            _context.DataEventRecords.Add(dataEventRecord);
            _context.SaveChanges();
        }

        public void Put(int id, DataEventRecord dataEventRecord)
        {
            _context.DataEventRecords.Update(dataEventRecord);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.DataEventRecords.First(t => t.Id == id);
            _context.DataEventRecords.Remove(entity);
            _context.SaveChanges();
        }
    }	
}
