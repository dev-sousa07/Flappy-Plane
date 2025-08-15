using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float velocidade = 5f;
    //GameObject para destruir
    [SerializeField] private GameObject obst;
    void Start()
    {
        Destroy(obst, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        // indo para a esquerda
        transform.position += Vector3.left * Time.deltaTime * velocidade;
        
    }
}
