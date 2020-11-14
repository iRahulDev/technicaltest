using Eagle_Eye.Models;
using System.Collections.Generic;

namespace Eagle_Eye.Data
{
    public interface IMovieRepository
    {
        string GetMovies();
        string GetMovieById(int id);
        void AddMovie(Movie movie);
    }
}