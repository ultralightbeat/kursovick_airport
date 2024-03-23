using Microsoft.VisualBasic.ApplicationServices;
using first_lab.model;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Text;
using first_lab.presenter;
using first_lab.view;
using first_lab.model;


namespace first_lab
{
    public partial class Form1 : Form, IFormView
    {
        private Airport airport;
        private MainPresenter presenter;
        private FontSelect formselector;
        public Form1()
        {
            InitializeComponent();
            presenter = new MainPresenter(this);
            formselector = new FontSelect();
            airport = new Airport(4328);
            this.Load += MainForm_Load;
            this.Text = "Airport Terminal";
            this.textBoxPrice.Text = 300.ToString();
            dateTimePickerFly.Value = DateTime.Today;
            buttonFilter.Text = "Add\nFilter";
            panel1.BackColor = Background.BackColor;

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (airport != null)
            {
                ListBoxTickets.DataSource = airport.Planes;
                comboBoxCompanies.DataSource = Enum.GetNames(typeof(PlaneCompany));
                comboBoxPlane.DataSource = Enum.GetNames(typeof(PlaneType));
                textBoxDest.DataBindings.Add(new Binding("Text", airport.Planes, "Destination"));
                comboBoxCompanies.DataBindings.Add(new Binding("SelectedItem", airport.Planes, "Comp"));
                comboBoxPlane.DataBindings.Add(new Binding("SelectedItem", airport.Planes, "Type"));
                dateTimePickerFly.DataBindings.Add(new Binding("Value", airport.Planes, "FlyDate"));
            }
            var airplains = presenter.LoadPlanesFromFile(airport);
            ListBoxTickets.DataSource = null;
            ListBoxTickets.DataSource = airplains;
            ListBoxTickets.DisplayMember = "FlightNumber";
        }

        private void HandleFlightEvent(object sender, FlightEventArgs e)
        {
            MessageBox.Show($"Static event - successful: Flight number added {e.FlightPlane.FlightNumber}.");
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxTickets.SelectedItem != null)
            {
                Plane selectedPlane = (Plane)ListBoxTickets.SelectedItem;

                richTextBoxWelcome.Text = selectedPlane.ToString();

                if (selectedPlane != null && !string.IsNullOrEmpty(selectedPlane.foto))
                {
                    pictureBox1.Image = presenter.GetImage(selectedPlane);
                }
            }
            else
            {
                // ���� ������ �� �������, �� ������ �������� ����������
                richTextBoxWelcome.Text = string.Empty;
            }
        }
        private void buttonAddToList_Click(object sender, EventArgs e)
        {
            Plane newPlane = presenter.GenerateObject(textBoxDest.Text, comboBoxCompanies.SelectedItem, comboBoxPlane.SelectedItem, textBoxPrice.Text, dateTimePickerFly.Value);

            airport.Planes.Add(newPlane);
            ListBoxTickets.DataSource = null;
            ListBoxTickets.DataSource = airport.Planes;
            ListBoxTickets.DisplayMember = "FlightNumber";
            try
            {
                pictureBox1.Image = presenter.SaveImage(newPlane);
            }
            catch (Exception ex)
            {
                MessageBox.Show("��������� ������: " + ex.Message);
            }
            FlightStatistics.UpdateStatistics(newPlane);

            // �������� ������� HandleFlightEvent
            HandleFlightEvent(null, new FlightEventArgs(newPlane));

            presenter.WriteToFile(newPlane);

        }
        private void buttonFont_Click(object sender, EventArgs e)
        {
            richTextBoxWelcome.Font = formselector.SelectFont(); 
        }

        private void buttonStatistic_Click(object sender, EventArgs e)
        {
            richTextBoxWelcome.Clear();
            richTextBoxWelcome.Text = FlightStatistics.DisplayStatistics();
        }
        private void buttonFilter_Click_1(object sender, EventArgs e)
        {
            using (Form2 filterForm = new Form2())
            {
                DialogResult result = filterForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // ��������� ������ � ����� ������
                    string destinationFilter = filterForm.Destination;
                    DateTime dateFilter = filterForm.Date;

                    // ��� ��� ��� ���������� �������
                    // ����������� ������ ���������� IFlightInfoProvider ��� ��������� ��������������� ������
                    var filteredPlanes = airport.GetFlightsByFilter(dateFilter, destinationFilter);

                    // �������� ������������ ������
                    ListBoxTickets.DataSource = null;
                    ListBoxTickets.DataSource = filteredPlanes;
                    ListBoxTickets.DisplayMember = "FlightNumber";
                }
                else if (result == DialogResult.Cancel)
                {
                    // ������ ����������: ��������� ��� �������� ��� ����������
                    ListBoxTickets.DataSource = null;
                    ListBoxTickets.DataSource = airport.Planes;
                    ListBoxTickets.DisplayMember = "FlightNumber";
                }
            }
        }
        private void buttonFindIndex_Click(object sender, EventArgs e)
        {
            // ���������, ������ �� ������
            if (int.TryParse(textBoxFindIndex.Text, out int flightNumber))
            {
                // ���������� ���������� ��� ������ �� ��������� ������
                Plane foundPlane = airport[flightNumber];

                // ���������, ������ �� �������
                if (foundPlane != null)
                {
                    // ������� ���������� � ������ � RichTextBox
                    richTextBoxWelcome.Text = $"{foundPlane.ToString()}";
                }
                else
                {
                    richTextBoxWelcome.Text = $"Flight with serial number {flightNumber} not found.";
                }
            }
            else
            {
                richTextBoxWelcome.Text = "Please enter a valid flight number.";
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (ListBoxTickets.SelectedItem != null)
            {
                // �������� ��������� ������
                Plane planeToRemove = (Plane)ListBoxTickets.SelectedItem;

                // ������� ������ �� ������ �������� �������
                airport.Planes.Remove(planeToRemove);

                // ��������� ������ � ListBox
                ListBoxTickets.DataSource = null;
                ListBoxTickets.DataSource = airport.Planes;
                ListBoxTickets.DisplayMember = "FlightNumber";
            }
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            // ������� ��� �������� �� ������ �������� �������
            airport.Planes.Clear();

            // ������� �������� ��������� ������
            ListBoxTickets.DataSource = null;

            // ������� ListBox
            ListBoxTickets.Items.Clear();
            presenter.ClearFile();
        }

    }

}