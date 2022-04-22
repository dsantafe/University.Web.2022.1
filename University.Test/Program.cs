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

            var books = Book.Books();
            var authors = Author.Authors();

            //Mostrar en consola los 3 libros con más ventas.
            var ex1 = books.OrderByDescending(x => x.Sales).Take(3).ToList();

            //Mostrar en consola los 3 libros con menos ventas.
            var ex2 = books.OrderBy(x => x.Sales).Take(3).ToList();

            //Mostrar en consola el autor con más libros publicados.
            var ex3 = from b in books
                      join a in authors on b.AuthorId equals a.AuthorId
                      group a by (a.AuthorId, a.Name) into query
                      orderby query.Count() descending
                      select query;

            var resultEx3 = ex3.FirstOrDefault();
            Console.WriteLine($"{resultEx3.Key.AuthorId} - {resultEx3.Key.Name} - {resultEx3.Count()}");
            Console.WriteLine();

            //Mostrar en consola el autor y la cantidad de libros publicados.
            foreach (var item in ex3)
            {
                Console.WriteLine($"{item.Key.Name} - {item.Count()}");
            }

            //Mostrar en consola los libros publicados hace menos de 50 años.
            var ex4 = books.Where(x => x.PublicationDate > DateTime.Now.AddYears(-50).Year).ToList();

            //Mostrar en consola el libro más viejo.
            var ex5 = books.OrderBy(x => x.PublicationDate).FirstOrDefault();

            #region Mostrar en consola los autores que tengan un libro que comience con 'El'.
            //Mostrar en consola los autores que tengan un libro que comience con 'El'.
            var ex6 = from b in books
                      join a in authors on b.AuthorId equals a.AuthorId
                      where b.Title.StartsWith("El")
                      select a; 
            #endregion

            Console.ReadKey();
        }
    }
}
