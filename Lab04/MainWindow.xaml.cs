using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Lab04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Person> users;

        public MainWindow()
        {
            InitializeComponent();

            users = new List<Person>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            if(File.Exists("Users.bin"))
            {
                Stream readStream = new FileStream("Users.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                users = (List<Person>)serializer.Deserialize(readStream);
                readStream.Close();
            }
            else
            {
                createUsers();
            }

            Stream writeStream = new FileStream("Users.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            serializer.Serialize(writeStream, users);
            dataGrid.ItemsSource = users;
            writeStream.Close();
        }

        private void AddPerson_Click(object Sender, EventArgs e)
        {
            NewPerson newPerson = new NewPerson();
            newPerson.ShowDialog();
            if (newPerson.person == null)
            {
                return;
            }
            users.Add(newPerson.person);
            dataGrid.Items.Refresh();
        }

        private void RemovePerson_Click(object Sender, EventArgs e)
        {
            if(dataGrid.SelectedItem != null)
            {
                users.Remove((Person)dataGrid.SelectedItem);
                dataGrid.Items.Refresh();
            }
        }

        private void EditPerson_Click(object Sender, EventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                NewPerson newPerson = new NewPerson((Person)dataGrid.SelectedItem);
                newPerson.ShowDialog();
                if(newPerson.person == null)
                {
                    return;
                }
                ((Person)dataGrid.SelectedItem).FirstName = newPerson.person.FirstName;
                ((Person)dataGrid.SelectedItem).LastName = newPerson.person.LastName;
                ((Person)dataGrid.SelectedItem).Email = newPerson.person.Email;
                ((Person)dataGrid.SelectedItem).Birthday = newPerson.person.Birthday;
                dataGrid.Items.Refresh();
            }
        }

        private void createUsers()
        {
            users.Add(new Person("John", "Doe", "john_doe@gmail.com", new DateTime(1971, 7, 31)));
            users.Add(new Person("Saul", "Smith", "ssmith@ukr.net", new DateTime(2006, 1, 30)));
            users.Add(new Person("Jake", "Williams", "jakew1985@gmail.com", new DateTime(1985, 5, 5)));
            users.Add(new Person("Ash", "Brown", "sefdghawdd15@gmail.com", new DateTime(1997, 8, 15)));
            users.Add(new Person("Mike", "Jones", "edplayer@outlook.com", new DateTime(1986, 11, 20)));
            users.Add(new Person("Adam", "Garcia", "cassunclescrooge@optonline.net", new DateTime(1975, 12, 1)));
            users.Add(new Person("William", "Miller", "trishstalker@yahoo.com", new DateTime(2003, 5, 6)));
            users.Add(new Person("Liam", "Davis", "reggieserious@icloud.com", new DateTime(1986, 7, 9)));
            users.Add(new Person("Noah", "Rodriguez", "selfconsciousmollie@sbcglobal.net", new DateTime(1969, 8, 30)));
            users.Add(new Person("Oliver", "Miller", "helplessdougie@me.com", new DateTime(1975, 3, 29)));
            users.Add(new Person("James", "Davis", "contempthuey@verizon.net", new DateTime(2002, 1, 13)));
            users.Add(new Person("Lucas", "Rodriguez", "contempthuey@verizon.net", new DateTime(2007, 9, 15)));
            users.Add(new Person("Henry", "Martinez", "overthrowtall@hotmail.com", new DateTime(1987, 10, 8)));
            users.Add(new Person("Jack", "Hernandez", "intoxicateright@comcast.net", new DateTime(1999, 9, 9)));
            users.Add(new Person("Alexander", "Lopez", "stonehefty@gmail.com", new DateTime(1985, 7, 26)));
            users.Add(new Person("Jackson", "Gonzalez", "copefatal@yahoo.ca", new DateTime(1974, 5, 23)));
            users.Add(new Person("Daneil", "Wilson", "compactbony@me.com", new DateTime(2001, 6, 20)));
            users.Add(new Person("Jacob", "Anderson", "violatebowed@yahoo.com", new DateTime(1969, 2, 10)));
            users.Add(new Person("David", "Thomas", "flourishmealy@yahoo.ca", new DateTime(2004, 4, 11)));
            users.Add(new Person("Joseph", "Taylor", "capsizesizzling@verizon.net", new DateTime(1987, 1, 2)));
            users.Add(new Person("Luke", "Moore", "overestimatedeafening@msn.com", new DateTime(1993, 8, 26)));
            users.Add(new Person("Juan", "Jackson", "quarrelhearty@protonmail.com", new DateTime(2002, 11, 24)));
            users.Add(new Person("Gabriel", "Martin", "photographyellowish@att.net", new DateTime(1987, 5, 3)));
            users.Add(new Person("Emily", "Lee", "growdirect@outlook.com", new DateTime(2000, 12, 8)));
            users.Add(new Person("Violet", "Perez", "accessunaware@outlook.com", new DateTime(1974, 6, 29)));
            users.Add(new Person("Ripley", "Thompson", "matteradmirable@icloud.com", new DateTime(1963, 4, 1)));
            users.Add(new Person("Lucy", "White", "choreographscared@me.com", new DateTime(1999, 3, 3)));
            users.Add(new Person("Delilah", "Harris", "choreographscared@me.com", new DateTime(2005, 12, 25)));
            users.Add(new Person("Alice", "Sanchez", "raisetriangular@me.com", new DateTime(1972, 11, 28)));
            users.Add(new Person("Bella", "Clark", "dustwretched@icloud.com", new DateTime(1983, 7, 9)));
            users.Add(new Person("Skylar", "Ramirez", "growlpurple@me.com", new DateTime(1959, 8, 24)));
            users.Add(new Person("Caroline", "Lewis", "betterevergreen@outlook.com", new DateTime(2005, 6, 11)));
            users.Add(new Person("Coraline", "Robison", "competeterrible@msn.com", new DateTime(1986, 12, 12)));
            users.Add(new Person("Anna", "Walker", "breednatural@comcast.net", new DateTime(1978, 10, 5)));
            users.Add(new Person("Lydia", "Young", "distinguishfickle@optonline.net", new DateTime(1988, 8, 6)));
            users.Add(new Person("Sarah", "Allen", "sidlekooky@comcast.net", new DateTime(2002, 2, 4)));
            users.Add(new Person("Piper", "King", "profittense@protonmail.com", new DateTime(2013, 1, 8)));
            users.Add(new Person("Clara", "Wright", "stealastonishing@protonmail.com", new DateTime(1996, 3, 10)));
            users.Add(new Person("Samantha", "Scott", "impresspleased@comcast.net", new DateTime(1995, 11, 11)));
            users.Add(new Person("Maria", "Torres", "plumpesteemed@outlook.com", new DateTime(1987, 5, 29)));
            users.Add(new Person("Lyla", "Nguyen", "rechargemild@comcast.net", new DateTime(1971, 8, 17)));
            users.Add(new Person("Eliza", "Hill", "humblemysterious@protonmail.com", new DateTime(2004, 9, 16)));
            users.Add(new Person("Melody", "Flores", "instituteultimate@mac.com", new DateTime(1976, 4, 14)));
            users.Add(new Person("Julia", "Green", "evaporateinfamous@me.com", new DateTime(2001, 6, 3)));
            users.Add(new Person("Rose", "Adams", "gagbustling@live.com", new DateTime(1980, 8, 29)));
            users.Add(new Person("Arya", "Nelson", "captaingleeful@hotmail.com", new DateTime(2010, 7, 25)));
            users.Add(new Person("Mary", "Baker", "guardviolent@gmail.com", new DateTime(1982, 2, 28)));
            users.Add(new Person("Kaylee", "Hall", "pitmotionless@me.com", new DateTime(1990, 10, 18)));
            users.Add(new Person("Isabel", "Rivera", "foilbony@optonline.net", new DateTime(1995, 4, 11)));
            users.Add(new Person("Valeria", "Campbell", "smearactual@yahoo.ca", new DateTime(1935, 12, 26)));
        }
    }
}
