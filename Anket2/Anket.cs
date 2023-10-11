namespace Anket2
{
    internal class Anket
    {
        private string ad;
        private string soyad;
        private string email;
        private string tel;
        
        public string Ad
        {
            get { return ad; }
            set
            {
                if ((int)value[0] >= 65 && (int)value[0] <= 90 && value.Length >= 3) ad = value;
                else throw new ApplicationException("Name Error...");
            }
        }

        public string Soyad
        {
            get { return soyad; }
            set
            {
                if ((int)value[0] >= 65 && (int)value[0] <= 90 && value.Length >= 5) soyad = value;
                else throw new ApplicationException("Surname Error...");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if ( value.EndsWith("@gmail.com")) email = value;
                else throw new ApplicationException("Email Error...");
            }
        }
        public string Tel
        {
            get { return tel; }
            set
            {
                if ((value.StartsWith("055") || value.StartsWith("050")|| value.StartsWith("051") || value.StartsWith("010")|| value.StartsWith("099")|| value.StartsWith("077") || value.StartsWith("070"))&& value.Length>= 10) tel = value;
                else throw new ApplicationException("Tel Error...");
            }
        }
        public DateTime Date { get; set; }

        public Anket() { }

        public Anket(string ad,string soyad,string email , string tel,DateTime date)
        {
            Ad = ad;
            Soyad = soyad;
            Email = email;
            Tel = tel;
            Date = date;
        }

    }
}
