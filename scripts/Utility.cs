namespace Clock
{
public static class Utility
{
    public enum ClockFormat
    {
        RAW,
        DAYS,
        HOURS,
        MINUTES,
        SECONDS
    }
    public static string ClockStringFromFloat(float seconds, ClockFormat format)
    {
        string timeString;
		int daysPart = (int)(seconds / 86400);      // Floor division of the seconds divided by (seconds per day)
		int hoursPart = (int)(seconds / 3600) % 24; // Floor division of the seconds divided by (seconds per hour)
		int minutesPart = (int)(seconds / 60) % 60; // Floor division of the seconds divided by (seconds per minute) mod 60. 
                                                    // The mod 60 keeps it from counting total minutes for multiple hours.
		int secondsPart = (int)(seconds) % 60;      // Seconds mod 60. Same reason as mod 60 on minutes.
		
		// lpad the time strings with 0s, and use the last two digits. This limits output hours to mod 100, but that's okay for the use case.
		string daysString 	= $"00{daysPart}".Substring($"0{daysPart}".Length - 1);
		string hourString 	= $"00{hoursPart}".Substring($"0{hoursPart}".Length - 1);
		string minuteString = $"00{minutesPart}".Substring($"0{minutesPart}".Length - 1);
		string secondString = $"00{secondsPart}".Substring($"0{secondsPart}".Length - 1);

        
        switch (format)
        {   // Cases are ordered by expected liklihood of use
            case ClockFormat.MINUTES:
                timeString = $"{minuteString}:{secondString}";
                break;
            case ClockFormat.SECONDS:
                timeString = $"{secondString}";
                break;
            case ClockFormat.HOURS:
                timeString = $"{hourString}:{minuteString}:{secondString}";
                break;
            case ClockFormat.DAYS:
                timeString = $"{daysString}:{hourString}:{minuteString}:{secondString}";
                break;
            // If no valid format was provided, just return the raw seconds as a string
            default:
                timeString = $"{seconds}";
                break;
        }

        return timeString;
    }
}
}