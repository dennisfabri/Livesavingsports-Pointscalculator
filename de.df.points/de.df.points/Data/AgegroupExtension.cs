using Xamarin.Forms;

namespace de.df.points.Data
{
    partial class Agegroup
    {

        public bool IsEnabled1 { get { return AmountOfDisciplines >= 1; } }
        public string Discipline1 { get; set; }

        public string Discipline1Full { get { return string.Format("{0} ({1})", Discipline1, Record1Text); } }

        private int Time1 { get; set; }

        public ReturnType ReturnType1
        {
            get {
                return IsEnabled2 ? ReturnType.Next : ReturnType.Done;
            }
        }

        private bool isValid1 = true;

        public bool IsValid1
        {
            get {
                return isValid1;
            }
            set {
                if (isValid1 != value)
                {
                    isValid1 = value;
                    OnThisPropertyChanged();
                }
            }
        }

        private string time1Text;

        public string Time1Text
        {
            get {
                return time1Text;
            }
            set {
                if (time1Text != value)
                {
                    time1Text = value;
                    Time1 = ToTime(value);
                    IsValid1 = IsValid(value);
                    // OnThisPropertyChanged();
                    OnPropertyChanged(nameof(Result1), nameof(Time1Seconds), nameof(Time1), nameof(Time1Formatted));
                    OnTimeChange();
                }
            }
        }

        public string Time1Formatted { get { return ToFormat(Time1); } }

        private double Time1Seconds { get { return ToSeconds(Time1); } }

        public int Record1 { get; set; }
        private double Record1Seconds { get { return 0.01 * Record1; } }
        public string Record1Text { get { return ToText(Record1); } }
        public double Result1 { get { return GetPoints(Time1Seconds, Record1Seconds); } }
        public bool IsEnabled2 { get { return AmountOfDisciplines >= 2; } }
        public string Discipline2 { get; set; }

        public string Discipline2Full { get { return string.Format("{0} ({1})", Discipline2, Record2Text); } }

        private int Time2 { get; set; }

        public ReturnType ReturnType2
        {
            get {
                return IsEnabled3 ? ReturnType.Next : ReturnType.Done;
            }
        }

        private bool isValid2 = true;

        public bool IsValid2
        {
            get {
                return isValid2;
            }
            set {
                if (isValid2 != value)
                {
                    isValid2 = value;
                    OnThisPropertyChanged();
                }
            }
        }

        private string time2Text;

        public string Time2Text
        {
            get {
                return time2Text;
            }
            set {
                if (time2Text != value)
                {
                    time2Text = value;
                    Time2 = ToTime(value);
                    IsValid2 = IsValid(value);
                    // OnThisPropertyChanged();
                    OnPropertyChanged(nameof(Result2), nameof(Time2Seconds), nameof(Time2), nameof(Time2Formatted));
                    OnTimeChange();
                }
            }
        }

        public string Time2Formatted { get { return ToFormat(Time2); } }

        private double Time2Seconds { get { return ToSeconds(Time2); } }

        public int Record2 { get; set; }
        private double Record2Seconds { get { return 0.01 * Record2; } }
        public string Record2Text { get { return ToText(Record2); } }
        public double Result2 { get { return GetPoints(Time2Seconds, Record2Seconds); } }
        public bool IsEnabled3 { get { return AmountOfDisciplines >= 3; } }
        public string Discipline3 { get; set; }

        public string Discipline3Full { get { return string.Format("{0} ({1})", Discipline3, Record3Text); } }

        private int Time3 { get; set; }

        public ReturnType ReturnType3
        {
            get {
                return IsEnabled4 ? ReturnType.Next : ReturnType.Done;
            }
        }

        private bool isValid3 = true;

        public bool IsValid3
        {
            get {
                return isValid3;
            }
            set {
                if (isValid3 != value)
                {
                    isValid3 = value;
                    OnThisPropertyChanged();
                }
            }
        }

        private string time3Text;

        public string Time3Text
        {
            get {
                return time3Text;
            }
            set {
                if (time3Text != value)
                {
                    time3Text = value;
                    Time3 = ToTime(value);
                    IsValid3 = IsValid(value);
                    // OnThisPropertyChanged();
                    OnPropertyChanged(nameof(Result3), nameof(Time3Seconds), nameof(Time3), nameof(Time3Formatted));
                    OnTimeChange();
                }
            }
        }

        public string Time3Formatted { get { return ToFormat(Time3); } }

        private double Time3Seconds { get { return ToSeconds(Time3); } }

        public int Record3 { get; set; }
        private double Record3Seconds { get { return 0.01 * Record3; } }
        public string Record3Text { get { return ToText(Record3); } }
        public double Result3 { get { return GetPoints(Time3Seconds, Record3Seconds); } }
        public bool IsEnabled4 { get { return AmountOfDisciplines >= 4; } }
        public string Discipline4 { get; set; }

        public string Discipline4Full { get { return string.Format("{0} ({1})", Discipline4, Record4Text); } }

        private int Time4 { get; set; }

        public ReturnType ReturnType4
        {
            get {
                return IsEnabled5 ? ReturnType.Next : ReturnType.Done;
            }
        }

        private bool isValid4 = true;

        public bool IsValid4
        {
            get {
                return isValid4;
            }
            set {
                if (isValid4 != value)
                {
                    isValid4 = value;
                    OnThisPropertyChanged();
                }
            }
        }

        private string time4Text;

        public string Time4Text
        {
            get {
                return time4Text;
            }
            set {
                if (time4Text != value)
                {
                    time4Text = value;
                    Time4 = ToTime(value);
                    IsValid4 = IsValid(value);
                    // OnThisPropertyChanged();
                    OnPropertyChanged(nameof(Result4), nameof(Time4Seconds), nameof(Time4), nameof(Time4Formatted));
                    OnTimeChange();
                }
            }
        }

        public string Time4Formatted { get { return ToFormat(Time4); } }

        private double Time4Seconds { get { return ToSeconds(Time4); } }

        public int Record4 { get; set; }
        private double Record4Seconds { get { return 0.01 * Record4; } }
        public string Record4Text { get { return ToText(Record4); } }
        public double Result4 { get { return GetPoints(Time4Seconds, Record4Seconds); } }
        public bool IsEnabled5 { get { return AmountOfDisciplines >= 5; } }
        public string Discipline5 { get; set; }

        public string Discipline5Full { get { return string.Format("{0} ({1})", Discipline5, Record5Text); } }

        private int Time5 { get; set; }

        public ReturnType ReturnType5
        {
            get {
                return IsEnabled6 ? ReturnType.Next : ReturnType.Done;
            }
        }

        private bool isValid5 = true;

        public bool IsValid5
        {
            get {
                return isValid5;
            }
            set {
                if (isValid5 != value)
                {
                    isValid5 = value;
                    OnThisPropertyChanged();
                }
            }
        }

        private string time5Text;

        public string Time5Text
        {
            get {
                return time5Text;
            }
            set {
                if (time5Text != value)
                {
                    time5Text = value;
                    Time5 = ToTime(value);
                    IsValid5 = IsValid(value);
                    // OnThisPropertyChanged();
                    OnPropertyChanged(nameof(Result5), nameof(Time5Seconds), nameof(Time5), nameof(Time5Formatted));
                    OnTimeChange();
                }
            }
        }

        public string Time5Formatted { get { return ToFormat(Time5); } }

        private double Time5Seconds { get { return ToSeconds(Time5); } }

        public int Record5 { get; set; }
        private double Record5Seconds { get { return 0.01 * Record5; } }
        public string Record5Text { get { return ToText(Record5); } }
        public double Result5 { get { return GetPoints(Time5Seconds, Record5Seconds); } }
        public bool IsEnabled6 { get { return AmountOfDisciplines >= 6; } }
        public string Discipline6 { get; set; }

        public string Discipline6Full { get { return string.Format("{0} ({1})", Discipline6, Record6Text); } }

        private int Time6 { get; set; }

        public ReturnType ReturnType6
        {
            get {
                return ReturnType.Done;
            }
        }

        private bool isValid6 = true;

        public bool IsValid6
        {
            get {
                return isValid6;
            }
            set {
                if (isValid6 != value)
                {
                    isValid6 = value;
                    OnThisPropertyChanged();
                }
            }
        }

        private string time6Text;

        public string Time6Text
        {
            get {
                return time6Text;
            }
            set {
                if (time6Text != value)
                {
                    time6Text = value;
                    Time6 = ToTime(value);
                    IsValid6 = IsValid(value);
                    // OnThisPropertyChanged();
                    OnPropertyChanged(nameof(Result6), nameof(Time6Seconds), nameof(Time6), nameof(Time6Formatted));
                    OnTimeChange();
                }
            }
        }

        public string Time6Formatted { get { return ToFormat(Time6); } }

        private double Time6Seconds { get { return ToSeconds(Time6); } }

        public int Record6 { get; set; }
        private double Record6Seconds { get { return 0.01 * Record6; } }
        public string Record6Text { get { return ToText(Record6); } }
        public double Result6 { get { return GetPoints(Time6Seconds, Record6Seconds); } }
    }
}