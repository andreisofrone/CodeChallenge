namespace Application.Common.Extensions
{
    public static class BooleanExtensions
    {
        private const string yes = "Yes";

        private const string no = "No";

        public static string ToYesNoString(this bool value)
        {
            return value ? yes : no;
        }
    }
}
