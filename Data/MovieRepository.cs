using System.Collections.Generic;
using System.IO;
using Eagle_Eye.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Eagle_Eye.Data
{
    public class MovieRepository : IMovieRepository
    {
        List<Movie> _movie = null;
        public MovieRepository()
        {
            //if (Debugger.IsAttached == false) Debugger.Launch();
            _movie = new List<Movie>();
        }
        public string GetMovies()
        {
            List<Dictionary<string, string>> listObjResult = GetMoviedata();

            return JsonConvert.SerializeObject(listObjResult);
        }
        public string GetMovieById(int id)
        {
            List<Dictionary<string, string>> listObjResult = GetMoviedata();

            var listMovieById = new List<Dictionary<string, string>>();

            foreach (var item in listObjResult)
            {
                foreach (var pair in item)
                {
                    if (pair.Key == "MovieId" && int.Parse(pair.Value) == id)
                    {
                        listMovieById.Add(item);
                    }
                }
            }

            return JsonConvert.SerializeObject(listMovieById);
        }
        public void AddMovie(Movie movie)
        {
            Movie newMovie = new Movie()
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Language = movie.Language,
                Duration = movie.Duration,
                ReleaseYear = movie.ReleaseYear
            };

            _movie.Add(movie);
        }
        private static List<Dictionary<string, string>> GetMoviedata()
        {
            var path = @"Files/metadata.csv";
            var lines = File.ReadAllLines(path);
            var csv = new List<string[]>();

            foreach (string line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (int j = 1; j < properties.Length; j++)
                {
                    objResult.Add(properties[j], csv[i][j]);
                }

                listObjResult.Add(objResult);
            }

            return listObjResult;
        }
    }
}