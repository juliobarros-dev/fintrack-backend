#!/bin/bash

set -e
cd "$(dirname "$0")"

echo "🟡 Subindo containers da aplicação (API + DB)..."

cd Docker/Local

docker-compose -p fintrack up -d

echo "⏳ Aguardando PostgreSQL ficar pronto..."
until docker exec fintrack_db pg_isready -U admin > /dev/null 2>&1; do
    sleep 1
done

echo "🟢 PostgreSQL está pronto!"

echo "🚀 Criando banco de dados fintrack (se ainda não existir)..."
docker exec -i fintrack_db psql -U admin -d postgres -tc "SELECT 1 FROM pg_database WHERE datname = 'fintrack'" | grep -q 1 || \
  docker exec -i fintrack_db psql -U admin -d postgres -c "CREATE DATABASE fintrack;"

echo "🚀 Criando schemas..."
docker exec -i fintrack_db psql -U admin -d fintrack < ./Scripts/create_schemas.sql

echo "✅ Everything is ready! Go to: http://localhost:7019/"