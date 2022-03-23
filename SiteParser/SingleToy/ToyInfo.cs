using System.Collections.Generic;


namespace SiteParser.ToySite
{
    public class ToyInfo
    {
        private ToySiteParser _toySiteParser;
        
        public ToyInfo(ToySiteParser toySiteParser)
        {
            _toySiteParser = toySiteParser;
        }

        public List<Toy> toyList = new List<Toy>();


    }
}
