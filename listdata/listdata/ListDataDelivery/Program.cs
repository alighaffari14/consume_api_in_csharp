using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace listdata
{
    class Program
    {
       
        static void Main(string[] args)
        {
            working w = new working();

            w.ListarFilmes();
            w.Print();
        }

        public class working
        {
            //myworking here
        
            List<jsonData> ResultFilm = new List<jsonData>();
            public List<jsonData> ListarFilmes()
            {

                try
                {
                    using (WebClient webClient = new System.Net.WebClient())
                    {
                        var url = @"https://min-api.cryptocompare.com/data/pricemulti?fsyms=BTC,ETH,EOS,NEO&tsyms=USD,EUR";
                        var json = webClient.DownloadString(url);
                        dynamic array = JsonConvert.DeserializeObject(json);
                       


                        JObject parsed = JObject.Parse(json);

                        foreach (var pair in parsed)
                        {
                            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                        }

                        Console.WriteLine("cryptocompare " + array.RAW.FROMSYMBOL + " " + array.RAW.PRICE + " " + array.RAW.LASTUPDATE);

                    }

                   
                }
                catch(Exception e)
                {

                }
              

                return ResultFilm;

            }

            public void Print()
            {

                for (int i = 0; i < ResultFilm.Count; i++)
                {
                    Console.WriteLine(ResultFilm[i]);
                }
            }
        }
         
    }
        }
        

      
