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
        public ActionResult Yonetim()//bu ActionResult Sayfa Oluşturur.
        {
            return View();
        }
        
        public ActionResult TasitAyar()
        {
            return View();
        }
        public ActionResult TasitBilgileri()
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
            }

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

                string sorgu = "select TB.ID,TB.Adi,FB.FirmaUnvani,TT.Tip,TB.KoltukSayisi from TasitBilgileri as TB left join FirmaBilgileri as FB on(TB.FirmaID=FB.FirmaID) left join TasitTipi as TT on(TB.TipID=TT.ID) "+ID;

                DataTable dt = f.GetDataTable(sorgu);
                if (dt.Rows.Count>0)
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
                if (dt3.Rows.Count>0)
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
                f.cmd("update FirmaBilgileri set FirmaUnvani='" + FirmaUnvani + "',FaliyetAlani='" + FaliyetAlani + "',MerkezAdresi='" + MerkezAdresi + "',MerkezTel='" + MerkezTel + "',PersonelSayisi='" + PersonelSayisi + "',TasitSayisi='" + TasitSayisi + "',FirmaNo='" + FirmaNo + "',FirmaSifre='" + FirmaSifre + "' where FirmaID='" + FirmaID + "'");
            }
            else
            {
                f.cmd("insert into FirmaBilgileri(FirmaUnvani,FaliyetAlani,MerkezAdresi,MerkezTel,PersonelSayisi,TasitSayisi,FirmaNo,FirmaSifre) values('" + FirmaUnvani + "','" + FaliyetAlani + "','" + MerkezAdresi + "','" + MerkezTel + "','" + PersonelSayisi + "','" + TasitSayisi + "','" + FirmaNo + "','" + FirmaSifre + "')");
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
            DataRow dr = f.GetDataRow("select FirmaID from FirmaBilgileri where FirmaUnvani='"+firma+"'");
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
    }
}