using System;

namespace Entidades
{
    public class Articulo
    {
        #region Atributos
        private long _id;
        private string _denominacion;
        private string _codigoBarras;
        private string _criticidad;
        private string _unidad;
        private int _stockGlobal;
        private bool _a1_PuntoCritico;
        private int _a1_PuntoCriticoLimite;
        private bool _a1_PuntoCriticoAlertado;
        private bool _a1_PuntoMinimo;
        private int _a1_PuntoMinimoLimite;
        private bool _a1_PuntoMinimoAlertado;
        private int _a1_PuntoMaximoLimite;
        private DateTime _a1_FechaIngreso;
        private int _a1_Stock;
        private bool _a2_PuntoCritico;
        private int _a2_PuntoCriticoLimite;
        private bool _a2_PuntoCriticoAlertado;
        private bool _a2_PuntoMinimo;
        private int _a2_PuntoMinimoLimite;
        private bool _a2_PuntoMinimoAlertado;
        private int _a2_PuntoMaximoLimite;
        private DateTime _a2_FechaIngreso;
        private int _a2_Stock;
        private double _costoBruto;
        private string _costoAlicuotaIVA;
        private double _costoBaseIVA;
        private double _costoNeto;
        private double _utilidad;
        private double _margenBruto;
        private double _precioBruto;
        private string _estado;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public string CodigoBarras { get => _codigoBarras; set => _codigoBarras = value; }
        public string Criticidad { get => _criticidad; set => _criticidad = value; }
        public string Unidad { get => _unidad; set => _unidad = value; }
        public int StockGlobal { get => _stockGlobal; set => _stockGlobal = value; }
        public bool A1_PuntoCritico { get => _a1_PuntoCritico; set => _a1_PuntoCritico = value; }
        public int A1_PuntoCriticoLimite { get => _a1_PuntoCriticoLimite; set => _a1_PuntoCriticoLimite = value; }
        public bool A1_PuntoCriticoAlertado { get => _a1_PuntoCriticoAlertado; set => _a1_PuntoCriticoAlertado = value; }
        public bool A1_PuntoMinimo { get => _a1_PuntoMinimo; set => _a1_PuntoMinimo = value; }
        public int A1_PuntoMinimoLimite { get => _a1_PuntoMinimoLimite; set => _a1_PuntoMinimoLimite = value; }
        public bool A1_PuntoMinimoAlertado { get => _a1_PuntoMinimoAlertado; set => _a1_PuntoMinimoAlertado = value; }
        public int A1_PuntoMaximoLimite { get => _a1_PuntoMaximoLimite; set => _a1_PuntoMaximoLimite = value; }
        public DateTime A1_FechaIngreso { get => _a1_FechaIngreso; set => _a1_FechaIngreso = value; }
        public int A1_Stock { get => _a1_Stock; set => _a1_Stock = value; }
        public bool A2_PuntoCritico { get => _a2_PuntoCritico; set => _a2_PuntoCritico = value; }
        public int A2_PuntoCriticoLimite { get => _a2_PuntoCriticoLimite; set => _a2_PuntoCriticoLimite = value; }
        public bool A2_PuntoCriticoAlertado { get => _a2_PuntoCriticoAlertado; set => _a2_PuntoCriticoAlertado = value; }
        public bool A2_PuntoMinimo { get => _a2_PuntoMinimo; set => _a2_PuntoMinimo = value; }
        public int A2_PuntoMinimoLimite { get => _a2_PuntoMinimoLimite; set => _a2_PuntoMinimoLimite = value; }
        public bool A2_PuntoMinimoAlertado { get => _a2_PuntoMinimoAlertado; set => _a2_PuntoMinimoAlertado = value; }
        public int A2_PuntoMaximoLimite { get => _a2_PuntoMaximoLimite; set => _a2_PuntoMaximoLimite = value; }
        public DateTime A2_FechaIngreso { get => _a2_FechaIngreso; set => _a2_FechaIngreso = value; }
        public int A2_Stock { get => _a2_Stock; set => _a2_Stock = value; }
        public double CostoBruto { get => _costoBruto; set => _costoBruto = value; }
        public string CostoAlicuotaIVA { get => _costoAlicuotaIVA; set => _costoAlicuotaIVA = value; }
        public double CostoBaseIVA { get => _costoBaseIVA; set => _costoBaseIVA = value; }
        public double CostoNeto { get => _costoNeto; set => _costoNeto = value; }
        public double Utilidad { get => _utilidad; set => _utilidad = value; }
        public double MargenBruto { get => _margenBruto; set => _margenBruto = value; }
        public double PrecioBruto { get => _precioBruto; set => _precioBruto = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public Articulo() { }
        public Articulo(long id, string denominacion, int a1_Stock, int a2_Stock) //Constructor parcial del Catálogo 
        {
            _id = id;
            _denominacion = denominacion;
            _a1_Stock = a1_Stock;
            _a2_Stock = a2_Stock;
        }
        public Articulo(long id, string denominacion, string codigoBarras, string criticidad, string unidad, int stockGlobal, bool a1_PuntoCritico, int a1_PuntoCriticoLimite, bool a1_PuntoCriticoAlertado, bool a1_PuntoMinimo, int a1_PuntoMinimoLimite, bool a1_PuntoMinimoAlertado, int a1_PuntoMaximoLimite, DateTime a1_FechaIngreso, int a1_Stock, bool a2_PuntoCritico, int a2_PuntoCriticoLimite, bool a2_PuntoCriticoAlertado, bool a2_PuntoMinimo, int a2_PuntoMinimoLimite, bool a2_PuntoMinimoAlertado, int a2_PuntoMaximoLimite, DateTime a2_FechaIngreso, int a2_Stock, double costoBruto, string costoAlicuotaIVA, double costoBaseIVA, double costoNeto, double utilidad, double margenBruto, double precioBruto, string estado, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _denominacion = denominacion;
            _codigoBarras = codigoBarras;
            _criticidad = criticidad;
            _unidad = unidad;
            _stockGlobal = stockGlobal;
            _a1_PuntoCritico = a1_PuntoCritico;
            _a1_PuntoCriticoLimite = a1_PuntoCriticoLimite;
            _a1_PuntoCriticoAlertado = a1_PuntoCriticoAlertado;
            _a1_PuntoMinimo = a1_PuntoMinimo;
            _a1_PuntoMinimoLimite = a1_PuntoMinimoLimite;
            _a1_PuntoMinimoAlertado = a1_PuntoMinimoAlertado;
            _a1_PuntoMaximoLimite = a1_PuntoMaximoLimite;
            _a1_FechaIngreso = a1_FechaIngreso;
            _a1_Stock = a1_Stock;
            _a2_PuntoCritico = a2_PuntoCritico;
            _a2_PuntoCriticoLimite = a2_PuntoCriticoLimite;
            _a2_PuntoCriticoAlertado = a2_PuntoCriticoAlertado;
            _a2_PuntoMinimo = a2_PuntoMinimo;
            _a2_PuntoMinimoLimite = a2_PuntoMinimoLimite;
            _a2_PuntoMinimoAlertado = a2_PuntoMinimoAlertado;
            _a2_PuntoMaximoLimite = a2_PuntoMaximoLimite;
            _a2_FechaIngreso = a2_FechaIngreso;
            _a2_Stock = a2_Stock;
            _costoBruto = costoBruto;
            _costoAlicuotaIVA = costoAlicuotaIVA;
            _costoBaseIVA = costoBaseIVA;
            _costoNeto = costoNeto;
            _utilidad = utilidad;
            _margenBruto = margenBruto;
            _precioBruto = precioBruto;
            _estado = estado;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion
    }
}