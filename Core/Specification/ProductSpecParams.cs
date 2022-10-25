namespace Core.Specification
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex {get;set;} = 1;
        private int _pageSize = 6;
        private string _search;
        public int pageSize
        {
            get => _pageSize;
            set => _pageSize = (value>MaxPageSize)?MaxPageSize:value;

        }

        public string search
        {
          get => _search;
          set => _search = value.ToString();     
        }
       public int? brandId;
       public int? typeId;
       public string sort {get;set;}


    }
}