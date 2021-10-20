using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FptController : ControllerBase
    {

        private string _ConnectionString = "";
        public FptController(IConfiguration Configuration)
        {
            _ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerModel customer)
        {
            using (IDbConnection DbConexion = new SqlConnection(_ConnectionString))
            {
                if (DbConexion.State == ConnectionState.Closed)
                    DbConexion.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", customer.Name);
                parameters.Add("@Phone", customer.Phone);
                parameters.Add("@Email", customer.Email);
                parameters.Add("@Notes", customer.Notes);

                var Result  = DbConexion.Execute("InsertCustomer", parameters, commandType: CommandType.StoredProcedure);
                if (Result != 1)
                {
                    return BadRequest();
                }
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (IDbConnection DbConexion = new SqlConnection(_ConnectionString))
            {
                if (DbConexion.State == ConnectionState.Closed)
                    DbConexion.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var Result = DbConexion.Execute("DeleteCustomer", parameters, commandType: CommandType.StoredProcedure);

                if (Result != 1)
                {
                    return BadRequest();
                }
            }
            return NoContent();
        }


        [HttpGet]
        public ActionResult<IEnumerable<CustomerModel>> List()
        {
            List<CustomerModel> CustomerList = new List<CustomerModel>();
            using (IDbConnection DbConexion = new SqlConnection(_ConnectionString))
            {
                if (DbConexion.State == ConnectionState.Closed)
                    DbConexion.Open();

                CustomerList =  DbConexion.Query<CustomerModel>("CustomerList", commandType: CommandType.StoredProcedure).ToList();
            }
            return CustomerList;
        }
    }
}
