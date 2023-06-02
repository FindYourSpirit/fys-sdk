using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYS_SDK.src.Interfaces
{
    public interface IApiCommand
    {
        Task<string> ExecuteAsync(string endpoint, HttpContent content);
    }
}
