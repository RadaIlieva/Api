using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.SwitchServices.Interfaces
{
    internal interface IOrganizationConsoleService
    {
        Task HandleOperation(string choice);
    }
}
