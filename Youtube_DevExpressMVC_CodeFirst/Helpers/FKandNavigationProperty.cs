using System.Collections.Generic;
using System.Reflection;
using YoutubeDevExpressMVC.Web.Models.Db;

namespace YoutubeDevExpressMVC.Web.Helpers
{
    public class FKandNavigationProperty
    {
        public FKandNavigationProperty()
        {
        }

        public string FK { get; set; }
        public PropertyInfo Navigation { get; set; }
        public IEnumerable<IEntity> Repo { get; set; }
        public string TextField { get; set; }
        public string ValueField { get; set; }
    }
}