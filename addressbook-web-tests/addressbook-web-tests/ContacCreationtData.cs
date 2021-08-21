using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactCreationtData 
    {
        public string firstname;
        public string lastname = "";
        public string middlename="";
        public string nickname = "";
        public string title = "";
        public string company = "";
        public string address = "";
        public string home = "";

        public ContactCreationtData(string firstname)
        {
            this.firstname = firstname;
           
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
