using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RestSharp.Extensions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UserRegisterSpecs.Domain;

namespace UserRegisterSpecs.StepDefinitons
{
    [Binding]
    public class PrepareTestData
    {
        private CleanRegistryApi cleanRegistry;

        public PrepareTestData(CleanRegistryApi cleanRegistry)
        {
            this.cleanRegistry = cleanRegistry;
        }

        [BeforeScenario]
        public void deleteAllUsers()
        {
            cleanRegistry.deleteAll();
        }
    }
}