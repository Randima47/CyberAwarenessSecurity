# CyberAwarenessBot - Part 3

CyberAwarenessBot has evolved into a multi-system WPF application that now combines cybersecurity awareness learning with an interactive quiz engine, task manager system, and activity logging.

This version focuses on structured logic, object-based design, and modular system separation, moving beyond a simple chatbot into a lightweight learning and productivity platform.

# Features

- Audio Greeting: Plays a custom recorded .wav file on startup.
* Plays a .wav file on startup
* Creates an immersive onboarding experience for users.

- Cybersecurity Awareness Chat
* RichTextBox - based chat interface
* Colour - coded responses for definitions, tips, and personality answers.
* Personalised interaction - Remembers user’s name and favourite topics for a tailored experience.
* Memory recall - Stores and recalls user’s favourite topics for deeper learning.

- Quiz System
Interactive cybersecurity quiz engine featuring:

* Multiple-choice questions
* Score tracking system
* Instant feedback per answer
* Final score summary
* Sequential question flow managed by QuizManager
Topics include:

* Malware
* Phishing
* Firewalls
* Social engineering
* Password security
* DDoS attacks
* HTTPS and web safety
* And many more!

- Task Manager System
A lightweight productivity module integrated into the app:

* Add tasks with title, description, and optional reminder date
* Mark tasks as completed
* Delete tasks
* Real-time task list updates

Built using:

* TaskManager (logic layer)
* TaskItem (data model)

- Activity Log System
Tracks user interactions across all application

* Logs all major actions ( Quiz answers, Task Upadates, Resets, etc. )
* Timestamped entries
* Live UI Updates via centralized logging system

- Glossary System

* Cybersecurity term definitions
* On-demand lookup system
* Educational reference support

- Fun Fact System

* Random cybersecurity facts
* Lightweight engagement feature

- Expanded Cybersecurity Topics

* Identity theft
* Social engineering
* Phishing attacks
* Encryption / Decryption
* Spyware, Trojan, Worms
* Botnets and DDoS attacks
* Brute force attacks
* Biometrics
* Data breaches
* Ethical hacking
* Zero-day exploits
* Password security best practices
* Network protection fundamentals

# How It Works

1 - Startup Sequence

* Plays audio greeting from greeting.wav file.
* Displays welcome message in GUI.
* Prompts for user name.

2 - Chat Loop & Learning System

* User interacts via text input
* ResponseHandler processes queries
System returns:
   * Definitions
   * Awareness tips
   * Personalized responses
*Messages are styled and auto-scrolled

3 - Quiz System Flow

* User starts quiz session
* Questions are loaded sequentially
* User selects answers via buttons
* System evaluates correctness instantly
* Score is tracked and displayed at the end

4 - Task System Flow 

* User adds tasks through UI
* Tasks are stored in TaskManager
* UI refreshes to display updated list
* User can complete or delete tasks
* Task state updates instantly in memory

- Activity Logging Flow

* Every major action is recorded
Logs include:
  * Timestamp
  * Action description
* UI displays live activity history

# Project Structure

- MainWindow.xaml / MainWindow.cs
* WPF UI layer, event handling, quiz/task integration, logging, chat interface
- ResponseHandler.cs
* Core cybersecurity chatbot logic
- QuizManager.cs
* Handles quiz logic, scoring, and question progression
- TaskManager.cs
* Manages task creation, updates, and deletion
- TaskItem.cs
* Data model representing individual tasks
- ActivityLog.cs
* Central logging system for user actions
- MemoryManager.cs
* Stores user preferences and memory-based responses
- SentimentAnalyzer.cs
* Detects sentiment and adjusts responses
- FunFacts.cs
* Generates random cybersecurity facts
- GlossaryManager.cs
* Handles cybersecurity term definitions

# Requirements

- .NET Framework 4.7.2 or later

- WPF environment with audio playback support

- greeting.wav file placed in the project’s output directory (bin/Debug or bin/Release)

# Usage

1 - Clone the repository
2 - Place greeting.wav in the build output directory (bin/Debug or bin/Release)
3 - Build and run the project
4 - Interact using:
   * Chat system
   * Quiz system
   * Task manager
   * Activity log tracking

# Example Interaction

Ask me about cybersecurity topics like phishing, passwords, or privacy.
Bot: Welcome to CyberAwarenessBot! Please enter your name.
User: Randima Ndivho
Bot: Nice to meet you, Randima Ndivho. Ask me about cybersecurity topics like phishing, passwords, or privacy.

User starts quiz

Bot: What is malware?
User selects: Malicious software
Bot: Correct!

System: Task "Study cybersecurity" added
System: Activity logged: Quiz completed
System: Your score: 12/15

# Credits

Developed by Randima Ndivho
Expanded into a full WPF cybersecurity learning system featuring:

* Chatbot intelligence
* Quiz engine
* Task management
* Activity tracking

# License

This project is for educational purposes only.

# References

- Stack Overflow – How to play a sound in C#

- Stack Overflow – Play WAV audio file from Resources

- Microsoft Developer Blog – Write markdown in Visual Studio

- AEANET – How to Add a README.md File in Visual Studio

- Microsoft Docs – WPF RichTextBox (learn.microsoft.com in Bing)

- Stack Overflow – Auto-scroll RichTextBox (stackoverflow.com in Bing)
