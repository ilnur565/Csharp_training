using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private string allPhones = "";
        private string mobile = "";
        private string work = "";
        private string email;
        private string email2;
        private string email3;
        private string allEmails;
        //private string allElements;

        public ContactCreationData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.Lastname = lastname;
           
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
        public string Id { get; set; }

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
        public string Lastname { get; set; }
        
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
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Allphones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {

                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone).Trim();
                }
            }
                    set
            {
                allPhones = value;
            }
        }
        public string AllPhonesWithPrefix
        {
            get 
            { if (allPhones != null)
                {
                    return SetPhonePrefix(DoLineFeed(HomePhone), 0) + SetPhonePrefix(DoLineFeed(MobilePhone), 1) + SetPhonePrefix(DoLineFeed(WorkPhone), 2);
                }
                else
                {

                    return SetPhonePrefix (DoLineFeed(HomePhone),0) + SetPhonePrefix(DoLineFeed(MobilePhone), 1) + SetPhonePrefix(DoLineFeed(WorkPhone),2); 
                }
            } 

            set {
                allPhones = value;
            }
        }
        public String DoLineFeed(string line)
        {
            if (string.IsNullOrEmpty(line)) {  return ""; }
            return line + "\r\n";

        }
        public string SetPhonePrefix(string phone, int index)
        {
            if (string.IsNullOrEmpty(phone)) {  return "";  }

            else
            {
                if (index == 0) return "H: " + phone;
                if (index == 1) return "M: " + phone;
                if (index == 2) return "W: " + phone;
            }
            return "error";
        }
        
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllEmails
        {
            get
            {
                if(allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim(); 
                }
            }
            set { 
                allEmails = value; }

        }
     /*   public string AllElements {
            get
            {
                if (allElements!=null)
                {
                    return allElements;
                }
                else 
                {
                    return (Firstname + Lastname + Address + Allphones + Allemails + AllElements);
                }
                
            }

            set { allElements = value; } 
        }*/

    public string CleanUp(string phone)
        {
            if (phone==null|| phone=="")
            { return ""; }

            return Regex.Replace(phone, "[ -()]", "")+"\r\n";

           
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
