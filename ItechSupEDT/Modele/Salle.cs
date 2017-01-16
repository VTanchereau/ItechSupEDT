using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Modele
{
    public class Salle : Destinataire 
    {
        private String _nom;
        private int _capacite;
        private List<Session> _lstSessions;
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Nom
        {
            get { return this._nom; }
            set { this._nom = value; }
        }
        public int Capacite
        {
            get { return this._capacite; }
            set { this._capacite = value; }
        }
        public List<Session> LstSessions
        {
            get { return this._lstSessions; }
            set { this._lstSessions = value; }
        }
        public Salle(String _nom, int _capacite, int id = 0)
        {
            this._nom = _nom;
            this._capacite = _capacite;
            this._lstSessions = new List<Session>();
            this._id = id;
        }
        public bool EstDisponible(DateTime _dateDebut, DateTime _dateFin)
        {
            bool disponible = true;
            foreach (Session session in this.LstSessions)
            {
                bool conflitDebut = (_dateDebut > session.DateDebut) && (_dateDebut < session.DateFin);
                bool conflitFin = (_dateFin > session.DateDebut) && (_dateFin < session.DateFin);
                if (conflitDebut || conflitFin)
                {
                    disponible = false;
                }
            }
            return disponible;
        }
        List<Session> Destinataire.GetSessions(DateTime _dateDebut, DateTime _dateFin)
        {
            List<Session> lstSessions = new List<Session>();
            foreach (Session session in this.LstSessions)
            {
                if (session.DateDebut > _dateDebut && session.DateFin < _dateFin)
                {
                    lstSessions.Add(session);
                }
            }
            return lstSessions;
        }
    }
}
