using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
          { "antivirus", "Antivirus software detects, prevents, and removes malicious software from devices. Tip: Keep your antivirus updated and run regular system scans." },
          { "vpn", "A VPN encrypts your internet connection. Tip: Choose a trustworthy provider and avoid free VPNs." },
          { "scam", "Scams trick you into giving away info. Tip: Always double-check sources before responding." },
          { "privacy", "Privacy matters. Tip: Review your social media settings and avoid oversharing personal details." },
          { "identity theft", "Identity theft happens when attackers steal your personal info. Tip: Monitor your accounts and use alerts for suspicious activity." },
          { "social media", "Social media can expose personal data. Tip: Limit what you share and adjust privacy settings." },
          { "cyberbullying", "Cyberbullying harms people online. Tip: Report abusive behavior and avoid engaging with bullies." },
          { "encryption", "Encryption is the process of converting data into a coded format to prevent unauthorized access. Tip: Use strong encryption methods to protect sensitive files and communications." },
          { "decryption", "Decryption is the process of converting encrypted data back into readable information. Tip: Only trusted users should have access to decryption keys." },
          { "spyware", "Spyware is malware that secretly collects information about a user without their consent. Tip: Avoid downloading software from untrusted websites." },
          { "trojan", "A Trojan is malware disguised as legitimate software to trick users into installing it. Tip: Never open suspicious files or email attachments." },
          { "worm", "A worm is malware that spreads automatically across networks without user interaction. Tip: Keep your operating system and software updated to reduce vulnerabilities." },
          { "botnet", "A botnet is a network of infected devices controlled remotely by cybercriminals. Tip: Secure your devices with strong passwords and updated security software." },
          { "ddos", "A DDoS attack overwhelms a server or network with traffic to make it unavailable. Tip: Use firewalls and traffic filtering systems to reduce attack impact." },
          { "brute force attack", "A brute force attack tries many password combinations until the correct one is found. Tip: Use long, complex passwords and enable account lockout policies." },
          { "two-factor authentication", "Two-factor authentication adds an extra layer of security by requiring two forms of verification. Tip: Enable 2FA on all important accounts whenever possible." },
          { "biometrics", "Biometrics uses unique physical traits like fingerprints or facial recognition for authentication. Tip: Combine biometrics with passwords for stronger security." },
          { "data breach", "A data breach occurs when sensitive information is accessed or stolen without authorization. Tip: Regularly monitor accounts and change passwords after breaches." },
          { "ethical hacking", "Ethical hacking is the legal practice of testing systems to find and fix security weaknesses. Tip: Always get proper authorization before performing security tests." },
          { "zero-day exploit", "A zero-day exploit attacks a software vulnerability before developers can release a fix. Tip: Keep systems updated and use advanced threat protection tools." },
          { "patch", "A patch is a software update designed to fix bugs or security vulnerabilities. Tip: Install patches promptly to reduce security risks." },
          { "backdoor", "A backdoor is a hidden method of bypassing normal authentication to gain system access. Tip: Regularly audit systems for suspicious accounts or software." },
          { "keylogger", "A keylogger records keyboard activity to steal passwords and sensitive information. Tip: Use antivirus software and avoid suspicious downloads." },
          { "authentication", "Authentication is the process of verifying a user's identity before granting access. Tip: Use strong authentication methods like passwords and biometrics together." },
          { "cyberattack", "A cyberattack is an attempt to damage, disrupt, or gain unauthorized access to systems or networks. Tip: Train users regularly on cybersecurity awareness and safe practices." },
          { "hashing", "Hashing converts data into a fixed-length value used for security and data integrity. Tip: Use secure hashing algorithms like SHA-256 for sensitive data." },
          { "cloud security", "Cloud security protects data, applications, and services stored online in cloud environments. Tip: Enable encryption and access controls for cloud accounts." },
          { "password manager", "A password manager securely stores and manages passwords for different accounts. Tip: Use a trusted password manager to create unique passwords for every account." },
          { "dark web", "The dark web is a hidden part of the internet accessible only through special software. Tip: Avoid visiting unknown dark web sites to reduce security risks." },
          { "penetration testing", "Penetration testing is a simulated cyberattack used to identify security weaknesses. Tip: Perform penetration tests regularly to improve system security." }
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
    }},

    { "firewall", new [] {
        "Use both network and software firewalls.",
        "Keep firewall rules updated regularly.",
        "Block unnecessary incoming connections.",
        "Monitor firewall alerts for suspicious traffic."
    }},

    { "social engineering", new [] {
        "Verify requests before sharing information.",
        "Be cautious of urgent or emotional messages.",
        "Attackers often target human trust.",
        "Never reveal passwords through email or phone calls."
    }},

    { "ransomware", new [] {
        "Keep offline backups of important files.",
        "Do not open suspicious attachments.",
        "Update systems to reduce vulnerabilities.",
        "Segment networks to limit ransomware spread."
    }},

    { "vpn", new [] {
        "Use trusted VPN providers only.",
        "Avoid free VPN services when possible.",
        "VPNs help secure public Wi-Fi connections.",
        "Always disconnect VPNs when not needed."
    }},

    { "scam", new [] {
        "Double-check offers that sound too good to be true.",
        "Scammers often create fake urgency.",
        "Verify identities before sending money.",
        "Never share banking details carelessly."
    }},

    { "privacy", new [] {
        "Review app permissions regularly.",
        "Limit the personal information you share online.",
        "Use strong privacy settings on social platforms.",
        "Avoid oversharing sensitive information."
    }},

    { "identity theft", new [] {
        "Monitor your bank statements regularly.",
        "Use alerts for suspicious account activity.",
        "Protect personal documents carefully.",
        "Shred sensitive paperwork before disposal."
    }},

    { "social media", new [] {
        "Think before posting personal details.",
        "Adjust privacy settings for better protection.",
        "Avoid accepting unknown friend requests.",
        "Be cautious of fake profiles and scams."
    }},

    { "cyberbullying", new [] {
        "Report abusive behavior immediately.",
        "Avoid responding to online harassment.",
        "Save evidence of harmful messages.",
        "Support victims and encourage safe reporting."
    }},

    { "encryption", new [] {
        "Encrypt sensitive files and communications.",
        "Use strong encryption standards.",
        "Encryption protects data from unauthorized access.",
        "Secure your encryption keys properly."
    }},

    { "decryption", new [] {
        "Only trusted users should access decrypted data.",
        "Protect decryption keys carefully.",
        "Use secure systems for decrypting information.",
        "Unauthorized decryption can expose sensitive data."
    }},

    { "spyware", new [] {
        "Avoid downloading from unknown websites.",
        "Run regular anti-spyware scans.",
        "Spyware secretly tracks user activity.",
        "Keep browsers and software updated."
    }},

    { "trojan", new [] {
        "Do not trust unknown software downloads.",
        "Trojans disguise themselves as legitimate apps.",
        "Scan files before opening them.",
        "Be cautious with email attachments."
    }},

    { "worm", new [] {
        "Worms spread automatically across networks.",
        "Keep systems patched and updated.",
        "Use firewalls to reduce network exposure.",
        "Avoid connecting infected devices to networks."
    }},

    { "botnet", new [] {
        "Secure IoT devices with strong passwords.",
        "Botnets can remotely control infected devices.",
        "Keep firmware updated regularly.",
        "Disconnect suspicious devices from the network."
    }},

    { "ddos", new [] {
        "Use traffic filtering to reduce attacks.",
        "Monitor unusual spikes in traffic.",
        "DDoS attacks overwhelm systems with requests.",
        "Use cloud-based protection services when possible."
    }},

    { "brute force attack", new [] {
        "Use long and complex passwords.",
        "Enable account lockout features.",
        "Avoid reusing passwords across accounts.",
        "Use password managers for stronger credentials."
    }},

    { "two-factor authentication", new [] {
        "Enable 2FA on important accounts.",
        "Use authentication apps instead of SMS when possible.",
        "2FA adds an extra layer of security.",
        "Never share verification codes with anyone."
    }},

    { "biometrics", new [] {
        "Use fingerprints or face recognition securely.",
        "Combine biometrics with passwords.",
        "Biometric data should be encrypted.",
        "Avoid relying only on biometrics for sensitive systems."
    }},

    { "data breach", new [] {
        "Change passwords after a breach.",
        "Monitor accounts for unusual activity.",
        "Companies should encrypt sensitive data.",
        "Enable alerts for suspicious logins."
    }},

    { "ethical hacking", new [] {
        "Ethical hackers test systems legally.",
        "Always get authorization before testing security.",
        "Ethical hacking helps find vulnerabilities early.",
        "Document findings responsibly."
    }},

    { "zero-day exploit", new [] {
        "Keep systems updated frequently.",
        "Zero-day attacks exploit unknown vulnerabilities.",
        "Use advanced threat detection tools.",
        "Apply security patches as soon as available."
    }},

    { "patch", new [] {
        "Install updates promptly.",
        "Patches fix bugs and security weaknesses.",
        "Enable automatic updates where possible.",
        "Outdated software increases security risks."
    }},

    { "backdoor", new [] {
        "Regularly audit systems for hidden access points.",
        "Backdoors bypass normal authentication.",
        "Remove unauthorized software immediately.",
        "Monitor unusual remote access attempts."
    }},

    { "keylogger", new [] {
        "Avoid suspicious software downloads.",
        "Use antivirus software to detect keyloggers.",
        "Keyloggers record keyboard activity secretly.",
        "Be cautious when entering passwords on public devices."
    }},

    { "authentication", new [] {
        "Use strong authentication methods.",
        "Authentication verifies user identity.",
        "Combine passwords with biometrics or 2FA.",
        "Never share login credentials."
    }},

    { "cyberattack", new [] {
        "Train employees on cybersecurity awareness.",
        "Cyberattacks target systems and sensitive data.",
        "Use layered security defenses.",
        "Monitor networks for suspicious activity."
    }},

    { "hashing", new [] {
        "Use secure hashing algorithms like SHA-256.",
        "Hashing helps verify data integrity.",
        "Never store passwords in plain text.",
        "Salt hashes for stronger password security."
    }},

    { "cloud security", new [] {
        "Enable encryption for cloud storage.",
        "Use strong access controls in cloud systems.",
        "Regularly review cloud permissions.",
        "Back up important cloud data."
    }},

    { "password manager", new [] {
        "Use unique passwords for every account.",
        "Password managers securely store credentials.",
        "Protect your master password carefully.",
        "Enable 2FA on your password manager."
    }},

    { "dark web", new [] {
        "Avoid visiting unknown dark web sites.",
        "Cybercriminals often trade stolen data there.",
        "Use caution when researching dark web activity.",
        "Never download files from untrusted sources."
    }},

    { "penetration testing", new [] {
        "Penetration tests simulate cyberattacks.",
        "Regular testing improves security posture.",
        "Document vulnerabilities clearly.",
        "Fix discovered weaknesses quickly."
    }}
};
        public static string GetResponse(string input, string userName)
        {
            if (string.IsNullOrWhiteSpace(input))
                return $"That looks empty, {userName}. Try typing a question like 'Tell me about phishing'.";

            input = input.ToLower();

            // 1. Awareness definitions first
            foreach (var kvp in staticResponses)
            {
                if (Regex.IsMatch(input, $@"\b{Regex.Escape(kvp.Key)}s?\b"))
                {
                    lastTopic = kvp.Key;
                    return kvp.Value.Replace("Tip:", $"Tip for you, {userName}:");
                }
            }

            // 2. Awareness tips (randomResponses) only if phrasing matches
            if (input.Contains("tell me more") || input.Contains("give me another tip") || input.Contains("explain more"))
            {
                if (!string.IsNullOrEmpty(lastTopic))
                    return $"Another {lastTopic} tip, {userName}: {GetRandomTip(lastTopic)}";
                else
                    return $"Let’s start fresh, {userName}. Ask me about phishing, passwords, or privacy.";
            }

            foreach (var kvp in randomResponses)
            {
                if (Regex.IsMatch(input, $@"\b{Regex.Escape(kvp.Key)}s?\b"))
                {
                    lastTopic = kvp.Key;
                    return $"{Capitalize(kvp.Key)} awareness, {userName}:\nTip: {GetRandomTip(kvp.Key)}";
                }
            }

            // 2. Sentiment detection
            var sentimentResult = SentimentAnalyzer.Analyze(input, userName);
            if (sentimentResult != null)
            {
                string topic = string.IsNullOrEmpty(sentimentResult.Topic) ? "phishing" : sentimentResult.Topic;
                lastTopic = topic;
                MemoryManager.Remember("topic", topic, userName);
                return sentimentResult.Response + "\nTip: " + GetRandomTip(topic);
            }

            // 3. Personality responses
            if (input.Contains("how are you"))
                return $"I’m really good, thanks for asking, {userName}! How are you feeling today?";
            if (input.Contains("your name"))
                return $"I’m....., whatever you want to call me, {userName}. What would you like to call me?";
            if (input.Contains("who created"))
                return $"Randima Ndivho built me for a project to raise cybersecurity awareness. What do you think inspired him to build me, {userName}?";

            // 4. Help / Topics
            if (input.Contains("help") || input.Contains("topics") || input.Contains("learn"))
                return $"I can teach you about these cybersecurity topics, {userName}:\n- Phishing\n- Password safety\n- Safe browsing\n- Malware\n- Firewall\n- Social engineering\n- Ransomware\n- Two-factor authentication (2FA)\n- Antivirus\n- VPN\n- Scam\n- Privacy\n- Identity theft\n- Social media\n- Cyberbullying\n\nWhich one would you like to learn about first?";

            // 5. Memory & recall
            if (input.StartsWith("remember my topic") ||
                input.StartsWith("remember ") ||
                input.StartsWith("i like ") ||
                input.StartsWith("favorite topic is "))
            {
                string[] parts = input.Split(' ');
                string topicToRemember = "";

                if (input.StartsWith("remember my topic") && parts.Length > 3)
                    topicToRemember = string.Join(" ", parts, 3, parts.Length - 3);
                else if (input.StartsWith("remember ") && parts.Length > 1)
                    topicToRemember = string.Join(" ", parts, 1, parts.Length - 1);
                else if (input.StartsWith("i like ") && parts.Length > 2)
                    topicToRemember = string.Join(" ", parts, 2, parts.Length - 2);
                else if (input.StartsWith("favorite topic is ") && parts.Length > 3)
                    topicToRemember = string.Join(" ", parts, 3, parts.Length - 3);

                if (!string.IsNullOrEmpty(topicToRemember))
                {
                    lastTopic = topicToRemember;
                    return MemoryManager.Remember("topic", topicToRemember, userName);
                }
                else
                {
                    return $"Please specify the topic you want me to remember, {userName}. For example: 'I like phishing'.";
                }
            }

            if (input.Contains("what do i like") || input.Contains("my favorite topic"))
            {
                return MemoryManager.Recall("topic", userName);
            }

            // 6. Conversation flow (single block)
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

        public static string GetRandomTip(string topic)
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