# GPT4All Chatbot – Local AI Assistant
## A lightweight local AI chatbot using GPT4All LLaMA 3 instruct model.
This application allows you to chat with an AI assistant locally on your machine. It can respond to questions with AI-generated answers, and you can also define custom responses for specific questions (like song lyrics or fun replies).

## Features
- Chat with a local GPT4All LLaMA 3 model without sending data to the cloud.
- Fully customizable: add hardcoded responses for specific questions.
- Demonstrates integration with .env configuration for model settings.
- Runs entirely locally — no API subscription required.
- Easy to extend for more custom Q&A entries or integrations (like weather APIs).

## Custom Response Example

If the user types:

``` What is love? ```


The chatbot responds with:

```🎵 Baby don't hurt me! 🎵```


You can add your own custom responses by editing the C# dictionary or conditional statements in the code.

## Getting Started (Local Setup)
### Prerequisites
- .NET 8.0 SDK
- GPT4All model running locally (e.g., llama-3-8b-instruct).
- Optional: .env file with configuration.

## Clone the repository
```git clone https://github.com/your-username/gpt4all-chatbot.git```

``` cd gpt4all-chatbot```
