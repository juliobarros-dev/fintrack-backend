DO $$
BEGIN
   IF NOT EXISTS (SELECT FROM pg_database WHERE datname = 'fintrack') THEN
      CREATE DATABASE fintrack;
END IF;
END
$$;