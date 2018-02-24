using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Interface.Models.Templates.Commons;

namespace Zal.Beauty.Interface.Models.Results.Commons
{
    public class FileResult: FileTemplate
    {
        /// <summary>
        /// OSSUrl
        /// </summary>
        public String Url { get; set; }
    }
}
