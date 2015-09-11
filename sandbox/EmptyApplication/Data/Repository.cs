using System.Collections.Generic;
using EmptyApplication.Models;
using Microsoft.Framework.Logging;
using System.Linq;

namespace EmptyApplication.Data
{
	public class Respository : IRespository
    {
        private readonly Context _context;

        private readonly ILogger _logger;

        public Respository(Context context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("IRepository");
        }

        public List<Record> GetAll()
        {
            _logger.LogCritical("Getting a the existing records");
            return _context.Records.ToList();
        }

        public Record Get(int id)
        {
            return _context.Records.First(t => t.Id == id);
        }

        public void Post(Record record)
        {
            _context.Records.Add(record);
            _context.SaveChanges();
        }

        public void Put(int id, Record record)
        {
            _context.Records.Update(record);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Records.First(t => t.Id == id);
            _context.Records.Remove(entity);
            _context.SaveChanges();
        }
    }
}
