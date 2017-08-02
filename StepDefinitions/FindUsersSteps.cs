using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UserRegisterSpecs.Domain;

namespace UserRegisterSpecs.StepDefinitions
{
    [Binding]
    public class FindUsersSteps
    {
        private ScenarioContext scenarioContext;
        private FindUsersApi findUsers;

        public FindUsersSteps(ScenarioContext scenarioContext,
                              FindUsersApi findUsers)
        {
            this.scenarioContext = scenarioContext;
            this.findUsers = findUsers;
        }

        [When(@"I list all of the registered users")]
        public void WhenIListAllOfTheRegisteredUsers()
        {
            List<RegisteredUser> retrievedUsers = findUsers.FindAll();
            this.scenarioContext["Users"] = retrievedUsers;
        }

        [When(@"I search for registered users named ""(.*)""")]
        public void WhenISearchForRegisteredUsersNamed(string name)
        {
            RegisteredUser retrievedUser = findUsers.FindByName(name);
            this.scenarioContext["Users"] = new List<RegisteredUser> {retrievedUser};
        }

        [When(@"I search for a registered user with the returned Id value")]
        public void WhenISearchForARegisteredUserWithTheReturnedIdValue()
        {
            string id = (string) scenarioContext["NewUserId"];

            RegisteredUser retrievedUser = findUsers.FindById(id);

            this.scenarioContext["Users"] = new List<RegisteredUser> { retrievedUser };
        }

        [Then(@"I should obtain the following users?:")]
        public void ThenIShouldObtainTheFollowingUsers(Table table)
        {
            List<User> expectedUsers = table.CreateSet<User>().ToList();
            List<String> expectedNames = expectedUsers.ConvertAll(user => user.name);

            List<RegisteredUser> retrievedUsers = (List<RegisteredUser>) scenarioContext["Users"];
            List<String> retrievedNames = retrievedUsers.ConvertAll(user => user.name);

            Assert.That(retrievedNames, Is.EquivalentTo(expectedNames));
        }
    
    }
}