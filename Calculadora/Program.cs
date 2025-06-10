﻿using EspacioCalculadora;
Calculadora Calc = new Calculadora();
int op;
string? texOp;
do
{
    Console.WriteLine("Ingrese el numero de Operacion");
    Console.WriteLine("1)Sumar");
    Console.WriteLine("2)Restar");
    Console.WriteLine("3)Multiplicar");
    Console.WriteLine("4)Dividir");
    Console.WriteLine("5)Limpiar Resultado");
    Console.WriteLine("6)Ver Historial");
    Console.WriteLine("0)Salir");
    texOp = Console.ReadLine();
    bool cambioOp = int.TryParse(texOp, out op);
    Console.WriteLine("Ingrese el numero a operar");
    string? numOp;
    double num;
    numOp = Console.ReadLine();
    bool cambio = double.TryParse(numOp, out num);
    if (cambioOp && cambio)
    {
        switch (op)
        {
            case 1:
                Calc.Sumar(num);
                break;
            case 2:
                Calc.Restar(num);
                break;
            case 3:
                Calc.Multiplicacion(num);
                break;
            case 4:
                Calc.Division(num);
                break;
            case 5:
                Calc.Limpiar();
                break;
            case 6:
                foreach (Operacion o in Calc.Historial)
                {
                    Console.WriteLine($"{o.ResultadoAnterior} {SimboloOperacion(o.Tipo)} {o.NuevoValor} = {o.Resultado}");
                }
                break;

        }
    }

} while (op != 0);
static string SimboloOperacion(TipoOperacion tipo)
{
    return tipo switch
    {
        TipoOperacion.Suma => "+",
        TipoOperacion.Resta => "-",
        TipoOperacion.Multiplicacion => "*",
        TipoOperacion.Division => "/",
        TipoOperacion.Limpiar => "LIMPIAR",
        _ => "?"
    };
}