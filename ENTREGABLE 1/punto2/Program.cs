/*Ejercicio 2: Número especial
Objetivo: Crear un programa que determine si un número ingresado por el usuario es
un número "especial". Un número es "especial" si cumple con los siguientes criterios:
1. Es divisible entre 5.
2. No es divisible entre 2 ni 3.*/
        Console.WriteLine("Ingrese un número: ");
        int numero = int.Parse(Console.ReadLine());
        bool esEspecial = true;

        if (numero % 2 == 0 || numero % 3 == 0)
        {
            esEspecial = false;
        }
 
        if (numero % 5 != 0)
        {
            esEspecial = false;
        }

        if (esEspecial)
        {
            Console.WriteLine("El número "+numero+ " es un número especial.");
        }
        else
        {
            Console.WriteLine("El número "+numero+ " no es un número especial.");
        }
    

