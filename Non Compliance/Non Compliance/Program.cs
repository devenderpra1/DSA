// See https://aka.ms/new-console-template for more information
using System.Linq;





List<Default> defaults = new List<Default>();
defaults.Add(new Default() { ID = 1, DateRange = new DateRange(new DateTime(2020, 01, 10), new DateTime(2020, 01, 20)), DefaultRate = .2 });
defaults.Add(new Default() { ID = 2, DateRange = new DateRange(new DateTime(2020, 01, 15), new DateTime(2020, 01, 20)), DefaultRate = .3 });

double CapRate = .4;



public class Calculator
{

    public static void Calculate(double Principal, List<Default> defaults, double CapRate)
    {
        //we need to find out all the rate applicable in all the time range

        List<DateTime> differentTime = new List<DateTime>();

        // for all the distict dates to find the different range

        for (int i = 0; i < defaults.Count; i++)
        {
            if (!differentTime.Contains(defaults[i].DateRange.StartDate))
            {
                differentTime.Add(defaults[i].DateRange.StartDate);
            }
            if (!differentTime.Contains(defaults[i].DateRange.EndDate))
            {
                differentTime.Add(defaults[i].DateRange.EndDate);
            }
        }
        differentTime.Sort();
        Dictionary<DateRange, List<Default>> dateRangeWisePenalty = new Dictionary<DateRange, List<Default>>();
        for (int i = 1; i < differentTime.Count; i++)
        {
            foreach (var def in defaults)
            {
                if (def.DateRange.StartDate == differentTime[i - 1] && def.DateRange.EndDate == differentTime[i])
                {
                    if (!dateRangeWisePenalty.TryGetValue(def.DateRange, out var actualValue))
                    {
                        dateRangeWisePenalty[def.DateRange] = new List<Default>() { def };
                    }
                    else
                    {
                        if (actualValue != null)
                        {
                            actualValue.Add(def);
                        }
                    }
                }
                else if (def.DateRange.StartDate < differentTime[i - 1] && def.DateRange.EndDate == differentTime[i])
                {
                    var startDefEnd = new DateRange(differentTime[i - 1], def.DateRange.EndDate);
                    if (!dateRangeWisePenalty.TryGetValue(startDefEnd, out var actualValue))
                    {
                        dateRangeWisePenalty[def.DateRange] = new List<Default>() { def };
                    }
                    else
                    {
                        if (actualValue != null)
                        {
                            actualValue.Add(def);
                        }
                    }
                }
                else if (def.DateRange.StartDate == differentTime[i - 1] && def.DateRange.EndDate < differentTime[i])
                {
                    var defStartDefEnd = new DateRange(differentTime[i - 1], def.DateRange.EndDate);
                    if (!dateRangeWisePenalty.TryGetValue(defStartDefEnd, out var actualValue))
                    {
                        dateRangeWisePenalty[def.DateRange] = new List<Default>() { def };
                    }
                    else
                    {
                        if (actualValue != null)
                        {
                            actualValue.Add(def);
                        }
                    }
                }
                else if (def.DateRange.StartDate < differentTime[i - 1] && def.DateRange.EndDate > differentTime[i])
                {
                    var startEnd = new DateRange(differentTime[i - 1], def.DateRange.EndDate);
                    if (!dateRangeWisePenalty.TryGetValue(startEnd, out var actualValue))
                    {
                        dateRangeWisePenalty[def.DateRange] = new List<Default>() { def };
                    }
                    else
                    {
                        if (actualValue != null)
                        {
                            actualValue.Add(def);
                        }
                    }
                }
            }
        }
        double totalPenalty = 0;
        Dictionary<Default, double> keyValuePairs = new Dictionary<Default, double>();

        foreach (var dateRange in dateRangeWisePenalty)
        {
            if (dateRange.Value.Any())
            {
                var totalpenaltyRate = dateRange.Value.Sum(a => a.DefaultRate);
                if (totalpenaltyRate < CapRate)
                {
                    CapRate = totalpenaltyRate;
                }
                totalPenalty += Principal * CapRate * ((dateRange.Key.StartDate - dateRange.Key.EndDate).Days + 1) / 365;
                foreach (var penalty in dateRange.Value)
                {
                    if (!keyValuePairs.TryGetValue(penalty, out var value))
                    {
                        keyValuePairs.Add(penalty, Principal * penalty.DefaultRate / totalpenaltyRate * CapRate * ((dateRange.Key.EndDate - dateRange.Key.StartDate).Days + 1) / 365);
                    }
                    else
                    {
                        keyValuePairs[penalty] += Principal * penalty.DefaultRate / totalpenaltyRate * CapRate * ((dateRange.Key.EndDate - dateRange.Key.StartDate).Days + 1) / 365;
                    }
                }
            }
        }

    }
}


public class DateRange : IEquatable<DateRange>
{
    public DateRange(DateTime start, DateTime end)
    {
        StartDate = start;
        EndDate = end;
    }
    public DateTime StartDate;
    public DateTime EndDate;

    public bool Equals(DateRange? other)
    {
        if (other == null)
        {
            return false;
        }
        else if (ReferenceEquals(other, this))
            return true;

        return StartDate == other.StartDate && EndDate == other.EndDate;
    }
}

public class Default
{
    public Default()
    {

    }
    public Default(Default thisDefault)
    {
        DateRange = thisDefault.DateRange;
        DefaultRate = thisDefault.DefaultRate;
    }

    public int ID;
    public DateRange DateRange;

    public double DefaultRate;

    public Default Copy()
    {
        return new Default(this);
    }

    public bool Equals(Default? other)
    {
        if (other == null)
        {
            return false;
        }
        else if (ReferenceEquals(other, this))
            return true;

        return ID == other.ID;
    }

}