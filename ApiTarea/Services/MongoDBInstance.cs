using ApiTarea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTarea.Services
{
    static class MongoDBInstance
    {
        private readonly static MongoDbContext _instance = new MongoDbContext("192.168.0.220");

        public static MongoDbContext getInstance
        {
            get
            {
                return _instance;
            }
        }

    }
}