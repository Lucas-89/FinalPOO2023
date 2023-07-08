namespace Clases;
// 1.La clase Paciente no puede ser instanciada y contiene las propiedades Nombre,
//      Apellido y Dni. Todos deben ser inicializados en el constructor.

public abstract class Paciente{
    public Paciente(string nombre, string apellido, int dni){
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.DNI = dni;
    }
    public string Nombre{get;set;}
    public string Apellido{get;set;}
    public int DNI{get;set;}
    public double Costo{get;set;}

    // 2. Debe contener un método MostrarDatosPersonales que devuelve un string con los datos 
    //      del paciente. Este método debe dar la posibilidad a clases derivadas de dar un nuevo 
    //      comportamiento si se requiere.
    public virtual string MostrarDatosPersonales(){
        return ("Paciente: " + this.Nombre + " " + this.Apellido+ ", DNI: "+ this.DNI );
    }
    
    // Un método Pagar que devuelve un valor del tipo double y recibe el parámetro costo del tipo double. 
    // Este método obligara a las clases derivadas a dar una implentación.
    public abstract double Pagar(double Costo);
}

// 4. La clase ObraSocial que contiene las propiedades Nombre (string) y Porcentaje (int) que 
//      deben ser inicializadas en el constructor.

public class ObraSocial{
    public ObraSocial(string nombre, int porcentaje){
        this.Nombre = nombre;
        this.Porcentaje = porcentaje;
    }
    public string Nombre{get;set;}
    public int Porcentaje{get;set;} 

}
// 5. La clase PacienteSinCobertura hereda de Paciente
public class PacienteSinCobertura : Paciente
{
    public PacienteSinCobertura(string nombre, string apellido, int dni) : base(nombre, apellido, dni)
    {
    }
    public override string MostrarDatosPersonales()
    {
        return base.MostrarDatosPersonales();
    }

   
// y en el método Pagar devolverá el costo (ya que no tiene ningún tipo de descuento)
    public override double Pagar(double Costo)
    {
        return Costo;
    }
}
// 6. La clase PacienteConCobertura hereda de Paciente y contiene una propiedad del tipo 
//       ObraSocial que deber ser inicializada en el constructor
public class PacienteConCobertura : Paciente{
    public PacienteConCobertura(string nombre, string apellido, int dni, ObraSocial obra): base(nombre, apellido, dni){
        this.ObraSocial = obra;
    }
    public ObraSocial ObraSocial{get;set;}

// En el método Pagar debe devolver el valor que debe abonar el paciente teniendo en cuenta 
//      el porcentaje de descuento de la obra social. Ej Porcentaje 50 %, el costo es 150 entonces 
//      el paciente debe abonar 75.
    public override double Pagar(double Costo)
    {
        double procentajeDescuento =this.ObraSocial.Porcentaje;
        double descuento = (Costo * ( procentajeDescuento/100));
        double costoFinal = (Costo - descuento);
        return costoFinal;
    }

    public override string MostrarDatosPersonales()
    {
        return base.MostrarDatosPersonales();
    }



}
// 7. La clase Nomenclador tiene las propiedades Diagnostico (string) y Costo (double), ambas deben 
//      ser inicializadas en el constructor.
public class Nomenclador{
    public Nomenclador(string diagnostico, double costo){
        this.Diagnostico = diagnostico;
        this.Costo = costo;
    }
    public string Diagnostico{get;set;}
    public double Costo{get;set;}
    // Debe contener un método MostrarNomenclador que debe devolver un string con el Diagnostico y el costo.
    public string MostrarNomenclador(){
        return ("Diagnostico: " + this.Diagnostico + ", Costo: " + this.Costo);
    }
}
// 8. La clase Internacion que contiene un Paciente y un Nomenclador que deben ser inicializados 
//      en el constructor. 
public class Internacion{
    public Internacion(Paciente pac, Nomenclador nomenclador){
        this.PacienteInternado = pac;
        this.NomencladorInternado = nomenclador;
    }
    public Paciente PacienteInternado{get;set;}
    public Nomenclador NomencladorInternado{get;set;}
}


// 9. La clase Hospital debe tener una lista del tipo Internacion. Una propiedad Cantidad(int). 
public class Hospital{
    private List<Internacion> ListaInternados = new List<Internacion>();
    public int Cantidad{get;set;}
    // 10. Un método Internar que no devuelve valores, recibe un Paciente y un Nomenclador. 
    // Debe agregar hasta la Cantidad (propiedad) permitida. Si supera el número de internados 
    // posibles debe lanzar una excepción “No hay más lugar”. En caso contrario agregar a la lista 
    // de internados.

    public void Internar(Paciente pac, Nomenclador nom){
        if (!(ListaInternados.Count >= Cantidad))                   //mientras la cantidad en la lista sea menor a la cantidad maxima
        {
            Internacion nuevaInternacion = new Internacion(pac,nom);
            ListaInternados.Add(nuevaInternacion);
            System.Console.WriteLine("Paciente agregado");
        }else{                                                      //si es mayor se lanza la excepcion    
            throw new Exception ("La lista de pacientes esta llena. Cantidad de pacientes: " + Cantidad);
        }
    }


     // 11. Un método Facturar que recibe un string con la obra social. Este método debe imprimir 
    // en pantalla los Pacientes que pertenezcan a la obra social que fue pasada por parámetro.
    public void Facturar(string nombreOS){
        Console.WriteLine("Obra Social: " + nombreOS);
        Console.WriteLine();
        
        foreach (var item in ListaInternados)
        {
            if (item.PacienteInternado.GetType() == typeof(PacienteConCobertura))
            {
                var pacienteCubierto = (PacienteConCobertura)item.PacienteInternado;
                if (pacienteCubierto.ObraSocial.Nombre ==nombreOS)
                {
                    
                    System.Console.WriteLine(pacienteCubierto.MostrarDatosPersonales());
                    System.Console.WriteLine("Diagnostico: " + item.NomencladorInternado.Diagnostico);
                    System.Console.WriteLine("Costo del tratamiento: " + pacienteCubierto.Costo);
                    System.Console.WriteLine("Costo con Cobertura: " + pacienteCubierto.Pagar(pacienteCubierto.Costo));
                    System.Console.WriteLine("------------------------------");
                }
            }
        }
    }

    

}
