#!/bin/bash
set -euo pipefail

cd "$(dirname "$0")"

echo "🟡 Starting database container..."

cd Docker/Local/Infrastructure/Database

docker-compose -p fintrack_postgres up -d --build

echo "⏳ Waiting for PostgreSQL to accept connections..."
until docker exec fintrack_postgres pg_isready -U admin > /dev/null 2>&1; do
    sleep 1
done

sleep 5

echo "🟢 PostgreSQL is ready!"

echo "🚀 Checking if the 'fintrack' database already exists..."
if docker exec -i fintrack_postgres psql -U admin -d postgres -tAc "SELECT 1 FROM pg_database WHERE datname = 'fintrack';" | grep -qw 1; then
  echo "✅ Database 'fintrack' already exists. Skipping creation."
else
  echo "🚧 Database does not exist yet. Creating..."
  docker exec -i fintrack_postgres psql -U admin -d postgres -c "CREATE DATABASE fintrack;"
  echo "✅ Database 'fintrack' created successfully."
fi

echo "🚀 Creating schemas..."
docker exec -i fintrack_postgres psql -U admin -d fintrack < ./Scripts/create_schemas.sql

echo "🟡 Starting service container..."

cd ../../Application

docker-compose -p fintrack_app up -d --build

echo "✅ All set! Access: http://localhost:7019/"
