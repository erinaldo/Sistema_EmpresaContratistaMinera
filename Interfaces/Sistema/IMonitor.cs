namespace Interfaces.Sistema
{
    public interface IMonitor
    {
        bool monitorearAlertas();
        bool monitorearAlertasDeArticulo();
        bool monitorearAlertasDeAntecedentes();
        bool monitorearAlertasDeCobro();
        bool monitorearAlertasDeCursoInduccion();
        bool monitorearAlertasDeCursoIzaje();
        bool monitorearAlertasDeEntrevista();
        bool monitorearAlertasDeExamenMedico();
        bool monitorearAlertasDeLicenciaConducir();
        bool monitorearAlertasDePago();
        bool monitorearEstados();
    }
}