using UsersSkills.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using UsersSkills.DAL.Interfaces;

namespace UsersSkills.DAL
{
    public class SkillDAO : ISkillDAO
    {

        private string _connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

        public void AddSkill(Skill skill)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertSkill";
                cmd.Parameters.AddWithValue(@"Name", skill.Name);
                if (skill.Description == null)
                {
                    cmd.Parameters.AddWithValue(@"Description", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue(@"Description", skill.Description);
                }
                var ID = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "ID",
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(ID);
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void EditSkill(Skill skill)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateSkill";
                cmd.Parameters.AddWithValue(@"ID", skill.ID);
                cmd.Parameters.AddWithValue(@"Name", skill.Name);
                if (skill.Description == null)
                {
                    cmd.Parameters.AddWithValue(@"Description", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue(@"Description", skill.Description);
                }
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void RemoveSkill(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteSkill";
                cmd.Parameters.AddWithValue(@"ID", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            List<Skill> skillList = new List<Skill>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllSkills";
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
