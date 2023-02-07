using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator.Models
{
    public interface IActivityRepository
    {
        void Add(ActivityModel actModel);
        void Edit(ActivityModel actModel);
        void Delete(int id);
        IEnumerable<ActivityModel> GetAll();
        IEnumerable<ActivityModel> GetByValue(string value);//Searchs
    }
}
