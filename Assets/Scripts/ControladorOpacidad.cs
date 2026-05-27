using UnityEngine;
//using UnityEngine.UI; // Necesario para interactuar con UI

public class ControladorOpacidad : MonoBehaviour
{
    public GameObject[] modelos;

    // Esta función recibe el número del Slider (entre 0 y 1)
    public void CambiarOpacidad(float valorAlpha)
    {
        // Revisamos cada modelo de la lista
        foreach (GameObject modelo in modelos)
        {
            if (modelo != null)
            {
                // Buscamos todos los renderers (incluso si el modelo tiene varias partes)
                Renderer[] renderers = modelo.GetComponentsInChildren<Renderer>(true);
                
                foreach (Renderer rend in renderers)
                {
                    // Cambiamos el valor "Alpha" (transparencia) del color
                    Color colorActual = rend.material.color;
                    colorActual.a = valorAlpha;
                    rend.material.color = colorActual;
                }
            }
        }
    }
}