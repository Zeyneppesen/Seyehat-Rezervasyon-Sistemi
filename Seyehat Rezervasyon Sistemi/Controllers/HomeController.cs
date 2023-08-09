using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seyehat_Rezervasyon_Sistemi.Controllers
{
    public class HomeController : Controller
    {
        Fonksiyonlar f = new Fonksiyonlar();

        List<TasitTipiModeli> TasitTipListe = new List<TasitTipiModeli>();
        List<FirmaBilgileriModeli> firmaBilgileriListesi = new List<FirmaBilgileriModeli>();
        List<TasitBilgileriModeli> TasitBilgileriListesi = new List<TasitBilgileriModeli>();
        List<MusteriBilgileriModeli> MusteriBilgileriListesi = new List<MusteriBilgileriModeli>();
        List<RezervasyonModeli> RezervasyonListesi = new List<RezervasyonModeli>();
        List<RezervasyonModeli> SatinListesi = new List<RezervasyonModeli>();
        List<SeferlerModeli> SeferlerModeliListesi = new List<SeferlerModeli>();
        List<TasitModeli> TasitModeliListesi = new List<TasitModeli>();
        List<IletisimModeli> IletisimModeliListesi = new List<IletisimModeli>();
        public class TasitTipiModeli
        {
            public string ID { get; set; }
            public string Tip { get; set; }
        }
        public class FirmaBilgileriModeli
        {
            public string FirmaID { get; set; }
            public string FirmaUnvani { get; set; }
            public string FaliyetAlani { get; set; }
            public string MerkezAdresi { get; set; }
            public string MerkezTel { get; set; }
            public string PersonelSayisi { get; set; }
            public string TasitSayisi { get; set; }
            public string FirmaNo { get; set; }
            public string FirmaSifre { get; set; }
        }

        public class TasitBilgileriModeli
        {
            public string ID { get; set; }
            public string Adi { get; set; }
            public string FirmaUnvani { get; set; }
            public string Tip { get; set; }
            public string KoltukSayisi { get; set; }
        }
        public class MusteriBilgileriModeli
        {
            public string ID { get; set; }
            public string Adi { get; set; }
            public string Soyadi { get; set; }
            public string Adres { get; set; }
            public string Tel { get; set; }
            public string Eposta { get; set; }
            public string Sifre { get; set; }
        }

        public class RezervasyonModeli
        {
            public string ID { get; set; }
            public string SEFERID { get; set; }
            public string TASITID { get; set; }
            public string ADI { get; set; }
            public string SOYADI { get; set; }
            public string TEL { get; set; }
            public string KALKIS { get; set; }
            public string VARIS { get; set; }
            public string KOLTUK { get; set; }
            public string TARIH { get; set; }
            public string SAAT { get; set; }
        }
        public class SeferlerModeli
        {
            public string SEFERSAYISI { get; set; }
            public string KALKIS { get; set; }
            public string VARIS { get; set; }
            public string TARIH { get; set; }
            public string SAAT { get; set; }
            public string FIYAT { get; set; }
        }
        public class TasitModeli
        {
            public string FIRMA { get; set; }
            public string TIP { get; set; }
            public string AD { get; set; }
            public string KOLTUK { get; set; }
        }

        public class IletisimModeli
        {
            public string ID { get; set; }
            public string ad { get; set; }
            public string mail { get; set; }
            public string konu { get; set; }
            public string mesaj { get; set; }
        }
        public ActionResult Yonetim()
        {
            if (Fonksiyonlar.LoginID != 0)
            {
                DataTable dtHakkinda = f.GetDataTable("select * from Hakkinda");
                if (dtHakkinda.Rows.Count>0)
                {
                    ViewBag.Mesaj = dtHakkinda.Rows[0].ItemArray[1].ToString();
                    ViewBag.Session = dtHakkinda.Rows[0].ItemArray[2].ToString();
                }
                else
                {

                    ViewBag.Mesaj = "";
                    ViewBag.Session = "";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Index");
            }
        }
        public ActionResult TasitAyar()
        {
            return View();
        }
        public ActionResult TasitBilgileri()
        {

            return View();
        }
        public ActionResult YonetimProfil()
        {

            return View();
        }

        public ActionResult TasitDuzenle(string ID)
        {
            DataTable dt3 = f.GetDataTable("select FirmaUnvani from FirmaBilgileri");
            if (dt3.Rows.Count > 0)
            {
                List<string> Firmalar = new List<string>();
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    Firmalar.Add(dt3.Rows[i].ItemArray[0].ToString());
                }
                ViewBag.Firmalar = new SelectList(Firmalar);

                DataTable dt2 = f.GetDataTable("select Tip from TasitTipi");
                if (dt2.Rows.Count > 0)
                {
                    List<string> Tipler = new List<string>();
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        Tipler.Add(dt2.Rows[i].ItemArray[0].ToString());
                    }
                    ViewBag.Tip = new SelectList(Tipler);
                }

                if (ID != null)
                {
                    ID = " where TB.ID=" + ID;

                    string sorgu = "select TB.ID,TB.Adi,FB.FirmaUnvani,TT.Tip,TB.KoltukSayisi from TasitBilgileri as TB left join FirmaBilgileri as FB on(TB.FirmaID=FB.FirmaID) left join TasitTipi as TT on(TB.TipID=TT.ID) " + ID;

                    DataTable dt = f.GetDataTable(sorgu);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < 1; i++)
                        {

                            string TID = dt.Rows[0].ItemArray[0].ToString();
                            string TAdi = dt.Rows[0].ItemArray[1].ToString();
                            string TFirmaUnvani = dt.Rows[0].ItemArray[2].ToString();
                            string TTip = dt.Rows[0].ItemArray[3].ToString();
                            string TKoltukSayisi = dt.Rows[0].ItemArray[4].ToString();


                            Fonksiyonlar.TID = TID;
                            Fonksiyonlar.TAdi = TAdi;
                            Fonksiyonlar.TFirmaUnvani = TFirmaUnvani;
                            Fonksiyonlar.TTip = TTip;
                            Fonksiyonlar.TKoltukSayisi = TKoltukSayisi;
                        }
                    }

                }
                else
                {
                    Fonksiyonlar.TID = "0";
                    Fonksiyonlar.TAdi = "";
                    Fonksiyonlar.TFirmaUnvani = "";
                    Fonksiyonlar.TTip = "";
                    Fonksiyonlar.TKoltukSayisi = "";
                }

                return View();
            }
            else
            {
                return RedirectToAction("TasitBilgileri", "Home");
            }


        }

        public ActionResult FirmaAyar()
        {
            return View();
        }
        public ActionResult FirmaDuzenleme(string ID)
        {
            if (ID != null)
            {
                ID = " where FirmaID=" + ID;

                string sorgu = "select * from FirmaBilgileri" + ID;

                DataTable dt3 = f.GetDataTable(sorgu);
                if (dt3.Rows.Count > 0)
                {
                    for (int i = 0; i < 1; i++)
                    {

                        string FirmaID = dt3.Rows[0].ItemArray[0].ToString();
                        string FirmaUnvani = dt3.Rows[0].ItemArray[1].ToString();
                        string FaliyetAlani = dt3.Rows[0].ItemArray[2].ToString();
                        string MerkezAdresi = dt3.Rows[0].ItemArray[3].ToString();
                        string MerkezTel = dt3.Rows[0].ItemArray[4].ToString();
                        string PersonelSayisi = dt3.Rows[0].ItemArray[5].ToString();
                        string TasitSayisi = dt3.Rows[0].ItemArray[6].ToString();
                        string FirmaNo = dt3.Rows[0].ItemArray[7].ToString();
                        string FirmaSifre = dt3.Rows[0].ItemArray[8].ToString();


                        Fonksiyonlar.FirmaID = FirmaID;
                        Fonksiyonlar.FirmaUnvani = FirmaUnvani;
                        Fonksiyonlar.FaliyetAlani = FaliyetAlani;
                        Fonksiyonlar.MerkezAdresi = MerkezAdresi;
                        Fonksiyonlar.MerkezTel = MerkezTel;
                        Fonksiyonlar.PersonelSayisi = PersonelSayisi;
                        Fonksiyonlar.TasitSayisi = TasitSayisi;
                        Fonksiyonlar.FirmaNo = FirmaNo;
                        Fonksiyonlar.FirmaSifre = FirmaSifre;
                    }
                }

            }
            else
            {
                Fonksiyonlar.FirmaID = "0";
                Fonksiyonlar.FirmaUnvani = "";
                Fonksiyonlar.FaliyetAlani = "";
                Fonksiyonlar.MerkezAdresi = "";
                Fonksiyonlar.MerkezTel = "";
                Fonksiyonlar.PersonelSayisi = "";
                Fonksiyonlar.TasitSayisi = "";
                Fonksiyonlar.FirmaNo = "";
                Fonksiyonlar.FirmaSifre = "";
            }

            return View();
        }
        public JsonResult FirmaEkle(FormCollection frm)
        {
            string FirmaID = frm["ID"].ToString();
            string FirmaUnvani = frm["funvan"].ToString();
            string FaliyetAlani = frm["falan"].ToString();
            string MerkezAdresi = frm["madres"].ToString();
            string MerkezTel = frm["ftel"].ToString();
            string PersonelSayisi = frm["psayi"].ToString();
            string TasitSayisi = frm["tsayi"].ToString();
            string FirmaNo = frm["fno"].ToString();
            string FirmaSifre = frm["fsifre"].ToString();
            if (FirmaID != "" && FirmaID != "0")
            {
                DataRow drsor = f.GetDataRow("select FirmaID from FirmaBilgileri where FirmaNo='" + FirmaNo + "'");
                if (drsor==null || drsor.ItemArray[0].ToString()==FirmaID)
                {
                    f.cmd("update FirmaBilgileri set FirmaUnvani='" + FirmaUnvani + "',FaliyetAlani='" + FaliyetAlani + "',MerkezAdresi='" + MerkezAdresi + "',MerkezTel='" + MerkezTel + "',PersonelSayisi='" + PersonelSayisi + "',TasitSayisi='" + TasitSayisi + "',FirmaNo='" + FirmaNo + "',FirmaSifre='" + FirmaSifre + "' where FirmaID='" + FirmaID + "'");
                }
            }
            else
            {
                DataRow drsor = f.GetDataRow("select * from FirmaBilgileri where FirmaNo='" + FirmaNo + "'");
                if (drsor == null)
                {
                    f.cmd("insert into FirmaBilgileri(FirmaUnvani,FaliyetAlani,MerkezAdresi,MerkezTel,PersonelSayisi,TasitSayisi,FirmaNo,FirmaSifre) values('" + FirmaUnvani + "','" + FaliyetAlani + "','" + MerkezAdresi + "','" + MerkezTel + "','" + PersonelSayisi + "','" + TasitSayisi + "','" + FirmaNo + "','" + FirmaSifre + "')");
                }
            }
            string sorgu = "select * from FirmaBilgileri";

            DataTable dt3 = f.GetDataTable(sorgu);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                FirmaBilgileriModeli firmaModeli = new FirmaBilgileriModeli()
                {
                    FirmaID = dt3.Rows[i]["FirmaID"].ToString(),
                    FirmaUnvani = dt3.Rows[i]["FirmaUnvani"].ToString(),
                    FaliyetAlani = dt3.Rows[i]["FaliyetAlani"].ToString(),
                    MerkezAdresi = dt3.Rows[i]["MerkezAdresi"].ToString(),
                    MerkezTel = dt3.Rows[i]["MerkezTel"].ToString(),
                    PersonelSayisi = dt3.Rows[i]["PersonelSayisi"].ToString(),
                    TasitSayisi = dt3.Rows[i]["TasitSayisi"].ToString(),
                    FirmaNo = dt3.Rows[i]["FirmaNo"].ToString(),
                    FirmaSifre = dt3.Rows[i]["FirmaSifre"].ToString(),

                };
                firmaBilgileriListesi.Add(firmaModeli);


            }
            return Json(firmaBilgileriListesi, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FirmaSil(string ID)
        {

            f.cmd("delete from FirmaBilgileri where FirmaID='" + ID + "'");
            return RedirectToAction("FirmaAyar", "Home");
        }
        public JsonResult FirmaBilgileri()
        {
            string sorgu = "select * from FirmaBilgileri";

            DataTable dt3 = f.GetDataTable(sorgu);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                FirmaBilgileriModeli firmaModeli = new FirmaBilgileriModeli()
                {
                    FirmaID = dt3.Rows[i]["FirmaID"].ToString(),
                    FirmaUnvani = dt3.Rows[i]["FirmaUnvani"].ToString(),
                    FaliyetAlani = dt3.Rows[i]["FaliyetAlani"].ToString(),
                    MerkezAdresi = dt3.Rows[i]["MerkezAdresi"].ToString(),
                    MerkezTel = dt3.Rows[i]["MerkezTel"].ToString(),
                    PersonelSayisi = dt3.Rows[i]["PersonelSayisi"].ToString(),
                    TasitSayisi = dt3.Rows[i]["TasitSayisi"].ToString(),
                    FirmaNo = dt3.Rows[i]["FirmaNo"].ToString(),
                    FirmaSifre = dt3.Rows[i]["FirmaSifre"].ToString(),

                };
                firmaBilgileriListesi.Add(firmaModeli);


            }
            return Json(firmaBilgileriListesi, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TasitBilgi()
        {
            string sorgu = "select TB.ID,TB.Adi,FB.FirmaUnvani,TT.Tip,TB.KoltukSayisi from TasitBilgileri as TB left join FirmaBilgileri as FB on(TB.FirmaID=FB.FirmaID) left join TasitTipi as TT on(TB.TipID=TT.ID)";
            DataTable dt3 = f.GetDataTable(sorgu);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                TasitBilgileriModeli tasitModeli = new TasitBilgileriModeli()
                {
                    ID = dt3.Rows[i]["ID"].ToString(),
                    Adi = dt3.Rows[i]["Adi"].ToString(),
                    FirmaUnvani = dt3.Rows[i]["FirmaUnvani"].ToString(),
                    Tip = dt3.Rows[i]["Tip"].ToString(),
                    KoltukSayisi = dt3.Rows[i]["KoltukSayisi"].ToString(),
                };
                TasitBilgileriListesi.Add(tasitModeli);


            }
            return Json(TasitBilgileriListesi, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TasitTipi()
        {
            string sorgu = "select * from TasitTipi";

            DataTable dt3 = f.GetDataTable(sorgu);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                TasitTipiModeli TasitModeli = new TasitTipiModeli()
                {
                    ID = dt3.Rows[i]["ID"].ToString(),
                    Tip = dt3.Rows[i]["Tip"].ToString()

                };
                TasitTipListe.Add(TasitModeli);


            }
            return Json(TasitTipListe, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TasitEkle(FormCollection frm)
        {
            string Name = frm["name"].ToString();
            f.cmd("insert into TasitTipi(Tip) values('" + Name + "')");
            string sorgu = "select * from TasitTipi";
            DataTable dt3 = f.GetDataTable(sorgu);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                TasitTipiModeli seferModeli = new TasitTipiModeli()
                {
                    ID = dt3.Rows[i]["ID"].ToString(),
                    Tip = dt3.Rows[i]["Tip"].ToString()

                };
                TasitTipListe.Add(seferModeli);


            }
            return Json(TasitTipListe, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TEkle(FormCollection frm)
        {
            string ID = frm["id"].ToString();
            string firma = frm["firma"].ToString();
            string tip = frm["tip"].ToString();
            string name = frm["name"].ToString();
            string ksayi = frm["ksayi"].ToString();
            DataRow dr = f.GetDataRow("select FirmaID from FirmaBilgileri where FirmaUnvani='" + firma + "'");
            firma = dr.ItemArray[0].ToString();
            DataRow dr1 = f.GetDataRow("select ID from TasitTipi where Tip='" + tip + "'");
            tip = dr1.ItemArray[0].ToString();
            if (ID != "" && ID != "0")
            {
                f.cmd("update TasitBilgileri set FirmaID='" + firma + "',TipID='" + tip + "',Adi='" + name + "',KoltukSayisi='" + ksayi + "' where ID='" + ID + "'");
            }
            else
            {
                f.cmd("insert into TasitBilgileri(FirmaID,TipID,Adi,KoltukSayisi) values('" + firma + "','" + tip + "','" + name + "','" + ksayi + "')");
            }
            string sorgu = "select TB.ID,TB.Adi,FB.FirmaUnvani,TT.Tip,TB.KoltukSayisi from TasitBilgileri as TB left join FirmaBilgileri as FB on(TB.FirmaID=FB.FirmaID) left join TasitTipi as TT on(TB.TipID=TT.ID)";

            DataTable dt3 = f.GetDataTable(sorgu);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                TasitBilgileriModeli tasitModeli = new TasitBilgileriModeli()
                {
                    ID = dt3.Rows[i]["ID"].ToString(),
                    Adi = dt3.Rows[i]["Adi"].ToString(),
                    FirmaUnvani = dt3.Rows[i]["FirmaUnvani"].ToString(),
                    Tip = dt3.Rows[i]["Tip"].ToString(),
                    KoltukSayisi = dt3.Rows[i]["KoltukSayisi"].ToString(),

                };
                TasitBilgileriListesi.Add(tasitModeli);


            }
            return Json(TasitBilgileriListesi, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TasitSil(string ID)
        {
            if (ID != "0" && ID != "")
            {
                f.cmd("delete from Koltuklar Where TasitID='" + ID + "'");
                f.cmd("delete from TasitBilgileri where ID='" + ID + "'");
            }
            return RedirectToAction("TasitBilgileri", "Home");
        }

        public ActionResult TasitTipiSil(string ID)
        {
            if (ID != "0" && ID != "")
            {
                f.cmd("delete from TasitTipi where ID='" + ID + "'");
            }
            return RedirectToAction("TasitAyar", "Home");
        }

        public JsonResult ProfilDuzenle(FormCollection frm)
        {
            string ID = Fonksiyonlar.LoginID.ToString();
            string AD = frm["ad"].ToString();
            string sifre = frm["sifre"].ToString();
            string durum = "0";
            try
            {
                f.cmd("update YoneticiGiris set KAdi='" + AD + "', Sifre='" + sifre + "' where ID='" + ID + "'");
                durum = "1";
                Fonksiyonlar.LoginAD = AD;
                Fonksiyonlar.LoginSifre = sifre;

            }
            catch (Exception)
            {
                durum = "0";
            }

            return Json(durum, JsonRequestBehavior.AllowGet);
        }


        public ActionResult YonetMusteri()
        {
            return View();
        }
        public JsonResult MusteriListesi()
        {
            string sorgu = "select * from MusteriBilgileri";

            DataTable dt3 = f.GetDataTable(sorgu);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                MusteriBilgileriModeli musteriModeli = new MusteriBilgileriModeli()
                {
                    ID = dt3.Rows[i]["MusteriID"].ToString(),
                    Adi = dt3.Rows[i]["MusteriAdi"].ToString(),
                    Soyadi = dt3.Rows[i]["MusteriSoyadi"].ToString(),
                    Adres = dt3.Rows[i]["MusteriAdresi"].ToString(),
                    Tel = dt3.Rows[i]["MusteriTel"].ToString(),
                    Eposta = dt3.Rows[i]["MusteriEposta"].ToString(),
                    Sifre = dt3.Rows[i]["MusteriSifre"].ToString()

                };
                MusteriBilgileriListesi.Add(musteriModeli);


            }
            return Json(MusteriBilgileriListesi, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MusteriDuzenle(string ID)
        {
            if (ID != "" && ID != null)
            {
                ID = " where MusteriID=" + ID;

                string sorgu = "select * from MusteriBilgileri" + ID;

                DataTable dt3 = f.GetDataTable(sorgu);
                if (dt3.Rows.Count > 0)
                {
                    for (int i = 0; i < 1; i++)
                    {

                        Fonksiyonlar.MusteriID = dt3.Rows[i].ItemArray[0].ToString();
                        Fonksiyonlar.MusteriAdi = dt3.Rows[i].ItemArray[1].ToString();
                        Fonksiyonlar.MusteriSoyadi = dt3.Rows[i].ItemArray[2].ToString();
                        Fonksiyonlar.MusteriAdres = dt3.Rows[i].ItemArray[3].ToString();
                        Fonksiyonlar.MusteriTel = dt3.Rows[i].ItemArray[4].ToString();
                        Fonksiyonlar.MusteriEposta = dt3.Rows[i].ItemArray[5].ToString();
                        Fonksiyonlar.MusteriSifre = dt3.Rows[i].ItemArray[6].ToString();
                    }
                }
            }
            else
            {
                Fonksiyonlar.MusteriID = "";
                Fonksiyonlar.MusteriAdi = "";
                Fonksiyonlar.MusteriSoyadi = "";
                Fonksiyonlar.MusteriAdres = "";
                Fonksiyonlar.MusteriTel = "";
                Fonksiyonlar.MusteriEposta = "";
                Fonksiyonlar.MusteriSifre = "";
            }
            return View();
        }

        public JsonResult MusteriEkle(FormCollection frm)
        {
            string ID = frm["ID"].ToString();
            string Adi = frm["adi"].ToString();
            string Soyadi = frm["soyadi"].ToString();
            string Adres = frm["madres"].ToString();
            string Tel = frm["mtel"].ToString();
            string Eposta = frm["eposta"].ToString();
            string Sifre = frm["sifre"].ToString();
            string Durum = "0";
            try
            {
                if (ID != "" && ID != "0")
                {
                    f.cmd("update MusteriBilgileri set MusteriAdi='" + Adi + "',MusteriSoyadi='" + Soyadi + "',MusteriAdresi='" + Adres + "',MusteriTel='" + Tel + "',MusteriEposta='" + Eposta + "',MusteriSifre='" + Sifre + "' where MusteriID='" + ID + "'");
                }
                else
                {
                    f.cmd("insert into MusteriBilgileri(MusteriAdi,MusteriSoyadi,MusteriAdresi,MusteriTel,MusteriEposta,MusteriSifre) values('" + Adi + "','" + Soyadi + "','" + Adres + "','" + Tel + "','" + Eposta + "','" + Sifre + "')");
                }
                Durum = "1";
            }
            catch (Exception)
            {
                Durum = "0";
            }
            return Json(Durum, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MusteriSil(string ID)
        {
            f.cmd("delete from MusteriBilgileri where MusteriID='" + ID + "'");
            return RedirectToAction("YonetMusteri", "Home");
        }

        public ActionResult Alinan()
        {
            string Sorgu = "select R.RezervasyonID,R.SeferID,R.TasitID,R.MusteriAdi,R.MusteriSoyadi,R.MusteriTel,R.KalkisKonumu,R.InisKonumu,R.KoltukNumarasi,R.Tarih,R.Saat from Rezervasyon as R left join TasitBilgileri as T on(R.TasitID=T.ID) left join FirmaBilgileri as F on(T.FirmaID=F.FirmaID) where F.FirmaID='" + Fonksiyonlar.LoginID + "'";
            DataTable dtRezerve = f.GetDataTable(Sorgu);
            if (dtRezerve.Rows.Count > 0)
            {
                for (int i = 0; i < dtRezerve.Rows.Count; i++)
                {
                    RezervasyonModeli rezerveModeli = new RezervasyonModeli()
                    {
                        ID = dtRezerve.Rows[i]["RezervasyonID"].ToString(),
                        SEFERID = dtRezerve.Rows[i]["SeferID"].ToString(),
                        TASITID = dtRezerve.Rows[i]["TasitID"].ToString(),
                        ADI = dtRezerve.Rows[i]["MusteriAdi"].ToString(),
                        SOYADI = dtRezerve.Rows[i]["MusteriSoyadi"].ToString(),
                        TEL = String.Format("{0:(###) ###-####}", dtRezerve.Rows[i]["MusteriTel"].ToString()),
                        KALKIS = dtRezerve.Rows[i]["KalkisKonumu"].ToString(),
                        VARIS = dtRezerve.Rows[i]["InisKonumu"].ToString(),
                        KOLTUK = Convert.ToInt32(dtRezerve.Rows[i]["KoltukNumarasi"].ToString()).ToString("D3"),
                        TARIH = DateTime.Parse(dtRezerve.Rows[i]["Tarih"].ToString()).ToShortDateString(),
                        SAAT = DateTime.Parse(dtRezerve.Rows[i]["Saat"].ToString()).ToShortTimeString()

                    };
                    RezervasyonListesi.Add(rezerveModeli);
                }
                ViewBag.RezerveListesi = RezervasyonListesi;
            }

            string Sorgus = "select R.SeferID,R.TasitID,R.MusteriAdi,R.MusteriSoyadi,R.MusteriTel,R.KalkisKonumu,R.InisKonumu,R.KoltukNumarasi,R.Tarih,R.Saat from GecmisRezervasyon as R left join TasitBilgileri as T on(R.TasitID=T.ID) left join FirmaBilgileri as F on(T.FirmaID=F.FirmaID) where F.FirmaID='" + Fonksiyonlar.LoginID + "'";
            DataTable dtRezerves = f.GetDataTable(Sorgus);
            for (int i = 0; i < dtRezerves.Rows.Count; i++)
            {
                RezervasyonModeli rezerveModeli = new RezervasyonModeli()
                {
                    SEFERID = dtRezerves.Rows[i]["SeferID"].ToString(),
                    TASITID = dtRezerves.Rows[i]["TasitID"].ToString(),
                    ADI = dtRezerves.Rows[i]["MusteriAdi"].ToString(),
                    SOYADI = dtRezerves.Rows[i]["MusteriSoyadi"].ToString(),
                    TEL = String.Format("{0:(###) ###-####}", dtRezerves.Rows[i]["MusteriTel"].ToString()),
                    KALKIS = dtRezerves.Rows[i]["KalkisKonumu"].ToString(),
                    VARIS = dtRezerves.Rows[i]["InisKonumu"].ToString(),
                    KOLTUK = Convert.ToInt32(dtRezerves.Rows[i]["KoltukNumarasi"].ToString()).ToString("D3"),
                    TARIH = DateTime.Parse(dtRezerves.Rows[i]["Tarih"].ToString()).ToShortDateString(),
                    SAAT = DateTime.Parse(dtRezerves.Rows[i]["Saat"].ToString()).ToShortTimeString()

                };
                SatinListesi.Add(rezerveModeli);
            }
            ViewBag.SatinListesi = SatinListesi;
            return View();
        }
        public JsonResult SeferGetir(string ID)
        {
            DataTable dt = f.GetDataTable("select SeferSayisi,BaslangicKonumu,BitisKonumu,Tarih,Saat,Fiyat from Seferler where SeferID='" + ID + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                SeferlerModeli seferlerModeli = new SeferlerModeli()
                {
                    SEFERSAYISI = Convert.ToInt32(dt.Rows[i]["SeferSayisi"].ToString()).ToString("D5"),
                    KALKIS = dt.Rows[i]["BaslangicKonumu"].ToString(),
                    VARIS = dt.Rows[i]["BitisKonumu"].ToString(),
                    TARIH = DateTime.Parse(dt.Rows[i]["Tarih"].ToString()).ToShortDateString(),
                    SAAT = DateTime.Parse(dt.Rows[i]["Saat"].ToString()).ToShortTimeString(),
                    FIYAT = dt.Rows[i]["Fiyat"].ToString() + " ₺"

                };
                SeferlerModeliListesi.Add(seferlerModeli);


            }
            return Json(SeferlerModeliListesi, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TasitGetir(string ID)
        {
            DataTable dt = f.GetDataTable("select F.FirmaUnvani,TP.Tip,T.Adi,T.KoltukSayisi from TasitBilgileri as T left join FirmaBilgileri as f on(T.FirmaID=F.FirmaID) left join TasitTipi as TP on(T.TipID=TP.ID) where T.ID='" + ID + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                TasitModeli tasitModeli = new TasitModeli()
                {
                    FIRMA = dt.Rows[i]["FirmaUnvani"].ToString(),
                    TIP = dt.Rows[i]["Tip"].ToString(),
                    AD = dt.Rows[i]["Adi"].ToString(),
                    KOLTUK = dt.Rows[i]["KoltukSayisi"].ToString() + " Adet."

                };
                TasitModeliListesi.Add(tasitModeli);


            }
            return Json(TasitModeliListesi, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RezervasyonIptal(string ID)
        {
            int Durum = 0;
            if (ID != null && ID != "")
            {
                try
                {
                    DataRow dr = f.GetDataRow("select TasitID,KoltukNumarasi from Rezervasyon where RezervasyonID='" + ID + "'");
                    if (dr != null)
                    {
                        string Tasit = dr.ItemArray[0].ToString();
                        string Koltuk = dr.ItemArray[1].ToString();
                        f.cmd("update Koltuklar set KoltukDurumu='False' where TasitID='" + Tasit + "' and KoltukNumarasi='" + Koltuk + "'");
                        f.cmd("delete from Rezervasyon where RezervasyonID='" + ID + "'");
                        Durum = 1;
                    }
                    else
                    {
                        Durum = 0;
                    }
                }
                catch (Exception)
                {
                    Durum = 0;
                }
            }
            else
            {
                Durum = 0;
            }
            return Json(Durum, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IletisimFormu()
        {
            return View();
        }

        public JsonResult FormGetir()
        {
            string sorgu = "select * from Iletisim";

            DataTable dt = f.GetDataTable(sorgu);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                IletisimModeli iletisimModeli = new IletisimModeli()
                {
                    ID = dt.Rows[i]["ID"].ToString(),
                    ad = dt.Rows[i]["Ad"].ToString(),
                    mail = dt.Rows[i]["Email"].ToString(),
                    konu = dt.Rows[i]["Konu"].ToString(),
                    mesaj = dt.Rows[i]["Mesaj"].ToString()

                };
                IletisimModeliListesi.Add(iletisimModeli);


            }
            return Json(IletisimModeliListesi, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Formicerik(string ID)
        {
            DataRow dr = f.GetDataRow("select * from Iletisim where ID='"+ID+"'");
            if (dr!=null)
            {
                ViewBag.ad = dr.ItemArray[1].ToString();
                ViewBag.mail = dr.ItemArray[2].ToString();
                ViewBag.konu = dr.ItemArray[3].ToString();
                ViewBag.mesaj = dr.ItemArray[4].ToString();
            }
            else
            {
                ViewBag.ad = "";
                ViewBag.mail = "";
                ViewBag.konu ="";
                ViewBag.mesaj = "";
            }
            return View();
        }
    }
}