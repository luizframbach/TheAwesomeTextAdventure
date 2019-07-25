namespace TheAwesomeTextAdventure.UnitTests.Helpers
{
    internal static class ObjectExtension
    {
        public static void SetProperty<T>(
            this T obj,
            string propertyName,
            object value) where T : class
        {
            obj.GetType().GetProperty(propertyName).SetValue(obj, value, null);
        }
    }
}
