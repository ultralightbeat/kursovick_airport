using first_lab.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using first_lab.model;

namespace first_lab.presenter
{
    public class MainPresenter
    {
        private IFormView view;
        private Db db;
        private MainModel md;
        public MainPresenter(IFormView view)
        {
            this.view = view;
            db = new Db();
            md = new MainModel();
        }
        public List<Plane> LoadPlanesFromFile(Airport airport)
        {
            return db.LoadPlanesFromFile(airport);
        }
        public void WriteToFile(Plane plane)
        {
            db.WriteToFile(plane);
        }
        public Image GetImage(Plane selectedPlane)
        {
            return db.GetImage(selectedPlane);
        }
        public Image SaveImage(Plane newPlane)
        {
            return db.SaveImage(newPlane);
        }

        public Plane GenerateObject(string destination, object company, object planeType, string price, DateTime flyDate)
        {
            Plane newPlane = md.GenerateObject(destination, company, planeType, price, flyDate);
            FlightStatistics.UpdateStatistics(newPlane);
            return newPlane;
        }
    }
}
