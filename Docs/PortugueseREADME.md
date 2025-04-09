# 🧾 FinTrack

Aplicativo de controle financeiro para ajudar usuários a gerenciar seus orçamentos e despesas. Este projeto inclui um backend feito com ASP.NET Core e PostgreSQL, todo containerizado com Docker.

---

## 🚀 Funcionalidades

- Banco de dados PostgreSQL modular com separação por schemas (`income`, `expense`)
- Ambiente local com Docker
- Web API em ASP.NET Core

---

## ⚙️ Requisitos

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/install/) (já vem com o Docker Desktop)
- [.NET SDK 9.0](https://dotnet.microsoft.com/pt-br/download) *(para rodar a API fora do container)*
- Terminal com suporte a `bash` (WSL, Git Bash no Windows ou terminal Linux/macOS)

---

## 🧪 Como Rodar Localmente

> Todo o processo de setup é automatizado pelo `setup.sh`.

### 1. Clone o repositório
```bash
git clone https://github.com/seu-usuario/FinTrack.git
cd FinTrack
```

### 2. Rode o Setup
```bash
sh setup.sh
```

Esse script irá:

- Subir os containers do PostgreSQL e da API
- Aguardar o PostgreSQL estar pronto
- Criar o banco de dados `fintrack` se ele ainda não existir
- Criar os schemas `income` e `expense`

### 3. Aproveite o FinTrack
```bash
✅ Tudo pronto! Acesse: http://localhost:7019/
```

---

## 📂 Estrutura do Projeto

```pgsql
FinTrack/
├── Docker/
│   └── Local/
│       ├── docker-compose.yml
│       └── Dockerfile
├── Docs/
├── Scripts/
│   ├── create_database.sql
│   └── create_schemas.sql
├── FinTrack.sln
├── setup.sh
└── README.md
```

## 🌐 Acesso
Quando tudo estiver rodando, acesse a API via:
```bash
http://localhost:7019/
```

## 🧼 Como Parar Tudo
Para parar e remover os containers:
```bash
cd Docker/Local
docker-compose -p fintrack down
```

## 🛠️ Solução de Problemas
- Porta em uso: Certifique-se que a porta 7019 não está sendo usada por outro aplicativo.
- Permissão negada: Se estiver no Unix/macOS, garanta que você executou `chmod +x setup.sh`.

## 📌 Notas
- A API roda com o perfil ASPNETCORE_ENVIRONMENT=Local.
- Usa rede personalizada: fintrack-net
- Usuário do banco: admin, senha: admin

## 🧑‍💻 Autor
Feito com ❤️ por Julio Nascimento

## 📃 Licença
MIT
