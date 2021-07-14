﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressBookWebTests

{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void TheContactModificationTest()
        {
            ContactData newData = new ContactData("NewName","NewLastName");

            app.Contacts.Modify(1, newData);
        }


    }
}
