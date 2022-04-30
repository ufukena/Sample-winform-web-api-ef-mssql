using System;
using System.Windows.Forms;
using ContactList.Infrastructure.Win.Repository;

namespace ContactList.Win
{
    public partial class ContactListForm : Form
    {
        private IContactRepository _contactRepository;
        private int? _itemId = null;

        public ContactListForm()
        {
            _contactRepository = new ContactRepository();

            InitializeComponent();
        }

        private void ContactListForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteData();
        }       

        private void UpdateButton_Click(object sender, EventArgs e)
        {

            UpdateData();

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm(this);
            contactForm.ShowDialog();
        }


        public async void LoadData()
        {
            this.ContactListDataGridView.SelectionChanged -= new System.EventHandler(this.ContactListDataGridView_SelectionChanged);

            _itemId = null;
            var contactlist = await _contactRepository.Get();
            ContactListDataGridView.BindingContext = new BindingContext();
            ContactListDataGridView.DataSource = contactlist;
            this.ContactListDataGridView.ClearSelection();

            this.ContactListDataGridView.SelectionChanged += new System.EventHandler(this.ContactListDataGridView_SelectionChanged);
            
        }

        public async void UpdateData()
        {
            if (_itemId == null) {
                MessageBox.Show("Select Item"); return;
            }

            var contact = await _contactRepository.Get((int)_itemId);

            ContactForm contactForm = new ContactForm(this,contact);
            contactForm.ShowDialog();

        }

        private async void DeleteData()
        {
            if (_itemId == null)
            {
                MessageBox.Show("Select Item"); return;
            }

            DialogResult result = MessageBox.Show("Do You Want to Delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                await _contactRepository.Delete((int)_itemId);

                LoadData();
            }
           
        }


        private void ContactListDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ContactListDataGridView.SelectedRows.Count > 0)
            {
                int selectedrowindex = ContactListDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = ContactListDataGridView.Rows[selectedrowindex];

                _itemId = Convert.ToInt16(selectedRow.Cells["Id"].Value);
                

            }
        }


    }


}
