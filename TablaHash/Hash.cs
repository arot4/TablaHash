/*
Nombre: Hash.cs
Autor: Alan Ortiz y Jose Palomares
Fecha: 13/10/2022
Descripcion: Estructura de la clase TablaHash
    La clase ofrece los siguientes metodos (varios de utileria pero para fines demostrativos se dejaron publicos):
    * Constructor de una Tabla Hash
    * Metodo de Copiado
    * Agregar un elemento a la Tabla Hash
    * Eliminar un elemento en la Tabla Hash
    * Busca un elemento en la Tabla Hash
    * Vacia la Tabla Hash (Metodo utilizado visualmente para conocer los elementos vacios)
    * Imprimir la Tabla Hash
    * Obtener la capacidad (Solo para pruebas y metodos internos)
    * Suma ASCII (Metodo utilizado por la funcion hash para crear un numero mayor que despues sera reducido por la Hash para que entre en el Array)
    * Hash (Utilizada para reducir la Suma ASCII que crece exponencialmente para entrar dentro del Array)
    * Redimensionar (Funcion utilizada para guardar los valores de la tabla mientras se cambia su capacidad y con ello su distribucion)
    * Verificar Capacidad (Metodo auxiliar utilizado para que la capacidad no sobrepase el 75 por ciento de la tabla)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TablaHash
{
    public class TablaHash
    {
        private int capacidad;
        private int numElem;
        string[] tabla;

        /** \brief Constructor de la clase TablaHash*/
        public TablaHash()
        {
            capacidad = 10;
            tabla = new string[capacidad];
            Vaciar();
        }
        /** \brief Agrega un nuevo elemento en la TablaHash
        *
        * \param valor es el elemento que se le va a agregar a la TablaHash
        */
        public void Agregar(string entrada)
        {
            int hasheo = Hash(entrada);
            while(tabla[hasheo] != null)
            {
                if(tabla[hasheo] == entrada) return;
                hasheo++;
                if(hasheo >= capacidad) hasheo = 0;
            }
            tabla[hasheo] = entrada;
            numElem++;
            if (VerificarCapacidad() > 75) Redimensionar(capacidad * 2);
        }
        /** \brief Busca un elemento en la TablaHash
        *
        *\return int con el valor de la posicion del elemento al ser encontrado o -1 en caso de no ser encontrado
        */
        public int Buscar(string entrada)
        {
            int hasheo = Hash(entrada);
            if (tabla[hasheo] == null) return -1;
            while(tabla[hasheo] != null)
            {
                if(tabla[hasheo] == entrada) return hasheo;
                hasheo++;
            }
            return -1;
        }
        /** \brief Elimina un elemento en la TablaHash
        *
        *\return int con el valor de la posicion del elemento al ser eliminado o -1 en caso de no ser eliminado
        */
        public int Eliminar(string entrada)
        {
            int eliminacion = Buscar(entrada);
            if(eliminacion == -1)
            {
                return -1;
            }
            else
            {
                tabla[eliminacion] = null;
                numElem--;
                return eliminacion;
            }
        }
        /** \brief Vacia los valores en la TablaHash */
        private void Vaciar()
        {
            for (int i = 0; i < capacidad; i++) tabla[i] = null;
            numElem = 0;
        }
        /** \brief Imprime la TablaHash*/
        public void ImprimirTabla()
        {
            for (int i = 0; i < capacidad; i++) Console.WriteLine($"Elemento[{i}]: {tabla[i]}");
        }
        /** \brief Obtiene la cantidad de elementos que puede almacenar la TablaHash
        *
        * \return Int con el numero de la capacidad de la TablaHash
        */
        public int ObtenerCapacidad()
        {
            return capacidad;
        }
        //Metodos de utileria
        /** \brief Metodo utilizado para verificar que la capacidad de la TablaHash se mantenga por debado del 80 por ciento
        *
        * \return Int que debe ser menor a 80 al momento de agregar un elemento o se redimensionara la TablaHash
        */
        public double VerificarCapacidad()
        {
            double verificar = ((double)numElem/capacidad) * 100;
            return verificar;
        }
        /** \brief Redimensiona y acomoda nuevamente los valores que estaban en la tabla antes de cambiar su capacidad*/
        public void Redimensionar(int nCapacidad)
        {
            string[] aux = CopiarTabla(tabla);
            int capAux = capacidad;
            capacidad = nCapacidad;
            tabla = new string[capacidad];
            Vaciar();
            for (int i = 0; i < capAux; i++)
            {
                if(aux[i] != null)
                {
                    Agregar(aux[i]);
                }
            }
        }
        /** \brief Hace una copia de una tabla tipo array que funciona dentro de la clase
         *
         * \return La copia de la tabla indice por indice de cualquier tabla
         */
        public string[] CopiarTabla(string[] t)
        {
            string[] aux = new string[t.Length];
            for (int i = 0; i < t.Length; i++)
            {
                aux[i] = t[i];
            }
            return aux;
        }

        /** \brief Funcion Hash que converte el numero dado en este caso el resultado de SumaASCII y lo reduce al modulo de la capacidad
        *
        * \return Int con un numero ya reducido que no puede ser menor a 0 o mayor a la capacidad
        */
        public int Hash(string entrada)
        {
            int indice = SumaASCII(entrada) % capacidad;
            return indice;
        }
        /** \brief Convierte una cadena string en la suma de los numeros ASCII de sus caracteres
        *
        * \return Int con la suma de los numeros ASCII de los caracteres de un string
        */
        public int SumaASCII(string entrada)
        {
            int suma = 0;
            foreach (var x in entrada)
            {
                suma += (int)x;
            }
            return suma;
        }


    }
}
