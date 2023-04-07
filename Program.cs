using System;
using PrimerParcialPOO.Core;

//El nombre de cada elemento "Producto" es a la vez su Código o Nombre de referencia (en este caso: guitElectrica1)
Producto guitElectrica1 = new Producto() {
    Nombre = "Guitar Electric Irvine Aet 350 Emg Grover Kingdom Music 037",
    Precio = 34999,
    Tipo = TipoInstrumento.GuitarraElectrica
};
Producto guitCriolla1 = new Producto() {
    Nombre = "Criolla Guitarra Fonseca 41kec Afinador Corte Musica Pilar",
    Precio = 47488,
    Tipo = TipoInstrumento.GuitarraCriolla
};
Producto soporte1 = new Producto() {
    Nombre = "Pie Soporte Guitarra Bajo De Piso Con Cuello Open Music",
    Precio = 1699,
    Tipo = TipoInstrumento.Soporte
};
Producto ukeleleSoprano1 = new Producto() {
    Nombre = "Ukelele Soprano Dy Uk Músicos Profesionales + Funda + Envío",
    Precio = 4129,
    Tipo = TipoInstrumento.Ukelele
};
Producto guitElectrica2 = new Producto() {
    Nombre = "Guitarra Eléctrica Accord Tiburón Fr Funda Kingdom Music 745",
    Precio = 34999,
    Tipo = TipoInstrumento.GuitarraElectrica
};


CalculoPrecioTotal calculo = new CalculoPrecioTotal();

calculo.CargarVenta(guitElectrica1, 14);        //489986
calculo.CargarVenta(guitCriolla1, 3);           //142464
calculo.CargarVenta(soporte1, 10);              //16990
calculo.CargarVenta(ukeleleSoprano1, 5);        //20645
calculo.CargarVenta(guitElectrica2, 8);         //279992
                                                
Console.WriteLine("El total de la factura es: $" + calculo.PrecioFinal());   //950077