using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UserRegisterSpecs.Domain
{
    public class User
    {
        public User() {}

        public User(string Name,
                    string Password,
                    PersonalDetails personalDetails)
        {
            this.name = Name;
            this.password = Password;
            this.personalDetails = personalDetails;
        }

        public string name { get; set; }
        public string password { get; set; }
        public PersonalDetails personalDetails { get; set; }
    }

    public class RegisteredUser : User
    {

        public RegisteredUser() { }

        public string id { get; set; }
    }

    public class PersonalDetails
    {
        public PersonalDetails()
        {
        }

        public PersonalDetails(string telephoneNumber, Address address)
        {
            this.telephoneNumber = telephoneNumber;
            this.address = address;
        }
        public string telephoneNumber { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public Address()
        {
        }

        public Address(string street, string city, string country)
        {
            this.addressLineOne = street;
            this.addressLineTwo = city;
            this.addressLineThree = country;
        }
        public string addressLineOne { get; set; }
        public string addressLineTwo { get; set; }
        public string addressLineThree { get; set; }
    }
}
