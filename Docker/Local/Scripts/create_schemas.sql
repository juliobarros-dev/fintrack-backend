-- Remover o schema 'public'
REVOKE ALL ON SCHEMA public FROM public;
DROP SCHEMA IF EXISTS public CASCADE;

-- Recriar o schema apenas se necessário (não obrigatório)
 CREATE SCHEMA IF NOT EXISTS income;
 CREATE SCHEMA IF NOT EXISTS expense;

