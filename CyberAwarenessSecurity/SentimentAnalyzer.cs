using System;
using System.Collections.Generic;
using System.Text;

namespace CyberAwarenessSecurity
{
    public static class SentimentAnalyzer
    {
        public static string Analyze(string input, string userName)
        {
            input = input.ToLower();

            if (input.Contains("worried") || input.Contains("scared"))
                return $"It’s completely understandable to feel that way, {userName}. Scammers can be very convincing. Here’s a tip: Always verify links before clicking.";

            if (input.Contains("frustrated") || input.Contains("angry"))
                return $"I hear your frustration, {userName}. Cybersecurity can be overwhelming, but small steps like using strong passwords make a big difference.";

            if (input.Contains("curious"))
                return $"Curiosity is great, {userName}! Let’s explore phishing first — attackers often disguise themselves as trusted organisations.";

            // No sentiment detected
            return null;
        }
    }
}