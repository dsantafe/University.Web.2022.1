using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Repositories;
using University.BL.Repositories.Implements;

namespace University.Test
{
    internal class Program
    {
        private static readonly UniversityModel university = new UniversityModel();
        private static readonly ICourseRepository courseRepository
            = new CourseRepository(new UniversityModel());
        static void Main(string[] args)
        {
            //var courses = university.Course.ToList();
            //var courses2 = courseRepository.GetAll().Result;
            //foreach (var item in courses2)
            //{
            //    Console.WriteLine($"{item.Title} {item.Credits}");
            //}

            //Mostrar en consola los 3 libros con más ventas.
            //Mostrar en consola los 3 libros con menos ventas.
            //Mostrar en consola el autor con más libros publicados.
            //Mostrar en consola el autor y la cantidad de libros publicados.
            //Mostrar en consola los libros publicados hace menos de 50 años.
            //Mostrar en consola el libro más viejo.
            //Mostrar en consola los autores que tengan un libro que comience con 'El'.

            var books = Book.Books();
            var authors = Author.Authors();

            //Linq
            var ex1 = books.OrderByDescending(x => x.Sales).Take(3).ToList();
            var ex2 = books.OrderBy(x => x.Sales).Take(3).ToList();

            foreach (var item in ex2)
            {
                Console.WriteLine($"{item.Title} - {item.Sales}");
            }

            Console.ReadKey();
        }
    }
}
