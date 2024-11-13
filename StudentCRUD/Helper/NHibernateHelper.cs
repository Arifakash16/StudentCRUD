using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using StudentCRUD.Mapping;
using System;
using System.IO;
using StudentCRUD.Models;

namespace StudentCRUD.Helper
{
    public class NHibernateHelper
    {

        private static ISessionFactory _sessionFactory;

        public static NHibernate.ISession OpenSession()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString("Server=DESKTOP-007;Database=StudentDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Student>())
                    .BuildSessionFactory();
            }
            return _sessionFactory.OpenSession();
        }
    }
}
