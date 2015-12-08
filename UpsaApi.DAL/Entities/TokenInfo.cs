namespace UpsaApi.DAL.Entities
{
    public class TokenInfo
    {
        public string Value { get; set; }

        public string Id { get; set; }

        public string FullName { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
