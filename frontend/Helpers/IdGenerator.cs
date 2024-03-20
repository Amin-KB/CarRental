namespace frontend.Helpers
{
    public static class IdGenerator
    {
        public static int GenerateId()
        {
            var now = DateTime.Now;
            var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
           return (int)(zeroDate.Ticks / 10000);
        }
    }
}
