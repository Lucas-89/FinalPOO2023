using Clases;

#region Obras Sociales
//creo obras sociales
var obraSocial1 = new ObraSocial("OSDE", 60);
var obraSocial2 = new ObraSocial("Swiss Medical", 70);
#endregion

#region Pacientes Sin Cobertura
//creo pacientes sin cobertura
var pacSC1 = new PacienteSinCobertura("German", "Sanchez", 123123);
pacSC1.Costo= 1000;

var pacSC2 = new PacienteSinCobertura("Luis", "Alvarez", 123456);
pacSC2.Costo= 3000; //esto lo puedo tomar desde el nomenclador? el costo si, pero el diagnostico no 
#endregion

#region Pacientes Con Cobertura
//creo pacientes con cobertura
var pacCO1 = new PacienteConCobertura("Javier", "Taza", 12121212, obraSocial1);
pacCO1.Costo=1000;
var pacCO2 = new PacienteConCobertura("Nicolas", "Gutierrez", 789789, obraSocial1);
pacCO2.Costo=1500; 

var pacCO3 = new PacienteConCobertura("Patricia", "Gimenez", 454656, obraSocial2);
pacCO3.Costo=1000;
var pacCO4 = new PacienteConCobertura("Maria", "Alonso", 44444, obraSocial2);
pacCO4.Costo=1500;
#endregion


#region nomencladores
// creo nomencladores
var nom1 = new Nomenclador("Apendicitis", pacSC1.Costo);
var nom2 = new Nomenclador("Fractura", 4500);
var nom3 = new Nomenclador("Deshidratacion", 2000);
var nom4 = new Nomenclador("Lesion Muscular", 2000);
#endregion




#region internaciones
//hago las internaciones
var internacion1 = new Internacion(pacSC1, nom1);
var internacion2 = new Internacion(pacCO1,nom2);
var internacion3 = new Internacion(pacCO2,nom3);
var internacion4 = new Internacion(pacCO4, nom4);
var internacion5 = new Internacion(pacSC2,nom4);

#endregion

#region Hopital
// creo un Hospital
var hosp1 = new Hospital();

//asigno la cantidad limite a la lista de internados
hosp1.Cantidad=4;

    

try
{
    hosp1.Internar(pacSC1,nom1);
    hosp1.Internar(pacCO1,nom2);
    hosp1.Internar(pacCO2,nom2);
    hosp1.Internar(pacCO3,nom2);
    hosp1.Internar(pacCO4, nom4);
    hosp1.Internar(pacCO3, nom4);

    // hosp1.Internar(internacion1);
    // hosp1.Internar(internacion2);
    // hosp1.Internar(internacion3);
    // hosp1.Internar(internacion4);
    // hosp1.Internar(internacion5);
}
catch (Exception ex)
{
    
    System.Console.WriteLine(ex.Message);
    System.Console.WriteLine();
}

#endregion



hosp1.Facturar(obraSocial1.Nombre);


System.Console.WriteLine("presione una tecla para continuar");
Console.ReadKey();
Console.Clear();

System.Console.WriteLine("Pruebo con la obra social Swiss");
System.Console.WriteLine();

hosp1.Facturar(obraSocial2.Nombre);

System.Console.WriteLine("presione una tecla para continuar");
Console.ReadKey();
Console.Clear();


System.Console.WriteLine("Metodo Mostrar Datos Personales");
System.Console.WriteLine();


System.Console.WriteLine(pacCO1.MostrarDatosPersonales());
System.Console.WriteLine(pacCO2.MostrarDatosPersonales());
System.Console.WriteLine(pacCO3.MostrarDatosPersonales());
System.Console.WriteLine(pacCO4.MostrarDatosPersonales());


Console.ReadKey();
Console.Clear();




