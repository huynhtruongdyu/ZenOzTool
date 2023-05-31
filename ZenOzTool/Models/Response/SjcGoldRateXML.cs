namespace ZenOzTool.Models.Response
{
    public class SjcGoldRateXML
    {
        public string Title { get; set; }
        public string Updated { get; set; }
        public string Unit { get; set; }
        public List<City> Cities { get; set; } = new();

        public class City
        {
            public string Name { get; set; }

            public City(string name)
            {
                Name = name;
            }

            public List<Item> Items { get; set; } = new();

            public class Item
            {
                public double Buy { get; set; }
                public double Sell { get; set; }
                public string Type { get; set; }
            }
        }
    }
}