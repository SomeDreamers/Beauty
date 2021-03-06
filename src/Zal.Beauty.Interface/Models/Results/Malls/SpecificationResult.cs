﻿using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Interface.Models.Templates.Malls;

namespace Zal.Beauty.Interface.Models.Results.Malls
{
    /// <summary>
    /// 规格值数据结果
    /// </summary>
    public class SpecificationResult : SpecificationTemplate
    {
        /// <summary>
        /// 规格值
        /// </summary>
        public List<SpecificationValueResult> Values { get; set; }
    }
}
