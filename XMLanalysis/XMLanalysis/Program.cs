using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLanalysis   {
     class FarmTran{
        
        public string transactionDate{ get;set;}
        public string cropCode { get; set; }
        public string cropName { get; set; }
        public string marketCode { get; set; }
        public string marketName { get; set; }
        public string priceHigh { get; set; }
        public string priceMid { get; set; }
        public string priceLow { get; set; }
        public string priceAvg { get; set; }
        public string transactionNum { get; set; }
    }
    class Program{
        static void Main(string[] args){



            
            
            var nodeList = new List<FarmTran>();

            XDocument docNew = XDocument.Load("/C#/XMLanalysis/FarmTransData.xml");
            //Console.WriteLine(docNew.ToString());
            IEnumerable<XElement> nodes = docNew.Element("DocumentElement").Elements("row");

            nodeList = nodes
                .Select(node =>{
                    var item = new FarmTran();
                    item.transactionDate = getValue(node, "交易日期");
                    item.cropCode = getValue(node, "作物代號");
                    item.cropName = getValue(node, "作物名稱");
                    item.marketCode = getValue(node, "市場代號");
                    item.marketName = getValue(node, "市場名稱");
                    item.priceHigh = getValue(node, "上價");
                    item.priceMid = getValue(node, "中價");
                    item.priceLow = getValue(node, "下價");
                    item.priceAvg = getValue(node, "平均價");
                    item.transactionNum = getValue(node, "交易量");
                    return item;
                }).ToList();
            Display(nodeList);
            

            /*
            var nodeList = new List<FarmTran>();

            var xml = XElement.Load("/C#/XMLanalysis/FarmTransData.xml");
            var nodes = xml.Descendants("row").ToList();
            nodeList = nodes
                .Where(x =>x.IsEmpty)//.Where(x => !x.IsEmpty)
                .ToList().Select(node => {
                    var item = new FarmTran();
                    item.transactionDate = getValue(node, "交易日期");
                    item.cropCode = getValue(node, "作物代號");
                    item.cropName = getValue(node, "作物名稱");
                    item.marketCode = getValue(node, "市場代號");
                    item.marketName = getValue(node, "市場名稱");
                    item.priceHigh = getValue(node, "上價");
                    item.priceMid = getValue(node, "中價");
                    item.priceLow = getValue(node, "下價");
                    item.priceAvg = getValue(node, "平均價");
                    item.transactionNum = getValue(node, "交易量");
                    return item;
                }).ToList();
           
            */
            Console.ReadKey();
        }

        private static string getValue(XElement node, string propertyName) {
            return node.Element(propertyName)?.Value.Trim();
        }
        private static void Display(List<FarmTran> nodes) {
                                         
            nodes.GroupBy(node => node.marketName).ToList()
                .ForEach(group => {
                    var key = group.Key;
                    var groupData = group.ToList();
                    var message = $"市場名稱:{key},共有 {groupData.Count()}筆";
                            
                    Console.WriteLine(message);
                    foreach (var item in groupData)
                    {
                        Console.WriteLine($"\t交易日期: {item.transactionDate}");
                        Console.WriteLine($"\t作物代號: {item.cropCode}");
                        Console.WriteLine($"\t作物名稱: {item.cropName}");
                        Console.WriteLine($"\t上價: {item.priceHigh}");
                        Console.WriteLine($"\t中價: {item.priceMid}");
                        Console.WriteLine($"\t下價: {item.priceLow}");
                        Console.WriteLine($"\t平均價: {item.priceAvg}");
                        Console.WriteLine($"\t交易量: {item.transactionNum}");
                        Console.WriteLine();
                    }
                });               
                               
        }
    }
}
