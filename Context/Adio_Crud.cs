using curdoperation.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace curdoperation.Context
{
    public class Adio_CRUD_DAL
    {

        string connectionString = "Data Source=ABTANKPC;Initial Catalog=master; Integrated Security=True";

        //GetstudentData

        public IEnumerable<Curd> GetAllStudent()
        {
            var SP_GetAllStudent = "SP_GetAllStudent";
            using (var connection = new SqlConnection(connectionString))
            {
                var stud = connection.Query<Curd>(SP_GetAllStudent, commandType: CommandType.StoredProcedure);

                return stud;
            }

            //var studentList = new List<Curd>();
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand("SP_GetAllStudent", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    con.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        var student = new Curd();
            //        student.Newid = Convert.ToInt32(dr["Newid"].ToString());
            //        student.Firstname = dr["Firstname"].ToString();
            //        student.Lastname = dr["Lastname"].ToString();
            //        student.Birthdate = (DateTime?)dr["Birthdate"];
            //        student.Zodiac = dr["Zodiac"].ToString();
            //        student.Mobileno = dr["Mobileno"].ToString();
            //        student.Email = dr["Email"].ToString();

            //        studentList.Add(student);
            //    }
            //    con.Close();
            //    return studentList;

            //}

        }


        //Create New Student

        public Curd CreateStudent(Curd student)
        {

            //var SP_CreateNewStudent = "SP_CreateNewStudent";

            //using (var connection = new SqlConnection(connectionString))

            int reslt = 0;

            using(IDbConnection con = new SqlConnection(connectionString))

            {
                if (con.State == ConnectionState.Closed)
                    con.Open();


                DynamicParameters parameters = new DynamicParameters(student.Newid);

               parameters.Add("@ID", student.Newid);
               parameters.Add("@Firstname", student.Firstname);
                parameters.Add("@Lastname", student.Lastname);
               parameters.Add("@Birthdate", student.Birthdate.Value.ToString("yyyy-MM-dd"));
               parameters.Add("@Zodiac", student.Zodiac);
               parameters.Add("@Mobileno", student.Mobileno);
              parameters.Add("@Email", student.Email);



                //con.Execute(SP_CreateNewStudent,student,commandType: CommandType.StoredProcedure);
                reslt = con.Execute("SP_CreateNewStudent", parameters, commandType: CommandType.StoredProcedure);
            }
            return student;





            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand("SP_CreateNewStudent", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@Id", student.Newid);
            //    cmd.Parameters.AddWithValue("@Firstname", student.Firstname);
            //    cmd.Parameters.AddWithValue("@Lastname", student.Lastname);
            //    cmd.Parameters.AddWithValue("@Birthdate", student.Birthdate.Value.ToString("yyyy-MM-dd"));
            //    cmd.Parameters.AddWithValue("@Zodiac", student.Zodiac);
            //    cmd.Parameters.AddWithValue("@Mobileno", student.Mobileno);
            //    cmd.Parameters.AddWithValue("@Email", student.Email);

            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();

            //}


        }

















        public Curd UpdateStudent(Curd student)
        {

            //var SP_CreateNewStudent = "SP_CreateNewStudent";

            //using (var connection = new SqlConnection(connectionString))

            int reslt = 0;

            using (IDbConnection con = new SqlConnection(connectionString))

            {
                if (con.State == ConnectionState.Closed)
                    con.Open();


                DynamicParameters parameters = new DynamicParameters(student.Newid);

                parameters.Add("@ID", student.Newid);
                parameters.Add("@Firstname", student.Firstname);
                parameters.Add("@Lastname", student.Lastname);
                parameters.Add("@Birthdate", student.Birthdate.Value.ToString("yyyy-MM-dd"));
                parameters.Add("@Zodiac", student.Zodiac);
                parameters.Add("@Mobileno", student.Mobileno);
                parameters.Add("@Email", student.Email);



                //con.Execute(SP_CreateNewStudent,student,commandType: CommandType.StoredProcedure);
                reslt = con.Execute("SP_UpdateStudent", parameters, commandType: CommandType.StoredProcedure);
            }
            return student;





            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand("SP_CreateNewStudent", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@Id", student.Newid);
            //    cmd.Parameters.AddWithValue("@Firstname", student.Firstname);
            //    cmd.Parameters.AddWithValue("@Lastname", student.Lastname);
            //    cmd.Parameters.AddWithValue("@Birthdate", student.Birthdate.Value.ToString("yyyy-MM-dd"));
            //    cmd.Parameters.AddWithValue("@Zodiac", student.Zodiac);
            //    cmd.Parameters.AddWithValue("@Mobileno", student.Mobileno);
            //    cmd.Parameters.AddWithValue("@Email", student.Email);

            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();

            //}


        }

        //Update Student

        //public void UpdateStudent(Curd student)
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_UpdateStudent", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@Id", student.Newid);
        //        cmd.Parameters.AddWithValue("@Firstname", student.Firstname);
        //        cmd.Parameters.AddWithValue("@Lastname", student.Lastname);
        //        if (student.Birthdate.HasValue)
        //        {
        //            cmd.Parameters.AddWithValue("@Birthdate", student.Birthdate.Value.ToString("yyyy-MM-dd"));

        //        }
        //        else
        //        {
        //            cmd.Parameters.AddWithValue("@Birthdate", student.Birthdate);

        //        }

        //        cmd.Parameters.AddWithValue("@Zodiac", student.Zodiac);
        //        cmd.Parameters.AddWithValue("@Mobileno", student.Mobileno);
        //        cmd.Parameters.AddWithValue("@Email", student.Email);

        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();

        //    }


        //}


        //Delete Student





        public void DeleteStudent(int? Id)
        {
            

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);

               con.Execute("SP_DeletStudent", parameters, commandType: CommandType.StoredProcedure);
            }

           

        }





            //public void DeleteStudent(int? Id)
            //{
            //    using (SqlConnection con = new SqlConnection(connectionString))
            //    {
            //        SqlCommand cmd = new SqlCommand("SP_DeletStudent", con);
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        cmd.Parameters.AddWithValue("@Id", Id);


            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();

            //    }


            //}


            //Get Student ID

            public Curd GetStudentById(int? Id)
        {
            var student = new Curd();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("SP_GetStudentById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);


                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    student.Newid = Convert.ToInt32(dr["Id"].ToString());
                    student.Firstname = dr["Firstname"].ToString();
                    student.Lastname = dr["Lastname"].ToString();
                    student.Birthdate = (DateTime?)dr["Birthdate"];
                    student.Zodiac = dr["Zodiac"].ToString();
                    student.Mobileno = dr["Mobileno"].ToString();
                    student.Email = dr["Email"].ToString();

                }
                con.Close();

            }
            return student;


        }







    }
}
