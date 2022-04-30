using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoConsola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (BarDbEntities1 db = new BarDbEntities1())
            {
                Console.WriteLine("----- BIENVENIDO -----\n");
                Console.WriteLine("1. Desea ingresar un producto.");
                Console.WriteLine("2. Desea actualiazar un producto.");
                Console.WriteLine("3. Desea eliminar un producto\n");
                Console.WriteLine("Seleccione la opcion segun el proceso que desea realizar");
                int opc = Convert.ToInt32(Console.ReadLine());

                Producto producto = new Producto();
                var lst = db.Productoes;

                if (opc == 1)
                {
                    
                    Console.WriteLine("Escriba un nombre");
                    producto.nomProd = Console.ReadLine();
                    Console.WriteLine("Escriba una descripcion del producto");
                    producto.descripcion = Console.ReadLine();
                    Console.WriteLine("Escriba su precio");
                    producto.precio = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Escriba la cantidad");
                    producto.cantidad = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Estado");
                    producto.estado = Convert.ToInt32(Console.ReadLine());
                    db.Productoes.Add(producto);
                    db.SaveChanges();
                    Console.WriteLine("Presione cualquier tecla para mostrar registro");

                    
                    Console.WriteLine("\n-------MOSTRANDO REGISTROS--------");

                    foreach (var oProducto in lst)
                    {
                        //estamos mostrando nombre, pero podemos cambiar a cual deseemos mostrar en consola
                        Console.WriteLine(oProducto.nomProd);

                    }
                    Console.ReadLine();
                }

                if (opc == 2)
                {
                    //actualizar
                    Console.WriteLine("Escriba el id del producto que desea actualizar");
                    int idprodc = Convert.ToInt32(Console.ReadLine());
                    producto = db.Productoes.Find(idprodc);
                    Console.WriteLine("Escriba el nuevo nombre de su producto");
                    producto.nomProd = Console.ReadLine();
                    db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();


                    Console.WriteLine("\n-------MOSTRANDO REGISTROS--------");
                    foreach (var oProducto in lst)
                    {

                        //estamos mostrando nombre, pero podemos cambiar a cual deseemos mostrar en consola
                        Console.WriteLine(oProducto.nomProd);

                    }
                    Console.ReadLine();

                }

                if (opc == 3)
                {
                    //ELIMINAR 
                    Console.WriteLine("Escriba el id del producto que desea eliminar");
                    int idprod = Convert.ToInt32(Console.ReadLine());
                    producto = db.Productoes.Find(idprod);
                    db.Productoes.Remove(producto);
                    db.SaveChanges();



                    Console.WriteLine("\n-------MOSTRANDO REGISTROS--------");

                    foreach (var oProducto in lst)
                    {
                        //estamos mostrando nombre, pero podemos cambiar a cual deseemos mostrar en consola
                        Console.WriteLine(oProducto.nomProd);

                    }
                    Console.ReadLine();

                }

                else
                    Console.WriteLine("Escriba una opcion valida!");
                    Console.ReadLine();
            }
        }
    }
}
