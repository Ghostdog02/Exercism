using System;

namespace FootballMatchReports
{
    public static class PlayAnalyzer
    {
        public static void Main()
        {

        }

        public static string AnalyzeOnField(int shirtNum)
        {
            switch (shirtNum)
            {
                case 1:
                    return "goalie";
                case 2:
                    return "left back";
                case 3:
                case 4:
                    return "center back";
                case 5:
                    return "right back";
                case 6:
                case 7:
                case 8:
                    return "midfielder";
                case 9:
                    return "left wing";
                case 10:
                    return "striker";
                case 11:
                    return "right wing";
                default:
                    throw new ArgumentOutOfRangeException();

            }
        }

        public static string AnalyzeOffField(object report)
        {
            switch (report)
            {
                case int:
                    return $"There are {report} supporters at the match.";
                case string:
                    return $"{report}";
                case Foul newFoul:
                    return "The referee deemed a foul.";
                case Injury newInjury:
                    return $"Oh no! Player {newInjury} is injured. Medics are on the field.";
                case Incident newIncident:
                    return $"An incident happened.";
                case Manager newManager:
                    if (newManager.Club == null)
                    {
                        return $"{newManager.Name}";
                    }

                    else
                    {
                        return $"{newManager.Name} ({newManager?.Club})";
                    }
                   

                default:
                    throw new ArgumentException();
                
            }
        }
    }
    abstract class Incident
    {


    }

    class Foul : Incident
    {

    }

    class Injury : Incident
    {
        public int Number = 0;

        public Injury(int number)
        {
            number = Number;
        }
    }

    public class Manager
    {
        public string Name { get; }

        public string? Club { get; }

        public Manager(string name, string? club)
        {
            this.Name = name;
            this.Club = club;
        }
    }
}



