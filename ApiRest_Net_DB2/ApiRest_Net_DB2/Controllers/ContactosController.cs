using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IBM.Data.DB2.iSeries;
using ApiRest_Net_DB2;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ApiRest_Net_DB2.Models;

namespace ApiRest_Net_DB2.Controllers
{
    public class ContactosController : ApiController
    {
        // GET api/values
        public IHttpActionResult GetContactos()
        {
            List<Contacto> oContacto = new List<Contacto>();
            string connString = ConfigurationManager.ConnectionStrings["PUB400"].ConnectionString;
            iDB2Connection connection = new iDB2Connection(connString);
            string query = "select * from davidec1.contactos";
            iDB2Command db2Command = new iDB2Command();
            db2Command.Connection = connection;
            db2Command.CommandText = query;
            connection.Open();

            iDB2DataReader reader = db2Command.ExecuteReader();

            while(reader.Read())
            {
                oContacto.Add(new Contacto()
                {
                    Id = Convert.ToInt32(reader.GetValue(0).ToString()),
                    Nombre = reader.GetValue(1).ToString(),
                    Telefono = reader.GetValue(2).ToString(),
                    Correo = reader.GetValue(3).ToString(),
                    Edad = Convert.ToInt32(reader.GetValue(4).ToString())
                });
            }
            return Ok(oContacto);

        }


        // GET api/values/5
        public IHttpActionResult GetContactosById(int id)
        {
            List<Contacto> oContacto = new List<Contacto>();
            string connString = ConfigurationManager.ConnectionStrings["PUB400"].ConnectionString;
            iDB2Connection connection = new iDB2Connection(connString);
            string query = "select * from davidec1.contactos where id = @id";
            iDB2Command db2Command = new iDB2Command();
            db2Command.Connection = connection;
            db2Command.CommandText = query;
            db2Command.Parameters.AddWithValue("@id", id);
            connection.Open();

            iDB2DataReader reader = db2Command.ExecuteReader();

            while (reader.Read())
            {
                oContacto.Add(new Contacto()
                {
                    Id = Convert.ToInt32(reader.GetValue(0).ToString()),
                    Nombre = reader.GetValue(1).ToString(),
                    Telefono = reader.GetValue(2).ToString(),
                    Correo = reader.GetValue(3).ToString(),
                    Edad = Convert.ToInt32(reader.GetValue(4).ToString())
                });
            }
            return Ok(oContacto);

        }

        // POST api/values
        public void Post([FromBody] Contacto oContacto)
        {
            string connString = ConfigurationManager.ConnectionStrings["PUB400"].ConnectionString;
            iDB2Connection connection = new iDB2Connection(connString);
            connection.Open();
            iDB2Command db2Command = new iDB2Command();

            string query = "INSERT INTO DAVIDEC1.CONTACTOS " +
                "(NOMBRE, TELEFONO, CORREO, EDAD) " +
                "VALUES (@nombre, @telefono, @correo, @edad)";

            db2Command.Connection = connection;
            db2Command.CommandText = query;
            db2Command.Parameters.Add(new iDB2Parameter("@nombre", oContacto.Nombre));
            db2Command.Parameters.Add(new iDB2Parameter("@telefono", oContacto.Telefono));
            db2Command.Parameters.Add(new iDB2Parameter("@correo", oContacto.Correo));
            db2Command.Parameters.Add(new iDB2Parameter("@edad", oContacto.Edad));
            db2Command.ExecuteNonQuery();

            connection.Close();

        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Contacto oContacto)
        {
            string connString = ConfigurationManager.ConnectionStrings["PUB400"].ConnectionString;
            iDB2Connection connection = new iDB2Connection(connString);
            connection.Open();
            iDB2Command db2Command = new iDB2Command();

            string query = "UPDATE DAVIDEC1.CONTACTOS " +
                "SET NOMBRE = @nombre , " +
                "TELEFONO = @telefono , " +
                "CORREO = @correo , " +
                "EDAD = @edad " +
                "WHERE ID = @id";

            db2Command.Connection = connection;
            db2Command.CommandText = query;
            db2Command.Parameters.Add(new iDB2Parameter("@nombre", oContacto.Nombre));
            db2Command.Parameters.Add(new iDB2Parameter("@telefono", oContacto.Telefono));
            db2Command.Parameters.Add(new iDB2Parameter("@correo", oContacto.Correo));
            db2Command.Parameters.Add(new iDB2Parameter("@edad", oContacto.Edad));
            db2Command.Parameters.Add(new iDB2Parameter("@id", id));
            db2Command.ExecuteNonQuery();

            connection.Close();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            string connString = ConfigurationManager.ConnectionStrings["PUB400"].ConnectionString;
            iDB2Connection connection = new iDB2Connection(connString);
            connection.Open();
            iDB2Command db2Command = new iDB2Command();

            string query = "DELETE FROM DAVIDEC1.CONTACTOS " +
                "WHERE ID = @id";

            db2Command.Connection = connection;
            db2Command.CommandText = query;
            db2Command.Parameters.Add(new iDB2Parameter("@id", id));
            db2Command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
