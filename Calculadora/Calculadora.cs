namespace EspacioCalculadora;

public enum TipoOperacion
{
    Suma,
    Resta,
    Multiplicacion,
    Division,
    Limpiar
}
public class Operacion
{
    private double resultadoAnterior;
    private double nuevoValor;
    private TipoOperacion operacion;
    public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacion) {
        this.operacion = operacion;
        this.nuevoValor = nuevoValor;
        this.resultadoAnterior = resultadoAnterior;
    }
    public TipoOperacion Tipo { get => operacion; set => operacion = value; }


    public double Resultado
    {
        get
        {
            switch (operacion)
            {
                case TipoOperacion.Suma:
                    return resultadoAnterior + nuevoValor;
                case TipoOperacion.Resta:
                    return resultadoAnterior - nuevoValor;
                case TipoOperacion.Multiplicacion:
                    return resultadoAnterior * nuevoValor;
                case TipoOperacion.Division:
                    if (nuevoValor != 0)
                    {
                        return resultadoAnterior / nuevoValor;
                    }
                    else
                    {
                        return 0;
                    }
                case TipoOperacion.Limpiar:
                    return 0;
                default:
                    return 0;
            }
        }
    }
    public double NuevoValor { get => nuevoValor; }

    public double ResultadoAnterior { get => resultadoAnterior; set => resultadoAnterior = value; }

    public TipoOperacion OperacionRealizada { get => operacion; }
}
public class Calculadora
{
    private List<Operacion> historial;
    private double resultado;

    public double Resultado { get => resultado; }

    public Calculadora()
    {
        historial = new List<Operacion>();
        resultado = 0;
    }
    public void Sumar(double termino)
    {
        var operacion = new Operacion(resultado, termino, TipoOperacion.Suma);
        historial.Add(operacion);
        resultado = operacion.Resultado;
    }
    public void Restar(double termino)
    {
        var operacion = new Operacion(resultado, termino, TipoOperacion.Resta);
        historial.Add(operacion);
        resultado = operacion.Resultado;
    }
    public void Multiplicacion(double termino)
    {
        var operacion = new Operacion(resultado, termino, TipoOperacion.Multiplicacion);
        historial.Add(operacion);
        resultado = operacion.Resultado;
    }
    public void Division(double termino)
    {
        var operacion = new Operacion(resultado, termino, TipoOperacion.Division);
        historial.Add(operacion);
        resultado = operacion.Resultado;
    }
     public void Limpiar()
    {
        historial.Add(new Operacion(resultado, 0, TipoOperacion.Limpiar));
        resultado = 0;
    }
    public List<Operacion> Historial { get => historial; }

    public List<Operacion> ObtenerHistorial()
    {
        return historial;
    }
}