﻿using Microsoft.Extensions.Configuration;
using System;

namespace Shared.Utility._App
{
    public class AppSettings
    {
        #region Constructor
        private static readonly IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        #endregion
        public static string SqlConnection => _configuration["ConnectionStrings:Sql"];
        public static string MongoConnection => _configuration["ConnectionStrings:Mongo"];
        public static string RedisConnection => _configuration["ConnectionStrings:Redis"];
        public static bool MongoLogging => Convert.ToBoolean(_configuration["Custom:MongoLogging"]);
        public static bool FileLogging => Convert.ToBoolean(_configuration["Custom:FileLogging"]);
        public static string FileUrl => _configuration["Custom:FileUrl"];
        public static string FilePath => _configuration["Custom:FilePath"];
        public static string AvatarResolution => _configuration["Custom:AvatarResolution"];
        public static string AvatarSize => _configuration["Custom:AvatarSize"];
    }
}