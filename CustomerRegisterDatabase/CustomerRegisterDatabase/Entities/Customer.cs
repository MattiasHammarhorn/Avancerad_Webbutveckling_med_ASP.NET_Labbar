using System;

namespace CustomerRegisterDatabase.Entities
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender GenderType { get; set; }
        public int Age { get; set; }

        public string GenderTypeEnglish
        {
            get
            {
                switch(GenderType)
                {
                    case Gender.Male:
                        return "Male";
                    case Gender.Female:
                        return "Female";
                    case Gender.Other:
                        return "Other";
                }

                return GenderType.ToString();
            }
        }
    }
}
