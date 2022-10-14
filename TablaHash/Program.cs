/*
Nombre: Program.cs
Autor: Alan Ortiz y Jose Palomares
Fecha: 13/10/2022
Descripcion: Programa que utiliza una Tabla Hash con capacidad iniciar de 10 (es redimensionable) donde se pueden probar los siguientes metodos.
    *Agregar un elemento
    *Eliminar un elemento
    *Buscar un elemento
    *Imprimir para ver la lista completa (incluyendo los elementos vacios)
    *Redimensionar (con este metodo incluso se cambiar la funcion Hash de la tabla)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TablaHash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TablaHash tabla = new TablaHash();
            int option = 0;
            string valor;
            int capacidad;

            do
            {
                Console.WriteLine("________Menu:________");
                Console.WriteLine("0.- __Salir__");
                Console.WriteLine("1.- __Agregar__");
                Console.WriteLine("2.- __Eliminar__");
                Console.WriteLine("3.- __Buscar__");
                Console.WriteLine("4.- __Imprimir__");
                Console.WriteLine("5.- __Redimensionar__");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Ingrese un dato a la tabla: ");
                        valor = Console.ReadLine();
                        tabla.Agregar(valor);
                        Console.WriteLine($"Suma de sus valores ASCII: {tabla.SumaASCII(valor)}");
                        Console.WriteLine($"Utilizando la funcion Hash: {tabla.Hash(valor)}");
                        Console.WriteLine("Dato agregado exitosamente...");
                        Console.WriteLine($"Capacidad: {tabla.VerificarCapacidad()}");
                        break;
                    case 2:
                        Console.WriteLine("Ingrese el dato a eliminar en la tabla: ");
                        valor= Console.ReadLine();
                        if(tabla.Eliminar(valor) == -1)
                        {
                            Console.WriteLine($"No existe el dato: \"{valor}\" en la tabla");
                        }
                        else
                        {
                            Console.WriteLine($"\"{valor}\" ha sido eliminado exitosamente...");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Ingrese el dato a buscar en la tabla: ");
                        valor = Console.ReadLine();
                        if (tabla.Buscar(valor) == -1)
                        {
                            Console.WriteLine($"No existe el dato: \"{valor}\" en la tabla");
                        }
                        else
                        {
                            Console.WriteLine($"\"{valor}\" se ha encontrado exitosamente en la posicion: {tabla.Buscar(valor)}...");
                        }
                        break;
                    case 4:
                        tabla.ImprimirTabla();
                        break;
                    case 5:
                        Console.WriteLine("Ingrese la nueva capacidad de la tabla");
                        tabla.Redimensionar(capacidad = int.Parse(Console.ReadLine()));
                        tabla.ImprimirTabla();
                        break;
                    default:
                        if(option != 0) Console.WriteLine("Seleccione una opcion valida");
                        break;
                }
            } while (option != 0);
        }
    }
}
