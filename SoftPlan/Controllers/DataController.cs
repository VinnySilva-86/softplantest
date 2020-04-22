/*
 * Objective: This class was created in order to save the compound interests
             requested by our APIs. It will give each month interest and 
             its total interest and its balance.
             Files will be better saved in csv format.
 * Created by: Vinny Silva
 * Created at: April 21th, 2020
 */
namespace SoftPlan.Controllers
{
    using System;   
    using CsvHelper;
    using System.IO;
    using SoftPlan.Models;
    using System.Globalization;
    using System.Collections.Generic;

    public class DataController
    {
        //Create its absolute path
        private readonly string PATH = AppDomain.CurrentDomain.BaseDirectory + "Files\\";
        private readonly DateTime DATETIME = DateTime.Now;

        /*
         * This method will receive the interest and the total value in order to create the report file
         */
        public void CreateReport<T>(List<T> data) { 
            Directory.CreateDirectory(PATH);

            var file = PATH + @"Relatorio - (" + String.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DATETIME) + ").csv";

            using (TextWriter textWriter = new StreamWriter(file, true, System.Text.Encoding.UTF8))
            {
                var csvFileLenth = new FileInfo(file).Length;
                var csv = new CsvWriter(textWriter, CultureInfo.InvariantCulture);

                if (csvFileLenth != 0)// check if file exist
                {
                    csv.Configuration.HasHeaderRecord = false;
                }

                csv.WriteRecords(data);
            }
        }
    }
}