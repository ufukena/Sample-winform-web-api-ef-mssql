using ContactList.Domain.Model;
using ContactList.Infrastructure.Win.Repository;
using System;
using System.Windows.Forms;

namespace ContactList.Win
{
    public partial class ContactForm : Form
    {
        private ContactListForm _contactListForm;
        private IContactRepository _contactRepository;
        private bool _action;
        Contact _contact;

        public ContactForm(ContactListForm contactListForm)
        {
            _contactListForm = contactListForm;
            _contactRepository = new ContactRepository();

            InitializeComponent();

        }

        public ContactForm(ContactListForm contactListForm, Contact contact)
        {
            _contactListForm = contactListForm;
            _contactRepository = new ContactRepository();
            _contact = contact;

            InitializeComponent();

            LoadData();

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {

                #region Controls
                
                if (string.IsNullOrWhiteSpace(NameSurnameTextBox.Text))
                {
                    MessageBox.Show("Name Surname Can Not Be Empty"); return;
                }

                if (string.IsNullOrWhiteSpace(PhoneTextBox.Text))
                {
                    MessageBox.Show("Phone Can Not Be Empty"); return;
                }

                if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
                {
                    MessageBox.Show("Email Can Not Be Empty"); return;
                }

                #endregion


                if (_contact == null)
                {
                    _contact = new Contact
                    {
                        NameSurname = NameSurnameTextBox.Text.Trim(),
                        Phone = PhoneTextBox.Text.Trim(),
                        Email = EmailTextBox.Text.Trim(),
                        Address = AddressTextBox.Text == string.Empty ? null : AddressTextBox.Text.Trim()
                    };

                    _contactRepository.Insert(_contact);
                }
                else
                {
                    _contact.NameSurname = NameSurnameTextBox.Text.Trim();
                    _contact.Phone = PhoneTextBox.Text.Trim();
                    _contact.Email = EmailTextBox.Text.Trim();
                    _contact.Address = AddressTextBox.Text == string.Empty ? null : AddressTextBox.Text.Trim();

                    _contactRepository.Update(_contact);

                }

               

                _action = true;
                Exit();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Exit()
        {
            if (_action) {
                _contactListForm.LoadData();
            }

            this.Close();

        }

        private void LoadData()
        {
            NameSurnameTextBox.Text = _contact.NameSurname;
            PhoneTextBox.Text = _contact.Phone;
            EmailTextBox.Text = _contact.Email;
            AddressTextBox.Text = _contact.Address;
        }


    }
}
