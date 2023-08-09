using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Seyehat_Rezervasyon_Sistemi.Controllers
{
    public class IndexController : Controller
    {
        Fonksiyonlar f = new Fonksiyonlar();
        List<LoginModeli> LoginListesi = new List<LoginModeli>();
        List<SeferModeli> SeferListesi = new List<SeferModeli>();
        List<SeferAraModeli> SeferAraListesi = new List<SeferAraModeli>();
        List<KayitModeli> KayitListesi = new List<KayitModeli>();
        List<TasitBilgileriModeli> TasitBilgileriListesi = new List<TasitBilgileriModeli>();
        List<DizaynModeli> TasitDizaynListesi = new List<DizaynModeli>();
        List<Koltuklar> Koltuklars = new List<Koltuklar>();
        List<RezervasyonlarimModeli> RezervasyonlarimListesi = new List<RezervasyonlarimModeli>();

        List<SatinAlListeModeli> SatinAlListe = new List<SatinAlListeModeli>();
        List<SatinAlinanlarModeli> SatinAlinanlarListe = new List<SatinAlinanlarModeli>();
        List<Yorumlar> YorumlarListe = new List<Yorumlar>();
        public class SatinAlListeModeli
        {
            public string ID { get; set; }
            public string Siparis { get; set; }
            public string Fiyat { get; set; }
            public string Logo { get; set; }
        }

        public class Yorumlar
        {
            public string ID { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Puan { get; set; }
            public string S1 { get; set; }
            public string S2 { get; set; }
            public string S3 { get; set; }
            public string S4 { get; set; }
            public string S5 { get; set; }
            public string Yorum { get; set; }
            public string YorumTam { get; set; }
            public int Sira { get; set; }

        }


        public class SatinAlinanlarModeli
        {
            public string Sira { get; set; }
            public string GRezervasyonID { get; set; }
            public string SeferSayisi { get; set; }
            public string FirmaUnvani { get; set; }
            public string MusteriAdi { get; set; }
            public string MusteriSoyadi { get; set; }
            public string KalkisKonumu { get; set; }
            public string InisKonumu { get; set; }
            public string KoltukNumarasi { get; set; }
            public string Tarih { get; set; }
            public string Saat { get; set; }
            public string Fiyat { get; set; }
            public string Logo { get; set; }
            public string FID { get; set; }
        }
        public class RezervasyonlarimModeli
        {
            public string ID { get; set; }
            public string FirmaUnvani { get; set; }
            public string BaslangicKonumu { get; set; }
            public string BitisKonumu { get; set; }
            public string KoltukNumarasi { get; set; }
            public string Tarih { get; set; }
            public string Saat { get; set; }
            public string Fiyat { get; set; }
            public string Logo { get; set; }
        }
        public class TasitBilgileriModeli
        {
            public string ID { get; set; }
            public string Adi { get; set; }
            public string FirmaUnvani { get; set; }
            public string Tip { get; set; }
            public string KoltukSayisi { get; set; }
            public string DizaynDurum { get; set; }
        }

        public class DizaynModeli
        {
            public string ID { get; set; }
            public string DAd { get; set; }
            public string Satir { get; set; }
            public string ToplamSayi { get; set; }
            public int SeferID { get; set; }
        }

        public class Koltuklar
        {
            public string KoltukKonfor { get; set; }
            public string KoltukDurumu { get; set; }
            public int SeferID { get; set; }
        }

        public class LoginModeli
        {
            public int ID { get; set; }
            public int Durum { get; set; }
        }

        public class SeferModeli
        {
            public int SeferID { get; set; }
            public int SeferSayisi { get; set; }
            public string Adi { get; set; }
            public string FirmaUnvani { get; set; }
            public string BaslangicKonumu { get; set; }
            public string BitisKonumu { get; set; }
            public string Tarih { get; set; }
            public string Saat { get; set; }
            public string Fiyat { get; set; }
            public int TasitID { get; set; }
            public string Logo { get; set; }
        }
        public class SeferAraModeli
        {
            public string Tip { get; set; }
            public int SeferID { get; set; }
            public string FirmaUnvani { get; set; }
            public string BaslangicKonumu { get; set; }
            public string BitisKonumu { get; set; }
            public string Tarih { get; set; }
            public string Saat { get; set; }
            public string Fiyat { get; set; }
            public string Logo { get; set; }
            public string S1 { get; set; }
            public string S2 { get; set; }
            public string S3 { get; set; }
            public string S4 { get; set; }
            public string S5 { get; set; }
            public string Ort { get; set; }
            public string Adet { get; set; }
            public string FirmaID { get; set; }
        }

        public class KayitModeli
        {
            public int Durum { get; set; }
        }
        public ActionResult Index()
        {
            if (Session["LOGINID"] == null && Fonksiyonlar.LoginID != 0)
            {
                Fonksiyonlar.LoginID = 0;
                Fonksiyonlar.LoginAD = "";
                Fonksiyonlar.LoginSifre = "";
                Fonksiyonlar.LoginTur = 0;
                Fonksiyonlar.LoginSOYAD = "";
                Fonksiyonlar.LoginTEL = "";
                Fonksiyonlar.LoginSepet = 0;
                return RedirectToAction("Login", "Index");
            }
            else
            {
                if (Session["LOGINID"] != null)
                {
                    return View();
                }
                else
                {
                    Fonksiyonlar.LoginID = 0;
                    Fonksiyonlar.LoginAD = "";
                    Fonksiyonlar.LoginSifre = "";
                    Fonksiyonlar.LoginTur = 0;
                    Fonksiyonlar.LoginSOYAD = "";
                    Fonksiyonlar.LoginTEL = "";
                    Fonksiyonlar.LoginSepet = 0;
                    return View();
                }
            }
        }

        public ActionResult Login(string ID)
        {
            if (ID == "-1")
            {
                Fonksiyonlar.LoginID = 0;
                Fonksiyonlar.LoginAD = "";
                Fonksiyonlar.LoginSifre = "";
                Fonksiyonlar.LoginTur = 0;
                Fonksiyonlar.LoginSOYAD = "";
                Fonksiyonlar.LoginTEL = "";
                Fonksiyonlar.LoginSepet = 0;
                Session["LOGINID"] = null;
                return RedirectToAction("Login", "Index");
            }
            else
            {
                if (Fonksiyonlar.LoginID == 0)
                {
                    Session["LOGINID"] = null;
                    return View();
                }
                else
                {
                    if (Fonksiyonlar.LoginTur == 3)
                    {
                        return RedirectToAction("Index", "Index");
                    }
                    else if (Fonksiyonlar.LoginTur == 2)
                    {
                        return RedirectToAction("FirmaSeferler", "Index");
                    }
                    else if (Fonksiyonlar.LoginTur == 1)
                    {
                        return RedirectToAction("Yonetim", "Home");
                    }
                    else
                    {
                        Fonksiyonlar.LoginID = 0;
                        Fonksiyonlar.LoginAD = "";
                        Fonksiyonlar.LoginSifre = "";
                        Fonksiyonlar.LoginTur = 0;
                        Fonksiyonlar.LoginSOYAD = "";
                        Fonksiyonlar.LoginTEL = "";
                        Fonksiyonlar.LoginSepet = 0;
                        Session["LOGINID"] = null;
                        return View();
                    }
                }
            }

        }
        public ActionResult UyeOl()
        {
            return View();
        }
        public ActionResult Firma()
        {
            return View();
        }
        public ActionResult Hakkinda()
        {
            DataTable dtHakkinda = f.GetDataTable("select * from Hakkinda");
            ViewBag.Mesaj = dtHakkinda.Rows[0].ItemArray[1].ToString();
            return View();
        }
        public JsonResult HakkindaKaydet(FormCollection frm)
        {
            int Durum = 0;
            string Mesaj = frm["mesaj"].ToString();
            try
            {
                f.cmd("update Hakkinda Set Mesaj='" + Mesaj + "'");
                Durum = 1;
            }
            catch (Exception)
            {
                Durum = 0;
            }
            return Json(Durum, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SessionKaydet(FormCollection frm)
        {
            int Durum = 0;
            string Mesaj = frm["session"].ToString();
            try
            {
                f.cmd("update Hakkinda Set Session='" + Mesaj + "'");
                Durum = 1;
            }
            catch (Exception)
            {
                Durum = 0;
            }
            return Json(Durum, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FirmaTasitBilgileri()
        {
            return View();
        }

        public JsonResult TasitBilgi()
        {
            string sorgu = "select TB.ID,TB.Adi,FB.FirmaUnvani,TT.Tip,TB.KoltukSayisi from TasitBilgileri as TB left join FirmaBilgileri as FB on(TB.FirmaID=FB.FirmaID) left join TasitTipi as TT on(TB.TipID=TT.ID) where FB.FirmaID='" + Fonksiyonlar.LoginID + "'";
            DataTable dt3 = f.GetDataTable(sorgu);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                string Durum = "";
                DataTable dtbak = f.GetDataTable("select * from Dizayn where TasitID='" + dt3.Rows[i]["ID"].ToString() + "'");
                if (dtbak.Rows.Count > 0)
                {
                    Durum = "Taşıt Dizaynı Yapıldı.";
                }
                else
                {
                    Durum = "Taşıt Dizaynı Yapılmadı.";
                }
                TasitBilgileriModeli tasitModeli = new TasitBilgileriModeli()
                {
                    ID = dt3.Rows[i]["ID"].ToString(),
                    Adi = dt3.Rows[i]["Adi"].ToString(),
                    FirmaUnvani = dt3.Rows[i]["FirmaUnvani"].ToString(),
                    Tip = dt3.Rows[i]["Tip"].ToString(),
                    KoltukSayisi = dt3.Rows[i]["KoltukSayisi"].ToString(),
                    DizaynDurum = Durum,
                };
                TasitBilgileriListesi.Add(tasitModeli);


            }
            return Json(TasitBilgileriListesi, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TasitDuzenle(string ID)
        {
            DataTable dt3 = f.GetDataTable("select FirmaUnvani from FirmaBilgileri where FirmaID='" + Fonksiyonlar.LoginID + "'");
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
                return RedirectToAction("FirmaTasitBilgileri", "Index");
            }


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
            return RedirectToAction("FirmaTasitBilgileri", "Index");
        }

        public ActionResult Dizayn(string ID)
        {
            if (ID != null && ID != "")
            {
                Fonksiyonlar.DizaynTasitID = ID;
                DataTable dt = f.GetDataTable("select D.ID,T.Adi,D.Ad,D.Satir,D.ToplamSayi,T.KoltukSayisi from Dizayn as D left join TasitBilgileri as T on(D.TasitID=T.ID) where D.TasitID='" + ID + "'");
                if (dt.Rows.Count > 0)
                {
                    ViewBag.TAdi = dt.Rows[0].ItemArray[1].ToString();
                    ViewBag.TKoltuk = dt.Rows[0].ItemArray[5].ToString();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DizaynModeli dizaynModeli = new DizaynModeli()
                        {
                            ID = dt.Rows[i]["ID"].ToString(),
                            DAd = dt.Rows[i]["Ad"].ToString(),
                            Satir = dt.Rows[i]["Satir"].ToString(),
                            ToplamSayi = dt.Rows[i]["ToplamSayi"].ToString()

                        };
                        TasitDizaynListesi.Add(dizaynModeli);


                    }
                    ViewBag.Dizayn = TasitDizaynListesi;

                    return View();
                }
                else
                {
                    DataTable dt2 = f.GetDataTable("select * from TasitBilgileri where ID='" + ID + "'");
                    if (dt2.Rows.Count > 0)
                    {
                        ViewBag.TAdi = dt2.Rows[0].ItemArray[3].ToString();
                        ViewBag.TKoltuk = dt2.Rows[0].ItemArray[4].ToString();
                        DizaynModeli dizaynModeli = new DizaynModeli()
                        {
                            ID = "0",
                            DAd = "",
                            Satir = "",
                            ToplamSayi = ""

                        };
                        TasitDizaynListesi.Add(dizaynModeli);
                        ViewBag.Dizayn = TasitDizaynListesi;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("FirmaTasitBilgileri", "Index");
                    }
                }
            }
            else
            {
                return RedirectToAction("FirmaTasitBilgileri", "Index");
            }
        }

        public JsonResult DizaynEkle(FormCollection frm)
        {
            string ID = frm["id"].ToString();
            string adi = frm["adi"].ToString();
            string sat = frm["sat"].ToString();
            string TSayi = frm["TSayi"].ToString();
            int Durum = 0;
            try
            {
                if (ID != null && ID != "")
                {
                    f.cmd("update Dizayn set Ad='" + adi + "',Satir='" + sat + "',ToplamSayi='" + TSayi + "' where ID='" + ID + "'");
                }
                else
                {
                    f.cmd("insert into Dizayn(TasitID,Ad,Satir,ToplamSayi) values('" + Fonksiyonlar.DizaynTasitID + "','" + adi + "','" + sat + "','" + TSayi + "')");
                }
                Durum = 1;
            }
            catch (Exception)
            {
                Durum = 0;
            }
            return Json(Durum, JsonRequestBehavior.AllowGet);

        }
        public JsonResult DizaynSil(FormCollection frm)
        {
            string ID = frm["id"].ToString();
            int Durum = 0;
            try
            {
                f.cmd("delete from Dizayn where ID='" + ID + "'");
                Durum = 1;
            }
            catch (Exception)
            {
                Durum = 0;
            }
            return Json(Durum, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DizaynKaydi(FormCollection frm)
        {
            string ID = frm["id"].ToString();
            int Durum = 0;
            try
            {
                f.cmd("delete from Koltuklar where TasitID='" + Fonksiyonlar.DizaynTasitID + "'");
                DataTable dt = f.GetDataTable("select sum(ToplamSayi) from Dizayn where TasitID='" + Fonksiyonlar.DizaynTasitID + "'");
                if (dt.Rows.Count > 0)
                {
                    string TasitID = Fonksiyonlar.DizaynTasitID;
                    int Sayi = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                    DataTable dt2 = f.GetDataTable("select * from Dizayn where TasitID='" + Fonksiyonlar.DizaynTasitID + "'");
                    int say = 0;
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        int sayi2 = Convert.ToInt32(dt2.Rows[i].ItemArray[4].ToString());
                        for (int j = 0; j < sayi2; j++)
                        {
                            int Kno = say + 1;
                            Boolean Kdurum = false;
                            string Konfor = dt2.Rows[i].ItemArray[2].ToString();
                            f.cmd("insert into Koltuklar(TasitID,KoltukNumarasi,KoltukDurumu,Konfor) values('" + TasitID + "','" + Kno + "','" + Kdurum + "','" + Konfor + "')");
                            say++;
                        }
                    }
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
            return Json(Durum, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Rezervasyon(string ID, string Kod, string Basla, string Bit)
        {

           
                string Tar = "";
                if (ID != null && ID != "")
                {
                    if (Kod != "" && Kod != "0" && Kod != null)
                    {
                        DateTime Gelen = DateTime.Parse(Kod);
                        DateTime Gidecek = DateTime.Parse("01." + Gelen.Month + "." + Gelen.Year);
                        Gidecek = Gidecek.AddMonths(1).AddDays(-1);
                        Tar = " or S.Tarih>='" + DateTime.Parse(Kod).ToString("yyyy-MM-dd") + "' and S.Tarih<='" + Gidecek.ToString("yyyy-MM-dd") + "' and S.BaslangicKonumu='" + Bit + "' and S.BitisKonumu='" + Basla + "'";
                    }
                    else
                    {
                        Kod = "";
                    }
                    string sorgu = "select S.SeferID,S.SeferSayisi,TB.Adi,FB.FirmaUnvani,S.BaslangicKonumu,S.BitisKonumu,S.Tarih,S.Saat,S.Fiyat,S.TasitID,FB.FirmaLogo from Seferler as S left join TasitBilgileri as TB on(S.TasitID=TB.ID) left join FirmaBilgileri as FB on(TB.FirmaID=FB.FirmaID) where S.SeferID='" + ID + "'" + Tar + " order by S.Tarih,S.Saat";
                    DataTable dt3 = f.GetDataTable(sorgu);
                    if (dt3.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt3.Rows.Count; i++)
                        {
                            string TasitID = dt3.Rows[i].ItemArray[9].ToString();
                            string SeferID = dt3.Rows[i]["SeferID"].ToString();
                            string GelenLogo = dt3.Rows[i]["FirmaLogo"].ToString();
                            if (GelenLogo == "")
                            {
                                GelenLogo = "none.png";
                            }
                            SeferModeli seferModeli = new SeferModeli()
                            {
                                SeferID = Convert.ToInt32(dt3.Rows[i]["SeferID"].ToString()),
                                SeferSayisi = Convert.ToInt32(dt3.Rows[i]["SeferSayisi"].ToString()),
                                Adi = dt3.Rows[i]["Adi"].ToString(),
                                FirmaUnvani = dt3.Rows[i]["FirmaUnvani"].ToString(),
                                BaslangicKonumu = dt3.Rows[i]["BaslangicKonumu"].ToString(),
                                BitisKonumu = dt3.Rows[i]["BitisKonumu"].ToString(),
                                Tarih = DateTime.Parse(dt3.Rows[i]["Tarih"].ToString()).ToString("d"),
                                Saat = dt3.Rows[i]["Saat"].ToString(),
                                Fiyat = dt3.Rows[i]["Fiyat"].ToString(),
                                TasitID = Convert.ToInt32(dt3.Rows[i]["TasitID"].ToString()),
                                Logo = GelenLogo

                            };
                            SeferListesi.Add(seferModeli);
                            DataTable dt = f.GetDataTable("select * from Dizayn where TasitID='" + TasitID + "'");
                            if (dt.Rows.Count > 0)
                            {
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    DizaynModeli dizaynModeli = new DizaynModeli()
                                    {
                                        ID = dt.Rows[j]["ID"].ToString(),
                                        DAd = dt.Rows[j]["Ad"].ToString(),
                                        Satir = dt.Rows[j]["Satir"].ToString(),
                                        ToplamSayi = dt.Rows[j]["ToplamSayi"].ToString(),
                                        SeferID = Convert.ToInt32(SeferID)
                                    };
                                    TasitDizaynListesi.Add(dizaynModeli);


                                }
                                ViewBag.Dizayn = TasitDizaynListesi;

                                sorgu = "select * from Koltuklar where TasitID='" + TasitID + "'";
                                DataTable dt2 = f.GetDataTable(sorgu);
                                for (int j = 0; j < dt2.Rows.Count; j++)
                                {
                                    Koltuklar koltuklar = new Koltuklar()
                                    {
                                        KoltukDurumu = dt2.Rows[j]["KoltukDurumu"].ToString(),
                                        KoltukKonfor = dt2.Rows[j]["Konfor"].ToString(),
                                        SeferID = Convert.ToInt32(SeferID)
                                    };
                                    Koltuklars.Add(koltuklar);
                                }
                                ViewBag.Koltuklar = Koltuklars;

                            }
                        }
                        ViewBag.Seferler = SeferListesi;
                        return View();



                    }
                    else
                    {
                        return RedirectToAction("Index", "Index");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Index");
                }
            

        }
        public JsonResult RezervasyonTamamla(string Koltukid, string Adi, string Soyadi, string Tel, string Tasit, string Sefer)
        {
            string MusteriAdi = Adi;
            string MusteriSoyadi = Soyadi;
            string MusteriTel = Tel;
            string GelenKoltuk = Koltukid;

            DataRow dr = f.GetDataRow("select * from Seferler where SeferID='" + Sefer + "'");
            int Durum = 0;
            if (dr != null)
            {
                try
                {
                    string KalkisKonumu = dr.ItemArray[3].ToString();
                    string BitisKonumu = dr.ItemArray[4].ToString();
                    string Tarih = dr.ItemArray[5].ToString();
                    string Saat = dr.ItemArray[6].ToString();
                    string Fiyat = dr.ItemArray[7].ToString();
                    Fiyat = Fiyat.Replace(",", ".");
                    string sorgu = "insert into Rezervasyon(SeferID,TasitID,MusteriID,MusteriAdi,MusteriSoyadi,MusteriTel,KalkisKonumu,InisKonumu,KoltukNumarasi,Fiyat,Tarih,Saat) " +
                        "values('" + Sefer + "','" + Tasit + "','" + Fonksiyonlar.LoginID + "','" + MusteriAdi + "','" + MusteriSoyadi + "','" + MusteriTel + "','" + KalkisKonumu + "','" + BitisKonumu + "','" + GelenKoltuk + "','" + Fiyat + "','" + DateTime.Parse(Tarih).ToString("yyyy-MM-dd") + "','" + Saat + "')";
                    f.cmd(sorgu);

                    string sorgukoltuk = "update Koltuklar set KoltukDurumu='True' where TasitID='" + Tasit + "' and KoltukNumarasi='" + GelenKoltuk + "'";
                    f.cmd(sorgukoltuk);
                    Durum = 1;
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
            DataTable dtbak = f.GetDataTable("select * from Rezervasyon where MusteriID='" + Fonksiyonlar.LoginID + "'");
            Fonksiyonlar.LoginSepet = dtbak.Rows.Count;
            return Json(Durum, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RezervasyonIptal(string ID)
        {
            if (Session["LOGINID"] != null)
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
                DataTable dtbak = f.GetDataTable("select * from Rezervasyon where MusteriID='" + Fonksiyonlar.LoginID + "'");
                Fonksiyonlar.LoginSepet = dtbak.Rows.Count;
                return RedirectToAction("Rezervasyonlarim", "Index");
            }
            else
            {
                Fonksiyonlar.LoginID = 0;
                Fonksiyonlar.LoginAD = "";
                Fonksiyonlar.LoginSifre = "";
                Fonksiyonlar.LoginTur = 0;
                Fonksiyonlar.LoginSOYAD = "";
                Fonksiyonlar.LoginTEL = "";
                Fonksiyonlar.LoginSepet = 0;
                return RedirectToAction("Login", "Index");

            }

        }

        public ActionResult Rezervasyonlarim()
        {
            if (Session["LOGINID"] == null)
            {
                Fonksiyonlar.LoginID = 0;
                Fonksiyonlar.LoginAD = "";
                Fonksiyonlar.LoginSifre = "";
                Fonksiyonlar.LoginTur = 0;
                Fonksiyonlar.LoginSOYAD = "";
                Fonksiyonlar.LoginTEL = "";
                Fonksiyonlar.LoginSepet = 0;
                Fonksiyonlar.FirmaLogo = "";
                return RedirectToAction("Login", "Index");
            }

            if (Fonksiyonlar.LoginID != 0)
            {
                DataTable dtbak = f.GetDataTable("select * from Rezervasyon where MusteriID='" + Fonksiyonlar.LoginID + "'");
                Fonksiyonlar.LoginSepet = dtbak.Rows.Count;
                DataRow drFiyat = f.GetDataRow("select SUM(Fiyat) from Rezervasyon where MusteriID='" + Fonksiyonlar.LoginID + "'");
                if (drFiyat != null)
                {
                    ViewBag.ToplamFiyat = drFiyat.ItemArray[0].ToString();
                    string sorgu = "select R.RezervasyonID,FB.FirmaUnvani,R.KalkisKonumu,R.InisKonumu,R.KoltukNumarasi,R.Tarih,R.Saat,R.Fiyat,FB.FirmaLogo from Rezervasyon as R left join TasitBilgileri as TB on(R.TasitID=TB.ID) left join FirmaBilgileri as FB on(TB.FirmaID=FB.FirmaID) where R.MusteriID='" + Fonksiyonlar.LoginID + "'";
                    DataTable dt = f.GetDataTable(sorgu);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string LogoGelen = dt.Rows[i].ItemArray[8].ToString();
                        if (LogoGelen == "")
                        {
                            LogoGelen = "none.png";
                        }
                        RezervasyonlarimModeli rezervasyonlarimModeli = new RezervasyonlarimModeli()
                        {
                            ID = dt.Rows[i].ItemArray[0].ToString(),
                            FirmaUnvani = dt.Rows[i].ItemArray[1].ToString(),
                            BaslangicKonumu = dt.Rows[i].ItemArray[2].ToString(),
                            BitisKonumu = dt.Rows[i].ItemArray[3].ToString(),
                            KoltukNumarasi = dt.Rows[i].ItemArray[4].ToString(),
                            Tarih = DateTime.Parse(dt.Rows[i].ItemArray[5].ToString()).ToShortDateString(),
                            Saat = DateTime.Parse(dt.Rows[i].ItemArray[6].ToString()).ToShortTimeString(),
                            Fiyat = dt.Rows[i].ItemArray[7].ToString(),
                            Logo = LogoGelen
                        };
                        RezervasyonlarimListesi.Add(rezervasyonlarimModeli);
                    }
                    ViewBag.Liste = RezervasyonlarimListesi;
                }

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Index");
            }
        }

        public ActionResult FirmaSeferler()
        {
            if (Fonksiyonlar.LoginID != 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Index");
            }
        }
        public JsonResult Giris(FormCollection frm)
        {
            Fonksiyonlar.FirmaID = "0";
            DataTable dtHakkinda = f.GetDataTable("select * from Hakkinda");
            if (dtHakkinda.Rows.Count > 0)
            {
                try
                {
                    int Time = Convert.ToInt32(dtHakkinda.Rows[0].ItemArray[2].ToString());
                    Session.Timeout = Time;
                }
                catch (Exception)
                {

                }
            }
            string KADI = frm["kadi"].ToString();
            string SIFRE = frm["sifre"].ToString();
            int durum = 0;
            DataRow drYonet = f.GetDataRow("Select * from YoneticiGiris where KAdi='" + KADI + "' and Sifre='" + SIFRE + "'");
            if (drYonet != null)
            {
                durum = 1;
                LoginModeli loginModeli = new LoginModeli()
                {
                    ID = -1,
                    Durum = durum
                };
                Fonksiyonlar.LoginAD = drYonet.ItemArray[1].ToString();
                Fonksiyonlar.LoginID = Convert.ToInt32(drYonet.ItemArray[0].ToString());
                Session["LOGINID"] = Fonksiyonlar.LoginID;
                Fonksiyonlar.LoginSifre = drYonet.ItemArray[2].ToString();
                Fonksiyonlar.LoginTur = 1;
                LoginListesi.Add(loginModeli);
            }
            else
            {
                try
                {
                    DataRow drfirma = f.GetDataRow("select * from FirmaBilgileri where FirmaNo='" + KADI + "' and FirmaSifre='" + SIFRE + "'");
                    if (drfirma != null)
                    {
                        durum = 2;
                        LoginModeli loginModeli = new LoginModeli()
                        {
                            ID = Convert.ToInt32(drfirma.ItemArray[0].ToString()),
                            Durum = durum
                        };
                        LoginListesi.Add(loginModeli);
                        Fonksiyonlar.LoginID = Convert.ToInt32(drfirma.ItemArray[0].ToString());
                        Session["LOGINID"] = Fonksiyonlar.LoginID;
                        Fonksiyonlar.LoginTur = durum;
                        Fonksiyonlar.LoginAD = drfirma.ItemArray[1].ToString();
                        Fonksiyonlar.FirmaLogo = drfirma.ItemArray[9].ToString();
                        Fonksiyonlar.FirmaID = "1";
                    }
                    else
                    {
                        DataRow drkul = f.GetDataRow("select * from MusteriBilgileri where MusteriEposta='" + KADI + "' and MusteriSifre='" + SIFRE + "'");
                        if (drkul != null)
                        {
                            durum = 3;
                            LoginModeli loginModeli = new LoginModeli()
                            {
                                ID = Convert.ToInt32(drkul.ItemArray[0].ToString()),
                                Durum = durum
                            };
                            LoginListesi.Add(loginModeli);
                            Fonksiyonlar.LoginID = Convert.ToInt32(drkul.ItemArray[0].ToString());
                            Session["LOGINID"] = Fonksiyonlar.LoginID;
                            Fonksiyonlar.LoginTur = durum;
                            Fonksiyonlar.LoginAD = drkul.ItemArray[1].ToString();
                            Fonksiyonlar.LoginSOYAD = drkul.ItemArray[2].ToString();
                            Fonksiyonlar.LoginADRES = drkul.ItemArray[3].ToString();
                            Fonksiyonlar.LoginTEL = drkul.ItemArray[4].ToString();
                            Fonksiyonlar.LoginEMAIL = drkul.ItemArray[5].ToString();
                            DataTable dtbak = f.GetDataTable("select * from Rezervasyon where MusteriID='" + Fonksiyonlar.LoginID + "'");
                            Fonksiyonlar.LoginSepet = dtbak.Rows.Count;
                        }
                        else
                        {
                            Session["LOGINID"] = null;
                            durum = 0;
                            LoginModeli loginModeli = new LoginModeli()
                            {
                                ID = durum,
                                Durum = durum
                            };
                            LoginListesi.Add(loginModeli);
                        }
                    }
                }
                catch (Exception)
                {
                    Session["LOGINID"] = null;
                    durum = -1;
                    LoginModeli loginModeli = new LoginModeli()
                    {
                        ID = durum,
                        Durum = durum
                    };
                    LoginListesi.Add(loginModeli);
                }
            }
            return Json(LoginListesi, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SeferOlustur(string id)
        {
            string ID = " where FirmaID=" + Fonksiyonlar.LoginID;
            string sorgu = "select Adi,ID from TasitBilgileri " + ID;

            DataTable dt2 = f.GetDataTable(sorgu);
            if (dt2.Rows.Count > 0)
            {
                List<string> Tipler = new List<string>();
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    DataTable dtbak = f.GetDataTable("select * from Dizayn where TasitID='" + dt2.Rows[i].ItemArray[1].ToString() + "'");
                    if (dtbak.Rows.Count > 0)
                    {
                        Tipler.Add(dt2.Rows[i].ItemArray[0].ToString());
                    }
                }
                ViewBag.Tip = new SelectList(Tipler);
            }

            if (id != "" && id != null)
            {
                DataRow dr = f.GetDataRow("select * from Seferler where SeferID='" + id + "'");
                if (dr != null)
                {
                    ViewBag.ID = id;
                    DataRow dr2 = f.GetDataRow("select Adi from TasitBilgileri where ID='" + dr.ItemArray[2].ToString() + "'");
                    if (dr2 != null)
                    {
                        ViewBag.Tasit = dr2.ItemArray[0].ToString();
                    }
                    else
                    {
                        ViewBag.Tasit = "";
                    }
                    ViewBag.basla = dr.ItemArray[3].ToString();
                    ViewBag.bit = dr.ItemArray[4].ToString();
                    DateTime dt = DateTime.Parse(dr.ItemArray[5].ToString());
                    ViewBag.Tarih = dt.ToString("yyyy-MM-dd");
                    ViewBag.Saat = dr.ItemArray[6].ToString();
                    ViewBag.Tutar = dr.ItemArray[7].ToString();
                }
                else
                {
                    ViewBag.ID = "0";
                    ViewBag.Tasit = "";
                    ViewBag.basla = "";
                    ViewBag.bit = "";
                    ViewBag.Tarih = "";
                    ViewBag.Saat = "";
                    ViewBag.Tutar = "";
                }
            }
            else
            {
                ViewBag.ID = "0";
                ViewBag.Tasit = "";
                ViewBag.basla = "";
                ViewBag.bit = "";
                ViewBag.Tarih = "";
                ViewBag.Saat = "";
                ViewBag.Tutar = "";
            }

            return View();
        }

        public JsonResult SeferBilgi()
        {
            string sorgu = "select S.SeferID,S.SeferSayisi,TB.Adi,FB.FirmaUnvani,S.BaslangicKonumu,S.BitisKonumu,S.Tarih,S.Saat,S.Fiyat from Seferler as S left join TasitBilgileri as TB on(S.TasitID=TB.ID) left join FirmaBilgileri as FB on(TB.FirmaID=FB.FirmaID) where FB.FirmaID='" + Fonksiyonlar.LoginID + "'";

            DataTable dt3 = f.GetDataTable(sorgu);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                SeferModeli seferModeli = new SeferModeli()
                {
                    SeferID = Convert.ToInt32(dt3.Rows[i]["SeferID"].ToString()),
                    SeferSayisi = Convert.ToInt32(dt3.Rows[i]["SeferSayisi"].ToString()),
                    Adi = dt3.Rows[i]["Adi"].ToString(),
                    FirmaUnvani = dt3.Rows[i]["FirmaUnvani"].ToString(),
                    BaslangicKonumu = dt3.Rows[i]["BaslangicKonumu"].ToString(),
                    BitisKonumu = dt3.Rows[i]["BitisKonumu"].ToString(),
                    Tarih = DateTime.Parse(dt3.Rows[i]["Tarih"].ToString()).ToString("d"),
                    Saat = dt3.Rows[i]["Saat"].ToString(),
                    Fiyat = dt3.Rows[i]["Fiyat"].ToString()

                };
                SeferListesi.Add(seferModeli);


            }
            return Json(SeferListesi, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SeferEkle(FormCollection frm)
        {
            string id = frm["id"].ToString();
            string SeferSayisi = "";
            string tasit = frm["tasit"].ToString();
            string basla = frm["basla"].ToString();
            string bit = frm["bit"].ToString();
            string tarih = frm["tarih"].ToString();
            string saat = frm["saat"].ToString();
            string fiyat = frm["fiyat"].ToString();
            fiyat = fiyat.Replace(",", ".");
            int Durum = 0;
            try
            {
                DataRow drSayi = f.GetDataRow("select MAX(SeferSayisi) from Seferler");
                string Gelen = drSayi.ItemArray[0].ToString();
                if (Gelen!="" && Gelen!=null)
                {
                    int sayi = Convert.ToInt32(Gelen);
                    sayi += 1;
                    SeferSayisi = sayi.ToString();
                }
                else
                {
                    SeferSayisi = "1";
                }
                if (basla != "" && bit != "")
                {
                    DataRow dr = f.GetDataRow("select ID from TasitBilgileri Where Adi='" + tasit + "'");
                    if (dr != null)
                    {
                        tasit = dr.ItemArray[0].ToString();
                        DateTime tar = DateTime.Parse(tarih);
                        tarih = tar.ToString("yyyy-MM-dd");
                        DateTime st = DateTime.Parse(saat);
                        saat = st.ToString("T");
                        if (id != "" && id != "0")
                        {
                            f.cmd("update Seferler set SeferSayisi='" + SeferSayisi + "',TasitID='" + tasit + "',BaslangicKonumu='" + basla + "',BitisKonumu='" + bit + "',Tarih='" + tarih + "',Saat='" + saat + "',Fiyat='" + fiyat + "' Where SeferID='" + id + "'");
                        }
                        else
                        {
                            f.cmd("insert into Seferler(SeferSayisi,TasitID,BaslangicKonumu,BitisKonumu,Tarih,Saat,Fiyat) values('" + SeferSayisi + "','" + tasit + "','" + basla + "','" + bit + "','" + tarih + "','" + saat + "','" + fiyat + "')");
                        }
                        Durum = 1;
                    }
                    else
                    {
                        Durum = 0;//hata
                    }

                }
                else
                {
                    Durum = -1;//Eksik Bilgi
                }
            }
            catch (Exception)
            {
                Durum = 0;//Hata
            }
            return Json(Durum, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SeferSil(string ID)
        {

            f.cmd("delete from Seferler where SeferID='" + ID + "'");
            return RedirectToAction("FirmaSeferler", "Index");
        }

        public ActionResult FirmaProfil()
        {
            string ID = Fonksiyonlar.LoginID.ToString();
            if (ID != "" && ID != "0" && ID != null)
            {
                DataRow dr = f.GetDataRow("select * from FirmaBilgileri where FirmaID='" + ID + "'");
                if (dr != null)
                {
                    ViewBag.FirmaUnvani = dr.ItemArray[1].ToString();
                    ViewBag.FaliyetAlani = dr.ItemArray[2].ToString();
                    ViewBag.MerkezAdresi = dr.ItemArray[3].ToString();
                    ViewBag.MerkezTel = dr.ItemArray[4].ToString();
                    ViewBag.PersonelSayisi = dr.ItemArray[5].ToString();
                    ViewBag.TasitSayisi = dr.ItemArray[6].ToString();
                    ViewBag.FirmaNo = dr.ItemArray[7].ToString();
                    ViewBag.FirmaSifre = dr.ItemArray[8].ToString();
                    ViewBag.Logo = dr.ItemArray[9].ToString();
                    Fonksiyonlar.FirmaLogo = dr.ItemArray[9].ToString();
                }
                else
                {
                    ViewBag.FirmaUnvani = "";
                    ViewBag.FaliyetAlani = "";
                    ViewBag.MerkezAdresi = "";
                    ViewBag.MerkezTel = "";
                    ViewBag.PersonelSayisi = "";
                    ViewBag.TasitSayisi = "";
                    ViewBag.FirmaNo = "";
                    ViewBag.FirmaSifre = "";
                    ViewBag.Logo = "";
                }
            }
            else
            {
                ViewBag.FirmaUnvani = "";
                ViewBag.FaliyetAlani = "";
                ViewBag.MerkezAdresi = "";
                ViewBag.MerkezTel = "";
                ViewBag.PersonelSayisi = "";
                ViewBag.TasitSayisi = "";
                ViewBag.FirmaNo = "";
                ViewBag.Logo = "";
                ViewBag.FirmaSifre = "";
            }
            return View();
        }

        public JsonResult FirmaProfilDuzenle(FormCollection frm)
        {
            string ID = Fonksiyonlar.LoginID.ToString();
            string funvan = frm["funvan"].ToString();
            string falan = frm["falan"].ToString();
            string adres = frm["adres"].ToString();
            string tel = frm["tel"].ToString();
            string psayi = frm["psayi"].ToString();
            string tsayi = frm["tsayi"].ToString();
            string fno = frm["fno"].ToString();
            string sifre = frm["sifre"].ToString();
            string durum = "0";
            try
            {
                f.cmd("update FirmaBilgileri set FirmaUnvani='" + funvan + "',FaliyetAlani='" + falan + "',MerkezAdresi='" + adres + "',MerkezTel='" + tel + "',PersonelSayisi='" + psayi + "',TasitSayisi='" + tsayi + "',FirmaNo='" + fno + "',FirmaSifre='" + sifre + "' where FirmaID='" + ID + "'");
                durum = "1";
                Fonksiyonlar.LoginAD = funvan;
                Fonksiyonlar.LoginSifre = sifre;

            }
            catch (Exception)
            {
                durum = "0";
            }

            return Json(durum, JsonRequestBehavior.AllowGet);
        }


        public ActionResult MusteriProfil()
        {
            string ID = Fonksiyonlar.LoginID.ToString();
            if (ID != "" && ID != "0" && ID != null)
            {
                DataRow dr = f.GetDataRow("select * from MusteriBilgileri where MusteriID='" + ID + "'");
                if (dr != null)
                {
                    ViewBag.MusteriAdi = dr.ItemArray[1].ToString();
                    ViewBag.MusteriSoyadi = dr.ItemArray[2].ToString();
                    ViewBag.MusteriAdresi = dr.ItemArray[3].ToString();
                    ViewBag.MusteriTel = dr.ItemArray[4].ToString();
                    ViewBag.MusteriEposta = dr.ItemArray[5].ToString();
                    ViewBag.MusteriSifre = dr.ItemArray[6].ToString();
                }
                else
                {
                    ViewBag.MusteriAdi = "";
                    ViewBag.MusteriSoyadi = "";
                    ViewBag.MusteriAdresi = "";
                    ViewBag.MusteriTel = "";
                    ViewBag.MusteriEposta = "";
                    ViewBag.MusteriSifre = "";
                }
            }
            else
            {
                ViewBag.MusteriAdi = "";
                ViewBag.MusteriSoyadi = "";
                ViewBag.MusteriAdresi = "";
                ViewBag.MusteriTel = "";
                ViewBag.MusteriEposta = "";
                ViewBag.MusteriSifre = "";
            }
            return View();
        }

        public JsonResult MusteriProfilDuzenle(FormCollection frm)
        {
            string ID = Fonksiyonlar.LoginID.ToString();
            string ad = frm["ad"].ToString();
            string sad = frm["sad"].ToString();
            string adres = frm["adres"].ToString();
            string tel = frm["tel"].ToString();
            string eposta = frm["eposta"].ToString();
            string sifre = frm["sifre"].ToString();
            string durum = "0";
            try
            {
                f.cmd("update MusteriBilgileri set MusteriAdi='" + ad + "',MusteriSoyadi='" + sad + "',MusteriAdresi='" + adres + "',MusteriTel='" + tel + "',MusteriEposta='" + eposta + "',MusteriSifre='" + sifre + "' where MusteriID='" + ID + "'");
                f.cmd("update KartBilgileri set Adi='" + ad + " " + sad + "' where KulID='" + ID + "'");
                durum = "1";
                Fonksiyonlar.LoginAD = ad;
                Fonksiyonlar.LoginSOYAD = sad;
                Fonksiyonlar.LoginSifre = sifre;

            }
            catch (Exception)
            {
                durum = "0";
            }

            return Json(durum, JsonRequestBehavior.AllowGet);
        }


        public JsonResult SeferlerListesi(FormCollection frm)
        {
            string Basla = frm["basla"].ToString();
            string Bit = frm["bit"].ToString();
            string Bastar = frm["bastar"].ToString();
            string Donustar = frm["donustar"].ToString();
            string trip = frm["trip"].ToString();
            string Durum = "";


            string sorgu = "select TT.Tip,S.SeferID,FB.FirmaUnvani,S.BaslangicKonumu,S.BitisKonumu,S.Tarih,S.Saat,S.Fiyat,FB.FirmaLogo,FB.FirmaID from Seferler as S left join TasitBilgileri as TB on(S.TasitID=TB.ID) left join FirmaBilgileri as FB on(TB.FirmaID=FB.FirmaID) left join TasitTipi as TT on(TB.TipID=TT.ID)" +
            " where S.BaslangicKonumu='" + Basla + "' and S.BitisKonumu='" + Bit + "' and S.Tarih='" + Bastar + "' order by TT.Tip,S.Tarih,S.Saat";

            DataTable dt3 = f.GetDataTable(sorgu);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                string ID = dt3.Rows[i].ItemArray[9].ToString();
                string S1 = "";
                string S2 = "";
                string S3 = "";
                string S4 = "";
                string S5 = "";
                string Ortalama = "";
                string Adet = "";
                DataRow dr2 = f.GetDataRow("select COUNT(Puan),SUM(Puan) from Yorumlar where FirmaID='" + ID + "'");
                if (dr2 != null)
                {
                    string ToplamAdet = dr2.ItemArray[0].ToString();
                    if (Convert.ToInt32(ToplamAdet)>0)
                    {
                        Adet = "Toplam " + ToplamAdet + " Kişi Değerlendirdi.";
                    }
                    else
                    {
                        Adet = "Hiç Değerlendirme Yapılmadı.";
                    }
                    string ToplamSayi = dr2.ItemArray[1].ToString();
                    double Ort = 0;
                    if (ToplamAdet != "0" && ToplamSayi != "")
                    {
                        Ort = Convert.ToDouble(ToplamSayi) / Convert.ToDouble(ToplamAdet);

                    }
                    Ortalama = Math.Round(Ort, 1).ToString();
                    DataTable dt = f.GetDataTable("select PUAN,COUNT(Puan) as TANE from Yorumlar where FirmaID='" + ID + "' GROUP BY PUAN");
                    
                    if (Ort > 0)
                    {
                        S1 = "checked";
                    }
                    else
                    {
                        S1 = "";
                    }
                    if (Ort > 1)
                    {
                        S2 = "checked";
                    }
                    else
                    {
                        S2 = "";
                    }
                    if (Ort > 2)
                    {
                        S3 = "checked";
                    }
                    else
                    {
                        S3 = "";
                    }
                    if (Ort > 3)
                    {
                        S4 = "checked";
                    }
                    else
                    {
                        S4 = "";
                    }
                    if (Ort > 4)
                    {
                        S5 = "checked";
                    }
                    else
                    {
                        S5 = "";
                    }
                }




                string LogoGelen = dt3.Rows[i]["FirmaLogo"].ToString();
                if (LogoGelen == "")
                {
                    LogoGelen = "none.png";
                }
                SeferAraModeli seferAraModeli = new SeferAraModeli()
                {
                    Tip = dt3.Rows[i]["Tip"].ToString(),
                    SeferID = Convert.ToInt32(dt3.Rows[i]["SeferID"].ToString()),
                    FirmaUnvani = dt3.Rows[i]["FirmaUnvani"].ToString(),
                    BaslangicKonumu = dt3.Rows[i]["BaslangicKonumu"].ToString(),
                    BitisKonumu = dt3.Rows[i]["BitisKonumu"].ToString(),
                    Tarih = DateTime.Parse(dt3.Rows[i]["Tarih"].ToString()).ToString("dd.MM.yyyy"),
                    Saat = DateTime.Parse(dt3.Rows[i]["Saat"].ToString()).ToShortTimeString(),
                    Fiyat = dt3.Rows[i]["Fiyat"].ToString(),
                    Logo = LogoGelen,
                    S1=S1,
                    S2=S2,
                    S3=S3,
                    S4=S4,
                    S5=S5,
                    Ort=Ortalama,
                    Adet= " (" + Adet + ")",
                    FirmaID =ID

                };
                SeferAraListesi.Add(seferAraModeli);


            }
            return Json(SeferAraListesi, JsonRequestBehavior.AllowGet);
        }

        public JsonResult KayitOl(FormCollection frm)
        {
            string adi = frm["adi"].ToString();
            string soyadi = frm["soyadi"].ToString();
            string adres = frm["adres"].ToString();
            string tel = frm["tel"].ToString();
            string email = frm["email"].ToString();
            string sifre = frm["sifre"].ToString();
            string Durum = "0";
            try
            {
                DataRow dr = f.GetDataRow("select * from MusteriBilgileri where MusteriEposta='" + email + "'");
                if (dr != null)
                {
                    KayitModeli kayitModeli = new KayitModeli()
                    {
                        Durum = 2

                    };
                    KayitListesi.Add(kayitModeli);
                }
                else
                {
                    f.cmd("insert into MusteriBilgileri(MusteriAdi,MusteriSoyadi,MusteriAdresi,MusteriTel,MusteriEposta,MusteriSifre,Aktiflik) values('" + adi + "','" + soyadi + "','" + adres + "','" + tel + "','" + email + "','" + sifre + "','False')");
                    KayitModeli kayitModeli = new KayitModeli()
                    {
                        Durum = 1

                    };
                    KayitListesi.Add(kayitModeli);
                }
            }
            catch (Exception)
            {
                KayitModeli kayitModeli = new KayitModeli()
                {
                    Durum = 0

                };
                KayitListesi.Add(kayitModeli);
            }
            return Json(KayitListesi, JsonRequestBehavior.AllowGet);
        }



        public ActionResult SatinAlinan()
        {
            string LogID = Fonksiyonlar.LoginID.ToString();
            if (LogID != "" && LogID != "0" && LogID != null)
            {


                DataTable dt = f.GetDataTable(@"select G.GRezervasyonID,S.SeferSayisi,F.FirmaUnvani,G.MusteriAdi,G.MusteriSoyadi,G.KalkisKonumu,G.InisKonumu,G.KoltukNumarasi,G.Tarih,G.Saat,G.Fiyat,F.FirmaLogo,F.FirmaID
                                                from GecmisRezervasyon as G left join TasitBilgileri as T on(G.TasitID=T.ID)
                                                left join FirmaBilgileri as F on(T.FirmaID=F.FirmaID)
                                                left join Seferler as S on(G.SeferID=S.SeferID)
                                                left join MusteriBilgileri as M on(G.MusteriID=M.MusteriID) where M.MusteriID='" + LogID + "' order by G.GRezervasyonID DESC");
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = f.GetDataRow("select SUM(G.Fiyat) from GecmisRezervasyon as G left join MusteriBilgileri as M on(G.MusteriID=M.MusteriID) where M.MusteriID='" + LogID + "'");
                    if (dr != null)
                    {
                        ViewBag.ToplamFiyat = dr.ItemArray[0].ToString() + " ₺";
                    }
                    else
                    {
                        ViewBag.ToplamFiyat = "";
                    }
                    ViewBag.ToplamSayi = dt.Rows.Count;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string LogoGelen = dt.Rows[i].ItemArray[11].ToString();
                        if (LogoGelen == "")
                        {
                            LogoGelen = "none.png";
                        }
                        SatinAlinanlarModeli satinAlinanlarModeli = new SatinAlinanlarModeli()
                        {
                            Sira = (i + 1).ToString(),
                            GRezervasyonID = dt.Rows[i].ItemArray[0].ToString(),
                            SeferSayisi = Convert.ToInt32(dt.Rows[i].ItemArray[1].ToString()).ToString("D5"),
                            FirmaUnvani = dt.Rows[i].ItemArray[2].ToString(),
                            MusteriAdi = dt.Rows[i].ItemArray[3].ToString(),
                            MusteriSoyadi = dt.Rows[i].ItemArray[4].ToString(),
                            KalkisKonumu = dt.Rows[i].ItemArray[5].ToString(),
                            InisKonumu = dt.Rows[i].ItemArray[6].ToString(),
                            KoltukNumarasi = dt.Rows[i].ItemArray[7].ToString(),
                            Tarih = DateTime.Parse(dt.Rows[i].ItemArray[8].ToString()).ToShortDateString(),
                            Saat = DateTime.Parse(dt.Rows[i].ItemArray[9].ToString()).ToShortTimeString(),
                            Fiyat = dt.Rows[i].ItemArray[10].ToString() + " ₺",
                            Logo = LogoGelen,
                            FID = dt.Rows[i].ItemArray[12].ToString()
                        };
                        SatinAlinanlarListe.Add(satinAlinanlarModeli);
                    }
                    ViewBag.Liste = SatinAlinanlarListe;
                }
                else
                {

                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Index");
            }

        }

        public ActionResult SatinAl(string KOD, string ID)
        {
            string LogID = Fonksiyonlar.LoginID.ToString();
            if (LogID != "" && LogID != "0" && LogID != null)
            {
                if (Fonksiyonlar.SatinOnay)
                {
                    Fonksiyonlar.SiparisListe.Clear();
                    Fonksiyonlar.SatinAlToplam = 0;
                    string Kosul = "";
                    if (KOD == "1")
                    {//Tekli Sipariş Satın Alma
                        Kosul = "MusteriID='" + Fonksiyonlar.LoginID + "' and RezervasyonID='" + ID + "'";
                    }
                    else
                    {
                        Kosul = "MusteriID='" + Fonksiyonlar.LoginID + "'";
                    }

                    DataTable dt = f.GetDataTable("select RezervasyonID,KalkisKonumu,InisKonumu,KoltukNumarasi,Tarih,Saat,Fiyat,FB.FirmaLogo from Rezervasyon as R left join TasitBilgileri as TB on(R.TasitID=TB.ID) left join FirmaBilgileri as FB on(TB.FirmaID=FB.FirmaID) where " + Kosul);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow drTop = f.GetDataRow("select SUM(Fiyat) from Rezervasyon where " + Kosul);
                        if (drTop != null)
                        {
                            double Toplam = 0;
                            DataTable dtPuan = f.GetDataTable("select * from GecmisRezervasyon where MusteriID='" + Fonksiyonlar.LoginID + "'");
                            if (dtPuan.Rows.Count > 0)
                            {
                                Fonksiyonlar.GecmisAlinan = dtPuan.Rows.Count;
                                Toplam = Convert.ToDouble(drTop.ItemArray[0].ToString());
                                double yuzde = Convert.ToDouble((Toplam * (0.4 * dtPuan.Rows.Count)) / 100);
                                Toplam = Toplam - yuzde;
                                ViewBag.ToplamFiyat = Math.Round(Toplam, 2);
                                Fonksiyonlar.SatinAlToplam = Toplam;
                                ViewBag.Yuzde = "Geçmişte yapılan satın almalara göre her bir bilet için 0,4 oranında indirim yapılmaktadır. Sizin Geçmişte " + dtPuan.Rows.Count + " adet satın alınmış seyehat planınız bulunduğu için " + Math.Round(yuzde, 2) + " ₺ indirim yapılmıştır.";
                                ViewBag.indirim = Math.Round(yuzde, 2);
                            }
                            else
                            {
                                Fonksiyonlar.GecmisAlinan = 0;
                                ViewBag.ToplamFiyat = drTop.ItemArray[0].ToString();
                                Fonksiyonlar.SatinAlToplam = Convert.ToDouble(drTop.ItemArray[0].ToString());
                                ViewBag.Yuzde = "";
                            }

                        }
                        else
                        {
                            Fonksiyonlar.GecmisAlinan = 0;
                            ViewBag.ToplamFiyat = 0;
                            Fonksiyonlar.SatinAlToplam = 0;
                            ViewBag.Yuzde = "";
                        }
                        ViewBag.ToplamSatir = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Fonksiyonlar.SiparisListe.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                            SatinAlListeModeli satinalModeli = new SatinAlListeModeli()
                            {
                                ID = dt.Rows[i].ItemArray[0].ToString(),
                                Siparis = (i + 1) + ") " + dt.Rows[i].ItemArray[1].ToString() + " Konumundan -> " + dt.Rows[i].ItemArray[2].ToString() + " Konumuna, " + dt.Rows[i].ItemArray[3].ToString() + " Koltuk No ile " + DateTime.Parse(dt.Rows[i].ItemArray[4].ToString()).ToShortDateString() + " " + dt.Rows[i].ItemArray[5].ToString() + " Zamanındaki Seyehat Siparişiniz.",
                                Fiyat = dt.Rows[i].ItemArray[6].ToString(),
                                Logo = dt.Rows[i].ItemArray[7].ToString()
                            };
                            SatinAlListe.Add(satinalModeli);
                        }
                        ViewBag.Liste = SatinAlListe;

                        DataRow drKart = f.GetDataRow("select * from KartBilgileri where KulID='" + LogID + "'");
                        if (drKart != null)
                        {
                            ViewBag.Durum = "1";
                            ViewBag.Adi = drKart.ItemArray[2].ToString();
                            string Kart = drKart.ItemArray[3].ToString();
                            ViewBag.KartNumarasi = Kart;
                            string SonTar = drKart.ItemArray[4].ToString();
                            string Ay = "";
                            string Yil = "";
                            if (SonTar.Length > 0)
                            {
                                Boolean Durum = false;
                                for (int i = 0; i < SonTar.Length; i++)
                                {
                                    if (SonTar[i].ToString() != "/")
                                    {
                                        if (Durum == false)
                                        {
                                            Ay += SonTar[i].ToString();
                                        }
                                        else
                                        {
                                            Yil += SonTar[i].ToString();
                                        }
                                    }
                                    else
                                    {
                                        Durum = true;
                                    }
                                }
                            }
                            ViewBag.Ay = Ay;
                            ViewBag.Yil = Yil;
                            ViewBag.CVV = drKart.ItemArray[5].ToString();
                            ViewBag.Bakiye = drKart.ItemArray[6].ToString();
                            ViewBag.IBAN = drKart.ItemArray[7].ToString();
                        }
                        else
                        {
                            ViewBag.Durum = "0";
                            ViewBag.Adi = "";
                            ViewBag.KartNumarasi = "";
                            ViewBag.Ay = "";
                            ViewBag.Yil = "";
                            ViewBag.CVV = "";
                            ViewBag.Bakiye = "";
                            ViewBag.IBAN = "";
                        }

                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Rezervasyonlarim", "Index");
                    }

                }
                else
                {
                    return RedirectToAction("Rezervasyonlarim", "Index");
                }

            }
            else
            {
                return RedirectToAction("Login", "Index");
            }

        }

        public JsonResult SeferAlTamam(FormCollection frm)
        {
            string CNAME = frm["cname"].ToString();
            string CNUM = frm["cnum"].ToString();
            string AY = frm["ay"].ToString();
            string YIL = frm["yil"].ToString();
            string CVV = frm["cvv"].ToString();
            string NAME = frm["name"].ToString();
            string EMAIL = frm["email"].ToString();
            string ADRES = frm["adres"].ToString();
            string TEL = frm["tel"].ToString();
            int Durum = 0;
            DataRow dr = f.GetDataRow("select KartID,Bakiye from KartBilgileri where Adi='" + CNAME + "' and KartNumarasi='" + CNUM + "' and SonTarih='" + AY + "/" + YIL + "' and CVV='" + CVV + "'");
            if (dr != null)
            {
                double Bakiye = Convert.ToDouble(dr.ItemArray[1].ToString());
                string KartID = dr.ItemArray[0].ToString();
                if (Bakiye < Fonksiyonlar.SatinAlToplam)
                {
                    Durum = 1;//Kartın Bakiyesi Yetersizdir.
                }
                else
                {
                    try
                    {
                        double Kalan = Bakiye - Fonksiyonlar.SatinAlToplam;
                        string KalanUcret = Math.Round(Kalan, 2).ToString();
                        KalanUcret = KalanUcret.Replace(",", ".");
                        f.cmd("update KartBilgileri set Bakiye=" + KalanUcret + " where KartID='" + KartID + "'");
                        try
                        {
                            foreach (var item in Fonksiyonlar.SiparisListe)
                            {
                                int ID = item;
                                DataRow drRezerve = f.GetDataRow("select * from Rezervasyon where RezervasyonID='" + ID + "'");
                                if (drRezerve != null)
                                {
                                    string RezervasyonID = drRezerve.ItemArray[0].ToString();
                                    string SeferID = drRezerve.ItemArray[1].ToString();
                                    string TasitID = drRezerve.ItemArray[2].ToString();
                                    DataRow drFir = f.GetDataRow("select FirmaID from TasitBilgileri where ID='" + TasitID + "'");
                                    string MusteriID = drRezerve.ItemArray[3].ToString();
                                    string MusteriAdi = drRezerve.ItemArray[4].ToString();
                                    string MusteriSoyadi = drRezerve.ItemArray[5].ToString();
                                    string MusteriTel = drRezerve.ItemArray[6].ToString();
                                    string Kalkis = drRezerve.ItemArray[7].ToString();
                                    string inis = drRezerve.ItemArray[8].ToString();
                                    string Koltuk = drRezerve.ItemArray[9].ToString();
                                    string Fiyat = drRezerve.ItemArray[10].ToString();
                                    double Ucret = Convert.ToDouble(Fiyat);
                                    DataRow drFirKart = f.GetDataRow("select Bakiye from KartBilgileri where KulID='" + drFir.ItemArray[0].ToString() + "' and KulTur=2");
                                    if (drFirKart != null)
                                    {
                                        double EskiTutar = Convert.ToDouble(drFirKart.ItemArray[0].ToString());
                                        EskiTutar += Ucret;
                                        string YeniTutar = EskiTutar.ToString();
                                        YeniTutar = YeniTutar.Replace(",", ".");
                                        f.cmd("update KartBilgileri set Bakiye='" + YeniTutar + "' where KulID='" + drFir.ItemArray[0].ToString() + "' and KulTur=2");
                                    }
                                    double yuzde = Convert.ToDouble((Ucret * (0.4 * Fonksiyonlar.GecmisAlinan)) / 100);
                                    double Top = Ucret - yuzde;
                                    Fiyat = Math.Round(Top, 2).ToString();
                                    Fiyat = Fiyat.Replace(",", ".");
                                    string Tarih = drRezerve.ItemArray[11].ToString();
                                    DateTime tar = DateTime.Parse(Tarih);
                                    string Saat = drRezerve.ItemArray[12].ToString();
                                    DateTime saat = DateTime.Parse(Saat);

                                    string Sorgu = "insert into GecmisRezervasyon(RezervasyonID,SeferID,TasitID,MusteriID,MusteriAdi,MusteriSoyadi,MusteriTel,MusteriAdres,MusteriEposta,KalkisKonumu,InisKonumu,KoltukNumarasi,Fiyat,Tarih,Saat) values('" + RezervasyonID + "','" + SeferID + "','" + TasitID + "','" + MusteriID + "','" + MusteriAdi + "','" + MusteriSoyadi + "','" + TEL + "','" + ADRES + "','" + EMAIL + "','" + Kalkis + "','" + inis + "','" + Koltuk + "'," + Fiyat + ",'" + tar.ToString("yyyy-MM-dd") + "','" + saat.ToString("T") + "')";
                                    f.cmd(Sorgu);
                                }
                            }

                            try
                            {
                                foreach (var item in Fonksiyonlar.SiparisListe)
                                {
                                    f.cmd("delete from Rezervasyon where RezervasyonID='" + item + "'");
                                }
                                Durum = 2;
                            }
                            catch (Exception)
                            {
                                foreach (var item in Fonksiyonlar.SiparisListe)
                                {
                                    f.cmd("delete from GecmisRezervasyon where RezervasyonID='" + item + "'");
                                }
                                string Tutar = Bakiye.ToString();
                                Tutar = Tutar.Replace(",", ".");
                                f.cmd("update KartBilgileri set Bakiye=" + Tutar + " where KartID='" + KartID + "'");
                                Durum = -3;
                            }

                        }
                        catch (Exception ex)
                        {
                            foreach (var item in Fonksiyonlar.SiparisListe)
                            {
                                f.cmd("delete from GecmisRezervasyon where RezervasyonID='" + item + "'");
                            }
                            string Tutar = Bakiye.ToString();
                            Tutar = Tutar.Replace(",", ".");
                            f.cmd("update KartBilgileri set Bakiye=" + Tutar + " where KartID='" + KartID + "'");
                            Durum = -2;//Geçmiş Rezervasyon Hatası.
                        }
                    }
                    catch (Exception)
                    {
                        Durum = -1;//Bakiye düşüş Hatası
                    }
                }
            }
            else
            {
                Durum = 0;//Kart Bulunamadı.
            }
            return Json(Durum, JsonRequestBehavior.AllowGet);

        }

        public JsonResult MailAt(FormCollection frm)
        {
            Boolean Durum = false;


            try
            {
            }

            catch (Exception ex)
            {
                Durum = false;
            }
            return Json(Durum, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cuzdan()
        {
            string LogID = Fonksiyonlar.LoginID.ToString();
            if (LogID != "" && LogID != "0" && LogID != null)
            {
                DataTable dtPuan = f.GetDataTable("select * from GecmisRezervasyon where MusteriID='" + LogID + "'");
                if (dtPuan.Rows.Count > 0)
                {
                    int Sayi = dtPuan.Rows.Count;
                    double Puan = Sayi * (0.4);
                    ViewBag.Puan = Puan.ToString();

                }
                else
                {
                    ViewBag.Puan = "0";
                }
                ViewBag.Alinan = dtPuan.Rows.Count;

                DataRow drKart = f.GetDataRow("select * from KartBilgileri where KulID='" + LogID + "' and KulTur=1");
                if (drKart != null)
                {
                    ViewBag.Durum = "1";
                    ViewBag.Adi = drKart.ItemArray[2].ToString();
                    string Kart = drKart.ItemArray[3].ToString();
                    Kart = Kart.Replace("-", " ");
                    ViewBag.KartNumarasi = Kart;
                    ViewBag.SonTarih = drKart.ItemArray[4].ToString();
                    ViewBag.CVV = drKart.ItemArray[5].ToString();
                    ViewBag.Bakiye = drKart.ItemArray[6].ToString();
                    ViewBag.IBAN = drKart.ItemArray[7].ToString();
                }
                else
                {
                    ViewBag.Durum = "0";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Index");
            }
        }

        public JsonResult HesapOlustur(FormCollection frm)
        {
            int Durum = 0;
            try
            {
                string LogID = Fonksiyonlar.LoginID.ToString();
                string AD = Fonksiyonlar.LoginAD + " " + Fonksiyonlar.LoginSOYAD;
                Random rnd = new Random();
                string Kartno = rnd.Next(1000, 9999).ToString() + "-" + rnd.Next(1000, 9999).ToString() + "-" + rnd.Next(1000, 9999).ToString() + "-" + rnd.Next(1000, 9999).ToString();
                DateTime date = DateTime.Now;
                string Ay = date.Month.ToString();
                string Yil = date.AddYears(10).Year.ToString();
                Yil = Yil.Substring(Yil.Length - 2);
                int Ay2 = Convert.ToInt32(Ay);
                int Yil2 = Convert.ToInt32(Yil);
                string SonTarih = Ay2.ToString("D2") + "/" + Yil2.ToString("D2");
                string CVV = rnd.Next(100, 999).ToString();
                double Bakiye = 0;
                string IBAN = "TR" + rnd.Next(10, 99) + " 0001 00" + rnd.Next(10, 99) + " " + rnd.Next(1000, 9999) + " " + rnd.Next(1000, 9999) + " " + rnd.Next(1000, 9999) + " " + rnd.Next(10, 99);
                f.cmd("insert into KartBilgileri(KulID,Adi,KartNumarasi,SonTarih,CVV,Bakiye,IBAN,KulTur) values('" + LogID + "','" + AD + "','" + Kartno + "','" + SonTarih + "','" + CVV + "','" + Bakiye + "','" + IBAN + "',1)");
                Durum = 1;
            }
            catch (Exception ex)
            {
                Durum = 0;
            }
            return Json(Durum, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BakiyeYukle(string Bakiye, int KulTur)
        {
            string LogID = Fonksiyonlar.LoginID.ToString();
            int Durum = 0;
            if (LogID != "" && LogID != null && LogID != "0")
            {
                try
                {
                    double Girilen = Convert.ToDouble(Bakiye);
                    DataRow drKart = f.GetDataRow("select Bakiye from KartBilgileri where KulID='" + LogID + "' and KulTur='" + KulTur + "'");
                    if (drKart != null)
                    {
                        string GelenBakiye = drKart.ItemArray[0].ToString();
                        double GelBak = Convert.ToDouble(GelenBakiye);
                        double Toplam = GelBak + Girilen;
                        string Gidecek = Toplam.ToString();
                        Gidecek = Gidecek.Replace(",", ".");
                        f.cmd("update KartBilgileri set Bakiye='" + Gidecek + "' where KulID='" + LogID + "' and KulTur='" + KulTur + "'");
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

        public ActionResult FirmaCuzdan()
        {
            string LogID = Fonksiyonlar.LoginID.ToString();
            if (LogID != "" && LogID != "0" && LogID != null)
            {
                DataRow drKart = f.GetDataRow("select * from KartBilgileri where KulID='" + LogID + "' and KulTur=2");
                if (drKart != null)
                {
                    ViewBag.Durum = "1";
                    ViewBag.Adi = drKart.ItemArray[2].ToString();
                    string Kart = drKart.ItemArray[3].ToString();
                    Kart = Kart.Replace("-", " ");
                    ViewBag.KartNumarasi = Kart;
                    ViewBag.SonTarih = drKart.ItemArray[4].ToString();
                    ViewBag.CVV = drKart.ItemArray[5].ToString();
                    ViewBag.Bakiye = drKart.ItemArray[6].ToString();
                    ViewBag.IBAN = drKart.ItemArray[7].ToString();
                }
                else
                {
                    ViewBag.Durum = "0";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Index");
            }
        }


        public JsonResult FirmaHesapOlustur(FormCollection frm)
        {
            int Durum = 0;
            try
            {
                string LogID = Fonksiyonlar.LoginID.ToString();
                string AD = Fonksiyonlar.LoginAD + " " + Fonksiyonlar.LoginSOYAD;
                Random rnd = new Random();
                string Kartno = rnd.Next(1000, 9999).ToString() + "-" + rnd.Next(1000, 9999).ToString() + "-" + rnd.Next(1000, 9999).ToString() + "-" + rnd.Next(1000, 9999).ToString();
                DateTime date = DateTime.Now;
                string Ay = date.Month.ToString();
                string Yil = date.AddYears(10).Year.ToString();
                Yil = Yil.Substring(Yil.Length - 2);
                int Ay2 = Convert.ToInt32(Ay);
                int Yil2 = Convert.ToInt32(Yil);
                string SonTarih = Ay2.ToString("D2") + "/" + Yil2.ToString("D2");
                string CVV = rnd.Next(100, 999).ToString();
                double Bakiye = 0;
                string IBAN = "TR" + rnd.Next(10, 99) + " 0001 00" + rnd.Next(10, 99) + " " + rnd.Next(1000, 9999) + " " + rnd.Next(1000, 9999) + " " + rnd.Next(1000, 9999) + " " + rnd.Next(10, 99);
                f.cmd("insert into KartBilgileri(KulID,Adi,KartNumarasi,SonTarih,CVV,Bakiye,IBAN,KulTur) values('" + LogID + "','" + AD + "','" + Kartno + "','" + SonTarih + "','" + CVV + "','" + Bakiye + "','" + IBAN + "',2)");
                Durum = 1;
            }
            catch (Exception ex)
            {
                Durum = 0;
            }
            return Json(Durum, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProfilFotoGuncelle(HttpPostedFileBase file)
        {
            string Resim = "";
            if (file != null)
            {
                DataRow drlogo = f.GetDataRow("select FirmaLogo from FirmaBilgileri where FirmaID='" + Fonksiyonlar.LoginID + "'");
                Resim = drlogo.ItemArray[0].ToString();
                var sil = Server.MapPath("~/Fotograf/" + Resim + "");
                var yenisil = sil.Replace("\\", "/");
                if (System.IO.File.Exists(yenisil))
                {
                    System.IO.File.Delete(yenisil);

                }

                var Firma = "Firma";
                string GelenUzanti = Path.GetExtension(file.FileName);
                string GelenAd = Firma + "-" + Fonksiyonlar.LoginID + GelenUzanti;
                file.SaveAs(Server.MapPath("~/Fotograf/" + GelenAd));

                f.cmd("update FirmaBilgileri set FirmaLogo='" + GelenAd + "' where FirmaID='" + Fonksiyonlar.LoginID + "'");

                //drlogo = db.GetDataRow("select Logo from Firmalar where FirmaID='" + Session["FirmaID"] + "'");
                //Database.Logo = drlogo.ItemArray[0].ToString();

            }
            return Redirect("/Index/FirmaProfil");
        }

        public ActionResult FotoSil()
        {
            DataRow drlogo = f.GetDataRow("select FirmaLogo from FirmaBilgileri where FirmaID='" + Fonksiyonlar.LoginID + "'");
            string Resim = drlogo.ItemArray[0].ToString();
            var sil = Server.MapPath("~/Fotograf/" + Resim + "");
            var yenisil = sil.Replace("\\", "/");
            if (System.IO.File.Exists(yenisil))
            {
                System.IO.File.Delete(yenisil);

            }
            f.cmd("update FirmaBilgileri set FirmaLogo=NULL where FirmaID='" + Fonksiyonlar.LoginID + "'");
            return Redirect("/Index/FirmaProfil");
        }


        public ActionResult Yorum(string ID)
        {
            if (ID!="")
            {
                Fonksiyonlar.FirmaYorum = Convert.ToInt32(ID);
                DataRow dr = f.GetDataRow("select * from FirmaBilgileri where FirmaID='" + ID + "'");
                if (dr != null)
                {
                    ViewBag.ID = dr.ItemArray[0].ToString();
                    ViewBag.Funvan = dr.ItemArray[1].ToString();
                    ViewBag.Falan = dr.ItemArray[2].ToString();
                    ViewBag.Madres = dr.ItemArray[3].ToString();
                    ViewBag.Mtel = dr.ItemArray[4].ToString();
                    ViewBag.Psayi = dr.ItemArray[5].ToString();
                    ViewBag.Tsayi = dr.ItemArray[6].ToString();
                    ViewBag.Flogo = dr.ItemArray[9].ToString();
                    ViewBag.Fpuan = dr.ItemArray[10].ToString();
                    DataRow dr2 = f.GetDataRow("select COUNT(Puan),SUM(Puan) from Yorumlar where FirmaID='" + ID + "'");
                    if (dr2 != null)
                    {
                        string ToplamAdet = dr2.ItemArray[0].ToString();
                        string ToplamSayi = dr2.ItemArray[1].ToString();
                        double Ort = 0;
                        if (ToplamAdet != "0" && ToplamSayi != "")
                        {
                            Ort = Convert.ToDouble(ToplamSayi) / Convert.ToDouble(ToplamAdet);

                        }
                        ViewBag.ToplamAdet = ToplamAdet;
                        ViewBag.ToplamSayi = ToplamSayi;
                        ViewBag.Ort = Math.Round(Ort, 1);
                        DataTable dt = f.GetDataTable("select PUAN,COUNT(Puan) as TANE from Yorumlar where FirmaID='" + ID + "' GROUP BY PUAN");
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string Puan = dt.Rows[i].ItemArray[0].ToString();
                                string kacAdet = dt.Rows[i].ItemArray[1].ToString();
                                if (Puan == "1")
                                {
                                    ViewBag.Puan1 = kacAdet;
                                    ViewBag.Yuzde1 = ((Convert.ToInt32(kacAdet) * 100) / Convert.ToInt32(ToplamAdet)).ToString();
                                }
                                else if (Puan == "2")
                                {
                                    ViewBag.Puan2 = kacAdet;
                                    ViewBag.Yuzde2 = ((Convert.ToInt32(kacAdet) * 100) / Convert.ToInt32(ToplamAdet)).ToString();
                                }
                                else if (Puan == "3")
                                {
                                    ViewBag.Puan3 = kacAdet;
                                    ViewBag.Yuzde3 = ((Convert.ToInt32(kacAdet) * 100) / Convert.ToInt32(ToplamAdet)).ToString();
                                }
                                else if (Puan == "4")
                                {
                                    ViewBag.Puan4 = kacAdet;
                                    ViewBag.Yuzde4 = ((Convert.ToInt32(kacAdet) * 100) / Convert.ToInt32(ToplamAdet)).ToString();
                                }
                                else if (Puan == "5")
                                {
                                    ViewBag.Puan5 = kacAdet;
                                    ViewBag.Yuzde5 = ((Convert.ToInt32(kacAdet) * 100) / Convert.ToInt32(ToplamAdet)).ToString();
                                }
                                else
                                {

                                }
                            }
                        }
                        else
                        {
                            ViewBag.Puan1 = "0";
                            ViewBag.Puan2 = "0";
                            ViewBag.Puan3 = "0";
                            ViewBag.Puan4 = "0";
                            ViewBag.Puan5 = "0";
                            ViewBag.Yuzde1 = "0";
                            ViewBag.Yuzde2 = "0";
                            ViewBag.Yuzde3 = "0";
                            ViewBag.Yuzde4 = "0";
                            ViewBag.Yuzde5 = "0";

                        }
                        if (Ort > 0)
                        {
                            ViewBag.S1 = "checked";
                        }
                        else
                        {
                            ViewBag.S1 = "";
                        }
                        if (Ort > 1)
                        {
                            ViewBag.S2 = "checked";
                        }
                        else
                        {
                            ViewBag.S2 = "";
                        }
                        if (Ort > 2)
                        {
                            ViewBag.S3 = "checked";
                        }
                        else
                        {
                            ViewBag.S3 = "";
                        }
                        if (Ort > 3)
                        {
                            ViewBag.S4 = "checked";
                        }
                        else
                        {
                            ViewBag.S4 = "";
                        }
                        if (Ort > 4)
                        {
                            ViewBag.S5 = "checked";
                        }
                        else
                        {
                            ViewBag.S5 = "";
                        }

                        DataTable dtYorumlar = f.GetDataTable("select Y.ID,M.MusteriAdi,M.MusteriSoyadi,Puan,Yorum from Yorumlar as Y left join MusteriBilgileri as M on(Y.MusteriID=M.MusteriID) where MusteriAdi IS NOT NULL and FirmaID='" + ID + "' ORDER BY ID");
                        ViewBag.ToplamKisi = dtYorumlar.Rows.Count;
                        for (int i = 0; i < dtYorumlar.Rows.Count; i++)
                        {
                            int Puan = Convert.ToInt32(dtYorumlar.Rows[i].ItemArray[3].ToString());
                            string S1 = "";
                            string S2 = "";
                            string S3 = "";
                            string S4 = "";
                            string S5 = "";
                            if (Puan > 0)
                            {
                                S1 = "checked";
                            }
                            else
                            {
                                S1 = "";
                            }
                            if (Puan > 1)
                            {
                                S2 = "checked";
                            }
                            else
                            {
                                S2 = "";
                            }
                            if (Puan > 2)
                            {
                                S3 = "checked";
                            }
                            else
                            {
                                S3 = "";
                            }
                            if (Puan > 3)
                            {
                                S4 = "checked";
                            }
                            else
                            {
                                S4 = "";
                            }
                            if (Puan > 4)
                            {
                                S5 = "checked";
                            }
                            else
                            {
                                S5 = "";
                            }
                            string YorumTam = dtYorumlar.Rows[i].ItemArray[4].ToString();
                            string Yorum = YorumTam;

                            if (Yorum.Length > 130)
                            {
                                Yorum = Yorum.Substring(0, 129);
                                Yorum += "...";
                            }

                            for (int j = 1; j <= YorumTam.Length; j++)
                            {
                                if (j % 105 == 0)
                                {
                                    string Eski = YorumTam.Substring(0, j - 1);
                                    string Yeni = YorumTam.Substring(j);
                                    YorumTam = Eski + "<br>" + Yeni;
                                }
                            }

                            Yorumlar YorumlarModeli = new Yorumlar()
                            {
                                ID = dtYorumlar.Rows[i].ItemArray[0].ToString(),
                                Ad = dtYorumlar.Rows[i].ItemArray[1].ToString(),
                                Soyad = dtYorumlar.Rows[i].ItemArray[2].ToString(),
                                Puan = dtYorumlar.Rows[i].ItemArray[3].ToString(),
                                S1 = S1,
                                S2 = S2,
                                S3 = S3,
                                S4 = S4,
                                S5 = S5,
                                Yorum = Yorum,
                                YorumTam = YorumTam,
                                Sira = i + 1

                            };
                            YorumlarListe.Add(YorumlarModeli);
                        }
                        ViewBag.Liste = YorumlarListe;

                        DataRow drKisi = f.GetDataRow("select Puan,Yorum from Yorumlar where MusteriID='"+Fonksiyonlar.LoginID+"' and FirmaID='"+ID+"'");
                        if (drKisi!=null)
                        {
                            string Puan = drKisi.ItemArray[0].ToString();
                            string Yorum = drKisi.ItemArray[1].ToString();
                            if (Puan=="1")
                            {
                                ViewBag.KS2 = "";
                                ViewBag.KS3 = "";
                                ViewBag.KS4 = "";
                                ViewBag.KS5 = "";
                                ViewBag.KS1 = "checked=\"checked\"";
                            }
                            else if (Puan=="2") {
                                ViewBag.KS1 = "";
                                ViewBag.KS3 = "";
                                ViewBag.KS4 = "";
                                ViewBag.KS5 = "";
                                ViewBag.KS2 = "checked=\"checked\"";
                            }
                            else if (Puan == "3")
                            {
                                ViewBag.KS1 = "";
                                ViewBag.KS2 = "";
                                ViewBag.KS4 = "";
                                ViewBag.KS5 = "";
                                ViewBag.KS3 = "checked=\"checked\"";
                            }
                            else if (Puan == "4")
                            {
                                ViewBag.KS1 = "";
                                ViewBag.KS2 = "";
                                ViewBag.KS3 = "";
                                ViewBag.KS5 = "";
                                ViewBag.KS4 = "checked=\"checked\"";
                            }
                            else if (Puan == "5")
                            {
                                ViewBag.KS1 = "";
                                ViewBag.KS2 = "";
                                ViewBag.KS3 = "";
                                ViewBag.KS4 = "";
                                ViewBag.KS5 = "checked=\"checked\"";
                            }
                            else
                            {
                                ViewBag.KS1 = "";
                                ViewBag.KS2 = "";
                                ViewBag.KS3 = "";
                                ViewBag.KS4 = "";
                                ViewBag.KS5 = "";
                            }
                            ViewBag.KYorum = Yorum;
                        }
                        else
                        {
                            ViewBag.KS1 = "";
                            ViewBag.KS2 = "";
                            ViewBag.KS3 = "";
                            ViewBag.KS4 = "";
                            ViewBag.KS5 = "";
                            ViewBag.KYorum="";
                        }
                    }

                    if (ViewBag.Puan1 == null)
                    {
                        ViewBag.Puan1 = "0";
                        ViewBag.Yuzde1 = "0";
                    }
                    if (ViewBag.Puan2 == null)
                    {
                        ViewBag.Puan2 = "0";
                        ViewBag.Yuzde2 = "0";
                    }
                    if (ViewBag.Puan3 == null)
                    {
                        ViewBag.Puan3 = "0";
                        ViewBag.Yuzde3 = "0";
                    }
                    if (ViewBag.Puan4 == null)
                    {
                        ViewBag.Puan4 = "0";
                        ViewBag.Yuzde4 = "0";
                    }
                    if (ViewBag.Puan5 == null)
                    {
                        ViewBag.Puan5 = "0";
                        ViewBag.Yuzde5 = "0";
                    }
                    if (ViewBag.S1 == null)
                    {
                        ViewBag.S1 = "";
                    }
                    if (ViewBag.S2 == null)
                    {
                        ViewBag.S2 = "";
                    }
                    if (ViewBag.S3 == null)
                    {
                        ViewBag.S3 = "";
                    }
                    if (ViewBag.S4 == null)
                    {
                        ViewBag.S4 = "";
                    }
                    if (ViewBag.S5 == null)
                    {
                        ViewBag.S5 = "";
                    }
                    return View();
                }
                else
                {
                    return Redirect("/Index/SatinAlinan");
                }
            }
            else
            {
                return Redirect("/Index/Login");
            }

        }

        public JsonResult YorumKaydet(string S1,string S2,string S3,string S4,string S5,string Yorum)
        {
            int Durum = 0;
            try
            {
                string Sayi = "0";
                if (S1=="true")
                {
                    Sayi = "1";
                }
                else if (S2=="true")
                {
                    Sayi = "2";
                }
                else if (S3 == "true")
                {
                    Sayi = "3";
                }
                else if (S4 == "true")
                {
                    Sayi = "4";
                }
                else if (S5 == "true")
                {
                    Sayi = "5";
                }
                else
                {
                    Sayi = "0";
                }

                Yorum = Yorum.Replace("'", "");

                if (Sayi!="0")
                {
                    DataRow dr = f.GetDataRow("select * from Yorumlar where FirmaID='"+Fonksiyonlar.FirmaYorum+"' and MusteriID='"+Fonksiyonlar.LoginID+"'");
                    if (dr!=null) {
                        f.cmd("update Yorumlar set Puan='"+Sayi+"', Yorum='"+Yorum+"' where ID='" + dr.ItemArray[0].ToString() +"'");
                    }
                    else
                    {
                        f.cmd("insert into Yorumlar(FirmaID,MusteriID,Puan,Yorum) values('" + Fonksiyonlar.FirmaYorum + "','" + Fonksiyonlar.LoginID + "','" + Sayi + "','" + Yorum + "')");
                    }
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
            return Json(Durum, JsonRequestBehavior.AllowGet);
        }

        public JsonResult YorumSil()
        {
            int Durum = 0;
            try
            {
                f.cmd("delete from Yorumlar where FirmaID='"+Fonksiyonlar.FirmaYorum+"' and MusteriID='"+Fonksiyonlar.LoginID+"'");
                Durum = 1;
            }
            catch (Exception)
            {
                Durum = 0;
            }
            return Json(Durum, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Iletisim()
        {
            return View();
        }
        public JsonResult IletisimGonder(FormCollection frm)
        {
            string ad = frm["ad"].ToString();
            string mail = frm["mail"].ToString();
            string konu = frm["konu"].ToString();
            string mesaj = frm["mesaj"].ToString();
            int Durum = 0;
            try
            {
                f.cmd("insert into Iletisim(Ad,Email,Konu,Mesaj) values('"+ad+ "','"+mail+ "','"+konu+ "','"+mesaj+"')");
                Durum = 1;
            }
            catch (Exception)
            {
                Durum = 0;
            }
            return Json(Durum, JsonRequestBehavior.AllowGet);
        }
    }
}