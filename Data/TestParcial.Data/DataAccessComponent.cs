using System;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TFIParcial.Data
{
    /// <summary>
    /// Base data access component class.
    /// </summary>
    public abstract class DataAccessComponent
    {
        protected const string CONNECTION_NAME = "default";

        static DataAccessComponent()
        {
            // Required for Enterprise Library DAAB 6.0 when using Database Factories.
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
        }

        protected int PageSize
        {
            get
            {
                // TODO: Define PageSize in config file.
                return Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            }
        }

        protected static T GetDataValue<T>(IDataReader dr, string columnName)
        {
            int i = dr.GetOrdinal(columnName);

            if (!dr.IsDBNull(i))
                return (T)dr.GetValue(i);
            else
                return default(T);
        }

        protected string FormatFilterStatement(string filter)
        {
            return Regex.Replace(filter, "^(AND|OR)", string.Empty);
        }
    }
}

