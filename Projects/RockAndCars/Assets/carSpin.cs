using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script trata da rotação do carro. Ele modifica a rotação do objeto associado a ele. 
/// Uma coisa ficou confusa com ele: vendo a cena de cima, a imagem do carro não aparece.
/// Isso é porque ela está paralela à câmera e no meio da janela.
/// Quando o script é executado, ele pega o eixo "z" de imgNode apontar para frente, e isso acaba
/// trocando os eixos do seu "filho" carPlayerImg, então o carro começa a aparecer na tela.
/// </summary>

public class carSpin : MonoBehaviour
{

    Vector3 direction;
    //auxiliarVector é a metade do tamanho da tela em pixels
    Vector3 auxiliarVector = new Vector3(Screen.width / 2, Screen.height / 2, 0);

    void Start()
    {

    }

    void Update()
    {
        //direction é um vetor que aponta na direção do mouse.
        direction = Input.mousePosition - auxiliarVector;

        //Quaternion.LookRotation faz o z do objeto apontar na direção direction.
        //O segundo parâmetro deve apontar do objeto para cima dele.
        transform.rotation = Quaternion.LookRotation(direction, new Vector3 (0,0,-1));

        /*área de testes, imprime direction se o botão direito do mouse é apertado.
        if (Input.GetMouseButton(1))
        {
            print(direction);
        }
        */
    }
}