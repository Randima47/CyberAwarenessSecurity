using System.Collections.Generic;

namespace CyberAwarenessSecurity
{
    public static class GlossaryManager
    {
        private static readonly Dictionary<string, string> glossary = new Dictionary<string, string>
        {
         { "encryption", "Encryption is the process of converting data into a coded format to prevent unauthorized access." },
         { "decryption", "Decryption is the process of converting encrypted data back into readable information." },
         { "antivirus", "Antivirus software detects, prevents, and removes malicious software from devices." },
         { "spyware", "Spyware is malware that secretly collects information about a user without their consent." },
         { "trojan", "A Trojan is malware disguised as legitimate software to trick users into installing it." },
         { "worm", "A worm is malware that spreads automatically across networks without user interaction." },
         { "botnet", "A botnet is a network of infected devices controlled remotely by cybercriminals." },
        { "ddos", "A DDoS attack overwhelms a server or network with traffic to make it unavailable." },
        { "brute force attack", "A brute force attack tries many password combinations until the correct one is found." },
        { "two-factor authentication", "Two-factor authentication adds an extra layer of security by requiring two forms of verification." },
        { "biometrics", "Biometrics uses unique physical traits like fingerprints or facial recognition for authentication." },
        { "data breach", "A data breach occurs when sensitive information is accessed or stolen without authorization." },
        { "ethical hacking", "Ethical hacking is the legal practice of testing systems to find and fix security weaknesses." },
        { "zero-day exploit", "A zero-day exploit attacks a software vulnerability before developers can release a fix." },
        { "patch", "A patch is a software update designed to fix bugs or security vulnerabilities." },
        { "backdoor", "A backdoor is a hidden method of bypassing normal authentication to gain system access." },
        { "keylogger", "A keylogger records keyboard activity to steal passwords and sensitive information." },
        { "authentication", "Authentication is the process of verifying a user's identity before granting access." },
        { "authorization", "Authorization determines what resources or actions a user is allowed to access." },
        { "cyberattack", "A cyberattack is an attempt to damage, disrupt, or gain unauthorized access to systems or networks." },
        { "hashing", "Hashing converts data into a fixed-length value used for security and data integrity." },
        { "cloud security", "Cloud security protects data, applications, and services stored online in cloud environments." },
        { "password manager", "A password manager securely stores and manages passwords for different accounts." },
        { "dark web", "The dark web is a hidden part of the internet accessible only through special software." },
        { "penetration testing", "Penetration testing is a simulated cyberattack used to identify security weaknesses." }
        };

        public static string GetDefinition(string term, string userName)
        {
            term = term.ToLower();
            return glossary.ContainsKey(term)
                ? $"{userName}, here’s the definition of {term}: {glossary[term]}"
                : $"Sorry {userName}, I don’t have a definition for {term} yet.";
        }

        public static string ShowAllTerms(string userName)
        {
            string terms = string.Join(", ", glossary.Keys);
            return $"Here are the terms I can define for you, {userName}: {terms}";
        }
    }
}
