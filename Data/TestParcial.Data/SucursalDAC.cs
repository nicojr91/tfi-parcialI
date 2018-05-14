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
    public class SucursalDAC : DataAccessComponent
    {
        public Sucursal Create(Sucursal suc)
        {
            const string sqlStatement = "INSERT INTO dbo.Sucursal ([zona], [latitud], [longitud], [full_dir]) VALUES (@zona, @latitud, @longitud, @dir); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@zona", DbType.String, suc.Zona);
                db.AddInParameter(cmd, "@latitud", DbType.String, suc.Latitud);
                db.AddInParameter(cmd, "@longitud", DbType.String, suc.Longitud);
                db.AddInParameter(cmd, "@dir", DbType.String, suc.Direccion);
                // Obtener el valor de la primary key.
                suc.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return suc;
        }

        public Sucursal Update(Sucursal suc)
        {
            const string sqlStatement = "UPDATE dbo.Sucursal SET [latitud] = @latitud, [longitud] = @longitud, [full_dir] = @dir WHERE [Id] = @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@latitud", DbType.String, suc.Longitud);
                db.AddInParameter(cmd, "@longitud", DbType.String, suc.Latitud);
                db.AddInParameter(cmd, "@Id", DbType.Int32, suc.Id);

                db.ExecuteNonQuery(cmd);
            }

            return suc;
        }

        public List<Sucursal> SelectAll()
        {
            const string sqlStatement = "SELECT [Id], [zona], [latitud], [longitud], [full_dir] FROM dbo.Sucursal ";

            var result = new List<Sucursal>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        result.Add(LoadSucursal(dr));
                    }
                }
            }

            return result;
        }

        public bool Remove(int Id)
        {
            const string sqlStatement = "DELETE FROM dbo.Sucursal WHERE [Id] = @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, Id);
                db.ExecuteNonQuery(cmd);
            }

            return true;
        }

        public Sucursal SelectById(int Id)
        {
            const string sqlStatement = "SELECT [Id], [zona], [latitud], [longitud], [full_dir] FROM dbo.Sucursal WHERE Id = @Id";

            Sucursal price = new Sucursal();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, Id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        price = LoadSucursal(dr); // Mapper
                    }
                }
            }

            return price;
        }

        private Sucursal LoadSucursal(IDataReader dr)
        {
            Sucursal student = new Sucursal();

            student.Id = GetDataValue<int>(dr, "Id");
            student.Zona = GetDataValue<string>(dr, "zona");
            student.Longitud = GetDataValue<string>(dr, "longitud");
            student.Latitud = GetDataValue<string>(dr, "latitud");
            student.Direccion = GetDataValue<string>(dr, "full_dir");

            return student;
        }
    }
}
