namespace CovidAssignment.Extension
{
    public static class StringExtension
    {
        public static string ShortDate(this string date)
        {
            {
                //The index of letter T in string
                var index = date.IndexOf("T");

                //return content string from index 0 to index of letter T
                return date.Substring(0, index);
            }
        }
    }
}