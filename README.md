# CyberAwarenessBot - Part 2

CyberAwarenessBot has been upgraded from a console chatbot into a WPF GUI application designed to raise cybersecurity awareness in a professional, interactive way.
It combines audio greetings, modern GUI design, personalised interactions, and structured responses to teach users about key cybersecurity concepts.

# Features

- Audio Greeting: Plays a custom recorded .wav file on startup.

- GUI Interface: RichTextBox chat display with auto‑scroll, styled chat bubbles, and buttons for quick actions.

- Personalised Greeting: Prompts for the user’s name and uses it consistently throughout the conversation.

Interactive Chat Flow:

Awareness definitions (green) for cybersecurity topics.

- Randomised awareness tips for deeper learning.

- Personality answers (cyan) for casual interaction.
Memory recall of favourite topics.

- Glossary button to show definitions.

- Fun Fact button for random cybersecurity facts.

Expanded Cybersecurity Topics:

- Identity theft

- Social media

- Cyberbullying

- Encryption / Decryption

- Spyware, Trojan, Worms

- Botnets, DDoS

- Brute force attacks

- Biometrics

- Data breaches

- Ethical hacking

- Zero‑day exploits

- And more!

# How It Works
1 - Startup Sequence

Plays audio greeting.

Displays welcome message in GUI.

Prompts for user name.

2 - Chat Loop

User types a question or keyword.

ResponseHandler processes input and returns a definition or tip.

Messages are styled and auto‑scrolled in the RichTextBox.

3 - Buttons & Actions

Fun Fact -> shows a random cybersecurity fact.

Glossary -> shows all terms or defines a specific one.

Clear Chat -> resets the conversation and memory.

# Project Structure

- MainWindow.xaml / MainWindow.cs  
WPF GUI, audio greeting, input handling, auto‑scroll, buttons.

- ResponseHandler.cs  
Core logic for awareness topics, tips, personality, memory.

- MemoryManager.cs  
Stores and recalls user’s favourite topics.

- SentimentAnalyzer.cs  
Detects sentiment and adjusts responses.

- FunFacts.cs  
Provides random cybersecurity facts.

- GlossaryManager.cs  
Manages definitions and glossary display.

# Requirements

- .NET Framework 4.7.2 or later

- WPF environment with audio playback support

- greeting.wav file placed in the project’s output directory (bin/Debug or bin/Release)

# Usage

1 - Clone the repository.

2 - Place your recorded greeting.wav in the project directory.

3 - Build and run the project.

4 - Interact with the bot via the GUI: type questions, click buttons, and explore topics.

# Example Interaction

Bot: Welcome to CyberSecurity AwarenessBot! Please enter your name to begin.
You: Randima Ndivho
Bot: Nice to meet you, Randima Ndivho! Ask me about cybersecurity topics like phishing, passwords, or privacy.
You: define keylogger
Bot: A keylogger records keyboard activity to steal passwords and sensitive information.
Tip for you, Randima Ndivho: Use antivirus software and avoid suspicious downloads.

# Credits

Developed by Randima Ndivho for a cybersecurity awareness project.
Upgraded to WPF GUI with expanded awareness topics and interactive features for Part 2.

# License

This project is for educational purposes.

# References

- Stack Overflow – How to play a sound in C#

- Stack Overflow – Play WAV audio file from Resources

- Microsoft Developer Blog – Write markdown in Visual Studio

- AEANET – How to Add a README.md File in Visual Studio

- Microsoft Docs – WPF RichTextBox (learn.microsoft.com in Bing)

- Stack Overflow – Auto-scroll RichTextBox (stackoverflow.com in Bing)
