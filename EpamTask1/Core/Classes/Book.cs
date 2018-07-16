﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask1.Core.Interfaces;
using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1.Core.Classes
{
    public class Book : IBook
    {
        public string Isbn { get; set; }
        public string[] Authors { get; set; }
        public string PubCity { get; set; }
        public string PubName { get; set; }
        public int PubYear { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int CountPages { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(Book) && Equals((Book) obj);
        }

        protected bool Equals(Book other)
        {
            return string.Equals(Isbn, other.Isbn) && Equals(Authors, other.Authors) && string.Equals(PubCity, other.PubCity) 
                   && string.Equals(PubName, other.PubName) && PubYear.Equals(other.PubYear) 
                   && string.Equals(Name, other.Name) && string.Equals(Note, other.Note) && CountPages == other.CountPages;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Isbn != null ? Isbn.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Authors != null ? Authors.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PubCity != null ? PubCity.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PubName != null ? PubName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PubYear.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Note != null ? Note.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CountPages;
                return hashCode;
            }
        }
    }
}