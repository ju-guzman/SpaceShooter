using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Vector3 direccion;

    private float anchoImagen;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
        anchoImagen = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float resto = (velocidad * Time.time) % anchoImagen;
        transform.position = posicionInicial + (direccion * resto);
    }
}
