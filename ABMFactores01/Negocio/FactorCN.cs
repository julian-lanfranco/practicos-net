using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DATOS;

namespace Negocio
{
    public class FactorCN
    {
        public static List<Factor> GetFactores()
        {
            FactorDALC obj = new FactorDALC();
            return obj.GetFactores();
        }

        public static bool Existe(int id)
        {
            FactorDALC obj = new FactorDALC();
            return FactorDALC.Existe(id);
        }

        public static Factor GetFactor(int id)
        {       
            return FactorDALC.GetFactor(id);
        }

        public static Factor CreateFactor(Factor fact)
        {
            return FactorDALC.CreateFactor(fact);
        }

        public static Factor UpdateFactor(Factor fact)
        {
           return  FactorDALC.UpdateFactor(fact);

        }

        public static void deleteFactor(int id)
        {
         FactorDALC.deleteFactor(id); 
        }

    }
}
