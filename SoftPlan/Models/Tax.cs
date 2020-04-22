/*
 * Objective: This class is to hold the obj result from the compound calculation
 * Created by: Vinny Silva
 * Created at: April 21th, 2020
 */
namespace SoftPlan.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tax
    {
        [CsvHelper.Configuration.Attributes.Name("Mês")]
        public string month { get; set; }

        [CsvHelper.Configuration.Attributes.Name("Juros do mês")]
        public string month_interest { get; set; }

        [CsvHelper.Configuration.Attributes.Name("Total do juros")]
        public string total_interest { get; set; }

        [CsvHelper.Configuration.Attributes.Name("Saldo do juros")]
        public string balance_interest { get; set; }
    }
}