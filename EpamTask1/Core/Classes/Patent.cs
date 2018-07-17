﻿using System;
using EpamTask1.Core.Interfaces;

namespace EpamTask1.Core.Classes
{
    public class Patent : IPatent
    {
        public int RegNumber { get; set; }
        public string Country { get; set; }
        public string[] Inventors { get; set; }
        public DateTime AppDate { get; set; }
        public DateTime PubDate { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int CountPages { get; set; }
        public int PubYear { get; set; }
        public int Price { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Patent) obj);
        }

        protected bool Equals(Patent other)
        {
            return RegNumber == other.RegNumber && string.Equals(Country, other.Country) && Equals(Inventors, other.Inventors) 
                   && AppDate.Equals(other.AppDate) && PubDate.Equals(other.PubDate) && string.Equals(Name, other.Name) && string.Equals(Note, other.Note) && CountPages == other.CountPages;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = RegNumber;
                hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Inventors != null ? Inventors.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ AppDate.GetHashCode();
                hashCode = (hashCode * 397) ^ PubDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Note != null ? Note.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CountPages;
                return hashCode;
            }
        }
    }
}
