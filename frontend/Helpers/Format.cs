namespace frontend.Helpers
{
    public static class Format
    {
        /// <summary>
        /// Formats the given date in the format "dd-MM-yyyy".
        /// </summary>
        /// <param name="dt">The date to be formatted.</param>
        /// <returns>The formatted date as a string.</returns>
        public static string  FormatDate(DateTime dt)
        => dt.ToString("dd-MM-yyyy");

         
    }
}
