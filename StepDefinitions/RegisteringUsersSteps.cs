using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UserRegisterSpecs.Domain;

namespace UserRegisterSpecs.StepDefinitons
{
    [Binding]
    public class RegisteringUsersSteps
    {
        private ScenarioContext scenarioContext;
        private RegisterUserApi registerUsers;
        private FindUsersApi findUsers;

        public RegisteringUsersSteps(ScenarioContext scenarioContext, 
                                     RegisterUserApi registerUsers,
                                     FindUsersApi findUsers)
        {
            this.scenarioContext = scenarioContext;
            this.registerUsers = registerUsers;
            this.findUsers = findUsers;
        }

        [Given(@"a new user")]
        public void GivenANewUser(Table table)
        {
            this.scenarioContext["NewUser"] = table.CreateInstance<UserDetails>().AsUser();
        }

        [Given(@"the following registered users")]
        public void GivenTheFollowingRegisteredUsers(Table table)
        {
            List<UserDetails> users = table.CreateSet<UserDetails>().ToList();

            users.ForEach(
                userDetails => registerUsers.Register(userDetails.AsUser())
            );
        }

        [When(@"he (?:registers|tries to register) online")]
        public void WhenHeRegistersOnline()
        {
            User newUser = (User)scenarioContext["NewUser"];

            string userLocation = registerUsers.Register(newUser);

            string userId = userLocation.Split('/').Last();

            this.scenarioContext["NewUserId"] = userId;
        }

        [Given(@"he has registered online")]
        public void HeHasRegisteredOnline()
        {
            WhenHeRegistersOnline();
        }

        [Then(@"he should be assigned a unique account number")]
        public void ThenHeShouldBeAssignedAUniqueAccountNumber()
        {
            String userName = ((User) scenarioContext["NewUser"]).name;
            RegisteredUser registeredUser = findUsers.FindByName(userName);

            scenarioContext["RegisteredUser"] = registeredUser;

            Assert.That(registeredUser.id, Is.Not.Null);
        }


        [Then(@"his request should be rejected with a (.*) error")]
        public void ThenHisRequestShouldBeRejected(HttpStatusCode expectedErrorCode)
        {
            Assert.That(registerUsers.LastStatusCode, Is.EqualTo(expectedErrorCode));
        }

    }

    public class UserDetails
    {
        public string Name;
        public string Password;
        public string TelephoneNumber;
        public string Street;
        public string City;
        public string Country;

        public User AsUser()
        {
            Address address = new Address(Street, City, Country);
            PersonalDetails personalDetails = new PersonalDetails(TelephoneNumber, address);
            return new User(Name, Password, personalDetails);
        }
    }
}