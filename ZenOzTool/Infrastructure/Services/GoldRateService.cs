using System.Xml;

using ZenOzTool.Applications.Services;
using ZenOzTool.Models.Constants;
using ZenOzTool.Models.Response;

using static ZenOzTool.Models.Response.SjcGoldRateXML;
using static ZenOzTool.Models.Response.SjcGoldRateXML.City;

namespace ZenOzTool.Infrastructure.Services
{
    public class GoldRateService : IGoldRateService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GoldRateService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public SjcGoldRateXML GetSJC()
        {
            var result = new SjcGoldRateXML();
            XmlDocument xml = new();
            xml.Load($"{HttpClientConstants.SJC.Host}/xml/tygiavang.xml");
            var title = xml.SelectSingleNode("root/title").InnerText;
            var updated = xml.SelectSingleNode("/root/ratelist").Attributes["updated"].InnerText;
            var unit = xml.SelectSingleNode("/root/ratelist").Attributes["unit"].InnerText;
            var rawCities = xml.SelectNodes("/root/ratelist/city");

            foreach (XmlNode rCity in rawCities)
            {
                var city = new City(rCity.Attributes["name"].InnerText);
                var childNodeItem = rCity.ChildNodes;
                if (childNodeItem.Count > 0)
                {
                    foreach (XmlNode childNode in childNodeItem)
                    {
                        var item = new Item()
                        {
                            Buy = double.Parse(childNode.Attributes["buy"].InnerText),
                            Sell = double.Parse(childNode.Attributes["sell"].InnerText),
                            Type = childNode.Attributes["type"].InnerText
                        };
                        city.Items.Add(item);
                    }
                }
                result.Cities.Add(city);
            }
            result.Title = title;
            result.Updated = updated;
            result.Unit = unit;

            return result;
        }
    }
}