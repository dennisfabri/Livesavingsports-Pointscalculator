using System;
using System.Linq;

namespace de.df.points.Data
{
    internal class DataModel
    {
        private static readonly int FirstYear = 2017;

        private static readonly Agegroup[][] Single = new Agegroup[][] { DataModel2017.Single, DataModel2018.Single, DataModel2019.Single, DataModel2020.Single, DataModel2021.Single, DataModel2022.Single };
        private static readonly Agegroup[][] Team = new Agegroup[][] { DataModel2017.Team, DataModel2018.Team, DataModel2019.Team, DataModel2020.Team, DataModel2021.Team, DataModel2022.Single };

        private static readonly int[] Years = Single.Select((agegroup, index) => FirstYear + index).ToArray();

        internal static Agegroup[] GetCurrentSingle()
        {
            return Single.Last();
        }

        internal static Agegroup[] GetCurrentTeam()
        {
            return Team.Last();
        }

        internal static Agegroup[] GetSingle(int year)
        {
            return Single[year - 2017];
        }

        internal static Agegroup[] GetTeam(int year)
        {
            return Team[year - 2017];
        }

        internal static int[] GetYears()
        {
            return Years.ToArray();
        }
    }
}
