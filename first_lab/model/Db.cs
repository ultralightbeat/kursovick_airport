using System;
using System.Collections.Generic;
using System.IO; 
using System.Windows.Forms; 


namespace first_lab.model
{
    public class Db
    {
        public List<Plane> LoadPlanesFromFile(Airport airport)
        {
            string filePath = "C:\\Users\\Kolya\\Desktop\\уни\\2 sem\\programming\\MyClassLibrary\\MyClassLibrary\\files\\id_data.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    airport.Planes.Clear();
                    FlightStatistics.ClearStatistics();
                    foreach (string line in File.ReadLines(filePath))
                    {
                        Plane plane = Plane.Deserialize(line);
                        if (plane != null)
                        {
                            airport.Planes.Add(plane);
                            FlightStatistics.UpdateStatistics(plane);
                        }
                    }
                    return airport.Planes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Возвращаем значение в случае успешной загрузки или в случае обработки исключения
            return airport.Planes;
        }
        public void WriteToFile(Plane plane)
        {
            using (StreamWriter write = new StreamWriter("C:\\Users\\Kolya\\Desktop\\уни\\2 sem\\programming\\MyClassLibrary\\MyClassLibrary\\files\\id_data.txt", true))
            {
                write.Write(plane.FlightNumber);
                write.Write("|");
                write.Write(plane.Destination);
                write.Write("|");
                write.Write(plane.Comp);
                write.Write("|");
                write.Write(plane.Type);
                write.Write("|");
                write.Write(plane.FlyDate);
                write.Write("|");
                write.Write(plane.foto);
                write.Write("|");
                write.Write(plane.Price);
                write.WriteLine();
                write.Close();
            }
        }
        public Image GetImage(Plane selectedPlane)
        {
            return Image.FromFile(selectedPlane.foto);
        }
        public Image SaveImage(Plane newPlane)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Изображения (*.jpg)|*.jpg|Все файлы (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    newPlane.foto = filePath;
                    return Image.FromFile(filePath);

                }
                else
                {
                    return null;
                }
            }
        }
    }
}
