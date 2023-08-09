using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Seyehat_Rezervasyon_Sistemi
{
    public class Fonksiyonlar
    {
        
        //Login
        public static int LoginID = 0;
        public static string LoginAD = "";
        public static string LoginSOYAD = "";
        public static string LoginTEL = "";
        public static string LoginADRES = "";
        public static string LoginEMAIL = "";
        public static string LoginSifre = "";
        public static int LoginTur = 0;
        public static int LoginSepet = 0;


        public static string MusteriID = "";
        public static string MusteriAdi = "";
        public static string MusteriSoyadi = "";
        public static string MusteriAdres = "";
        public static string MusteriTel = "";
        public static string MusteriEposta = "";
        public static string MusteriSifre = "";



        public static string FirmaID = "";
        public static string FirmaUnvani = "";
        public static string FaliyetAlani = "";
        public static string MerkezAdresi = "";
        public static string MerkezTel = "";
        public static string PersonelSayisi = "";
        public static string TasitSayisi = "";
        public static string FirmaNo = "";
        public static string FirmaSifre = "";
        public static string FirmaLogo = "";

        public static string TID = "";
        public static string TAdi = "";
        public static string TFirmaUnvani = "";
        public static string TTip = ""; 
        public static string TKoltukSayisi = "";


        public static string DizaynTasitID = "";

        public static double SatinAlToplam = 0;
        public static int GecmisAlinan = 0;

        public static int FirmaYorum = 0;
        public static Boolean SatinOnay = true;

        public static List<int> SiparisListe = new List<int>();

        //Rezervasyon Yapma
        

        public SqlConnection Baglan()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=UcakRezervasyonu;integrated Security=True;");
            if (baglanti.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    baglanti.Open();
                    SqlConnection.ClearPool(baglanti);
                }
                catch (SqlException)
                {
                }
            }

            return baglanti;

        }

        public int cmd(string sqlcumle)
        {
            SqlConnection baglan = this.Baglan();
            SqlCommand cmd = new SqlCommand(sqlcumle, baglan);
            int sonuc = 0;
            try
            {
                sonuc = cmd.ExecuteNonQuery();
                cmd.CommandTimeout = 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            cmd.CommandTimeout = 0;
            cmd.Dispose();
            baglan.Close();
            baglan.Dispose();
            return (sonuc);
        }

        public DataTable GetDataTable(string sql)
        {
            SqlConnection baglan = this.Baglan();
            SqlDataAdapter adap = new SqlDataAdapter(sql, baglan);
            DataTable dt = new DataTable();
            try
            {
                adap.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            adap.Dispose();
            baglan.Close();
            return dt;
        }
        public void SessionEkle(string SessionAdi, string SessionDegeri)
        {
            HttpContext.Current.Session.Add("" + SessionAdi + "", "" + SessionDegeri + "");
        }

        public DataTable Listele(string TabloAdi)
        {
            string sorgu = "select * from  " + TabloAdi + "";


            return GetDataTable(sorgu);
        }
        public DataTable WhereListele(string TabloAdi, string sart)
        {
            string sorgu = "select * from  " + TabloAdi + "  where  '" + sart + "'";
            return GetDataTable(sorgu);
        }
        public DataRow GetDataRow(string sql)
        {

            DataTable dt = GetDataTable(sql);
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }

    }
}