namespace HEFrameApp.Models
{
    public class PersonalInfo
    {

        public PersonalInfo(string name, int age, Sex sex, string address, bool isMember, string occupation, string phoneNumber, string idNumber, string remarks)
        {
            Name = name;
            Age = age;
            Sex = sex;
            Address = address;
            IsMember = isMember;
            Occupation = occupation;
            PhoneNumber = phoneNumber;
            IdNumber = idNumber;
            Remarks = remarks;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public string Address { get; set; }
        public bool IsMember { get; set; }
        public string Occupation { get; set; }
        public string PhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public string Remarks { get; set; }
    }
    public enum Sex
    {
        男,
        女
    }

}
