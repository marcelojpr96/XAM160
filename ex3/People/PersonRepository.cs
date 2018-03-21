﻿using System;
using System.Collections.Generic;
using System.Linq;
using People.Models;
using SQLite;

namespace People
{
    public class PersonRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteConnection conn;
        public PersonRepository(string dbPath)
        {
            // TODO: Initialize a new SQLiteConnection
            // TODO: Create the Person table
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Person>();
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = conn.Insert(new Person { name = name });

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public List<Person> GetAllPeople()
        {
            // TODO: return a list of people saved to the Person table in the database

            try
            {
                return conn.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Person>();
        }
    }
}