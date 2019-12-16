using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Db_ADO_Net
{
    class Provider
    {
        public int Energy_provider_Id { get; set; }
        public String Company_name { get; set; }
        public int Number_of_staff { get; set; }
        public decimal Payroll { get; set; }
        public int Tax_free_id { get; set; }

        static SqlConnection connection;

        public Provider() {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание обьекта подключения
            connection = new SqlConnection(connString);
        }

        static Provider()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание обьекта подключения
            connection = new SqlConnection(connString);
        }
        // Переопределение метода ToString() 
        public override string ToString()
        {
            return string.Format("Energy provider Id = {0} - Company name: {1} - Number of satff: {2} - Payroll: {3} - Taxx free id: {4}",
                Energy_provider_Id, Company_name, Number_of_staff, Payroll, Tax_free_id );
        }
        // Полученик списка всех поставщиков
        public static IEnumerable<Provider> GetAllProviders() {
            var commandString = "SELECT Energy_provider_Id, Company_name, Number_of_staff, Payroll, Tax_free_id FROM Providers";
            SqlCommand GetAllCommand = new SqlCommand(commandString, connection);
            connection.Open();
            var reader = GetAllCommand.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    var energy_provider_id = reader.GetInt32(0);
                    var company_name = reader.GetString(1);
                    var number_of_staff = reader.GetInt32(2);
                    var payroll = reader.GetSqlDecimal(3);
                    object tax_free_id_obj;
                    int tax_free_id;
                    if (reader.IsDBNull(4))
                    {
                        tax_free_id = 0;
                    }
                    else {
                        tax_free_id_obj = reader.GetValue(4);
                        tax_free_id = Convert.ToInt32(tax_free_id_obj);
                    }

                    var provider = new Provider()
                    {
                        Energy_provider_Id = energy_provider_id,
                        Company_name = company_name,
                        Number_of_staff = number_of_staff,
                        Payroll = (decimal)payroll,
                        Tax_free_id = tax_free_id 
                    };
                    yield return provider;
                }
            }
            connection.Close();
        }

        // Новая запись в БД
        public void Insert() {
            var commandString = "INSERT INTO Providers (Company_name, Number_of_staff, Payroll, Tax_free_id)"
                + "VALUES (@company_name, @number_of_staff, @payroll, @tax_free_id)";
            SqlCommand insertCommand = new SqlCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("company_name", Company_name),
                    new SqlParameter("number_of_staff", Number_of_staff),
                    new SqlParameter("payroll", Payroll),
                    new SqlParameter("tax_free_id", Tax_free_id)
                });
            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        // Получение записи с заданным ID
        public static Provider GetProvider(int id) {
            foreach (var provider in GetAllProviders()) {
                if (provider.Energy_provider_Id == id)
                    return provider;
            }
            return null;
        }

        // Изменение текущей записи в БД
        public void Update() {
            var commandString = "UPDATE Providers SET Company_name=@company_name, Number_of_staff=@number_of_staff, Payroll=@payroll, Tax_free_id=@tfid WHERE(Energy_provider_Id=@id)";
            SqlCommand updateCommand = new SqlCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("company_name", Company_name),
                    new SqlParameter("number_of_staff", Number_of_staff),
                    new SqlParameter("payroll",Payroll),
                    new SqlParameter("tfid", Tax_free_id),
                    new SqlParameter("id", Energy_provider_Id),
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        // Удаление записи из БД
        public static void Delete(int id) {
            var commandString = "DELETE FROM Providers WHERE(Energy_provider_Id=@id)";
            SqlCommand deleteCommand = new SqlCommand(commandString, connection);
            deleteCommand.Parameters.AddWithValue("id", id);
            connection.Open();
            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
