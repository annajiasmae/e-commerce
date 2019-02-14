using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerceApp.Database;
using ecommerceApp.Entities;

namespace ecommerceApp.services
{
   public class CategoriesService
    {
        #region Singleton
        public static CategoriesService Instance
        {
            get
            {
                if (instance == null) instance = new CategoriesService();
                return instance;
            }
        }

        private static CategoriesService instance { get; set; }
        private CategoriesService() { }
        #endregion

        public Categorie GetCategorie(int Id)
        {
            using (var context = new CBContext())
            {
                return context.Categories.Find(Id);
            }

        }

        public List<Categorie> GetCategories()
        {
            using (var context = new CBContext())
            {
                return context.Categories.ToList();
            }

        }

        public void SaveCategorie(Categorie c)
        {
            
            using (var context = new CBContext())
            {
                context.Categories.Add(c);
                context.SaveChanges();
            }

        }

        public void EditCategorie(Categorie cat)
        {
            Console.WriteLine(" from service id ="+cat.Id);
            using (var context = new CBContext())
            {
                context.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                /*context.Database.ExecuteSqlCommand("Update dbo.Categories SET nom = {0} , description = {1} WHERE Id ={2} ",cat.nom,cat.description,cat.Id);
                SqlParameter p = new SqlParameter("@nom", cat.nom);
                SqlParameter p5 = new SqlParameter("@description", cat.description);
                SqlParameter p6 = new SqlParameter("@id", cat.Id);*/
            }

        }

        public void DeleteCategorie(Categorie cat)
        {

            using (var context = new CBContext())
            {
                context.Entry(cat).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                /*context.Database.ExecuteSqlCommand("Update dbo.Categories SET nom = {0} , description = {1} WHERE Id ={2} ",cat.nom,cat.description,cat.Id);
                SqlParameter p = new SqlParameter("@nom", cat.nom);
                SqlParameter p5 = new SqlParameter("@description", cat.description);
                SqlParameter p6 = new SqlParameter("@id", cat.Id);*/
            }

        }
    }
}
