﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLINQ
{
    internal class AddressBookTable
    {
        DataTable table;
        //Creating method to add data to table
        public void AddToDataTable()
        {
            //Creating object of class
            table = new DataTable();
            table.Columns.Add("FirstName");
            table.Columns.Add("LastName");
            table.Columns.Add("Address");
            table.Columns.Add("City");
            table.Columns.Add("State");
            table.Columns.Add("Zip");
            table.Columns.Add("PhoneNumber");
            table.Columns.Add("Email");
        }

        public void InsertintoDataTable(ContactDetails contact)
        {
            DataRow dtRow = table.NewRow();
            dtRow["FirstName"] = contact.FirstName;
            dtRow["LastName"] = contact.LastName;
            dtRow["Address"] = contact.Address;
            dtRow["City"] = contact.City;
            dtRow["State"] = contact.State;
            dtRow["Zip"] = contact.zip;
            dtRow["PhoneNumber"] = contact.PhoneNumber;
            dtRow["Email"] = contact.Email;
            table.Rows.Add(dtRow);
        }
        public void AddContacts()
        {
            AddToDataTable();
            ContactDetails contact = new ContactDetails();
            contact.FirstName = "Shalini";
            contact.LastName = "Venkatesh";
            contact.PhoneNumber = 9842905050;
            contact.Email = "shalini@gmail.com";
            contact.Address = "4,B Block,Avadi";
            contact.City = "chennai";
            contact.State = "TN";
            contact.zip = 600072;
            InsertintoDataTable(contact);

            contact.FirstName = "Raksha";
            contact.LastName = "Parthiban";
            contact.PhoneNumber = 7742905050;
            contact.Email = "raksha@gmail.com";
            contact.Address = "Sasthri street,ambattur";
            contact.City = "chennai";
            contact.State = "TN";
            contact.zip = 123001;
            InsertintoDataTable(contact);

        }

        public void EditContact(string FirstName, string ColumnName)
        {
            AddContacts();
            var recordData = (from table in table.AsEnumerable() where table.Field<string>("FirstName") == FirstName select table).FirstOrDefault();
            if (recordData != null)
            {
                recordData[ColumnName] = "Sampada";
                Display();
            }
            else
            {
                Console.WriteLine("No such record is available....");
            }
        }
        public void Display()
        {

            foreach (DataRow dtRows in table.Rows)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7}\n", dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
            }
        }
    }
}