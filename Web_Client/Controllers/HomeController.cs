using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Client.Models;

namespace Web_Client.Controllers
{
    public class HomeController : Controller
    {
        KandidatService.KandidatClient kandidat = new KandidatService.KandidatClient();
        public ActionResult Index()
        {
            List<Candidate> listCd = new List<Candidate>();

            var lcd = kandidat.ShowKandidat();

            foreach(var data in lcd)
            {
                Candidate cd = new Candidate();
                cd.Nama = data.nama;
                cd.Nomor_urut = data.nomorUrut;
                cd.Prodi = data.prodi;
                cd.Jurusan = data.jurusan;
                cd.Visi = data.visi;
                cd.Misi = data.misi;
                cd.Foto = data.picture;

                listCd.Add(cd);
            }

            return View(listCd);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}