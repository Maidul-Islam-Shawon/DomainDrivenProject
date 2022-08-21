namespace SharedKernel.Models
{
    public class QueryResult<T>
    {
        public QueryResult()
        {
        }

        public QueryResult(IEnumerable<T> entities, int totalCount)
        {
            TotalCount = totalCount;
            Entities = entities;
        }

        public IEnumerable<T> Entities { get; set; }
        public int TotalCount { get; set; }
    }
}
