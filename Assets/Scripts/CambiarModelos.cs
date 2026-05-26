using UnityEngine;

public class CambiarModelos : MonoBehaviour
{
    // Importar los modelos de cuerpo, cabeza y rostro en valiables públicas para poder asignarlos desde el inspector de Unity
    public GameObject cuerpoGeo;
    public GameObject cabezaGeo;
    public GameObject rostro;
    public GameObject torsoGeo;
    public GameObject brazoGeo;
    public GameObject piernaGeo;
    public GameObject pie;

    //Olcultamos los modelos
    private void OcultarModelos()
    {
        cuerpoGeo.SetActive(false);
        cabezaGeo.SetActive(false);
        rostro.SetActive(false);
        torsoGeo.SetActive(false);
        brazoGeo.SetActive(false);
        piernaGeo.SetActive(false);
        pie.SetActive(false);
    }

    //Funciones para mostrar cada modelo individualmente en botones
    public void MostrarCuerpo()
    {
        OcultarModelos(); //primero se oculta los modelos
        cuerpoGeo.SetActive(true); //luego se muestra el modelo de cuerpo
    }

    public void MostrarCabeza()
    {
        OcultarModelos();
        cabezaGeo.SetActive(true);
    }

    public void MostrarRostro()
    {
        OcultarModelos();
        rostro.SetActive(true);
    }

    public void MostrarTorso()
    {
        OcultarModelos();
        torsoGeo.SetActive(true);
    }

    public void MostrarBrazo()
    {
        OcultarModelos();
        brazoGeo.SetActive(true);
    }

    public void MostrarPierna()
    {
        OcultarModelos();
        piernaGeo.SetActive(true);
    }

    public void MostrarPie()
    {
        OcultarModelos();
        pie.SetActive(true);
    }
    
}
