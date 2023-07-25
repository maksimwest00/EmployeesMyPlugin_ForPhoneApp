using Newtonsoft.Json;
using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesMyPlugin
{
    [Author(Name = "Maksim Sukharev")]
    public class Plugin : IPluggable
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {
            logger.Info("{My} Loading employees");

            List<EmployeesDTO> employeesList = JsonConvert.DeserializeObject<List<EmployeesDTO>>(EmployeesMyPlugin.Properties.MyResources.EmployeesJson);

            logger.Info($"{{My}} Loaded {employeesList.Count()} employees");
            return employeesList.Cast<DataTransferObject>();
        }
    }
}
