using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Zal.Beauty.Core.ORM.Commons;
using Zal.Beauty.Interface.Models.Parameters.Commons;
using Zal.Beauty.Interface.Models.Results.Commons;

namespace Zal.Beauty.Core.MapProfiles.Commons
{
    public class FileProfile:Profile
    {
        public FileProfile()
        {
            CreateMap<FileParameter,File>();
            CreateMap<File,FileResult>();
        }
    }
}
