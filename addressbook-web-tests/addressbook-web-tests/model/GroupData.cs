﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>  // определяем ф-ю сравнения; Класс GroupData наследует IEquatable
    {
        private string name;
        private string header=""; 
        private string footer="";

        public GroupData (string name) //конструктор 
        {
            this.name = name;
        }
     /*   public GroupData(string name, string header, string footer) //конструктор (не применяем так как сложно запомнить порядок если много параметров)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }*/
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if(Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString() { 
        
        return "name = "+ Name;
        }
        public int CompareTo(GroupData other) { 
            if(Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }


        public string Name 
        { 
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        
        }
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


    }
}
