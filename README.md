# Support Chat API (Real-Time)

Backend de un sistema de chat en tiempo real para soporte técnico, desarrollado con **.NET**, **SignalR** y **MongoDB**.

Este proyecto implementa comunicación en tiempo real mediante WebSockets, permitiendo interacción instantánea entre usuarios y agentes de soporte.

---

## 🧠 Descripción del proyecto

API diseñada para gestionar conversaciones de soporte en tiempo real, con persistencia de mensajes y manejo de múltiples sesiones simultáneas.

El sistema permite:
- Comunicación instantánea usuario ↔ agente
- Gestión de múltiples chats activos
- Historial de conversaciones
- Panel de agentes en tiempo real

---

## 🏗️ Arquitectura

El proyecto sigue una arquitectura basada en capas:

- `Domain/`
  → Entidades del sistema (Chat, Message)

- `Application/`
  → Lógica de negocio (ChatService)

- `Infrastructure/`
  → Acceso a datos (MongoDB)

- `Repositories/`
  → Persistencia de datos

- `Hubs/`
  → Comunicación en tiempo real (SignalR)

---

## ⚙️ Stack Tecnológico

- .NET 10 (Preview)
- SignalR (WebSockets)
- MongoDB
- C#
- Docker

---

## 🔄 Flujo de comunicación

Cliente (Angular)
│
▼
SignalR Hub
│
▼
Application Services
│
▼
MongoDB

- Los clientes se conectan al **ChatHub**
- Se utilizan **SignalR Groups** para aislar conversaciones
- Cada chat tiene su propio canal en tiempo real

---

## 🧩 Componentes principales

### 🟣 ChatHub

Responsable de la comunicación en tiempo real.

Funciones principales:
- Crear chats
- Unirse a salas (groups)
- Enviar y recibir mensajes
- Notificar nuevos chats a agentes
- Cargar historial de conversaciones

---

### 🟢 ChatService

Capa de negocio que maneja:

- Creación de chats
- Validación de chats activos
- Persistencia de mensajes
- Consulta de historial
- Listado de chats activos

---

### 🟡 MongoDB

Base de datos NoSQL que almacena:

- Chats
- Mensajes
- Historial de conversaciones

---

## 📦 Funcionalidades implementadas

### 💬 Chat en tiempo real
- Comunicación instantánea con SignalR
- Uso de WebSockets
- Mensajes en tiempo real sin polling

---

### 👥 Manejo de sesiones
- Un usuario solo puede tener un chat activo
- Reutilización de chats existentes
- Identificación por email

---

### 🧠 Historial de conversaciones
- Persistencia de mensajes en MongoDB
- Recuperación de historial por chat
- Orden cronológico de mensajes

---

### 🧑‍💻 Panel de agentes
- Recepción de nuevos chats en tiempo real
- Visualización de chats activos
- Manejo de múltiples conversaciones

---

### 🧵 Uso de SignalR Groups
- Cada chat es un grupo independiente
- Aislamiento de mensajes por conversación
- Canal exclusivo por sesión

---
