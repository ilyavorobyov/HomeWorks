using System;
using System.Data;
using System.IO;
using System.Reflection;

namespace RefactoringNapilnik
{
    public class Model
    {
        private void OnCheckButtonClick(object sender, EventArgs e)
        {
            string necessaryInformation = "Введите серию и номер паспорта";
            string invalidPassportInfo = "Неверный формат серии или номера паспорта";

            if (this.passportTextbox.Text.Trim() == "")
            {
                MessageBox.Show(necessaryInformation);
            }
            else
            {
                string fileNotFoundError = "Файл db.sqlite не найден. Положите файл в папку вместе с exe.";
                string rawData = this.passportTextbox.Text.Trim().Replace(" ", string.Empty);

                if (rawData.Length < 10)
                {
                    this.textResult.Text = invalidPassportInfo;
                }
                else
                {
                    string commandText = string.Format("select * from passports where num='{0}' " +
                        "limit 1;", (object)Form1.ComputeSha256Hash(rawData));
                    string connectionString = string.Format("Data Source=" +
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\db.sqlite");

                    try
                    {
                        TryConnect(commandText, connectionString);
                    }
                    catch (SQLiteException ex)
                    {
                        if (ex.ErrorCode != 1)
                            return;

                        MessageBox.Show(fileNotFoundError);
                    }
                }
            }
        }

        private void TryConnect(string commandText, string connectionString)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter(
                new SQLiteCommand(commandText, connection));
            DataTable dataTable1 = new DataTable();
            DataTable dataTable2 = dataTable1;
            sqLiteDataAdapter.Fill(dataTable2);

            if (dataTable1.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dataTable1.Rows[0].ItemArray[1]))
                    this.textResult.Text = "По паспорту «" + this.passportTextbox.Text +
                        "» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
                else
                    this.textResult.Text = "По паспорту «" + this.passportTextbox.Text +
                        "» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";
            }
            else
            {
                this.textResult.Text = "Паспорт «" + this.passportTextbox.Text +
                    "» в списке участников дистанционного голосования НЕ НАЙДЕН";
                connection.Close();
            }
        }
    }

    public class  View
    {
        
    }

    public class Controller 
    {
        private Model _model;
        private View _view;

        public Controller(Model model, View view)
        {
            _model = model;
            _view = view;
        }
    
    }
}