using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDASCommunicationApp
{
    /// <summary>
    /// XDAS 태그 데이터를 표현할 때 사용합니다
    /// </summary>
    public class XDASTagValue
    {
        public string TagName { get; set; }
        public object Value { get; set; }
        public string Quality { get; set; }
        public DateTime Timestamp { get; set; }
        public string ErrorMessage { get; set; }
    }
}
