using CRUD_4.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

public class LanguageRepository
{
    private readonly string _connectionString;

    public LanguageRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection Connection => new MySqlConnection(_connectionString);

    public List<Language> GetAll()
    {
        using (var dbConnection = Connection)
        {
            dbConnection.Open();
            return dbConnection.Query<Language>("SELECT language_id AS LanguageId, name AS Name, last_update AS LastUpdate FROM language").ToList();
        }
    }

    public Language GetById(int id)
    {
        using (var dbConnection = Connection)
        {
            dbConnection.Open();
            return dbConnection.QueryFirstOrDefault<Language>("SELECT language_id AS LanguageId, name AS Name, last_update AS LastUpdate FROM language WHERE language_id = @Id", new { Id = id });
        }
    }

    public Language Insert(Language language)
    {
        using (var dbConnection = Connection)
        {
            dbConnection.Open();
            language.LastUpdate = DateTime.Now;  // 현재 시간으로 설정
            var sql = @"INSERT INTO language (name, last_update) VALUES (@Name, @LastUpdate); SELECT LAST_INSERT_ID();";
            int lastInsertedId = dbConnection.QuerySingle<int>(sql, language);
            language.LanguageId = lastInsertedId;
            return language;
        }
    }

    public void Update(Language language)
    {
        using (var dbConnection = Connection)
        {
            dbConnection.Open();

            // 현재 시간으로 설정
            if (language.LastUpdate == DateTime.MinValue)
            {
                language.LastUpdate = DateTime.Now;
            }

            var sql = @"UPDATE language SET name = @Name, last_update = @LastUpdate WHERE language_id = @LanguageId;";
            dbConnection.Execute(sql, language);
        }
    }

    public void Delete(int id)
    {
        using (var dbConnection = Connection)
        {
            dbConnection.Open();
            var sql = "DELETE FROM language WHERE language_id = @Id;";
            dbConnection.Execute(sql, new { Id = id });
        }
    }
}