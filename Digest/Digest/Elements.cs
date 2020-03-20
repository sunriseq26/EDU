//Кустарников Иван

// Программа собирает коллекцию фильмов, при желании можно отсортировать по жанрам

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Digest
{
    public class Element
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public string Genre { get; set; }
        public string Date { get; set; }

        private int year;
        public string Year
        {
            get
            {
                return year.ToString();
            }
            set
            {
                int.TryParse(value, out year);
            }
        }
    }
    public class Elements
    {
        List<Element> list;
        List<Element> listFilter;

        int index;

        public int CurrentNumber
        {
            get { return index; }
        }

        public int ListCurrentNumber
        {
            get { return index; }
        }

        public string[] ListGenre
        {
            get 
            {
                string[] s = new string[] { "Драма", "Фантастика" };
                return s;
            }
        }

        public void Next()
        {
            if (list.Count > index + 1) index++;

        }

        public void Prev()
        {
            if (index > 0) index--;

        }

        public void Add(Element element)
        {
            list.Add(element);
            index = list.Count - 1;//??
        }

        public void AddFilter(Element element)
        {
            listFilter.Add(element);
            index = listFilter.Count - 1;//??
        }

        public void Filter(string genre, Elements filter)
        {
            Load("database.XML");
            foreach (Element element in list)
            {
                if (element.Genre == genre)
                    filter.AddFilter(element);
                if (element.Genre != genre)
                    listFilter.Remove(element);
            }
        }

        public Elements()
        {
            list = new List<Element>();
            listFilter = new List<Element>();
            index = -1;
        }

        public Element CurrentElement
        {
            get
            {
                try
                {
                    return list[index];
                }
                catch
                {
                    return null;
                }
            }
        }

        public Element ListCurrentElement
        {
            get
            {
                try
                {
                    return listFilter[index];
                }
                catch
                {
                    return null;
                }
            }
        }

        public void Save(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Element>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
            index = 0;
        }

        public void Load(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Element>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Element>)xmlFormat.Deserialize(fStream);
            fStream.Close();
            index = 0;
        }
    }
}
