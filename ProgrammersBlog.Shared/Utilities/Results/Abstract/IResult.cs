using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    interface IResult
    {

        public ResultStatus ResultStatus { get;} // ResultStatus.Succes şeklinde kullanılır.
        public string Message { get;} // Get Olmalarının sebebi değiştirilemez olmaları
        public Exception Exception { get;}

    }
}
