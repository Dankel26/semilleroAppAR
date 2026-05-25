using UnityEngine;

public class GestosAR : MonoBehaviour
{
    [Header("Velocidades de Ajuste")]
    public float velocidadMover = 0.005f;
    public float velocidadEscalar = 0.005f;
    public float velocidadRotar = 1.5f;

    private bool objetoSeleccionado = false;
    private Vector3 posicionAnteriorRaton;

    void Update()
    {
        // =========================================================
        // 1. MODO PRUEBA EN COMPUTADOR (Con el Ratón)
        // =========================================================
        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayo, out RaycastHit golpe))
            {
                if (golpe.transform == transform)
                {
                    objetoSeleccionado = true;
                    posicionAnteriorRaton = Input.mousePosition;
                }
            }
        }

        if (Input.GetMouseButton(0) && objetoSeleccionado)
        {
            Vector3 diferencia = Input.mousePosition - posicionAnteriorRaton;
            // Usamos un multiplicador para que la velocidad del ratón se sienta similar a la del dedo
            transform.Translate(diferencia.x * (velocidadMover * 2f), diferencia.y * (velocidadMover * 2f), 0, Camera.main.transform);
            posicionAnteriorRaton = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            objetoSeleccionado = false;
        }
        #endif

        // =========================================================
        // 2. MODO CELULAR (Con los dedos en la pantalla)
        // =========================================================
       //Si no se detecta ningún toque, no hacemos nada
        if (Input.touchCount == 0) return;

        // --- 1 DEDO: MOVER EL OBJETO ---
        if (Input.touchCount == 1)
        {
            Touch toque = Input.GetTouch(0);

            if (toque.phase == TouchPhase.Began)
            {
                Ray rayo = Camera.main.ScreenPointToRay(toque.position);
                if (Physics.Raycast(rayo, out RaycastHit golpe))
                {
                    if (golpe.transform == transform) objetoSeleccionado = true;
                }
                else
                {
                    objetoSeleccionado = false;
                }
            }

            if (toque.phase == TouchPhase.Moved && objetoSeleccionado)
            {
                transform.Translate(toque.deltaPosition.x * velocidadMover, toque.deltaPosition.y * velocidadMover, 0, Camera.main.transform);
            }

            if (toque.phase == TouchPhase.Ended || toque.phase == TouchPhase.Canceled)
            {
                objetoSeleccionado = false;
            }
        }

        // --- 2 DEDOS: ESCALAR Y ROTAR ---
        else if (Input.touchCount == 2)
        {
            Touch toque0 = Input.GetTouch(0);
            Touch toque1 = Input.GetTouch(1);

            Vector2 toque0PosAnterior = toque0.position - toque0.deltaPosition;
            Vector2 toque1PosAnterior = toque1.position - toque1.deltaPosition;

            // Escalar
            float magnitudAnterior = (toque0PosAnterior - toque1PosAnterior).magnitude;
            float magnitudActual = (toque0.position - toque1.position).magnitude;
            float diferenciaMagnitud = magnitudAnterior - magnitudActual;

            Vector3 nuevaEscala = transform.localScale - new Vector3(diferenciaMagnitud, diferenciaMagnitud, diferenciaMagnitud) * velocidadEscalar;
            nuevaEscala.x = Mathf.Clamp(nuevaEscala.x, 0.01f, 5f);
            nuevaEscala.y = Mathf.Clamp(nuevaEscala.y, 0.01f, 5f);
            nuevaEscala.z = Mathf.Clamp(nuevaEscala.z, 0.01f, 5f);
            transform.localScale = nuevaEscala;

            // Rotar
            Vector2 direccionAnterior = toque1PosAnterior - toque0PosAnterior;
            Vector2 direccionActual = toque1.position - toque0.position;
            float angulo = Vector2.SignedAngle(direccionAnterior, direccionActual);
            transform.Rotate(Vector3.up, angulo * velocidadRotar, Space.World);
        }
    }
}