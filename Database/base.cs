using System;
using System.Collections.Generic;
using Dapper;
using Npgsql;

namespace NewAPI
{
    class TrySQL
    {
        public void TrySql(string[] args)
        {
            PrepareDatabase();

            using (var conn = CreateConnection("test"))
            {
                Process(conn);
            }

            Console.WriteLine("Press <Enter> to drop database");
            Console.Read();

            DropDatabase();
        }

        public void Process(NpgsqlConnection conn)
        {
            // дока по дапперу https://github.com/StackExchange/Dapper
            conn.Execute("create table books (id int, name text, url text)");

            conn.Execute("insert into books (id, name, url) values(:id, :name, :url)",
                new
                {
                    id = 1,
                    name = "Postgres: первое знакомство",
                    url = "https://postgrespro.ru/education/books/introbook"
                }
            );

            conn.Execute("insert into books (id, name, url) values(:id, :name, :url)",
                new
                {
                    id = 2,
                    name = "Высоконагруженные приложения. Программирование, масштабирование, поддержка",
                    url = "https://www.ozon.ru/context/detail/id/144402960/"
                }
            );

            IEnumerable<Book> books = conn.Query<Book>("select id, name, url from books");

            foreach (var book in books)
            {
                Console.WriteLine("{0,-5} {1,-80} {2}", book.Id, book.Name, book.Url);
            }
        }

        public void DropDatabase()
        {
            using (var conn = CreateConnection("postgres"))
            {
                conn.Execute("drop database test");
            }
        }

        public void PrepareDatabase()
        {
            using (var conn = CreateConnection("postgres"))
            {
                conn.Execute("create database test");
            }
        }

        private static NpgsqlConnection CreateConnection(string db)
        {
            // Все возможные параметрты https://www.npgsql.org/doc/connection-string-parameters.html
            var conn = new NpgsqlConnection($"server=localhost;userid=postgres;database={db};Pooling=false");

            conn.Open();

            return conn;
        }

        public class Book
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Url { get; set; }
        }
    }
}