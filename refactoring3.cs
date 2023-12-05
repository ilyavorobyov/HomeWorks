using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows;

namespace RefactoringNapilnik2
{
    public class Model
    {
        public DataTable DataTable1 { get; private set; }

        private string _connectionString;

        public void OnCheckButtonClick(string commandText, int numberOfException)
        {
            _connectionString = string.Format("Data Source=" + Path.GetDirectoryName
                (Assembly.GetExecutingAssembly().Location) + "\\db.sqlite");

            try
            {
                Connect(commandText);
            }
            catch (SQLiteException ex)
            {
                if (ex.ErrorCode != 1)
                    return;
                int num2 = numberOfException;
            }
        }

        public void Connect(string commandText)
        {
            SQLiteConnection connection = new SQLiteConnection(_connectionString);
            connection.Open();
            SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter
                (new SQLiteCommand(commandText, connection));
            DataTable1 = new DataTable();
            sqLiteDataAdapter.Fill(DataTable1);
            connection.Close();
        }
    }

    public class Controller
    {
        private Model _model = new Model();
        private View _view = new View();

        public void Begin()
        {
            _view.SetDataTable(_model.DataTable1);
            _model.OnCheckButtonClick(_view.CommandText, _view.GetNumberOfExceprion());
        }
    }

    public class View
    {
        private const string NecessaryInformation = "Введите серию и номер паспорта";
        private const string InvalidPassportInfo = "Неверный формат серии или номера паспорта";
        private const string FileNotFoundError = "Файл db.sqlite не найден. Положите файл в папку вместе с exe.";
        private const string AccessGrantedText = "ПРЕДОСТАВЛЕН";
        private const string AccessNotGrantedText = "НЕ ПРЕДОСТАВЛЕН";

        private DataTable _dataTable1;
        private string _rawData;
        private string _passportTextbox;

        public string CommandText { get; private set; }

        public void SetDataTable(DataTable dataTable)
        {
            _dataTable1 = dataTable;
        }

        public int GetNumberOfExceprion()
        {
            int num2 = (int)MessageBox.Show(FileNotFoundError);
            return num2;
        }

        private void ShowForm(object sender, EventArgs e)
        {
            int passportInfoLength = 10;

            if (this._passportTextbox.Text.Trim() == String.IsNullOrWhiteSpace)
            {
                int num1 = (int)MessageBox.Show(NecessaryInformation);
            }
            else
            {
                _rawData = this.passportTextbox.Text.Trim().Replace(" ", string.Empty);

                if (_rawData.Length < passportInfoLength)
                {
                    this.textResult.Text = InvalidPassportInfo;
                }
                else
                {
                    CommandText = string.Format("select * from passports where num='{0}' " +
                        "limit 1;", (object)Form1.ComputeSha256Hash(_rawData));

                    if (_dataTable1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(_dataTable1.Rows[0].ItemArray[1]))
                            this.textResult.Text = AccessToVoiting(AccessGrantedText, _passportTextbox);
                        else
                            this.textResult.Text = AccessToVoiting(AccessNotGrantedText, _passportTextbox);
                    }
                }
            }
        }

        private string AccessToVoiting(string access, string passportTextbox)
        {
            return $"По паспорту <{passportTextbox.Text}> доступ к бюллетеню на дистанционном " +
                $"электронном голосовании {access}";
        }
    }
}