using bumbo.poc.data.Models;
using bumbo.poc.data.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Linq;

namespace bumbo.poc.web.Models
{
    public class PrognoseViewModel
    {
        public int BranchId { get; set; }

        public int year { get; set;}

        public int week { get; set; }

        //Relatief? Beetje beun
        public int DaysInWeek = 7;
        public DateTime FirstDayOfWeek { get; set; }
        public List<int>? ExpectedPackages { get; set; }
        public List<int>? ExpectedCustomers { get; set; }
    }
}
