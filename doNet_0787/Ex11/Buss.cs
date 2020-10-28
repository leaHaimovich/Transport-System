using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Buss
{
    string licenseNumber;//לוחית רישוי
    DateTime firstUseDate;// תאריך שימוש ראשון 
    double km;
    double kmafterRefueling;//קילומטר נסיעה מאז התידלוק האחרון
    double kmFromLastTreat;

    public string LicenseNumber
    {
        get { return licenseNumber; }
        set => licenseNumber = value;

    }
    public double Km
    {
        get { return km; }
        set => km = value;

    }
    public double KmafterRefueling
    {
        get { return kmafterRefueling; }
        set => km = kmafterRefueling;

    }
    public double kMFromLastTreat
    {
        get { return kmFromLastTreat; }
        set => km = kmFromLastTreat;

    }
    // List<Buss> Buslist = new List<Buss>();//רשימת האוטובוסים
    public Buss(string lpn,DateTime t)
    {
        licenseNumber = lpn;
        firstUseDate = t;
    }
    public Buss() { }
}
