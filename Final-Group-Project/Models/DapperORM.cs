using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;


namespace Final_Group_Project.Models
{

    public  class DapperORM
    {
        private string connectionString = @"Data Source = localhost, 1433; UserID = sa; Password = Mypasswordisgreat; Initial catalog= Movies;";


        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }


        public void Add(MovieModel newMovie)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO PRODUCTS(MovieID, Title, Genre, Rating, ReleaseDate, IMDbscore) VALUES(@MovieID, @Title, @Genre, @Rating, @ReleaseDate, @IMDbscore)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, newMovie);
            }
        }



        public IEnumerable<MovieModel> GetAllMovies()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM MovieModel";
                dbConnection.Open();
                return dbConnection.Query<MovieModel>(sQuery);
            }
        }



        public MovieModel GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM MovieModel WHERE MovieID=@Id";
                dbConnection.Open();
                return dbConnection.Query<MovieModel>(sQuery, new { Id = id}).FirstOrDefault();
            }

        }
    }
    
}












//public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
//{
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        con.Open();
//        con.Execute(procedureName, param, commandType: CommandType.StoredProcedure);

//    }


//}
//public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
//{
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        con.Open();
//        return (T)Convert.ChangeType(con.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
//    }

//}
//public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
//{
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        con.Open();
//        return con.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);

//    }
//}