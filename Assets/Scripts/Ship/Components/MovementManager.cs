using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private bool blockXCamera;
    [SerializeField] private bool blockYCamera;

    public void Move(Vector2 movement)
    {
        transform.Translate(Time.deltaTime * speed * movement);
        LimitMovement();
    }

    private void LimitMovement()
    {
        Vector3 posicion = Camera.main.WorldToViewportPoint(transform.position);
        if (blockXCamera)
            posicion.x = Mathf.Clamp(posicion.x, 0.03f, 0.97f);
        if (blockYCamera)
            posicion.y = Mathf.Clamp(posicion.y, 0.05f, 0.95f);
        transform.position = Camera.main.ViewportToWorldPoint(posicion);
    }
}
