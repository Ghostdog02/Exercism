using System;

public class WeighingMachine
{
    public int Precision { get; }

    public WeighingMachine(int precision)
    {
        this.Precision = precision;
                                   
    }

    private double weight;

    public double Weight
    {
        get
        {
            return weight;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.weight = value;
        }
    }  

    public double TareAdjustment { get; set; } = 5.0;

    public string DisplayWeight
    {
        get
        {
            var displayWeight = Math.Round(Weight - TareAdjustment, Precision);
            var format = "0." + new string('0', Precision) + " kg";
            return displayWeight.ToString(format);
        }
    }
}