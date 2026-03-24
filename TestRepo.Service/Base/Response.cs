namespace TetPee.Service.Base;

public class Response
{
    public class PageResult<Tkey>
    {
        public List<Tkey> Items { get; set; } = new List<Tkey>();
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }        
    }
}