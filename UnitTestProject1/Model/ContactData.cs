﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AddressBookWebTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allPageData;
        public ContactData()
        {
        }
        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName == other.FirstName && LastName == other.LastName);
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "FirstName = " + FirstName + "\n" + "Lastname = " + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if ((FirstName.CompareTo(other.FirstName) == 0) && (LastName.CompareTo(other.LastName) == 0))
            {
                return 0;
            }

            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return 1;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phoneOrMail)
        {
            if ( phoneOrMail == null || phoneOrMail == "")
            {
                return "";
            }
            return Regex.Replace(phoneOrMail, "[ -()]", "") + "\r\n";
        }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllPageData
        {
            get
            {
                if (allPageData != null)
                {
                    return allPageData;
                }
                else
                {
                    string pageDataInString = "";

                    if (FirstName != null || LastName != null)
                    {
                        pageDataInString += FirstName != null ? FirstName + " " : "";
                        pageDataInString += LastName != null ? LastName + "\r\n" : "";
                        pageDataInString += "\r\n";
                    }

                    if (Address != null)
                    {
                        pageDataInString += Address != null ? Address + "\r\n" : "";
                        pageDataInString += "\r\n";
                    }

                    if (HomePhone != null || MobilePhone != null || WorkPhone != null)
                    {
                        pageDataInString += HomePhone != null ? "H: " + HomePhone + "\r\n" : "";
                        pageDataInString += MobilePhone != null ? "M: " + MobilePhone + "\r\n" : "";
                        pageDataInString += WorkPhone != null ? "W: " + WorkPhone + "\r\n" : "";
                        pageDataInString += "\r\n";
                    }

                    if (Email != null || Email2 != null || Email3 != null)
                    {
                        pageDataInString += Email != null ? Email + "\r\n" : "";
                        pageDataInString += Email2 != null ? Email2 + "\r\n" : "";
                        pageDataInString += Email3 != null ? Email3 + "\r\n" : "";
                    }

                    return pageDataInString;
                }
            }
            set
            {
                allPageData = value;
            }
        }
    }   
}
