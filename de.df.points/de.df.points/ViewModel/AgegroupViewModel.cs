using de.df.points.Data;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace de.df.points.ViewModel
{
    public partial class AgegroupViewModel
    {
        public Agegroup Data { get; set; }

        public AgegroupViewModel()
        {
        }

        private static HashSet<char> invalidChars = new HashSet<char>(new char[] { '6', '7', '8', '9' });

        [DependsOn("Result1", "Result2", "Result3", "Result4", "Result5", "Result6", "AmountOfDisciplines")]
        public double Result => CaclulateResultPoints();

        public Color Background { get { return string.IsNullOrWhiteSpace(Name) || Name.Contains("w") ? Color.LightPink : Color.LightBlue; } }

        public string Title => Name;

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

        private double CaclulateResultPoints()
        {
            return new[] { Result1, Result2, Result3, Result4, Result5, Result6 }.Take(AmountOfDisciplines).OrderByDescending(i => i).Take(CalculatedDisciplines).DefaultIfEmpty(0).Sum();
        }

        private const double Epsilon = 0.005;

        private static string ToText(int seconds100)
        {
            int m = (seconds100 / 6000);
            int s = (seconds100 / 100) % 60;
            int h = seconds100 % 100;
            return $"{m}:{s:D2},{h:D2}";
        }

        private static string ToFormat(int writing)
        {
            int m = (writing / 10000);
            int s = (writing / 100) % 100;
            int h = writing % 100;
            return $"{m}:{s:D2},{h:D2}";
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

            if (Int32.TryParse(v, out int time))
            {
                return time;
            }
            return 0;
        }

        #endregion
    }
}