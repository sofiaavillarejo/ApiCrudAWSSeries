using System.Reflection.Metadata.Ecma335;
using ApiCrudAWSSeries.Models;
using Microsoft.EntityFrameworkCore;
using MvcAWSSeriesELB.Data;

namespace MvcAWSSeriesELB.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task CreateSerieAsync(string nombre, string image, int anyo)
        {
            Serie s = new Serie
            {
                IdSerie = await this.context.Series.MaxAsync(s => s.IdSerie) + 1,
                Nombre = nombre,
                Imagen = image,
                Anyo = anyo
            };
            await this.context.AddAsync(s);
            await this.context.SaveChangesAsync();
        }

        public async Task<Serie> FindSerieAsync(int idSerie)
        {
            return await this.context.Series.FirstOrDefaultAsync(s => s.IdSerie == idSerie);
        }
        public async Task UpdateSerieAsync(int idSerie, string nombre, string image, int anyo)
        {
            Serie serie = await this.FindSerieAsync(idSerie);
            serie.Nombre = nombre;
            serie.Imagen = image;
            serie.Anyo = anyo;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteSerieAsync(int idSerie)
        {
            Serie serie = await this.FindSerieAsync(idSerie);
            this.context.Remove(serie);
            await this.context.SaveChangesAsync();
        }
    }
}
