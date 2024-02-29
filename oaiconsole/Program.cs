using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Azure OpenAI keys
var deploymentName = Environment.GetEnvironmentVariable("depname");
var endpoint =Environment.GetEnvironmentVariable("endpoint");
var apiKey = Environment.GetEnvironmentVariable("apikey");

// Create a chat completion service
var builder = Kernel.CreateBuilder();
if (deploymentName != null && endpoint != null && apiKey != null)
{
    builder.AddAzureOpenAIChatCompletion(deploymentName, endpoint, apiKey);
}

// Get the chat completion service
Kernel kernel = builder.Build();
var chat = kernel.GetRequiredService<IChatCompletionService>();

// Create a sample chat history
var history = new ChatHistory();
history.AddSystemMessage("You are a helpful assistant.");
// history.AddUserMessage("What is a haiku?");
history.AddUserMessage("Can you create a haiku about artificial intelligence?");

// run the prompt
var result = await chat.GetChatMessageContentsAsync(history);
Console.WriteLine(result[^1].Content);