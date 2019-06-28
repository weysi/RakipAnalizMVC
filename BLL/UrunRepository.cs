using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UrunRepository : BaseRepository<Urun>
    {
        RakipContext _db;
        public UrunRepository(RakipContext db) : base(db)
        {
            _db = db; //db: Unit of work'ten geliyor
        }

        public void GruplaEkle(Urun urun, int MarkaId, int[] gruplar)
        {
            //doğrusu
            //db den markayı seçtiğimiz için, mevcut bir kayıt olduğunu biliyor
            urun.Marka = _db.Markalar.Find(MarkaId);

            //yanlış:
            /*urun.Marka = new Marka() { Id = MarkaId, MarkaAdi = "adi" };
             aynı bilgiler olsa bile bu yeni marka.
             */

            urun.UrunGruplari = _db.UrunGruplari
                .Where(x => gruplar.Contains(x.Id))
                .ToList();
            //veya
            var sorgu = from x in _db.UrunGruplari
                        where gruplar.Contains(x.Id)
                        select x;
            urun.UrunGruplari = sorgu.ToList();

            _db.Urunler.Add(urun);
            _db.SaveChanges();
        }


        public override void Sil(int id)
        {
            //çoka çok ilişkiden dolayı ürünü silmeden önce ürün gruplarıyla ilgili kayıtlarını silmeliyiz
            var urun = BirTaneGetir(id);
            urun.UrunGruplari = new List<UrunGrubu>();
            Guncelle(urun);

            base.Sil(id); //ürünü sil
        }

        public override void Guncelle(IEntity yenientity)
        {
            Urun yeni = yenientity as Urun;
            var eski = BirTaneGetir(yeni.Id);

            eski.UrunGruplari.Clear();

            eski.Marka = yeni.Marka;
            eski.UrunGruplari = yeni.UrunGruplari;
            eski.UrunAdi = yeni.UrunAdi;
            eski.SN = yeni.SN;
            eski.ModelKodu = yeni.ModelKodu;

            _db.Entry(eski).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
