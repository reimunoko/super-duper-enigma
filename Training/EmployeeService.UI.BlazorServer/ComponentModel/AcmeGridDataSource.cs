using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EmployeeService.UI.Business.Model.Dto;
using EmployeeService.UI.Model;

namespace EmployeeService.UI.BlazorServer.ComponentModel
{
    public class AcmeGridDataSource<TEnumerable, TEnumerableType>
        where TEnumerable : IEnumerable<TEnumerableType> where TEnumerableType : class
    {
        private AcmeGridDataSource()
        {

        }

        public AcmeGridDataSource(IEnumerable<TEnumerableType> dataSource)
        {
            DataSource = dataSource;
        }

        public IEnumerable<string> Columns => DataSource == null ? null : DataSource.First().GetType().GetProperties()
                    .Where(x => Attribute.IsDefined(x, typeof(AcmeGridColumnAttribute)))
                    .Select(p => p.GetCustomAttribute<AcmeGridColumnAttribute>().Name);

        public IEnumerable<TEnumerableType> DataSource { get; set; }

         
    }


    public class Testing
    {
        public Testing()
        {
            var coll = new AcmeGridDataSource<List<DepartmentDto>, DepartmentDto>(
                new List<DepartmentDto>());


            foreach (var ds in coll.DataSource)
            {
                var dsprop = ds.GetType().GetProperties();
                foreach (var item in coll.Columns)
                {
                    dsprop.First(x => x.Name == item).GetValue(ds, null);
                }
            }




        }

    }
}
