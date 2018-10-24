using System;

namespace BusinessEntities
{
    public class UserInformationEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Married { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool? Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
