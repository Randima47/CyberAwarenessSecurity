using System;
using System.Collections.Generic;
using System.Text;

namespace CyberAwarenessSecurity
{
    public class SentimentResult
    {
        public string Response { get; set; }
        public string Topic { get; set; }
    }

    public static class SentimentAnalyzer
    {
        public static SentimentResult Analyze(string input, string userName)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new SentimentResult
                {
                    Response = $"I didn’t catch that, {userName}. Try telling me how you feel — worried, curious, or even excited.",
                    Topic = "phishing" // safe fallback
                };

            input = input.ToLower();

            // Emotion detection
            string emotion = null;
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("anxious")) emotion = "worried";
            else if (input.Contains("frustrated") || input.Contains("angry") || input.Contains("upset")) emotion = "frustrated";
            else if (input.Contains("curious") || input.Contains("interested")) emotion = "curious";
            else if (input.Contains("confused") || input.Contains("unsure")) emotion = "confused";
            else if (input.Contains("excited") || input.Contains("happy")) emotion = "excited";
            else if (input.Contains("overwhelmed") || input.Contains("stressed")) emotion = "overwhelmed";
            else if (input.Contains("bored")) emotion = "bored";
            else if (input.Contains("motivated") || input.Contains("driven")) emotion = "motivated";

            // Context detection
            string context = null;
            if (input.Contains("login") || input.Contains("password")) context = "password";
            else if (input.Contains("vpn")) context = "vpn";
            else if (input.Contains("browse") || input.Contains("web")) context = "safe browsing";
            else if (input.Contains("malware") || input.Contains("virus")) context = "malware";
            else if (input.Contains("firewall")) context = "firewall";
            else if (input.Contains("scam") || input.Contains("phishing")) context = "phishing";
            else if (input.Contains("identity")) context = "identity theft";

            // Decision engine
            string topic = context ?? emotion switch
            {
                "worried" => "phishing",
                "frustrated" => "password",
                "curious" => "safe browsing",
                "confused" => "malware",
                "excited" => "vpn",
                "overwhelmed" => "firewall",
                "bored" => "scam",
                "motivated" => "identity theft",
                _ => "phishing"
            };

            string response = emotion switch
            {
                "worried" => $"It’s completely understandable to feel that way, {userName}. Scammers can be very convincing.",
                "frustrated" => $"I hear your frustration, {userName}. Cybersecurity can feel overwhelming, but small steps like using strong passwords make a big difference.",
                "curious" => $"Curiosity is great, {userName}! Exploring cybersecurity topics helps you stay ahead of attackers.",
                "confused" => $"It’s okay to feel confused, {userName}. Cybersecurity has many layers, but I’ll break it down step by step.",
                "excited" => $"I love your energy, {userName}! Staying positive makes learning easier.",
                "overwhelmed" => $"I know it can feel overwhelming, {userName}. Cyber threats are everywhere, but focusing on one step at a time helps.",
                "bored" => $"Feeling bored, {userName}? Let’s spice things up with a quick awareness tip.",
                "motivated" => $"Love that motivation, {userName}! Let’s put it to use by learning about identity theft prevention.",
                _ => $"Thanks for sharing that, {userName}. Let’s keep building your awareness."
            };

            return new SentimentResult { Response = response, Topic = topic };
        }
    }
}


