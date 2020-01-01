using System;
using System.Linq;

namespace de.df.points.Data
{
    class DataModel
    {
        private static readonly int FirstYear = 2017;

        private static readonly int[] Years;

        private static readonly Agegroup[][] Single;
        private static readonly Agegroup[][] Team;

        static DataModel()
        {
            Single = new Agegroup[][] { DataModel2017.Single, DataModel2018.Single, DataModel2019.Single, DataModel2020.Single };
            Team = new Agegroup[][] { DataModel2017.Team, DataModel2018.Team, DataModel2019.Team, DataModel2020.Team };

            foreach (Agegroup[] agegroups in Single)
            {
                foreach (Agegroup agegroup in agegroups)
                {
                    agegroup.IsSingle = true;
                }
            }
            foreach (Agegroup[] agegroups in Team)
            {
                foreach (Agegroup agegroup in agegroups)
                {
                    agegroup.IsSingle = false;
                }
            }

            Years = new int[Single.Length];
            for (int x = 0; x < Single.Length; x++)
            {
                Years[x] = FirstYear + x;
            }
        }

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
