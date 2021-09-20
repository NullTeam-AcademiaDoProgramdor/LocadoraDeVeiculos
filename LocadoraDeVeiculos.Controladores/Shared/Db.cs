using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LocadoraDeVeiculos.Controladores.Shared
{
    public delegate T ConverterDelegate<T>(IDataReader reader);

    public static class Db
    {

        private static readonly string bancoDeDados;
        private static readonly string connectionString = "";
        private static readonly string nomeProvider;
        private static readonly DbProviderFactory fabricaProvedor;
        private static readonly IConfiguration configuration;

        static Db()
        {
            configuration = InitConfiguration();
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

            //bancoDeDados = ConfigurationManager.AppSettings["bancoDeDados"];
            bancoDeDados = configuration.GetSection("bancoDeDados").Value;

            //connectionString = ConfigurationManager.ConnectionStrings[bancoDeDados].ConnectionString;

            connectionString = configuration.GetConnectionString(bancoDeDados);
            nomeProvider = configuration.GetSection("SQLProvider").Value;

            fabricaProvedor = DbProviderFactories.GetFactory(nomeProvider);
        }

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();
            return config;
        }


        public static int Insert(string sql, Dictionary<string, object> parameters)
        {
            using (IDbConnection connection = fabricaProvedor.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (IDbCommand command = fabricaProvedor.CreateCommand())
                {
                    command.CommandText = sql.AppendSelectIdentity();
                    command.Connection = connection;
                    command.SetParameters(parameters);

                    connection.Open();

                    int id = Convert.ToInt32(command.ExecuteScalar());

                    return id;
                }
            }
        }

        public static void Update(string sql, Dictionary<string, object> parameters = null)
        {
            using (IDbConnection connection = fabricaProvedor.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (IDbCommand command = fabricaProvedor.CreateCommand())
                {
                    command.CommandText = sql;

                    command.Connection = connection;

                    command.SetParameters(parameters);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(string sql, Dictionary<string, object> parameters)
        {
            Update(sql, parameters);
        }

        public static List<T> GetAll<T>(string sql, ConverterDelegate<T> convert, Dictionary<string, object> parameters = null)
        {
            using (IDbConnection connection = fabricaProvedor.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (IDbCommand command = fabricaProvedor.CreateCommand())
                {
                    command.CommandText = sql;

                    command.Connection = connection;

                    command.SetParameters(parameters);

                    connection.Open();

                    var list = new List<T>();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = convert(reader);
                            list.Add(obj);
                        }

                        return list;
                    }
                }
            }
        }

        public static T Get<T>(string sql, ConverterDelegate<T> convert, Dictionary<string, object> parameters)
        {
            using (IDbConnection connection = fabricaProvedor.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (IDbCommand command = fabricaProvedor.CreateCommand())
                {
                    command.CommandText = sql;

                    command.Connection = connection;

                    command.SetParameters(parameters);

                    connection.Open();

                    T t = default;

                    using (IDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                            t = convert(reader);

                        return t;
                    }
                }
            }
        }

        public static bool Exists(string sql, Dictionary<string, object> parameters)
        {
            using (IDbConnection connection = fabricaProvedor.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (IDbCommand command = fabricaProvedor.CreateCommand())
                {
                    command.CommandText = sql;

                    command.Connection = connection;

                    command.SetParameters(parameters);

                    connection.Open();

                    int numberRows = Convert.ToInt32(command.ExecuteScalar());

                    return numberRows > 0;
                }
            }
        }

        private static void SetParameters(this IDbCommand command, Dictionary<string, object> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return;

            foreach (var parameter in parameters)
            {
                string name = parameter.Key;

                object value = parameter.Value.IsNullOrEmpty() ? DBNull.Value : parameter.Value;

                IDataParameter dbParameter = command.CreateParameter();

                dbParameter.ParameterName = name;
                dbParameter.Value = value;

                command.Parameters.Add(dbParameter);
            }
        }

        private static string AppendSelectIdentity(this string sql)
        {
            switch (nomeProvider)
            {
                case "System.Data.SqlClient": return sql + ";SELECT SCOPE_IDENTITY()";

                default: return sql;
            }
        }

        public static bool IsNullOrEmpty(this object value)
        {
            return (value is string && string.IsNullOrEmpty((string)value)) ||
                    value == null;
        }

    }
}