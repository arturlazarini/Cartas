using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageCards : MonoBehaviour
{
    public static int Mode;

    public GameObject carta;                // Carta a ser descartada
    private bool primeiraCartaSelecionada, segundaCartaSelecionada; // indicadores para cada carta escolhida em cada linha
    private GameObject carta1, carta2;      // GameObject da 1ª e 2ª carta selecionada
    private string linhaCarta1, linhaCarta2; // linha da carta selecionada

    bool timerPausado, timerAcionado;       // indicador de pausa no Timer ou Start do Timer
    float timer;                            // Variável de tempo

    int numTentativas = 0;                  // número de tentativas na rodada
    int numAcertos = 0;                     // número de pares acertados
    AudioSource somOK;                      // som do acerto

    int ultimoJogo = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("mode").GetComponent<Text>().text = "MODO: " + Mode;

        switch (Mode)
        {
            case 1:
                GameObject.Find("recorde").GetComponent<Text>().text = "RECORDE: " + PlayerPrefs.GetInt("Recorde1", 999);
                ultimoJogo = PlayerPrefs.GetInt("Jogadas1", 0);
                break;

            case 2:
                GameObject.Find("recorde").GetComponent<Text>().text = "RECORDE: " + PlayerPrefs.GetInt("Recorde2", 999);
                ultimoJogo = PlayerPrefs.GetInt("Jogadas2", 0);
                break;

            default:
                GameObject.Find("recorde").GetComponent<Text>().text = "RECORDE: " + PlayerPrefs.GetInt("Recorde3", 999);
                ultimoJogo = PlayerPrefs.GetInt("Jogadas3", 0);
                break;
        }

        MostraCartas();
        UpdateTentativas();
        somOK = GetComponent<AudioSource>();

        GameObject.Find("ultimaJogada").GetComponent<Text>().text = "Jogo Anterior = " + ultimoJogo;

    }

    // Update is called once per frame
    void Update()
    {
        if (timerAcionado)
        {
            timer += Time.deltaTime;
            print(timer);
            if (timer > 1)
            {
                timerPausado = true;
                timerAcionado = false;

                switch (Mode)
                {
                    case 1:
                        if(carta1.tag == carta2.tag && linhaCarta1 != linhaCarta2)
                        {
                            Destroy(carta1);
                            Destroy(carta2);
                            numAcertos++;
                            somOK.Play();
                    
                            if(numAcertos == 13)
                            {
                                PlayerPrefs.SetInt("Jogadas1", numTentativas);

                                if (numTentativas < PlayerPrefs.GetInt("Recorde1", 0))
                                    PlayerPrefs.SetInt("Recorde1", numTentativas);
                                
                                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                            }
                        }
                        else
                        {
                            carta1.GetComponent<Tile>().EscondeCarta(carta1.GetComponent<Tile>().linha, carta1.GetComponent<Tile>().coluna);
                            carta2.GetComponent<Tile>().EscondeCarta(carta2.GetComponent<Tile>().linha, carta2.GetComponent<Tile>().coluna);
                        }
                        break;

                    case 2:
                        if (carta1.GetComponent<Tile>().originalCarta == carta2.GetComponent<Tile>().originalCarta && linhaCarta1 != linhaCarta2)
                        {
                            Destroy(carta1);
                            Destroy(carta2);
                            numAcertos++;
                            somOK.Play();

                            if (numAcertos == 13)
                            {
                                PlayerPrefs.SetInt("Jogadas2", numTentativas);

                                if (numTentativas < PlayerPrefs.GetInt("Recorde2", 0))
                                    PlayerPrefs.SetInt("Recorde2", numTentativas);

                                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                            }
                        }
                        else
                        {
                            carta1.GetComponent<Tile>().EscondeCarta(carta1.GetComponent<Tile>().linha, carta1.GetComponent<Tile>().coluna);
                            carta2.GetComponent<Tile>().EscondeCarta(carta2.GetComponent<Tile>().linha, carta2.GetComponent<Tile>().coluna);
                        }
                        break;

                    case 3:
                        if (carta1.GetComponent<Tile>().originalCarta == carta2.GetComponent<Tile>().originalCarta && linhaCarta1 != linhaCarta2)
                        {
                            Destroy(carta1);
                            Destroy(carta2);
                            numAcertos++;
                            somOK.Play();

                            if (numAcertos == 16)
                            {
                                PlayerPrefs.SetInt("Jogadas3", numTentativas);

                                if (numTentativas < PlayerPrefs.GetInt("Recorde3", 0))
                                    PlayerPrefs.SetInt("Recorde3", numTentativas);

                                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                            }
                        }
                        else
                        {
                            carta1.GetComponent<Tile>().EscondeCarta(carta1.GetComponent<Tile>().linha, carta1.GetComponent<Tile>().coluna);
                            carta2.GetComponent<Tile>().EscondeCarta(carta2.GetComponent<Tile>().linha, carta2.GetComponent<Tile>().coluna);
                        }
                        break;
                }
                primeiraCartaSelecionada = false;
                segundaCartaSelecionada = false;
                carta1 = null;
                carta2 = null;
                linhaCarta1 = "";
                linhaCarta2 = "";
                timer = 0;
            }
        }
    }

    void MostraCartas()
    {
        if(Mode == 1 || Mode == 2)
        {
            int[] arrayEmbaralhado = criaArrayEmbaralhado();
            int[] arrayEmbaralhado2 = criaArrayEmbaralhado();

            for (int i = 0; i < 13; i++)
            {
                AddUmaCarta(0, i, arrayEmbaralhado[i], 0);
                AddUmaCarta(1, i, arrayEmbaralhado2[i], 0);
            }
        }
        else
        {
            int[] arrayEmbaralhado = criaArrayEmbaralhado();
            int[] arrayEmbaralhado2 = criaArrayEmbaralhado();
            int[] arrayEmbaralhado3 = criaArrayEmbaralhado();
            int[] arrayEmbaralhado4 = criaArrayEmbaralhado();

            int[] arrayEmbaralhado5 = criaArrayEmbaralhado();
            int[] arrayEmbaralhado6 = criaArrayEmbaralhado();
            int[] arrayEmbaralhado7 = criaArrayEmbaralhado();
            int[] arrayEmbaralhado8 = criaArrayEmbaralhado();

            for (int i = 0; i < 4; i++)
            {
                AddUmaCarta(0, i, arrayEmbaralhado[i], 0);
                AddUmaCarta(1, i, arrayEmbaralhado2[i], 0);
                AddUmaCarta(2, i, arrayEmbaralhado3[i], 0);
                AddUmaCarta(3, i, arrayEmbaralhado4[i], 0);
                
                AddUmaCarta(4, i, arrayEmbaralhado5[i], 1);
                AddUmaCarta(5, i, arrayEmbaralhado6[i], 1);
                AddUmaCarta(6, i, arrayEmbaralhado7[i], 1);
                AddUmaCarta(7, i, arrayEmbaralhado8[i], 1);
            }
        }
    }

    void AddUmaCarta(int linha, int rank, int valor, int coluna)
    {
        GameObject centro = GameObject.Find("centroDaTela");
        float escalaCartaOriginal = carta.transform.localScale.x;
        float fatorDeEscalaX = (575 * escalaCartaOriginal) / 110.0f;
        float fatorDeEscalaY = (850 * escalaCartaOriginal) / 110.0f;

        Vector3 novaPosicao = new Vector3(centro.transform.position.x + ((rank - 13 / 2 + coluna*9) * fatorDeEscalaX), centro.transform.position.y + ((-(linha%4) + 1) * fatorDeEscalaY), centro.transform.position.z);
        
        GameObject c = (GameObject)(Instantiate(carta, novaPosicao, Quaternion.identity));
        c.tag = "" + (valor);
        c.name = "" + linha + " " + valor;
        c.GetComponent<Tile>().linha = linha;
        c.GetComponent<Tile>().coluna = coluna;

        string nomeDaCarta = "";
        string numeroCarta = "";

        if (valor == 0)
            numeroCarta = "ace";
        else if (valor == 10)
            numeroCarta = "jack";
        else if (valor == 11)
            numeroCarta = "queen";
        else if (valor == 12)
            numeroCarta = "king";
        else
            numeroCarta = "" + (valor + 1);

        if(Mode == 1 || Mode == 3)
        {
            // escolhe o nipe das cartas utilizando a var linha 
            switch (linha%4)
            {
                case 0:
                    nomeDaCarta = numeroCarta + "_of_clubs";
                    break;

                case 1:
                    nomeDaCarta = numeroCarta + "_of_hearts";
                    break;

                case 2:
                    nomeDaCarta = numeroCarta + "_of_spades";
                    break;

                default:
                    nomeDaCarta = numeroCarta + "_of_diamonds";
                    break;
            }
        }else if(Mode == 2)
        {
            nomeDaCarta = numeroCarta + "_of_clubs";
        }
       

        Sprite s1 = (Sprite)(Resources.Load<Sprite>(nomeDaCarta));
        print("S1: " + s1);

        c.GetComponent<Tile>().EscondeCarta(linha, coluna);

        GameObject.Find("" + linha + " " + valor).GetComponent<Tile>().setCartaOriginal(s1);
    }

    public int[] criaArrayEmbaralhado()
    {
        if(Mode == 1 || Mode == 2)
        {
            int[] novoArray = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            int temp;
            for(int t = 0; t < 13; t++)
            {
                temp = novoArray[t];
                int r = Random.Range(t, 13);
                novoArray[t] = novoArray[r];
                novoArray[r] = temp;
            }
            return novoArray;
        }
        else
        {
            int[] novoArray = new int[] {0, 10, 11, 12};
            int temp;
            for (int t = 0; t < 4; t++)
            {
                temp = novoArray[t];
                int r = Random.Range(t, 4);
                novoArray[t] = novoArray[r];
                novoArray[r] = temp;
            }
            return novoArray;
        }
    }

    public void CartaSelecionada(GameObject carta)
    {
        if (!primeiraCartaSelecionada)
        {
            string linha = carta.name.Substring(0, 1);
            linhaCarta1 = linha;
            primeiraCartaSelecionada = true;
            carta1 = carta;
            carta1.GetComponent<Tile>().RevelaCarta();

        }
        else if (primeiraCartaSelecionada && !segundaCartaSelecionada)
        {
            string linha = carta.name.Substring(0, 1);
            linhaCarta2 = linha;
            primeiraCartaSelecionada = true;
            carta2 = carta;
            carta2.GetComponent<Tile>().RevelaCarta();
            VerificaCartas();
        }     
    }

    public void VerificaCartas()
    {
        DisparaTimer();
        numTentativas++;
        UpdateTentativas();
    }

    public void DisparaTimer()
    {
        timerPausado = false;
        timerAcionado = true;
    }

    void UpdateTentativas()
    {
        GameObject.Find("numTentativas").GetComponent<Text>().text = "Tentativas = " + numTentativas;
    }
}
