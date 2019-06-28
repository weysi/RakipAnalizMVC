using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UnitOfWork
    {
        RakipContext db = new RakipContext();
        #region props
        public BaseRepository<Marka> MarkaRep;
       public BaseRepository<UrunGrubu> UrunGrubuRep;
       public UrunRepository UrunRep;
       public BaseRepository<Kayit> KayitRep;
       public BaseRepository<RakipAnaliz> RakipAnalizRep;
        #endregion
        public UnitOfWork()
        {
            MarkaRep = new BaseRepository<Marka>(db);
            UrunGrubuRep = new BaseRepository<UrunGrubu>(db);
            UrunRep = new UrunRepository(db);
            KayitRep = new BaseRepository<Kayit>(db);
            RakipAnalizRep = new BaseRepository<RakipAnaliz>(db);
        }
    }
}
