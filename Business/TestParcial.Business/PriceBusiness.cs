using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestParcial.Data;
using TestParcial.Entities;

namespace TFIParcial.Business
{
    public class PriceBusiness
    {
        private PriceDAC dac;

        public PriceBusiness()
        {
            dac = new PriceDAC();
        }

        public List<Price> All()
        {
            return dac.SelectAll();

        }
        public Price Add(Price price)
        {
            return dac.Create(price);
        }

        public bool Remove(int Id)
        {
            return dac.Remove(Id);
        }

        public Price Edit(Price price)
        {
            return dac.Update(price);
        }

        public Price FindByKm(float km)
        {
            return dac.SelectByKm(km);
        }
    }
}
