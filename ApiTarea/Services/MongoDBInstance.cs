using ApiTarea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTarea.Services
{
    static class MongoDBInstance
    {
        private readonly static MongoDbContext _instance = new MongoDbContext("192.168.56.102");

        public static MongoDbContext getInstance
        {
            get
            {
                return _instance;
            }
        }

    }
}