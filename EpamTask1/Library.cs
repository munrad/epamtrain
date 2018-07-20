﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EpamTask1.Core;
using EpamTask1.Core.Classes;
using EpamTask1.Core.Extensions;
using EpamTask1.Core.Interfaces;
using EpamTask1.Core.Interfaces.Catalog;

namespace EpamTask1
{
    public class Library
    {
        private readonly Catalog catalog;
        public int PubYear { get; set; }

        public Library()
        {
            catalog = new Catalog();
        }

        public void Add(ICatalogObject obj, bool isForce = true)
        {
            catalog.Add(obj, isForce);
        }

        public IList<ICatalogObject> GetAllObjects()
        {
            return catalog.GetAllObjects();
        }

        public void Remove(ICatalogObject obj)
        {
            catalog.Remove(obj);
        }

        public IList<ICatalogObject> SearchByName(string name)
        {
            return catalog.SearchByName(name);
        }

        public IList<ICatalogObject> SortByYear(bool isReverse)
        {
            return catalog.SortByYear(isReverse);
        }

        public IList<IBook> SearchBooksByAuthors(string name)
        {
            return catalog.SearchBooksByAuthors(name);
        }

        public IDictionary<string, IList<IBook>> GetSortBooks(string symb)
        {
            return catalog.GetSortBooks(symb);
        }

        public IDictionary<int, IList<ICatalogObject>> GroupByYear()
        {
            return catalog.GroupByYear();
        }

        public IList<ICatalogObject> Search(object obj, Func<List<ICatalogObject>, List<ICatalogObject>> func)
        {
            return catalog.Search(obj, func);
        }

        public IList<ICatalogObject> Sort(Action<List<ICatalogObject>> func)
        {
            return catalog.Sort(func);
        }

        public void Save(string objectName)
        {
            var list = new List<string>();
            if (!(GetAllObjects() is List<ICatalogObject> catalogLocal))
            {
                throw new Exception("Каталог пуст!");
            }
            foreach (var catItem in catalogLocal)
            {
                switch (catItem)
                {
                    case IPaper paper:
                        Extensions.Serializer(list, paper as Paper);
                        break;
                    case IBook book:
                        Extensions.Serializer(list, book as Book);
                        break;
                    case IPatent patent:
                        Extensions.Serializer(list, patent as Patent);
                        break;
                }
            }

            File.WriteAllLines(objectName, list);
        }

        public void Load(string objectName, bool isForce = false)
        {
            var obj = File.ReadAllLines(objectName).ToList();
            Extensions.Deserialize(ref catalog.CatalogObjects, obj, isForce);
        }
    }
}
