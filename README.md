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
```bash 
git clone https://github.com/your-username/gpt4all-chatbot.git

cd gpt4all-chatbot
```

## Create a ```.env``` file

Add the following Variables:

```
GPT4ALL_API_BASE=http://localhost:4891/v1

MODEL_ID=llama-3-8b-instruct
```

## Build and Run
``` bash
dotnet build

dotnet run
```

Chat with the AI! Type your questions and hit Enter. Type q to quit.

## How it Works
1. The chatbot reads your .env configuration to locate your GPT4All local API.
2. When you type a question:
	- If it matches a custom response, the chatbot replies immediately.
	- Otherwise, the request is sent to the GPT4All model for a generative answer.
3. Responses are displayed directly in your terminal.

## Extending the Chatbot

- Add more custom responses:
<br>
Edit the Program.cs and add additional if statements or a dictionary mapping questions to answers.
- Integrate APIs:
<br>
You can add features like weather, jokes, or other data sources by extending the main loop.
- Change model:
<br>
Update MODEL_ID in your .env to point to another GPT4All-compatible model.


## Why This Is Cool
- Fully local: no internet or cloud required.
- Customizable: personalize responses for fun or business use.
- demonstrates modern AI integration in a small, readable C# project.

## Example
 <img src="https://github.com/user-attachments/assets/5313ff01-ba6a-4243-91ef-bd09d2aa169e" width="1100px" height="500px" />
