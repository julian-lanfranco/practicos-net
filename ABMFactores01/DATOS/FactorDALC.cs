using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace DATOS
{
    public class FactorDALC
    {
        
       public List<Factor> GetFactores()
       { 
       {
           using (adminproyectosEntities db = new adminproyectosEntities())
                {
                    return db.Factor.ToList();
                }
            }
          
        }

       public static bool Existe(int id)
         {
            using (adminproyectosEntities db = new adminproyectosEntities())
                {
                   var query = (from al in db.Factor where al.idFactor == id select al).Count();
                    if (query == 0)
                    return false;
                    else
                    return true;
                }   
        }

       public static Factor GetFactor(int id)
            {
             Factor fact = new Factor();
                using (adminproyectosEntities db = new adminproyectosEntities())
                    {
                        var query = (from al in db.Factor
                         where al.idFactor == id
                         select al).Single();

                        fact.idFactor = query.idFactor;
                        fact.nombre = query.nombre;
                        fact.detalle = query.detalle;
                        fact.estado = query.estado;
            
                    }   
            return fact;
            }

       public static Factor CreateFactor(Factor fact)
            {
            Factor factor = new Factor();
            using (adminproyectosEntities db = new adminproyectosEntities())
                {
           
                    factor.nombre = fact.nombre;
                    factor.detalle=fact.detalle;
                    factor.estado=fact.estado;
            
                    db.Factor.Add(factor);
                    db.SaveChanges();

                }
            return factor;
            }

       public static Factor UpdateFactor(Factor fact)
    {
        using (adminproyectosEntities db = new adminproyectosEntities())
        {
            var query = (from al in db.Factor
                         where al.idFactor == fact.idFactor
                         select al).Single();
 
            query.nombre = fact.nombre;
            query.detalle = fact.detalle;
            query.estado = fact.estado;
           
          db.SaveChanges();
        }
        return fact;
    }

       public static void deleteFactor(int id)
            {
             Factor fact = new Factor();
             using (adminproyectosEntities db = new adminproyectosEntities())
                {
                 var query = (from al in db.Factor
                 where al.idFactor == id
                 select al).Single();
                 db.Factor.Remove(query);
                 db.SaveChanges();
                 }   
           
            }

        }

        }


    

