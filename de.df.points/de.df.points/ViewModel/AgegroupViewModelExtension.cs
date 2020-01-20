using PropertyChanged;
using Xamarin.Forms;

namespace de.df.points.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public partial class AgegroupViewModel
    {
        #region proxy

        [DependsOn("Data")]
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

        [DependsOn("Data")]
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

        [DependsOn("Data")]
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

        [DependsOn("Data")]
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


        [DependsOn("Data")]
        public string Discipline1
        {
            get {
                if (Data == null)
                {
                    return "";
                }
                return Data.Discipline1;
            }
        }

        [DependsOn("Data")]
        public int Record1
        {
            get {
                if (Data == null)
                {
                    return 1;
                }
                return Data.Record1;
            }
        }

        private double Record1Seconds => 0.01 * Record1;
        public string Record1Text => ToText(Record1);
        public bool IsEnabled1 => AmountOfDisciplines >= 1;
        public string Discipline1Full => $"{Discipline1} ({Record1Text})";
        public ReturnType ReturnType1 => AmountOfDisciplines >= 1 ? ReturnType.Next : ReturnType.Done;


        [DependsOn("Data")]
        public string Discipline2
        {
            get {
                if (Data == null)
                {
                    return "";
                }
                return Data.Discipline2;
            }
        }

        [DependsOn("Data")]
        public int Record2
        {
            get {
                if (Data == null)
                {
                    return 1;
                }
                return Data.Record2;
            }
        }

        private double Record2Seconds => 0.01 * Record2;
        public string Record2Text => ToText(Record2);
        public bool IsEnabled2 => AmountOfDisciplines >= 2;
        public string Discipline2Full => $"{Discipline2} ({Record2Text})";
        public ReturnType ReturnType2 => AmountOfDisciplines >= 2 ? ReturnType.Next : ReturnType.Done;


        [DependsOn("Data")]
        public string Discipline3
        {
            get {
                if (Data == null)
                {
                    return "";
                }
                return Data.Discipline3;
            }
        }

        [DependsOn("Data")]
        public int Record3
        {
            get {
                if (Data == null)
                {
                    return 1;
                }
                return Data.Record3;
            }
        }

        private double Record3Seconds => 0.01 * Record3;
        public string Record3Text => ToText(Record3);
        public bool IsEnabled3 => AmountOfDisciplines >= 3;
        public string Discipline3Full => $"{Discipline3} ({Record3Text})";
        public ReturnType ReturnType3 => AmountOfDisciplines >= 3 ? ReturnType.Next : ReturnType.Done;


        [DependsOn("Data")]
        public string Discipline4
        {
            get {
                if (Data == null)
                {
                    return "";
                }
                return Data.Discipline4;
            }
        }

        [DependsOn("Data")]
        public int Record4
        {
            get {
                if (Data == null)
                {
                    return 1;
                }
                return Data.Record4;
            }
        }

        private double Record4Seconds => 0.01 * Record4;
        public string Record4Text => ToText(Record4);
        public bool IsEnabled4 => AmountOfDisciplines >= 4;
        public string Discipline4Full => $"{Discipline4} ({Record4Text})";
        public ReturnType ReturnType4 => AmountOfDisciplines >= 4 ? ReturnType.Next : ReturnType.Done;


        [DependsOn("Data")]
        public string Discipline5
        {
            get {
                if (Data == null)
                {
                    return "";
                }
                return Data.Discipline5;
            }
        }

        [DependsOn("Data")]
        public int Record5
        {
            get {
                if (Data == null)
                {
                    return 1;
                }
                return Data.Record5;
            }
        }

        private double Record5Seconds => 0.01 * Record5;
        public string Record5Text => ToText(Record5);
        public bool IsEnabled5 => AmountOfDisciplines >= 5;
        public string Discipline5Full => $"{Discipline5} ({Record5Text})";
        public ReturnType ReturnType5 => AmountOfDisciplines >= 5 ? ReturnType.Next : ReturnType.Done;


        [DependsOn("Data")]
        public string Discipline6
        {
            get {
                if (Data == null)
                {
                    return "";
                }
                return Data.Discipline6;
            }
        }

        [DependsOn("Data")]
        public int Record6
        {
            get {
                if (Data == null)
                {
                    return 1;
                }
                return Data.Record6;
            }
        }

        private double Record6Seconds => 0.01 * Record6;
        public string Record6Text => ToText(Record6);
        public bool IsEnabled6 => AmountOfDisciplines >= 6;
        public string Discipline6Full => $"{Discipline6} ({Record6Text})";
        public ReturnType ReturnType6 => AmountOfDisciplines >= 6 ? ReturnType.Next : ReturnType.Done;

        #endregion proxy

        #region properties
        private int Time1 => ToTime(Time1Text);
        public bool IsValid1 => IsValid(Time1Text);
        public string Time1Text { get; set; }
        public string Time1Formatted => ToFormat(Time1);
        private double Time1Seconds => ToSeconds(Time1);
        public double Result1 => GetPoints(Time1Seconds, Record1Seconds);

        private int Time2 => ToTime(Time2Text);
        public bool IsValid2 => IsValid(Time2Text);
        public string Time2Text { get; set; }
        public string Time2Formatted => ToFormat(Time2);
        private double Time2Seconds => ToSeconds(Time2);
        public double Result2 => GetPoints(Time2Seconds, Record2Seconds);

        private int Time3 => ToTime(Time3Text);
        public bool IsValid3 => IsValid(Time3Text);
        public string Time3Text { get; set; }
        public string Time3Formatted => ToFormat(Time3);
        private double Time3Seconds => ToSeconds(Time3);
        public double Result3 => GetPoints(Time3Seconds, Record3Seconds);

        private int Time4 => ToTime(Time4Text);
        public bool IsValid4 => IsValid(Time4Text);
        public string Time4Text { get; set; }
        public string Time4Formatted => ToFormat(Time4);
        private double Time4Seconds => ToSeconds(Time4);
        public double Result4 => GetPoints(Time4Seconds, Record4Seconds);

        private int Time5 => ToTime(Time5Text);
        public bool IsValid5 => IsValid(Time5Text);
        public string Time5Text { get; set; }
        public string Time5Formatted => ToFormat(Time5);
        private double Time5Seconds => ToSeconds(Time5);
        public double Result5 => GetPoints(Time5Seconds, Record5Seconds);

        private int Time6 => ToTime(Time6Text);
        public bool IsValid6 => IsValid(Time6Text);
        public string Time6Text { get; set; }
        public string Time6Formatted => ToFormat(Time6);
        private double Time6Seconds => ToSeconds(Time6);
        public double Result6 => GetPoints(Time6Seconds, Record6Seconds);

        #endregion properties
    }

}