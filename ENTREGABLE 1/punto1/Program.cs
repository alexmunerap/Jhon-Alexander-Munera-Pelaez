/*Ejercicio 1: Calculadora de Fracciones
Objetivo: Crear una calculadora que maneje fracciones. El usuario ingresará dos
fracciones y un operador. La calculadora deberá realizar la operación. Debes manejar
sumas, restas, multiplicaciones y divisiones. Si el usuario intenta dividir entre cero,
deberás mostrar un mensaje de error*/
        
        Console.WriteLine("Ingrese la primera fracción (numerador/denominador):");
        string fraccion1 = Console.ReadLine();
        Console.WriteLine("Ingrese la segunda fracción (numerador/denominador):");
        string fraccion2 = Console.ReadLine();

        
        Console.WriteLine("Ingrese el operador (+, -, *, /):");
        string operador = Console.ReadLine();

     
        if (operador == "/" && fraccion2 == "0/1")
        {
            Console.WriteLine("Error: No se puede dividir por cero.");
            return;
        }

        
        string[] partes1 = fraccion1.Split('/');
        string[] partes2 = fraccion2.Split('/');

        int numerador1 = int.Parse(partes1[0]);
        int denominador1 = int.Parse(partes1[1]);
        int numerador2 = int.Parse(partes2[0]);
        int denominador2 = int.Parse(partes2[1]);

       
        int nuevoNumerador, nuevoDenominador;

        switch (operador)
        {
            case "+":
                nuevoNumerador = numerador1 * denominador2 + numerador2 * denominador1;
                nuevoDenominador = denominador1 * denominador2;
                break;
            case "-":
                nuevoNumerador = numerador1 * denominador2 - numerador2 * denominador1;
                nuevoDenominador = denominador1 * denominador2;
                break;
            case "*":
                nuevoNumerador = numerador1 * numerador2;
                nuevoDenominador = denominador1 * denominador2;
                break;
            case "/":
                nuevoNumerador = numerador1 * denominador2;
                nuevoDenominador = denominador1 * numerador2;
                break;
            default:
                throw new ArgumentException("Operador no válido.");
        }

        
        Console.WriteLine("Resultado: " + nuevoNumerador + "/" + nuevoDenominador);
    


