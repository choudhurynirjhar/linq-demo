namespace LinqInternals.Demo
{
    public static class StringExtension
    {
        public static string GiveFirstCharacter(this string item)
        {
            return item.Substring(0, 1);
        }
    }
}
