using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TaskManager.ResultAggrigate.Entity;

public class Result
{
    public bool Flag { get; set; }
    public string Message { get; set; }

    public Result(bool flag, string message)
    {
        Flag = flag;
        Message = message;
    }
}
