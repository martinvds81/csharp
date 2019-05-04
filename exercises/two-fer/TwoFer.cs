public static class TwoFer
{
    public static string Speak(string givenName = "")
    {
        givenName = (string.IsNullOrEmpty(givenName)) ? "you" : givenName;

        return $"One for {givenName}, one for me.";
    }
}