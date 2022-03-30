using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // private bool tileRevelada = false;              // indicador de carta virada ou não
    public Sprite originalCarta;                    // Sprite da carta desejada
    public Sprite backCarta1;                        // Sprite do verso da carta
    public Sprite backCarta2;
    public int linha;
    public int coluna;

    // Start is called before the first frame update
    void Start()
    {
        // EscondeCarta(ManageCards.Mode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        print("Você pressionou num Tile");
        /*if (tileRevelada)
            EscondeCarta();
        else
            RevelaCarta();*/        // Não guarda número de cartas

        GameObject.Find("gameManager").GetComponent<ManageCards>().CartaSelecionada(gameObject);
    }

    public void EscondeCarta(int i, int j)
    {
        switch (ManageCards.Mode)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = backCarta1;
                // tileRevelada = false;
                break;

            case 2:
                if(i == 0)
                    GetComponent<SpriteRenderer>().sprite = backCarta1;
                else
                    GetComponent<SpriteRenderer>().sprite = backCarta2;

                break;

            default:
                if (j == 0)
                    GetComponent<SpriteRenderer>().sprite = backCarta1;
                else
                    GetComponent<SpriteRenderer>().sprite = backCarta2;

                break;
        }
    }

    public void RevelaCarta()
    {
        GetComponent<SpriteRenderer>().sprite = originalCarta;
        // tileRevelada = true;
    }

    public void setCartaOriginal(Sprite novaCarta)
    {
        originalCarta = novaCarta;
    }
}
