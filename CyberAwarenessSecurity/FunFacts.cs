using System;
using System.Collections.Generic;

namespace CyberAwarenessSecurity
{
    public static class FunFacts
    {
        private static readonly List<string> facts = new List<string>
        {
          "The first webcam was created to monitor a coffee pot at Cambridge University.",
          "More than 90% of cyberattacks begin with a phishing email.",
          "The famous 'ILOVEYOU' virus caused billions of dollars in damage in 2000.",
          "Cybercrime is predicted to cost the world trillions of dollars annually.",
          "Two-factor authentication can block most automated hacking attempts.",
          "The strongest passwords are usually long phrases instead of random short words.",
          "Public Wi-Fi networks are common targets for cybercriminals.",
          "Ransomware attacks often demand payment in Bitcoin or other cryptocurrencies.",
          "The average data breach can take months to detect.",
          "Some hackers are hired legally to test company security systems; they are called ethical hackers.",
          "The first spam email was sent in 1978 to hundreds of users on ARPANET.",
          "Captcha systems were created to distinguish humans from bots.",
          "Many data breaches happen because of weak or reused passwords.",
          "The dark web is only a small portion of the entire internet.",
          "Biometric security includes fingerprints, facial recognition, and iris scans.",
          "Cybersecurity jobs are among the fastest-growing tech careers worldwide.",
          "The Stuxnet worm was one of the first cyberweapons designed to damage physical equipment.",
          "Social engineering attacks manipulate people instead of attacking computers directly.",
          "Updating software regularly helps patch security vulnerabilities.",
          "Some malware can remain hidden on a device for years before being discovered.",
          "The first known computer bug was an actual moth stuck inside a computer in 1947.",
          "Firewalls act like digital security guards for networks and devices.",
          "Hackers sometimes use fake USB drives to spread malware.",
          "Password managers help users create and store secure passwords safely.",
          "Deepfake technology can be used in cybercrime to impersonate real people."
        };

        public static string GetRandomFact(string userName)
        {
            Random rand = new Random();
            string fact = facts[rand.Next(facts.Count)];
            return $"Here’s a fun cybersecurity fact for you, {userName}: {fact}";
        }
    }
}
