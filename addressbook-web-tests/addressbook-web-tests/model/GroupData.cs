using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_tests.model;
using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>, IEnumerable<GroupData>  // определяем ф-ю сравнения; Класс GroupData наследует IEquatable
    {

        private string header=""; 
        private string footer="";

        public GroupData() //конструктор 
        {
            
        }
        public GroupData (string name) //конструктор 
        {
            Name = name;
        }
        /*   public GroupData(string name, string header, string footer) //конструктор (не применяем так как сложно запомнить порядок если много параметров)
           {
               this.name = name;
               this.header = header;
               this.footer = footer;
           }*/

        [Column(Name= "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
                return false;
            if (Object.ReferenceEquals(this, other))
                return true;
            return Name == other.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return "name= " + Name + "\nheader= " + Header + "\nfooter= " + Footer;
        }
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        [Column(Name = "group_name"), NotNull]
        public string Name { get; set; }
        [Column(Name = "group_header"), NotNull]
        public string Header
        { 
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        
        }
        [Column(Name = "group_footer"), NotNull]

        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }

        }
        public static  List <GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

         IEnumerator<GroupData> IEnumerable<GroupData>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
