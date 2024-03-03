
string usuarioPredefinido = "admin";
string contraseñaPredefinida = "12345";

int intentosRestantes = 3;

while (intentosRestantes > 0)
{
    
    Console.WriteLine("Ingrese su nombre de usuario:");
    string usuarioIngresado = Console.ReadLine();

    Console.WriteLine("Ingrese su contraseña:");
    string contraseñaIngresada = Console.ReadLine();

    if (usuarioIngresado == usuarioPredefinido && contraseñaIngresada == contraseñaPredefinida)
    {
        Console.WriteLine("Acceso concedido!");
        break;
    }
    else
    {
        Console.WriteLine("Nombre de usuario o contraseña incorrectos. Intentos restantes: "+intentosRestantes);
        intentosRestantes--;
    }
}


if (intentosRestantes == 0)
{
    Console.WriteLine("Acceso denegado. Se agotaron los intentos.");
}
