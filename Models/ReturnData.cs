using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCF_POC.Models
{
    public class ReturnData
    {
        public ReturnData()
        {
        }
        public ReturnData(ReturnCodes code, object data, string message)
        {
            Code = code;
            Data = data;
            Message = message;
            Messages = new List<string>();
        }
        public object Data { get; set; }
        public ReturnCodes Code { get; set; }
        public string Message { get; set; }
        public List<string> Messages { get; set; }
    }
    public enum ReturnCodes
    {
        Error = 0,
        Success = 200
    }
}
