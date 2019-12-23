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

           
          
        }

        public class working
        {
          
        
            
            public List<jsonData> ListarFilmes()
            {
                List<jsonData> jd = new List<jsonData>();
                
                try
                {
                    using (WebClient webClient = new System.Net.WebClient())
                    {
                        var url = @"https://min-api.cryptocompare.com/data/pricemulti?fsyms=BTC,ETH,EOS,NEO&tsyms=USD,EUR";
                        var json = webClient.DownloadString(url);
                        jsonData array = JsonConvert.DeserializeObject<jsonData>(json);
                        JObject parsed = JObject.Parse(json);

                        foreach (var pair in parsed)
                        {

                            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                        }
                        jd.Add(array);
                        Console.ReadLine();
                        //Console.WriteLine("cryptocompare " + array.RAW.FROMSYMBOL + " " + array.RAW.PRICE + " " + array.RAW.LASTUPDATE);

                    }

                   
                }
                catch(Exception e)
                {
                    Console.WriteLine("Something Went Wrong");
                }
                return jd;



            }

           
        }
         
    }
        }
        

      
