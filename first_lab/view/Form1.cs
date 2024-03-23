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
                // Если ничего не выбрано, вы можете очистить информацию
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
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
            FlightStatistics.UpdateStatistics(newPlane);

            // Вызываем событие HandleFlightEvent
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
                    // Примените фильтр к вашим данным
                    string destinationFilter = filterForm.Destination;
                    DateTime dateFilter = filterForm.Date;

                    // Ваш код для применения фильтра
                    // Используйте методы интерфейса IFlightInfoProvider для получения отфильтрованных данных
                    var filteredPlanes = airport.GetFlightsByFilter(dateFilter, destinationFilter);

                    // Обновите отображаемые данные
                    ListBoxTickets.DataSource = null;
                    ListBoxTickets.DataSource = filteredPlanes;
                    ListBoxTickets.DisplayMember = "FlightNumber";
                }
                else if (result == DialogResult.Cancel)
                {
                    // Отмена фильтрации: загрузить все самолеты без фильтрации
                    ListBoxTickets.DataSource = null;
                    ListBoxTickets.DataSource = airport.Planes;
                    ListBoxTickets.DisplayMember = "FlightNumber";
                }
            }
        }
        private void buttonFindIndex_Click(object sender, EventArgs e)
        {
            // Проверяем, введен ли индекс
            if (int.TryParse(textBoxFindIndex.Text, out int flightNumber))
            {
                // Используем индексатор для поиска по серийному номеру
                Plane foundPlane = airport[flightNumber];

                // Проверяем, найден ли самолет
                if (foundPlane != null)
                {
                    // Выводим информацию о полете в RichTextBox
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
                // Получаем выбранный объект
                Plane planeToRemove = (Plane)ListBoxTickets.SelectedItem;

                // Удаляем объект из списка объектов проекта
                airport.Planes.Remove(planeToRemove);

                // Обновляем список в ListBox
                ListBoxTickets.DataSource = null;
                ListBoxTickets.DataSource = airport.Planes;
                ListBoxTickets.DisplayMember = "FlightNumber";
            }
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            // Удаляем все элементы из списка объектов проекта
            airport.Planes.Clear();

            // Убираем привязку источника данных
            ListBoxTickets.DataSource = null;

            // Очищаем ListBox
            ListBoxTickets.Items.Clear();
            presenter.ClearFile();
        }

    }

}