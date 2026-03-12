# Support Chat SignalR API

Backend API for a real-time technical support chat system built with **.NET**, **SignalR**, and **MongoDB**.

This API provides the real-time communication layer that allows users and support agents to exchange messages instantly through WebSockets.

---

## Features

- Real-time messaging using SignalR
- Chat session management
- Chat history persistence
- Multiple chat rooms using SignalR Groups
- Agent dashboard support for handling multiple conversations
- Clean service-based architecture

---

## Tech Stack

- .NET
- SignalR
- MongoDB
- C#

---

## Architecture Overview

User and agent clients connect to the **SignalR Hub** to exchange messages in real time.

Client (Angular)
│
▼
SignalR Hub
│
▼
Application Services
│
▼
MongoD

SignalR Groups are used to isolate conversations so each chat session receives only its own messages.

---

## Main Components

### ChatHub

Handles all real-time communication between connected clients.

Responsibilities:

- Create chat sessions
- Join chat rooms
- Send and receive messages
- Broadcast updates to agents

### ChatService

Application layer responsible for:

- chat creation
- message persistence
- retrieving chat history
- managing active chats

### MongoDB

Stores:

- chat sessions
- messages
- chat history

---

## Running the API

Clone the repository: