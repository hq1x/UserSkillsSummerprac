using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UsersSkills.DAL.Interfaces;
using UsersSkills.Entities;

namespace UsersSkills.DAL
{
   public class SkillUserConnectionDAO: ISkillUserConnectionDAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

        public void AddSkillUserConnection(int userID, int skillID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertSkillUserConnection";
                cmd.Parameters.AddWithValue(@"UserID", userID);
                cmd.Parameters.AddWithValue(@"SkillID", skillID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void RemoveSkillUserConnection(int userID, int skillID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteSkillUserConnection";
                cmd.Parameters.AddWithValue(@"UserID", userID);
                cmd.Parameters.AddWithValue(@"SkillID", skillID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<Skill> GetAllSkillsByUser(int userID)
        {
            List<Skill> skillList = new List<Skill>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllSkillsByUser";
                cmd.Parameters.AddWithValue(@"UserID", userID);
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    skillList.Add(new Skill
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"]
                    });
                }
            }
            return skillList;
        }






    }
}
