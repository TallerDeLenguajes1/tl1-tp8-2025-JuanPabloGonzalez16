using System.Security.Cryptography;
using tar;
string ? numT;
int num;
List<Tarea> tareasPendientes = new List<Tarea>();
Console.WriteLine("Ingrese la cantidad de tareas aleatorias");
numT = Console.ReadLine();
bool resultado = int.TryParse(numT, out num);
Random random = new Random();
//Creo N Tareas
if(resultado){
    for(int i=0;i<num;i++){
        int tareaID = i;
        string descripcion = "Tarea" + (i+1);
        int duracion = random.Next(1,120);

        tareasPendientes.Add(new Tarea{TareaID = tareaID,Descripcion =descripcion,Duracion = duracion});
    }
}
foreach(var tarea in tareasPendientes){
    Console.WriteLine("Id: " + tarea.TareaID);
    Console.WriteLine("Descripcion : " + tarea.Descripcion);
    Console.WriteLine("Duracion : " + tarea.Duracion + "minuto/s");
}
List<Tarea> tareasRealizadas = new List<Tarea>();
int operacion;
string? textOp;
do{
    Console.WriteLine("Elija la opcion");
    Console.WriteLine("1)Mover tareas pendientes a Realizadas");
    Console.WriteLine("2)Buscar en tareas pendientes una tarea por su descripcion");
    Console.WriteLine("3)Mostrar Tareas Pendientes y Tareas Realizadas");
    textOp = Console.ReadLine();
    bool sePaso = int.TryParse(textOp,out operacion);
    switch(operacion){
        case 1 : Console.WriteLine("Ingrese la cantidad de tareas que quiere mover a la lista de realizadas");
                 int numTareas;
                 string? textCantTareas = Console.ReadLine();
                 bool sps = int.TryParse(textCantTareas,out numTareas);
                 if(sps){
                    for(int j=0;j<numTareas;j++){
                        Console.WriteLine("Ingrese el id de la tarea");
                        string? idTar = Console.ReadLine();
                        int Tar;
                        if(int.TryParse(idTar, out Tar)){
                            moverTareas(tareasPendientes, tareasRealizadas, Tar);

                        }
                    }
                 } 
        break;
        case 2:  Console.WriteLine("Ingrese la descripcion de la tarea que desea buscar en su lista de tareas pendientes");
                 string? descripcion = Console.ReadLine();
                 buscarDescripcion(tareasPendientes,descripcion);
        break;
        case 3:Console.WriteLine("LISTADO DE TAREAS PENDIENTES");
                mostrarTareas(tareasPendientes);
                Console.WriteLine("LISTADO DE TAREAS REALIZADAS");
                mostrarTareas(tareasRealizadas);
            break;
    }
}while (operacion != 0);

void moverTareas(List<Tarea> tareasPendientes,List<Tarea> tareasRealizadas,int num){
    Tarea tareaSeleccionada = null;  
    foreach(var tarea in tareasPendientes){
        if(tarea.TareaID == num){
            tareaSeleccionada = tarea;  
        }
    }
    if(tareaSeleccionada != null){
        tareasRealizadas.Add(tareaSeleccionada);
        tareasPendientes.Remove(tareaSeleccionada);
    }
    
}
void mostrarTareas(List<Tarea> tareas){
    foreach(var tarea in tareas){
        Console.WriteLine("Id: " + tarea.TareaID);
        Console.WriteLine("Descripcion : " + tarea.Descripcion);
       Console.WriteLine("Duracion : " + tarea.Duracion + "minuto/s");
    }
}
void buscarDescripcion(List<Tarea> tareasPendientes, string? descripcion){
    foreach(var tarea in tareasPendientes){
        if(descripcion == tarea.Descripcion){
            Console.WriteLine("Tarea: " + tarea.Descripcion);
            Console.WriteLine("Id: " + tarea.TareaID);
            Console.WriteLine("Duracion: " + tarea.Duracion);
        }
    }
} 