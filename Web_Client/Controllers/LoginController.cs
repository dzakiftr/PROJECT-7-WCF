﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Client.Models;

namespace Web_Client.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MahasiswaService.MahasiswaClient mhs = new MahasiswaService.MahasiswaClient();
        KandidatService.KandidatClient kandidat = new KandidatService.KandidatClient();
        KandidatService.VoteInfo vote = new KandidatService.VoteInfo();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string ID, string password)
        {
            bool log = mhs.login(ID, password);
            if (log != false)
            {
                Session["ID"] = ID;
                return RedirectToAction("UserPage");
            }
            else
            {
                ViewBag.Message = "Wrong!";
                return View();
            }
                
        }

        public ActionResult UserPage()
        {
            if (Session["ID"] != null)
            {
                List<Candidate> listCd = new List<Candidate>();

                var lcd = kandidat.ShowKandidat();

                foreach (var data in lcd)
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
            else
                return RedirectToAction("Login");
        }

        public ActionResult Vote(int Number)
        {
            string ID = Session["ID"].ToString();
            bool validate = kandidat.validateUser(ID);
            if(validate != true)
            {
                vote.Nomor_Urut = Number;
                vote.NIM = Convert.ToInt32(ID);

                int result = kandidat.doVote(vote);
                if (result > 0)
                {
                    ViewBag.Message = "Terimakasih untuk berpartisipasi dalam PilkaBEM tahun ini!";
                    return RedirectToAction("UserPage");
                }
                else
                {
                    ViewBag.Message = "Kesalahan dalam proses memilih!";
                    return RedirectToAction("UserPage");
                }
            }
            else
            {
                ViewBag.Message = "Anda telah berpartisipasi dalam pemilihan tahun ini!";
                return RedirectToAction("UserPage");
            }
        }
    }
}