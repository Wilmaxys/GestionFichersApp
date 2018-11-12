using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFichersApp.Databases
{
    public class GestionFichersDatabase
    {
        #region Singleton

        private static Lazy<GestionFichiersEntities> Instance = new Lazy<GestionFichiersEntities>(() => new GestionFichiersEntities());

        //public static GestionFichiersEntities Current
        //{
        //    get
        //    {
        //        return Instance.Value;
        //    }
        //}

        public static GestionFichiersEntities Current => Instance.Value;

        #endregion

        #region Static func
        
        public static void ReinitializeDatabase()
        {
            if (Instance.IsValueCreated)
            {
                Instance = new Lazy<GestionFichiersEntities>(() => new GestionFichiersEntities());
            }
        }

        #endregion
    }
}
