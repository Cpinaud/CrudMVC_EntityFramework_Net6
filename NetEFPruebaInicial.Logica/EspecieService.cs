using NetEFPruebaInicial.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFPruebaInicial.Logica
{
    public interface IEspecieService
    {
        List<Especie> ObtenerTodos(int tipoEspecie);
        void Insertar(Especie especie);
        void Eliminar(int id);
        void Modificar(Especie especie);
        List<Tipoespecie> ObtenerTE();

        Especie GetById(int id);

    }

    
    public class EspecieService : IEspecieService
    {
        private NetEFPruebaInicialContext _context;
        public EspecieService(NetEFPruebaInicialContext context)
        {
            _context = context; 
        }

        public void Eliminar(int id)
        {
            Especie esp= _context.Especies.Find(id);    
            _context.Especies.Remove(esp);
            _context.SaveChanges();
            
        }

        public Especie GetById(int id)
        {
            return _context.Especies.Find(id);
        }

        public void Insertar(Especie especie)
        {
            _context.Especies.Add(especie);
            _context.SaveChanges(); 
        }

        public void Modificar(Especie especie)
        {
            var esp= _context.Especies.Find(especie.IdEspecie);

            if (esp == null) return;
            
            esp.Nombre = especie.Nombre;
            esp.EdadPromedio = especie.EdadPromedio;
            esp.PesoPromedio = especie.PesoPromedio;
            esp.IdTipoEspecie = especie.IdTipoEspecie;
            _context.SaveChanges();
        }

        public List<Tipoespecie> ObtenerTE()
        {
            return _context.Tipoespecies.ToList();
        }

        public List<Especie> ObtenerTodos(int tipoEspecie)
        {
            if (tipoEspecie!=0)
            {
                return _context.Especies.Where(a => a.IdTipoEspecie == tipoEspecie).ToList();
            }
            else
            {
                return _context.Especies.ToList();
            }
            
        }
    }
}
