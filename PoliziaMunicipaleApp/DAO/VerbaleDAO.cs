﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.DAO
{
    public class VerbaleDAO
    {
        private readonly string _connectionString;

        public VerbaleDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Verbale> GetAll()
        {
            var list = new List<Verbale>();

            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM VERBALE";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Verbale
                            {
                                Idverbale = (int)reader["Idverbale"],
                                DataViolazione = (DateTime)reader["DataViolazione"],
                                IndirizzoViolazione = reader["IndirizzoViolazione"].ToString(),
                                Nominativo_Agente = reader["Nominativo_Agente"].ToString(),
                                DataTrascrizioneVerbale = (DateTime)reader["DataTrascrizioneVerbale"],
                                Importo = (decimal)reader["Importo"],
                                DecurtamentoPunti = (int)reader["DecurtamentoPunti"],
                                Idanagrafica = (int)reader["Idanagrafica"],
                                Idviolazione = (int)reader["Idviolazione"]
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void Add(Verbale verbale)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO VERBALE (DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, Idanagrafica, Idviolazione) VALUES (@DataViolazione, @IndirizzoViolazione, @Nominativo_Agente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti, @Idanagrafica, @Idviolazione)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                    command.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                    command.Parameters.AddWithValue("@Nominativo_Agente", verbale.Nominativo_Agente);
                    command.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                    command.Parameters.AddWithValue("@Importo", verbale.Importo);
                    command.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
                    command.Parameters.AddWithValue("@Idanagrafica", verbale.Idanagrafica);
                    command.Parameters.AddWithValue("@Idviolazione", verbale.Idviolazione);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
