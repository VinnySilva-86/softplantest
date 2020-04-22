/*
 * Objective: Class created to hold the API exercis/test
 *            given by softplan. 
 *            Create two APIs with endspoints.
 * Website: www.softplan.com.br 
 * Created by: Vinny Silva
 * Created at: April 22nd, 2020
 */
namespace SoftPlan.Controllers
{
    using System.Net;       
    using System.Web.Http;
    using SoftPlan.Models;
    using System.Collections.Generic;

    public class SoftController : ApiController
    {
        /// <summary>
        /// This method will be used to return 1% tax
        /// </summary>
        [HttpGet]
        public IHttpActionResult taxaJuros()
        {
            return Content(HttpStatusCode.OK, "Seu valor de juros é R$0.01");
        }

        /// <summary>
        /// Returns 1% on a given decimal number 
        /// </summary>
        [HttpGet]
        public decimal taxaJuros(decimal number)
        {
            return number/100;
        }

        /// <summary>
        /// This method returns what the results of a compund 
        /// interest would be giving its time in months and its initial value
        /// </summary>
        [HttpGet]
        public string calculajuros([FromUri] decimal valorinicial, int meses)
        {
            //Create a list to hold the taxes so we can display one by one on our Report
            List<Tax> taxes = new List<Tax>();

            decimal total_interest = taxaJuros(valorinicial);

            for (int x = 0; x < meses; x++) {
                //Instanciate the tax class
                Tax tax = new Tax();

                tax.month = (x + 1).ToString();                
                tax.total_interest = string.Format("R${0:N2}", total_interest);
                tax.month_interest = string.Format("R${0:N2}", taxaJuros(valorinicial));
                tax.balance_interest = string.Format("R${0:N2}", (valorinicial + taxaJuros(valorinicial)));

                //Calculate the next month taxes and add it to the balance
                valorinicial += taxaJuros(valorinicial);

                //Just for Report purposes, calculate the total acumulation of interest for the next month
                total_interest += taxaJuros(valorinicial);                

                //Add the month calculated tax to our list of obj
                taxes.Add(tax);
            }

            //Instanciate the Report controller class
            DataController dc = new DataController();
            //Pass the list of Tax obj to create the report
            dc.CreateReport(taxes);

            //Formate the result to be displayed to the requester
            string result = string.Format("R${0:N2}", valorinicial);

            return result; 
        }

        [HttpGet]
        public IHttpActionResult showmethecode()
        {
            return Content(HttpStatusCode.OK, "https://github.com/VinnySilva-86/softplantest.git");
        }
    }
}