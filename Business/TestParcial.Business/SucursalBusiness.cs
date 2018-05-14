using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestParcial.Data;
using TestParcial.Entities;

namespace TFIParcial.Business
{
    public class SucursalBusiness
    {
        private SucursalDAC dac;

        public SucursalBusiness()
        {
            dac = new SucursalDAC();
        }

        public List<Sucursal> All()
        {
            return dac.SelectAll();

        }
        public Sucursal Add(Sucursal suc)
        {
            return dac.Create(suc);
        }

        public bool Remove(int Id)
        {
            return dac.Remove(Id);
        }

        public Sucursal Edit(Sucursal suc)
        {
            return dac.Update(suc);
        }

        public Sucursal FindById(int Id)
        {
            return dac.SelectById(Id);
        }
    }
}
