using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraA1
{
    class Program
    {
        class Nodo
        {
            public int dato;
            public Nodo siguiente;
            public Nodo atras;
        }
        static void Main(string[] args)
        {
            Nodo primero = null, ultimo = null;
            int opcion_menu = 0, nuevoDato, datoBuscado, datoModificacion, datoEliminar, precio;
            string titulo, clasificacion, fecha = "13/09/2021";
            float longitud;
            do
            {
                Console.Write("\n|---------------------------------------|");
                Console.Write("\n| INVENTARIO DE CINTAS                  |");
                Console.Write("\n|--------------------|------------------|");
                Console.Write("\n| 1. Insertar        | 4. Eliminar     |");
                Console.Write("\n|                    | 5. Mostrar P.U   |");
                Console.Write("\n| 2. Buscar  |                         |");
                Console.Write("\n| 3. Modificar | 6. Salir |");
                Console.Write("\n|--------------------|------------------|");
                Console.Write("\n\n Escoja una Opcion: ");
                opcion_menu = int.Parse(Console.ReadLine());
                switch (opcion_menu)
                {
                    case 1:

                        Console.Write("\n\nINSERTAR UN CODIGO AL INICIO DE LA LISTA \n\n");
                        Console.Write("Ingrese el codigo de la cinta: ");
                        nuevoDato = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el precio de la cinta: ");
                        precio = int.Parse(Console.ReadLine());
                        Console.WriteLine("Introduzca titulo de la cinta");
                        titulo = Console.ReadLine();
                        Console.WriteLine("Introduzca clasificacion de la cinta");
                        clasificacion = Console.ReadLine();
                        Console.WriteLine("la fecha de hoy es : " + fecha);
                        Console.WriteLine("Introduzca la longitud de la cinta");
                        longitud = float.Parse(Console.ReadLine());
                        insertarDatoAlInicio(ref primero, ref ultimo, nuevoDato);
                        break;
                    case 2:
                        Console.Write("\n\nBUSCAR UN CODIGO EN LA LISTA \n\n");
                        Console.Write("Ingrese el codigo de la cinta que se quiere buscar: ");
                        datoBuscado = int.Parse(Console.ReadLine());
                        buscarDato(primero, datoBuscado);
                        break;
                    case 3:
                        Console.Write("\n\nMODIFICAR UN CODIGO DE LA LISTA \n\n");
                        Console.Write(" Ingrese el codigo de la cinta que se quiere modificar: ");
                        datoBuscado = int.Parse(Console.ReadLine());
                        Console.Write("\n Ingrese el nuevo codigo con el que se va a reemplazar: ");
                        datoModificacion = int.Parse(Console.ReadLine());
                        modificarDato(primero, datoBuscado, datoModificacion);
                        break;
                    case 4:
                        Console.Write("\n\nELIMINAR UN CODIGO DE LA LISTA \n\n");
                        Console.Write("Ingrese el codigo que se quiere eliminar: ");
                        datoEliminar = int.Parse(Console.ReadLine());
                        eliminarDato(ref primero, ref ultimo, datoEliminar);
                        break;
                    case 5:
                        Console.Write("\n\nMOSTRAR LOS CODIGOS DE LAS CINTAS DESDE EL PRINCIPIO HASTA EL FINAL\n\n");
                        Console.Write("Los codigos de las cintas son: ");
                        MostrarListaPrimeroUltimo(primero);
                        break;
                    case 6:
                        Console.Write("\n\nPROGRAMA FINALIZADO\n\n");
                        break;

                    default:
                        Console.Write("\n\nOPCION INCORRECTA \n\n");
                        break;
                }
            } while (opcion_menu != 6);
        }

        static void insertarDatoAlInicio(ref Nodo primero, ref Nodo ultimo, int nuevoDato) //Ingreso antes del primero
        {
            Nodo nuevo = new Nodo();
            nuevo.dato = nuevoDato;
            nuevo.atras = null;
            nuevo.siguiente = primero;
            if (primero != null)
                primero.atras = nuevo;
            else
                ultimo = nuevo;
            primero = nuevo;



        }

        static void buscarDato(Nodo primero, int datoBuscado)
        {
            int contador = 0;
            if (primero != null)
            {
                while (primero != null)

                {
                    if (primero.dato == datoBuscado)
                        contador++;
                    primero = primero.siguiente;
                }
            }
            else
                Console.Write("\nLa lista no tiene datos.\n\n");
            if (contador == 0)
                Console.Write("\nEl codigo " + datoBuscado + " no fue encontrado.\n");
            else if (contador == 1)
                Console.Write("\nEl codigo " + datoBuscado + " fue encontrado " + contador + " vez.\n");
            else
                Console.Write("\nEl codigo " + datoBuscado + " fue encontrado " + contador + " veces.\n");
        }

        static void modificarDato(Nodo primero, int datoBuscado, int datoModificacion)
        {
            int contador = 0;
            if (primero != null)
            {
                while (primero != null)
                {
                    if (primero.dato == datoBuscado)
                    {
                        primero.dato = datoModificacion;
                        contador++;
                    }
                    primero = primero.siguiente;
                }
            }
            else
                Console.Write("\nLa lista no tiene datos \n\n");
            if (contador == 0)
                Console.Write("\nEl dato " + datoBuscado + " no fue encontrado.\n");
            else if (contador == 1)
                Console.Write("\nEl dato " + datoBuscado + " fue encontrado " + contador + " vez.\n");
            else
                Console.Write("\nEl dato " + datoBuscado + " fue encontrado " + contador + " veces.\n");
        }

        static void eliminarDato(ref Nodo primero, ref Nodo ultimo, int datoEliminar)
        {
            int contador = 0;
            Nodo actual = primero, anterior = null;
            if (actual != null)
            {
                while (actual != null)
                {
                    if (actual.dato == datoEliminar)
                    {
                        if (actual == primero)
                        {
                            if (primero == ultimo)
                            {
                                primero = null;
                                ultimo = null;
                            }
                            else
                            {
                                primero = primero.siguiente;
                                primero.atras = null;
                            }
                        }
                        else if (actual == ultimo)
                        {
                            anterior.siguiente = null;
                            ultimo = anterior;
                        }
                        else
                        {
                            anterior.siguiente = actual.siguiente;
                            actual.siguiente.atras = anterior;
                        }
                        contador++;
                    }
                    anterior = actual;
                    actual = actual.siguiente;
                }
                anterior = null;
            }
            else
                Console.Write("\n La lista no tiene datos\n\n");
            if (contador == 0)
                Console.Write("\nEl dato " + datoEliminar + " no fue encontrado.\n");
            else if (contador == 1)
                Console.Write("\nEl dato " + datoEliminar + " fue encontrado " + contador + " vez.\n");
            else
                Console.Write("\nEl dato " + datoEliminar + " fue encontrado " + contador + " veces.\n");
        }

        static void MostrarListaPrimeroUltimo(Nodo primero)
        {
            Console.Write("null <-> ");
            while (primero != null)
            {
                Console.Write(primero.dato + " <-> ");
                primero = primero.siguiente;
            }
            Console.WriteLine("null");
        }

    }
}
