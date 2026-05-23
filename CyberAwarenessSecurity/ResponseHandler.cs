using System;
using System.Collections.Generic;

namespace CyberAwarenessSecurity
{
    public static class ResponseHandler
    {
        private static string lastTopic = "";

        private static readonly Dictionary<string, string> staticResponses = new Dictionary<string, string>
        {
            { "firewall", "A firewall acts like a security guard. Tip: Use both network and application firewalls for layered defense." },
            { "social engineering", "Social engineering manipulates people. Tip: Verify requests through official channels before sharing sensitive data." },
            { "ransomware", "Ransomware locks your files. Tip: Keep offline backups and segment your network." },
            { "antivirus", "Antivirus software detects and removes malicious programs. Tip: Pair antivirus with endpoint detection and response (EDR)." },
            { "vpn", "A VPN encrypts your internet connection. Tip: Choose a trustworthy provider and avoid free VPNs." },
            { "scam", "Scams trick you into giving away info. Tip: Always double-check sources before responding." },
            { "privacy", "Privacy matters. Tip: Review your social media settings and avoid oversharing personal details." },
            { "identity theft", "Identity theft happens when attackers steal your personal info. Tip: Monitor your accounts and use alerts for suspicious activity." },
            { "social media", "Social media can expose personal data. Tip: Limit what you share and adjust privacy settings." },
            { "cyberbullying", "Cyberbullying harms people online. Tip: Report abusive behavior and avoid engaging with bullies." }
        };

        private static readonly Dictionary<string, string[]> randomResponses = new Dictionary<string, string[]>
        {
            { "phishing", new [] {
                "Be cautious of emails asking for personal info.",
                "Hover over links before clicking.",
                "Enable 2FA to reduce damage.",
                "Check sender addresses carefully — scammers often mimic trusted domains."
            }},
            { "password", new [] {
                "Use long, unique passwords.",
                "Avoid personal details in passwords.",
                "Change passwords regularly.",
                "Enable two-factor authentication."
            }},
            { "safe browsing", new [] {
                "Avoid suspicious links.",
                "Use HTTPS but stay cautious.",
                "Install browser security extensions.",
                "Don’t download from unknown sites."
            }},
            { "malware", new [] {
                "Keep your OS patched.",
                "Avoid running as admin unnecessarily.",
                "Use reputable antivirus software.",
                "Don’t install software from unknown sources."
            }}
        };

        public static string GetResponse(string input, string userName)
        {
            if (string.IsNullOrWhiteSpace(input))
                return $"That looks empty, {userName}. Try typing a question like 'Tell me about phishing'.";

            input = input.ToLower();

            // 1. Sentiment detection
            string sentimentResponse = SentimentAnalyzer.Analyze(input, userName);
            if (sentimentResponse != null)
                return sentimentResponse + "\nTip: " + GetRandomTip("phishing");

            // 2. Personality responses
            if (input.Contains("how are you"))
                return $"I’m really good, thanks for asking, {userName}! How are you feeling today?";
            if (input.Contains("your name"))
                return $"I’m....., whatever you want to call me, {userName}. What would you like to call me?";
            if (input.Contains("who created"))
                return $"Randima Ndivho built me for a project to raise cybersecurity awareness. What do you think inspired him to build me, {userName}?";

            // 3. Help / Topics
            if (input.Contains("help") || input.Contains("topics") || input.Contains("learn"))
                return $"I can teach you about these cybersecurity topics, {userName}:\n- Phishing\n- Password safety\n- Safe browsing\n- Malware\n- Firewall\n- Social engineering\n- Ransomware\n- Two-factor authentication (2FA)\n- Antivirus\n- VPN\n- Scam\n- Privacy\n- Identity theft\n- Social media\n- Cyberbullying\n\nWhich one would you like to learn about first?";

            // 4. Awareness topics
            foreach (var kvp in randomResponses)
            {
                if (input.Contains(kvp.Key))
                {
                    lastTopic = kvp.Key;
                    return $"{Capitalize(kvp.Key)} awareness, {userName}:\nTip: {GetRandomTip(kvp.Key)}";
                }
            }

            foreach (var kvp in staticResponses)
            {
                if (input.Contains(kvp.Key))
                {
                    lastTopic = kvp.Key;
                    return kvp.Value.Replace("Tip:", $"Tip for you, {userName}:");
                }
            }
            
            // 5. Memory & recall
            if (input.StartsWith("remember my topic"))
            {
                
                string[] parts = input.Split(' ');
                if (parts.Length > 3)
                {
                    string topicToRemember = string.Join(" ", parts, 3, parts.Length - 3);
                    MemoryManager.Remember("topic", topicToRemember, userName);
                    return $"Got it, {userName}. I’ll remember that you’re interested in {topicToRemember}.";
                }
                else
                {
                    return $"Please specify the topic you want me to remember, {userName}. For example: 'remember my topic phishing'.";
                }
            }

            if (input.Contains("what do i like"))
            {
                string topic = MemoryManager.Recall("topic", userName);
                return topic != null
                    ? $"You mentioned {topic} earlier, {userName}. Let’s dive deeper into that."
                    : $"I don’t recall a topic yet, {userName}. Tell me what you’re interested in.";
            }


            // 6. Conversation flow
            if (input.Contains("tell me more") || input.Contains("give me another tip") || input.Contains("explain more"))
            {
                if (!string.IsNullOrEmpty(lastTopic))
                    return $"Another {lastTopic} tip, {userName}: {GetRandomTip(lastTopic)}";
                else
                    return $"Let’s start fresh, {userName}. Ask me about phishing, passwords, or privacy.";
            }

            // 7. Gibberish check
            if (input.Length < 3)
                return $"That looks like gibberish, {userName}. Try asking about a topic like phishing or privacy.";

            // 8. Fallback
            return $"I’m not sure I understand, {userName}. Can you try rephrasing?";
        }

        private static string GetRandomTip(string topic)
        {
            if (randomResponses.ContainsKey(topic))
            {
                Random rand = new Random();
                string[] tips = randomResponses[topic];
                return tips[rand.Next(tips.Length)];
            }
            return "Stay safe online!";
        }

        private static string Capitalize(string word)
        {
            return char.ToUpper(word[0]) + word.Substring(1);
        }
    }
}

