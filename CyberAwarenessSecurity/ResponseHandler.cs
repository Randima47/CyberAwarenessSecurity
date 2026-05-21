using System;
using System.Collections.Generic;

namespace CyberAwarenessSecurity
{
    public static class ResponseHandler
    {
        // Memory store for user interests
        private static Dictionary<string, string> memory = new Dictionary<string, string>();

        public static string GetResponse(string input, string userName)
        {
            input = input.ToLower();

            // 1. Sentiment Detection
            if (input.Contains("worried") || input.Contains("scared"))
                return $"It’s understandable to feel that way, {userName}. Scammers can be convincing — here’s a tip: Always verify links before clicking.";
            if (input.Contains("frustrated") || input.Contains("angry"))
                return $"I hear your frustration, {userName}. Cybersecurity can be overwhelming, but small steps like using strong passwords make a big difference.";
            if (input.Contains("curious"))
                return $"Curiosity is great, {userName}! Let’s explore phishing first — attackers often disguise themselves as trusted organisations.";

            // 2. Personality Responses
            if (input.Contains("how are you"))
                return $"I’m really good, thanks for asking, {userName}! How are you feeling today?";
            if (input.Contains("your name"))
                return $"I’m....., whatever you want to call me, {userName}. What would you like to call me?";
            if (input.Contains("who created"))
                return $"Randima Ndivho built me for a project to raise cybersecurity awareness. What do you think inspired him to build me, {userName}?";

            // 3. Help / Topics
            if (input.Contains("what kind of questions") || input.Contains("what can i ask"))
            {
                return $"Here are the exact questions you can ask me, {userName}:\n" +
                       "- how are you\n" +
                       "- your name\n" +
                       "- who created\n" +
                       "- purpose\n" +
                       "- help / topics / learn\n\n" +
                       "And for cybersecurity awareness:\n" +
                       "- phishing\n" +
                       "- password safety\n" +
                       "- safe browsing\n" +
                       "- malware\n" +
                       "- firewall\n" +
                       "- social engineering\n" +
                       "- ransomware\n" +
                       "- two-factor authentication (2FA)\n" +
                       "- antivirus\n" +
                       "- vpn\n\n" +
                       "Try one of these and I’ll guide you through it.";
            }

            if (input.Contains("purpose"))
                return $"Cybersecurity is the practice of protecting systems, networks, and data from digital attacks.\n\n" +
                       "Advantages: It keeps personal information safe, prevents financial loss, and builds trust online.\n" +
                       "Disadvantages: It can be costly, requires constant updates, and attackers are always evolving.\n\n" +
                       $"My purpose is to help you, {userName}, understand these concepts and stay safe online.";

            if (input.Contains("help") || input.Contains("topics") || input.Contains("learn"))
            {
                return $"I can teach you about these cybersecurity topics, {userName}:\n" +
                       "- Phishing\n" +
                       "- Password safety\n" +
                       "- Safe browsing\n" +
                       "- Malware\n" +
                       "- Firewall\n" +
                       "- Social engineering\n" +
                       "- Ransomware\n" +
                       "- Two-factor authentication (2FA)\n" +
                       "- Antivirus\n" +
                       "- VPN\n\n" +
                       "Which one would you like to learn about first?";
            }

            // 4. Awareness Topics + Random Responses
            if (input.Contains("phishing"))
            {
                string[] tips = {
                    "Be cautious of emails asking for personal info.",
                    "Hover over links before clicking.",
                    "Enable 2FA to reduce damage.",
                    "Check sender addresses carefully — scammers often mimic trusted domains."
                };
                Random rand = new Random();
                return $"Phishing is when attackers trick you into giving personal info, {userName}.\nTip: {tips[rand.Next(tips.Length)]}";
            }

            if (input.Contains("password"))
                return $"Strong passwords are your first defense, {userName}.\nTip: Use a password manager and enable two-factor authentication.";

            if (input.Contains("safe browsing"))
                return $"Safe browsing keeps you away from traps, {userName}.\nTip: Use browser security extensions and avoid downloads from unknown sites.";

            if (input.Contains("malware"))
                return $"Malware is malicious software, {userName}.\nTip: Keep your OS patched and avoid running as admin unnecessarily.";

            if (input.Contains("firewall"))
                return $"A firewall acts like a security guard, {userName}.\nTip: Use both network and application firewalls for layered defense.";

            if (input.Contains("social engineering"))
                return $"Social engineering manipulates people, {userName}.\nTip: Verify requests through official channels before sharing sensitive data.";

            if (input.Contains("ransomware"))
                return $"Ransomware locks your files, {userName}.\nTip: Keep offline backups and segment your network.";

            if (input.Contains("two-factor") || input.Contains("2fa"))
                return $"Two-factor authentication adds an extra layer of security, {userName}.\nTip: Use hardware tokens (like YubiKey) for stronger protection.";

            if (input.Contains("antivirus"))
                return $"Antivirus software detects and removes malicious programs, {userName}.\nTip: Pair antivirus with endpoint detection and response (EDR).";

            if (input.Contains("vpn"))
                return $"A VPN encrypts your internet connection, {userName}.\nTip: Choose a trustworthy provider and avoid free VPNs.";

            // 5. Memory & Recall
            if (input.Contains("remember my topic"))
            {
                memory["topic"] = "privacy";
                return $"Got it, {userName}. I’ll remember that you’re interested in privacy.";
            }

            if (input.Contains("what do i like"))
            {
                return memory.ContainsKey("topic")
                    ? $"You mentioned {memory["topic"]} earlier, {userName}. Let’s dive deeper into that."
                    : $"I don’t recall a topic yet, {userName}. Tell me what you’re interested in.";
            }

            // 6. Conversation Flow
            if (input.Contains("tell me more") || input.Contains("give me another tip") || input.Contains("explain more"))
            {
                string[] moreTips = {
                    "Always update your software to patch vulnerabilities.",
                    "Use multi-factor authentication wherever possible.",
                    "Be cautious of links in unexpected emails.",
                    "Regularly back up your important files."
                };
                Random rand = new Random();
                return moreTips[rand.Next(moreTips.Length)];
            }

            // 7. Fallback
            return $"I’m not sure I understand, {userName}. Can you try rephrasing?";
        }

        public static string GetFollowUp(string followUp, string originalInput, string userName)
        {
            followUp = followUp.ToLower();

            if (originalInput.Contains("how are you"))
            {
                if (followUp.Contains("fine") || followUp.Contains("good"))
                    return $"Glad to hear that, {userName}!";
                else if (followUp.Contains("not good") || followUp.Contains("bad") || followUp.Contains("sad"))
                    return $"I’m sorry to hear that, {userName}. Stay strong!";
                else
                    return $"Thanks for sharing, {userName}!";
            }

            if (originalInput.Contains("who created"))
            {
                if (followUp.Contains("because") || followUp.Contains("i wanted") || followUp.Contains("i built"))
                    return $"That’s inspiring, {userName}! Building me to raise cybersecurity awareness shows real vision.";
                else
                    return $"Interesting, {userName}! Whatever the reason, I’m glad to exist and help spread awareness.";
            }

            if (originalInput.Contains("your name"))
            {
                string normalized = followUp.ToLower();

                if (normalized.Contains("call you"))
                {
                    string newName = normalized
                        .Replace("i'll call you", "")
                        .Replace("i would like to call you", "")
                        .Replace("i'd like to call you", "")
                        .Trim();
                    return $"Got it, {userName}, you can call me {newName} from now on.";
                }
                else if (normalized.Contains("you are") || normalized.Contains("you're"))
                {
                    string newName = normalized
                        .Replace("you are", "")
                        .Replace("you're", "")
                        .Trim();
                    return $"Nice name, {userName}! I guess I’m {newName}. I’ll remember that.";
                }
                else
                {
                    return $"Alright, {userName}, I’ll just stick with CyberSecurityBot though.";
                }
            }

            if (originalInput.Contains("help") || originalInput.Contains("topics") || originalInput.Contains("learn"))
                return GetResponse(followUp, userName);

            if (originalInput.Contains("purpose"))
                return GetResponse(followUp, userName);

            return $"Thanks for your answer, {userName}!";
        }
    }
}
