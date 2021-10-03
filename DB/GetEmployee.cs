﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using System.Data;
using System.Data.SqlClient;

namespace EPM.DB
{
    public class GetEmployee
    {
        public IEnumerable<ModelGetEmp> GetEmp(string ConnectionString)
        {
            using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                List<ModelGetEmp> emps = new List<ModelGetEmp>();
                SqlCommand command = new SqlCommand("uspMEmployeeSD", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = 0;
                command.Parameters.Add("@Type", SqlDbType.Char).Value = "S";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ModelGetEmp modelGetEmp = new ModelGetEmp();
                    modelGetEmp.Id = reader["Id"].ToString();
                    modelGetEmp.Empid = reader["EmpId"].ToString();
                    modelGetEmp.Fname = reader["FName"].ToString();
                    modelGetEmp.Mname = reader["MName"].ToString();
                    modelGetEmp.Lname = reader["LName"].ToString();
                    modelGetEmp.Bdate = reader["BDate"].ToString();
                    modelGetEmp.Gender = reader["Gender"].ToString();
                    modelGetEmp.MaritalStatus = reader["MarritalStatus"].ToString();
                    modelGetEmp.Mobilenum = reader["MobileNmber"].ToString();
                    modelGetEmp.Altnum = reader["AlternateNmber"].ToString();
                    modelGetEmp.Address = reader["Address"].ToString();
                    modelGetEmp.State = reader["State"].ToString();
                    modelGetEmp.City = reader["City"].ToString();
                    modelGetEmp.Pincode = reader["Pincode"].ToString();
                    modelGetEmp.Salary = reader["Salary"].ToString();
                    modelGetEmp.Startdate = reader["StartDate"].ToString();
                    modelGetEmp.Qualification = reader["Qualifications"].ToString();
                    emps.Add(modelGetEmp);
                }
                con.Close();
                return emps.ToArray();
            }
        }
    }
}
