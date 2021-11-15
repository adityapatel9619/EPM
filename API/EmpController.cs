﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPM.Models;
using EPM.DB;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EPM.API
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        // For Getting Employee
        DB.GetEmployee data = new DB.GetEmployee();
        DB.GetEmployee datatest = new DB.GetEmployee();
        private readonly IOptions<ModelConnectionString> appsetting;
        public EmpController(IOptions<ModelConnectionString> app)
        {
            appsetting = app;
        }

        [HttpGet]
        [ActionName("GetAllEmp")]
        // GET: api/Emp/GetAllEmp
        public IEnumerable<ModelGetEmp> GetEmp()
        {
            return data.GetEmp(appsetting.Value.DefaultConnection);
        }

        // GET api/Emp/GetSingleEmp
        //[HttpGet]
        //[ActionName("GetSingleEmp")]
        //public IEnumerable<ModelGetSingleEmp> GetSingleEmp(int id)
        //{
        //    return data.GetSingleEmp(id);
        //}
        // This is just for testing
        [HttpPost]
        [ActionName("SaveEmp")]
        // POST api/Emp/SaveEmp     
        //public string Post(ModelAddNewEmp addNewEmp)
        //{
        //    return data.Post(addNewEmp, appsetting.Value.DefaultConnection);
        //}

        public string Post(ModelAddNewEmp stud)
        {
            var postMethod = datatest.Post(stud);
            return postMethod;
        }


        // PUT api/<EmpController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmpController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
