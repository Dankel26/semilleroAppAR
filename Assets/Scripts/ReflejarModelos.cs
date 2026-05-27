using UnityEngine;

public class ReflejarModelos : MonoBehaviour
{
    public void ReflejarModel()
    {
        // Reflejar el modelo en el eje X
        Vector3 escalaActual = transform.localScale; //Tomamos la escala actual del modelo
        escalaActual.x = -escalaActual.x; // Se multiplica por -1 para reflejar en el eje X luego alternar
        transform.localScale = escalaActual; // Aplicar la nueva escala al modelo
    }
}
