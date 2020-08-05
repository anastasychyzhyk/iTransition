using System;
using System.IO;
using System.Linq;

namespace generator
{
    struct PersonLocaleSettings
    {
        public int postCode;
        public string street, house, room, telephoneCode, country;
        public bool Load(string locale)
        {
            string[] localeSettings = File.ReadAllLines("base\\localeSettings.txt");
            for (int i = 0; i < localeSettings.Count(); i++)
            {
                string[] localeSetting = localeSettings[i].Split(';');
                if (localeSetting[0] == locale)
                {
                    country = localeSetting[1];
                    if (!int.TryParse(localeSetting[2], out postCode))
                    {
                        postCode = 0;
                    }
                    house = localeSetting[3];
                    room = localeSetting[4];
                    street = localeSetting[5];
                    telephoneCode = localeSetting[6];
                    return true;
                }
            }
            return false;
        }
    }
}
