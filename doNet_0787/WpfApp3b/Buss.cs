using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//public enum StatusBus { ReadyForRide = 0, inMiddleOfRide, Rufueling, inTreat };
public class Buss
{


    private string licenseNumber;//לוחית רישוי
    private DateTime firstUseDate;// תאריך שימוש ראשון 
    private DateTime lastTreat;
    private double km;
    private double kmafterRefueling;//קילומטר נסיעה מאז התידלוק האחרון
    private double kmFromLastTreat;
    int f;
    private StatusBus status;
  public  enum StatusBus { ReadyForRide = 0, inMiddleOfRide, Rufueling, inTreat };

    public StatusBus Status
    {
        get => status;
        set => status = value;
        
    } 
    public DateTime LastTreat
    {
        get { return lastTreat; }
        set => lastTreat = value;
    }
    public string LicenseNumber
    {
        get { return licenseNumber; }
        set => licenseNumber = value;

    }
    public double Km
    {
        //get { return km; }
        //set => km = value;
        get;set;
    }
    public double KmafterRefueling
    {
        //get { return kmafterRefueling; }
        //set => km = kmafterRefueling;
        get; set;
    }
    public double kMFromLastTreat
    {
        //get { return kmFromLastTreat; }
        //set => km = kmFromLastTreat;
        get; set;

    }
    // List<Buss> Buslist = new List<Buss>();//רשימת האוטובוסים
    public Buss(string lpn, DateTime t)//constractor with parameters
    {
        licenseNumber = lpn;
        firstUseDate = t;
    }
    public Buss() { }//constractor
    public override string ToString()
    { string str = "";
        str += "license Number " + licenseNumber + " ";
        str += "kiloemters " + km + " ";
        return str;
    }
    public string PrintBuss()
    {
        string str = "";
        str += "license Number:  " + licenseNumber + " ";
        str += "kiloemters " + km + " ";
        str += "kmafterRefueling:  " + kmafterRefueling + " ";
        str += "kmFromLastTreat:  " + kmFromLastTreat + "  ";
        str += "lastTreat:  " + lastTreat + "  ";
        return str;

    }
    public void REFUELING()
    {
        KmafterRefueling = 0;
        Status = StatusBus.Rufueling;
    }
    public void TRETMENT()
    {
        kMFromLastTreat = 0;
        LastTreat = DateTime.Now;
        Status = StatusBus.inTreat;
    }
    public void DRIVING()
    {

    }
    internal class STATUS
    {
    }
}
