using System;
using System.Linq;

namespace generator
{
    struct Person
    {
        public String surname, name, patronymic, city, street, postCode, house, room, telephone;
        public string this[int id]
        {
            get
            {
                switch (id)
                {
                    case 1:
                        return surname;
                    case 2:
                        return name;
                    case 3:
                        return patronymic;
                    case 4:
                        return city;
                    case 5:
                        return street;
                    case 6:
                        return postCode;
                    case 7:
                        return house;
                    case 8:
                        return room;
                    case 9:
                        return telephone;
                    default: return "";
                }
            }
            set
            {
                switch (id)
                {
                    case 1:
                        surname = value;
                        break;
                    case 2:
                        name = value;
                        break;
                    case 3:
                        patronymic = value;
                        break;
                    case 4:
                        city = value;
                        break;
                    case 5:
                        street = value;
                        break;
                    case 6:
                        postCode = value;
                        break;
                    case 7:
                        house = value;
                        break;
                    case 8:
                        room = value;
                        break;
                    case 9:
                        telephone = value;
                        break;
                    default: break;
                }
            }
        }
        public void Print(PersonLocaleSettings personLocalSettings)
        {
            Console.Write($"{surname} {name}");
            if (patronymic != "")
                Console.Write($" {patronymic}");
            Console.Write($"; {postCode}, {personLocalSettings.country}, {city}, {personLocalSettings.street} {street}, {personLocalSettings.house} {house}, {personLocalSettings.room} {room}; {personLocalSettings.telephoneCode}{telephone}");
        }
        public Person(Random rnd, BaseForGeneration baseForGeneration, PersonLocaleSettings personLocalSettings)
        {
            surname = baseForGeneration.surnames[rnd.Next(0, baseForGeneration.surnames.Count())];
            name = baseForGeneration.names[rnd.Next(0, baseForGeneration.names.Count())];
            if (baseForGeneration.patronymics!=null)
            {
                patronymic = baseForGeneration.patronymics[rnd.Next(0, baseForGeneration.patronymics.Count())];
            }
            else
            {
                patronymic = "";
            }
            city = baseForGeneration.cities[rnd.Next(0, baseForGeneration.cities.Count())];
            street = baseForGeneration.streets[rnd.Next(0, baseForGeneration.streets.Count())];
            house = rnd.Next(1, 50).ToString();
            room = rnd.Next(1, 108).ToString();
            telephone = rnd.Next(1000001, 9999999).ToString();
            postCode = rnd.Next(personLocalSettings.postCode, personLocalSettings.postCode * 10 - 1).ToString();
        }
    }
}
