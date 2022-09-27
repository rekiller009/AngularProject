namespace Angular_link_to_DB_API.Common
{
    public class Converter
    {
        public static string DecodeBase64(string value)
        {
            if(string.IsNullOrEmpty(value))
                return string.Empty;

            var valueBytes = System.Convert.FromBase64String(value);
            return System.Convert.ToBase64String(valueBytes);
        }
    }
}
