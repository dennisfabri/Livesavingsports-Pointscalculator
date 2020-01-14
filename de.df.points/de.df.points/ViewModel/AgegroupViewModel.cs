using de.df.points.Framework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace de.df.points.Data
{
    public partial class AgegroupViewModel : ViewModelBase
    {
        public Agegroup Data { get; set; }

        public AgegroupViewModel()
        {
        }

        private static HashSet<char> invalidChars = new HashSet<char>(new char[] { '6', '7', '8', '9' });

        public string Name
        {
            get {
                if (Data == null)
                {
                    return "";
                }
                return Data.Name;
            }
        }
        public string Description
        {
            get {
                if (Data == null)
                {
                    return "";
                }
                return Data.Description;
            }
        }
        public int AmountOfDisciplines
        {
            get {
                if (Data == null)
                {
                    return 0;
                }
                return Data.AmountOfDisciplines;
            }
        }
        public int CalculatedDisciplines
        {
            get {
                if (Data == null)
                {
                    return 0;
                }
                return Data.CalculatedDisciplines;
            }
        }

        public double Result { get; set; }

        public Color Background { get { return string.IsNullOrWhiteSpace(Name) || Name.Contains("w") ? Color.LightPink : Color.LightBlue; } }

        public string Title
        {
            get {
                // return string.Format("{0} - Rettungssport Punkte", Name);
                return string.Format("{0}", Name);
            }
        }

        #region Functions

        private bool IsValid(string value)
        {
            if (value == null || value.Length < 4)
            {
                return true;
            }
            char c = value.ToArray()[value.Length - 4];
            return !invalidChars.Contains(c);
        }

        private void OnTimeChange()
        {
            double[] points = new double[6];

            if (IsEnabled1)
            {
                points[0] = Result1;
            }
            if (IsEnabled2)
            {
                points[1] = Result2;
            }
            if (IsEnabled3)
            {
                points[2] = Result3;
            }
            if (IsEnabled4)
            {
                points[3] = Result4;
            }
            if (IsEnabled5)
            {
                points[4] = Result5;
            }
            if (IsEnabled6)
            {
                points[5] = Result6;
            }

            Result = points.OrderByDescending(i => i).Take(CalculatedDisciplines).DefaultIfEmpty(0).Sum();
            OnPropertyChanged(nameof(Result));
        }

        private const double Epsilon = 0.005;

        private static string ToText(int seconds100)
        {
            int m = (seconds100 / 6000);
            int s = (seconds100 / 100) % 60;
            int h = seconds100 % 100;
            return string.Format("{0}:{1:D2},{2:D2}", m, s, h);
        }

        private static string ToFormat(int writing)
        {
            int m = (writing / 10000);
            int s = (writing / 100) % 100;
            int h = writing % 100;
            return string.Format("{0}:{1:D2},{2:D2}", m, s, h);
        }

        private static double ToSeconds(int? writing)
        {
            if (writing == null)
            {
                return 0;
            }
            int m = (writing.Value / 10000);
            int s = (writing.Value / 100) % 100;
            int h = writing.Value % 100;
            if (s >= 60)
            {
                return 0;
            }
            return m * 60 + s + 0.01 * h;
        }

        private static double GetPoints(double seconds, double rec)
        {
            if (seconds <= Epsilon)
            {
                return 0;
            }
            if (rec <= Epsilon)
            {
                return 0;
            }

            double ergebnis = 0;
            double quo = seconds / rec;

            if (quo <= 2)
            {
                double r1 = 467.0 * quo * quo;
                double r2 = 2001.0 * quo;
                ergebnis = Math.Round((r1 - r2 + 2534.0) * 100.0) / 100.0;
            }
            else if (quo <= 5)
            {
                double r1 = 2000.0 / 3.0;
                double r2 = (400.0 / 3.0) * quo;
                ergebnis = r1 - r2;
                ergebnis = Math.Round(100.0 * ergebnis) / 100.0;
            }

            return ergebnis;
        }

        private static int ToTime(string value)
        {
            if (value == null)
            {
                return 0;
            }

            string v = new String(value.ToCharArray().Where(c => Char.IsDigit(c)).ToArray());

            int time = 0;
            Int32.TryParse(v, out time);
            return time;
        }

        #endregion
    }
}
