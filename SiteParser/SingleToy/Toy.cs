using System.Text;


namespace SiteParser.SingleToy
{
    public class Toy
    {
        public string RegionName { get; set; }
        public StringBuilder Breadcrumbs { get; set; }
        public StringBuilder ImageLinks { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string OldPrice { get; set; }
        public string Availability { get; set; }
        public string ImageLink { get; set; }
        public string ToyLink { get; set; }
    }
}
