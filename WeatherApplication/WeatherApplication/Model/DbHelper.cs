using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WeatherApplication.Entity;

namespace WeatherApplication.Model
{
    public class DbHelper
    {
        private DataContextcs _context;

        public DbHelper(DataContextcs contextcs)
        {
            _context = contextcs;
        }

        public List<ResultsModel> GetResults()
        {
            List<ResultsModel> response = new List<ResultsModel>();
            var dataList = _context.Results.ToList();
            dataList.ForEach(row => response.Add(new ResultsModel()
            {
                Id = row.Id,
                Location = row.Location,
                Temp = row.Temp,
                Country = row.Country
            }));
            return response;
        }

        public ResultsModel GetResultsById(int id)
        {
            ResultsModel response = new ResultsModel();
            var row = _context.Results.Where(d => d.Id.Equals(id)).FirstOrDefault();
                return new ResultsModel()
                {
                    Id = row.Id,
                    Location = row.Location,
                    Temp = row.Temp,
                    Country = row.Country
                };
            
        }


        public void SaveResult(ResultsModel resultsModel)
        {
            Entity.Results dbTable;

            if (resultsModel.Id > 0)
            {
                // Update existing record
                dbTable = _context.Results.FirstOrDefault(d => d.Id == resultsModel.Id);

                if (dbTable != null)
                {
                    dbTable.Location = resultsModel.Location;
                    dbTable.Temp = resultsModel.Temp;
                    dbTable.Country = resultsModel.Country;
                }
            }
            else
            {
                // Insert new record
                dbTable = new Entity.Results
                {
                    Location = resultsModel.Location,
                    Temp = resultsModel.Temp,
                    Country = resultsModel.Country
                };

                _context.Results.Add(dbTable);
            }

            _context.SaveChanges();
        }
        public void UpdateResult(ResultsModel resultsModel)
        {
            Entity.Results dbTable;

            
            
                // Update existing record
                dbTable = _context.Results.FirstOrDefault(d => d.Id == resultsModel.Id);

                
                
                    dbTable.Location = resultsModel.Location;
                    dbTable.Temp = resultsModel.Temp;
                    dbTable.Country = resultsModel.Country;
                
            
            

            _context.SaveChanges();
        }


        public void DeleteResults(int id)
        {
            var resultToDelete = _context.Results.FirstOrDefault(r => r.Id == id);
            if (resultToDelete != null)
            {
                _context.Results.Remove(resultToDelete);
                _context.SaveChanges();
            }
        }
    }
}
