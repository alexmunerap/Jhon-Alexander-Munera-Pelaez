 /*El programa tomará la edad del usuario y determinará cuántos días y
semanas han transcurrido desde el año actual.*/

int edad = 0;
int diasTranscurridos = 0;
int semanasTranscurridas = 0;
int diasTotales = 365;

Console.WriteLine("Introduzca su edad: ");
edad = int.Parse(Console.ReadLine());

diasTranscurridos = edad * diasTotales;

int aniosBisiestos = edad / 4;
diasTranscurridos += aniosBisiestos;

semanasTranscurridas = diasTranscurridos / 7;

Console.WriteLine("Días transcurridos desde el año actual: " + diasTranscurridos);
Console.WriteLine("Semanas transcurridas desde el año actual: " + semanasTranscurridas);

if (DateTime.IsLeapYear(DateTime.Now.Year))
{
  diasTranscurridos++;
  Console.WriteLine("Se ha añadido un día adicional por ser año bisiesto.");
}

