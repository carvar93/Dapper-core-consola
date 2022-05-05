using Dapper;
using System;
using System.Data.SqlClient;
using System.Data;

namespace MiDapper
{
    class Program
    {
        static void Main(string[] args)
        {
         string connection =@"Data Source= DESKTOP-5AQTLJ4\SQLEXPRESS; initial Catalog=StudentDB; User Id=sa; Password=base1234";

            using (var db = new SqlConnection(connection))
            {


                //Insert
                // var sqlInsert = "insert into persona(id,nombre,edad) values(@id,@nombre,@edad )";
                //var result = db.Execute(sqlInsert, new { id = "457896", nombre = "Pablo", edad = 19 }) ;                 

                //Editar
                //var sqlEdit="Update persona set nombre=@nombre where id=@id";
                //var result = db.Execute(sqlEdit, new { nombre = "Pablo Marmol",id=457833 }); 


                //Consulta
                //  var sql = "select id,nombre,edad from persona";
                //  var lst = db.Query<Persona>(sql);


                ///Consulta con store procedure con parametros 
                var p = "ListarEstudiantePorEdad";

              var result = db.Query<Persona>(p, new { edad = 19 }, commandType: CommandType.StoredProcedure);
               
                foreach (Persona item in result)
                {
                    Console.WriteLine(item.Nombre);
                }
               

                /*
                foreach (var item in lst)
                {
                    Console.WriteLine(item.Nombre);
                }
                */
            }
        }
    }
}
