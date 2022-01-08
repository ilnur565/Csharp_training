using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name = "address_in_groups")]
    public class GroupContactRelation
    {
        [Column(Name = "group_id")]
        public string GroupId { get; set; }

        [Column(Name = "id")]
        public string  ContactId { get; set; }

        public List<GroupContactRelation> GetGroupContactRelation()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from gcr in db.GCR
                        select gcr).ToList();
            }
        }
    }

    
}
