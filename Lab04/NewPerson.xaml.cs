using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Lab04
{
    /// <summary>
    /// Interaction logic for NewPerson.xaml
    /// </summary>
    public partial class NewPerson : Window
    {
        public Person person;
        
        public NewPerson()
        {
            InitializeComponent();
        }

        public NewPerson(Person person)
        {
            InitializeComponent();
            firstName.Text = person.FirstName;
            lastName.Text = person.LastName;
            email.Text = person.Email;
            datePicker.SelectedDate = person.Birthday;
        }


        private void Proceed_Click(object Sender, EventArgs e)
        {
            if (!Person.IsDateCorrect((DateTime)datePicker.SelectedDate))
            {
                MessageBox.Show("Date is incorrect");
                return;
            }
            person = new Person(firstName.Text, lastName.Text, email.Text, (DateTime)datePicker.SelectedDate);
            Hide();
        }

        private void DatePicker_DateChanged(object Sender, SelectionChangedEventArgs e)
        {
            changeButtonState();
        }

        private void TextChanged(object Sender, EventArgs e)
        {
            changeButtonState();
        }

        private void changeButtonState()
        {
            if (firstName.Text.Length != 0 && lastName.Text.Length != 0 && email.Text.Length != 0 && datePicker.SelectedDate.HasValue)
            {
                proceed.IsEnabled = true;
            }
            else
            {
                proceed.IsEnabled = false;
            }
        }
    }
}

