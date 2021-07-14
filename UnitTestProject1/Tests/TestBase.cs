﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace AddressBookWebTests
{
    public class TestBase
    {
        protected AppManager app;

        [SetUp]
        public void SetupAppManager()
        {
            app = AppManager.GetInstance();
        }   
    }
}
