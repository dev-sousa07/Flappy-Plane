using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InicioController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checar espaço pressionado
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Carregar a cena do jogo
            SceneManager.LoadScene("Jogo");
        }
    }
}
