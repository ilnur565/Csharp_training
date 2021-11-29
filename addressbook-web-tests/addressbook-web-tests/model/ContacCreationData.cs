using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactCreationData : IEquatable<ContactCreationData> , IComparable<ContactCreationData>
    {
        public string firstname;
        public string lastname = "";
        public string middlename="";
        public string nickname = "";
        public string title = "";
        public string company = "";
        public string address = "";
        public string home = "";

        public ContactCreationData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;

        }
        public bool Equals(ContactCreationData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return    Firstname == other.Firstname && Lastname == other.Lastname;
        }   
        public override int GetHashCode()
        {
            return Lastname.GetHashCode() + Firstname.GetHashCode();
            //return 0;
        }

        public override string ToString()
        {
            return   Lastname + " " + Firstname;
        }

        public int CompareTo(ContactCreationData other) 
        { 
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
            //return -1;
        }


        public string Firstname
        {

            get
            {
                return firstname;
            }
            set 
            {
                firstname = value;
            }

        }
        public string Lastname
        {

            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }

        }
        public string Middlename
        {

            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }

        }
        public string Nickname
        {

            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }

        }
        public string Title
        {

            get
            {
                return title;
            }
            set
            {
                title = value;
            }

        }
        public string Company
        {

            get
            {
                return company;
            }
            set
            {
                company = value;
            }

        }
        public string Address
        {

            get
            {
                return address;
            }
            set
            {
                address = value;
            }

        }
        public string Home
        {

            get
            {
                return home;
            }
            set
            {
                home = value;
            }

        }
    }
}
