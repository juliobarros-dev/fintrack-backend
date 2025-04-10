# 🧾 FinTrack

[:brazil: Português](./Docs/PortugueseREADME.md)

FinTrack is a financial tracking application designed to help users manage budgets and expenses effectively. This project includes a backend built with ASP.NET Core and PostgreSQL, all containerized using Docker.

---

## 🚀 Features

- Modular PostgreSQL database with schema separation (`income`, `expense`)
- Dockerized local environment setup
- ASP.NET Core Web API

---

## ⚙️ Requirements

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/install/) (comes with Docker Desktop)
- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download) *(to run the API outside the container)*
- Terminal with support to `bash` (`WSL`, Git Bash on Windows or terminal Linux/macOS)

---

## 🧪 How to Run Locally

> All the setup is automated using `setup.sh`.

### 1. Clone the repository
```bash
git clone https://github.com/your-username/FinTrack.git
cd FinTrack
```

### 2. Run Setup
```bash
sh setup.sh
```

This script will:

- Spin up the PostgreSQL and API containers
- Wait for PostgreSQL to become ready
- Create the fintrack database if it doesn't exist
- Create the required schemas: income, expense

### 3. Enjoy FinTrack
```bash
✅ All set! Access: http://localhost:7019/
```

---

## 📂 Project Structure

```pgsql
FinTrack/
├── Docker/
│   └── Local/
│       └── Application/
│       │   ├── docker-compose.yml
│       │   └── Dockerfile
│       └── Infrastructure/
│       │   └── Database/
│       │       ├── Scripts/
│       │       │   └── create_schemas.sql
│       └──     └── docker-compose.yml
│       
├── Docs/
├── Scripts/
│   ├── create_database.sql
│   └── create_schemas.sql
├── FinTrack.sln
├── setup.sh
└── README.md
```

---

## 🌐 Access
Once everything is up and running, access the API via:
```bash
http://localhost:7019/
```

---

## 🧼 How to Stop Everything
To stop and remove the containers:
```bash
cd Docker/Local/Application
docker-compose -p fintrack_api down

cd ../Infrastructure/Database
docker-compose -p fintrack_postgres down
```
Or use Docker Desktop

---

## 🛠️ Troubleshooting
- Port in use: Make sure port 7019 is not being used by another application.
- Permission denied: If using Unix/macOS, ensure you’ve run chmod +x setup.sh.

---

## 📌 Notes
- The API runs with the ASPNETCORE_ENVIRONMENT=Development
- Uses custom network: fintrack-net
- Database user: admin, password: admin

---

## 🧑‍💻 Author
Made with ❤️ by Julio Nascimento

---

## 📃 License
MIT
