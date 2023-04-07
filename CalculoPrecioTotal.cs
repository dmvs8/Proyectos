using System;
using System.Collections.Generic;

namespace PrimerParcialPOO.Core
{
    public class CalculoPrecioTotal
    {
        private List<Venta> _Ventas { get; set; } = new List<Venta>();

        public void CargarVenta(Producto producto, int cantidad)
        {
            _Ventas.Add(new Venta()
            {
                Producto = producto,
                Cantidad = cantidad,
                TotalVenta = producto.Precio * cantidad
            });
        }

        public double PrecioFinal()
        {
            double total = 0;

            foreach (var item in _Ventas)
            {
                total += item.TotalVenta;
            }

            return total;
        }

    }
}
