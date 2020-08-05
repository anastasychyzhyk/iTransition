using System.IO;
using System;

namespace generator
{
    struct BaseForGeneration
    {
        public String[] names, surnames, patronymics, cities, streets;
        public void Load(string locale)
        {
            if (File.Exists("base\\name_" + locale + ".txt"))
            {
                names = File.ReadAllLines("base\\name_" + locale + ".txt");
            }
            if (File.Exists("base\\fam_" + locale + ".txt"))
            {
                surnames = File.ReadAllLines("base\\fam_" + locale + ".txt");
            }
            if (File.Exists("base\\otch_" + locale + ".txt"))
            {
                patronymics = File.ReadAllLines("base\\otch_" + locale + ".txt");
            }
            if (File.Exists("base\\city_" + locale + ".txt"))
            {
                cities = File.ReadAllLines("base\\city_" + locale + ".txt");
            }
            if (File.Exists("base\\street_" + locale + ".txt"))
            {
                streets = File.ReadAllLines("base\\street_" + locale + ".txt");
            }
        }
    }
}
