using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestParcial.Entities;
using TFIParcial.Data;

namespace TestParcial.Data
{
    public class PriceDAC : DataAccessComponent
    {
        public Price Create(Price price)
        {
            const string sqlStatement = "INSERT INTO dbo.Price ([kilometers], [value]) VALUES (@kilometers, @value); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@kilometers", DbType.Int32, price.Kilometers);
                db.AddInParameter(cmd, "@value", DbType.Double, price.Value);
                // Obtener el valor de la primary key.
                price.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return price;
        }

        public Price Update(Price price)
        {
            const string sqlStatement = "UPDATE dbo.Price SET [kilometers] = @kilometers, [value] = @value WHERE [Id] = @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@kilometers", DbType.Int32, price.Kilometers);
                db.AddInParameter(cmd, "@value", DbType.Double, price.Value);
                db.AddInParameter(cmd, "@Id", DbType.Int32, price.Id);

                db.ExecuteNonQuery(cmd);
            }

            return price;
        }

        public List<Price> SelectAll()
        {
            const string sqlStatement = "SELECT [Id], [Kilometers], [value] FROM dbo.Price ";

            var result = new List<Price>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var country = LoadPrice(dr); // Mapper
                        result.Add(country);
                    }
                }
            }

            return result;
        }

        public bool Remove(int Id)
        {
            const string sqlStatement = "DELETE dbo.Country WHERE [Id] = @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, Id);
                db.ExecuteNonQuery(cmd);
            }

            return true;
        }

        public Price SelectByKm(float km)
        {
            const string sqlStatement = "SELECT TOP 1 * FROM dbo.Price WHERE kilometers >= @km";

            Price price = new Price();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@km", DbType.Double, km);
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        price = LoadPrice(dr); // Mapper
                    }
                }
            }

            return price;
        }

        public Price SelectById(int Id)
        {
            const string sqlStatement = "SELECT [Id], [Kilometers], [value] FROM dbo.Price WHERE Id = @Id";

            Price price = new Price();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        price = LoadPrice(dr); // Mapper
                    }
                }
            }

            return price;
        }

        private Price LoadPrice(IDataReader dr)
        {
            Price student = new Price();

            student.Id = GetDataValue<int>(dr, "Id");
            student.Kilometers = GetDataValue<int>(dr, "kilometers");
            student.Value = GetDataValue<double>(dr, "value");

            return student;
        }
    }
}
