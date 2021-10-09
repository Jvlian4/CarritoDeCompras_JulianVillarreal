using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoDeCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            String opcion;
            int opcionNumero = 0;
            int cantidadCamisas = 0;      
            float porcentajeDescuento = 0;

            do
            {
                float precioTotal = cantidadCamisas * 1000;
                Console.WriteLine("--Bienvenido--");
                
                //Menu
                Console.WriteLine("--Seleccione una opcion--");
                Console.WriteLine("__________________________________________");
                Console.WriteLine("1. Añadir una camisa al carrito de compras");
                Console.WriteLine("2. Eliminar camisa del carrito de compras");
                Console.WriteLine("3. Salir");
                Console.WriteLine("__________________________________________");
                Console.WriteLine("INFORMACION");
                Console.WriteLine("Precio unitario: $1.000");
                Console.WriteLine("Cantidad de camisas en el carro --> " + cantidadCamisas);               
                Console.WriteLine("Precio total sin descuento --> $" + precioTotal);
                Console.WriteLine("Tipo de descuento aplicado --> "+ calcularDescuento(cantidadCamisas)+ "%");
                porcentajeDescuento = calcularDescuento(cantidadCamisas);
                Console.WriteLine("Precio final con descuento --> $"+ obtenerMontoFinal(porcentajeDescuento, precioTotal));
                
                opcion = Console.ReadLine();
                opcionNumero = Convert.ToInt32(opcion);
 
                switch (opcionNumero) {
                    case 1:
                        Console.Clear();
                        contadorCamisas(ref cantidadCamisas);
                        break;

                    case 2:
                        Console.Clear();
                        eliminarCamisas(ref cantidadCamisas);
                        break;

                    case 3:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Seguro que desea salir?");
                            Console.WriteLine("S. Si");
                            Console.WriteLine("N. No");
                            opcion = Console.ReadLine();
                        } while ((opcion != "S") && (opcion != "N"));


                        if (opcion == "S")
                        {
                            Console.WriteLine("Saliendo");
                            break;
                        }
                        else
                        {
                            if (opcion == "N")
                            {
                                Console.WriteLine("Redirigiendo al menu...");
                                opcionNumero = 0;
                            }
                        }
                        break;
                }

            } while (opcionNumero != 3);
        }


        static public void contadorCamisas(ref int cantidadCamisas)//Envio valor por referencia para que el método sea capaz de cambiar el valor de la variable original
        {
            String almacenarCamisas;
            int sumadorCamisas;
            Console.WriteLine("Cuantas camisas quiere añadir al carro?");
            almacenarCamisas = Console.ReadLine();
            sumadorCamisas = Convert.ToInt32(almacenarCamisas);
            cantidadCamisas += sumadorCamisas;
        }

        static public void eliminarCamisas(ref int cantidadCamisas)
        {
            String almacenarCamisas;
            int camisasEliminadas;


            do //Ciclo para validar que las camisas eliminadas no sean mayor a las existentes
            {
                Console.WriteLine("Cuantas camisas quiere eliminar del carro? ...");
                almacenarCamisas = Console.ReadLine();
                camisasEliminadas = Convert.ToInt32(almacenarCamisas);
                if (camisasEliminadas > cantidadCamisas)
                {
                    Console.WriteLine("No puede eliminar mas camisas que las existentes. Intente nuevamente");
                }
                else
                {
                    cantidadCamisas -= camisasEliminadas;
                }
            } while (camisasEliminadas > cantidadCamisas);

        }

        static public float calcularDescuento(int cantidad)
        {
            float descuento = 0;

            if (cantidad >= 3 && cantidad <= 5)
            {
                descuento = 10;
            }
            else
            {
                if (cantidad > 5)
                {
                    descuento = 20;
                }
            }

            return descuento;
        }

        static public float obtenerMontoFinal(float porcentaje, float monto)
        {
            float montoDescuento = (porcentaje / 100) * monto;
            float montoFinal = monto - montoDescuento;
            return montoFinal;
        }


    }
}


