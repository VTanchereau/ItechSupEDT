﻿using ItechSupEDT.Ajout_UC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Modele
{
    public class Eleve : Nameable
    {
        private int id;
        private String nom;
        private String prenom;
        private String mail;
        private Promotion promotion;
        private List<Absence> listAbsences;
        public int Id
        {
            get { return this.id; }
        }
        public String Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public String Prenom
        {
            get { return this.prenom; }
            set { this.prenom = value; }
        }
        public String Mail
        {
            get { return this.mail; }
            set { this.mail = value; }
        }
        public Promotion Promotion
        {
            get { return this.promotion; }
            set { this.promotion = value; }
        }
        public List<Absence> ListAbsences
        {
            get { return this.listAbsences; }
            set { this.listAbsences = value; }
        }
        public Eleve(int _id, String _nom, String _prenom, String _mail, Promotion _promo)
        {
            this.id = _id;
            this.Nom = _nom;
            this.Prenom = _prenom;
            this.Mail = _mail;
            this.Promotion = _promo;
            this.ListAbsences = new List<Absence>();
        }
        public int GetNbAbsence(DateTime dateDebut, DateTime dateFin)
        {
            return this.ListAbsences.Count;
        }
        string Nameable.getNom()
        {
            return this.Prenom + " " + this.Nom;
        }
    }
}
