using System;
using System.Collections.Generic;
using System.Text;

namespace CyberAwarenessSecurity
{
    public static class SentimentAnalyzer
    {
        public static string Analyze(string input, string userName)
        {
            if (string.IsNullOrWhiteSpace(input))
                return $"I didn’t catch that, {userName}. Try telling me how you feel — worried, curious, or even excited.";

            input = input.ToLower();

            if (input.Contains("worried") || input.Contains("scared") || input.Contains("anxious"))
                return $"It’s completely understandable to feel that way, {userName}. Scammers can be very convincing. Let me share a phishing tip to help you stay safe.";

            if (input.Contains("frustrated") || input.Contains("angry") || input.Contains("upset"))
                return $"I hear your frustration, {userName}. Cybersecurity can feel overwhelming, but small steps like using strong passwords make a big difference. Here’s a password tip to guide you.";

            if (input.Contains("curious") || input.Contains("interested"))
                return $"Curiosity is great, {userName}! Exploring cybersecurity topics helps you stay ahead of attackers. Let’s start with safe browsing.";

            if (input.Contains("confused") || input.Contains("unsure"))
                return $"It’s okay to feel confused, {userName}. Cybersecurity has many layers, but I’ll break it down step by step. Here’s a simple malware tip to get clarity.";

            if (input.Contains("excited") || input.Contains("happy"))
                return $"I love your energy, {userName}! Staying positive makes learning easier. Let’s channel that excitement into a quick VPN tip.";

            if (input.Contains("overwhelmed") || input.Contains("stressed"))
                return $"I know it can feel overwhelming, {userName}. Cyber threats are everywhere, but focusing on one step at a time helps. Let’s begin with firewall basics.";

            if (input.Contains("bored"))
                return $"Feeling bored, {userName}? Let’s spice things up with a quick scam awareness tip — it might surprise you how creative attackers can be.";

            if (input.Contains("motivated") || input.Contains("driven"))
                return $"Love that motivation, {userName}! Let’s put it to use by learning about identity theft prevention.";

            // No sentiment detected
            return null;
        }
    }
}