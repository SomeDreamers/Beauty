using Aliyun.OSS;
using Aliyun.OSS.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Zal.Beauty.Base.Enums;
using Zal.Beauty.Base.Models;
using Zal.Beauty.Base.Utils;
using Zal.Beauty.Interface.Models.Parameters.Commons;

namespace Pls.Utils.oss
{
    /// <summary>
    /// 阿里云oss操作类
    /// </summary>
    public static class OssOptionUtil
    {
        public static OssClient client = new OssClient(OssConfig.endpoint, OssConfig.accessKeyId, OssConfig.accessKeySecret);
        /// <summary>
        /// 上传图片的Demo路径(本地上传路径)
        /// </summary>
        public static string localhost_image = Path.DirectorySeparatorChar + "upload" + Path.DirectorySeparatorChar;
        static OssOptionUtil()
        {
//#if DEBUG
//            client = new OssClient(OssConfig.endpoint, OssConfig.accessKeyId, OssConfig.accessKeySecret);
//#endif
        }

        /// <summary>
        /// 判断文件是否符合上传条件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static ReturnResult CheckFile(IFormFile file)
        {
            ReturnResult result = new ReturnResult();
            if (file == null)
            {
                result.IsSuccess = false;
                result.Message = "文件不存在";
                return result;
            }
            /*获取文件后缀*/
            var file_name = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            string extension = new FileInfo(file_name).Extension.ToLower();
            long size = file.Length / 1024;
            if (RegexUtil.GetFileType(extension) == FileType.image)
            {
                //图片不能大于1M
                if (size > 1024)
                {
                    result.IsSuccess = false;
                    result.Message = "上传图片不能大于1M";
                    return result;
                }
            }
            else
            {
                if (size > 2048)
                {
                    //文件不能大于2M
                    result.IsSuccess = false;
                    result.Message = "上传文件不能大于2M";
                    return result;
                }

            }
            result.Message = file_name;
            return result;

        }

        /// <summary>
        /// 获取OSS key
        /// </summary>
        /// <param name="files">上传文件的流信息</param>
        /// <param name="absolutely_address">存放的绝对路径</param>
        /// <param name="webRootPath">系统初始化路径</param>
        /// <param name="result_number">返回执行失败的错误码</param>
        ///  <param name="tagId">图片分类ID</param>
        /// <returns></returns>
        public static Dictionary<String,String> GetOSSKey(IFormFile file, string absolutely_address, string webRootPath,String file_name)
        {
            //读取图片名称和图片后缀
            string extension = new FileInfo(file_name).Extension.ToLower();

            //复制图片到本地临时文件夹
            file_name = CommonUtil.ReadDateTime()+ file.Length + extension;
            var fileToUpload = webRootPath + absolutely_address+ file_name;
            using (FileStream fs = File.Create(fileToUpload))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            //MD5获取素材key值
            string md5;
            using (var fs = File.Open(fileToUpload, FileMode.Open))
            {
                md5 = OssUtils.ComputeContentMd5(fs, fs.Length);
            }
            var key = md5.Replace("/", "@") + extension;
            // File.Delete(fileToUpload);
            Dictionary<String,String> map = new Dictionary<String, String>();
            map.Add("filePath",fileToUpload);
            map.Add("fileKey", key);
            return map;
        }

        /// <summary>
        /// 素材生成唯一MD5值
        /// </summary>
        /// <param name="fileToUpload"></param>
        /// <param name="extension"></param>
        /// <param name="file_name_noextension"></param>
        /// <param name="size"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public static FileParameter OssUpload(string fileToUpload, IFormFile file,String file_name,long tagId,String key)
        {
            //读取图片名称和图片后缀
            string extension = new FileInfo(file_name).Extension.ToLower();
            string file_name_noextension = file_name.ToString().Replace(extension, "");
            //获取图片大小（k）
            long size = file.Length / 1024;
            FileParameter fileParameter = new FileParameter();
            fileParameter.TagId = tagId;
            fileParameter.Name = file_name_noextension;
            fileParameter.Type = (int)RegexUtil.GetFileType(extension);
            fileParameter.OssKey = key;
            fileParameter.Postfix = extension;
            fileParameter.Size = size;
            fileParameter.IsDel = false;
            fileParameter.CreateTime= DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            var result = client.PutObject(OssConfig.bucket, key, fileToUpload);
            return fileParameter;
        }

        /// <summary>
        /// 通过osskey后去ossURL
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String GetOSSUrl(String key)
        {
            GeneratePresignedUriRequest request;
            request = new GeneratePresignedUriRequest(OssConfig.bucket, key);
            var url = client.GeneratePresignedUri(request);
            return url.ToString();
        } 
    }
}
