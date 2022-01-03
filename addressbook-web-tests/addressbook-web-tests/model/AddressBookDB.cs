using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using MySql.Data.MySqlClient;

namespace addressbook_web_tests.model
{
    public class AddressBookDB: LinqToDB.Data.DataConnection
    {   
        public AddressBookDB(): base("AddressBook") { }

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }
        public ITable<ContactCreationData> Contacts { get { return GetTable<ContactCreationData>(); } }
    }
}
