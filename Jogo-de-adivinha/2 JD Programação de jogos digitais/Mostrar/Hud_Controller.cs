using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Hud_Controller : MonoBehaviour
{
    public Text Coins_TXT;
    public Text XP_TXT;
    public Text Contador_de_kills_TXT;
    public Text Vidas_do_player_TXT;
    public Text Best_Kills;

    [Space(20)]
    //Menu de Pausa\\
    public Image Menu_de_pausa;
    public Button Botao_para_voltar_ao_jogo;
    public Button Botao_Opcoes;

    [Space(20)]
    //Menu de Configura��es\\
    public Image Menu_de_Config;
    public Button Exit_Menu_config_Button;
    public Button Preview_Ataque_das_armas_opcao;
    //public Toggle View_FPS;

    private bool Esta_aberta = false;

    //--Variaveis para os objetos necessarios--\\
    public SpriteRenderer Preview_area_de_ataque_das_armas_SPRITE_RENDERER;
    public GameObject Faca_Obj;
    public GameObject Machado_Obj;
    //public GameObject Espada_Obj;

    //Variavels para numeros aleatorios\\
    private int RandomNunber;

    [Space(20)]
    //Menu_Inicial\\
    public GameObject Menu_Inicial;
    public Button Play_Button;
    public Button Config_Button;
    public Button Inf_Button;

    [Space(20)]
    //Menu da Loja\\
    public Image Hud_da_loja;
    //Loja\\
    //public Image Loja_Image;

    [Space (20)]
    //CameraFOV Config\\
    public Button CameraFovMais;
    public Button CameraFovMenos;
    public Text Visor_Camera_FOV;

    [Space(10)]
    //--Panel1--\\
    public Image Panel1;
    public Button Panel1_Button1;
    public Button Panel1_Button2;
    public Button Panel1_Button3;

    [Space(10)]
    //--Panel2--\\
    public Image Panel2;
    public Button Panel2_Button1;
    public Button Panel2_Button2;
    public Button Panel2_Button3;

    private void Awake()
    {
        //Time.timeScale = 0;
        Botao_para_voltar_ao_jogo.onClick.AddListener(Fechar_o_menu_de_pausa);

        //Bot�es da Loja\\
        //--Panel1--\\
        Panel1_Button1.onClick.AddListener(Painel1_Button1);
        Panel1_Button2.onClick.AddListener(Painel1_Button2);
        Panel1_Button3.onClick.AddListener(Painel1_Button3);

        //--Panel2--\\
        Panel2_Button1.onClick.AddListener(Painel2_Button1);
        Panel2_Button2.onClick.AddListener(Painel2_Button2);
        Panel2_Button3.onClick.AddListener(Painel2_Button3);

        //Menu Inicial\\
        //Play_Button.onClick.AddListener(Play_Now);
        //Config_Button.onClick.AddListener(Abrir_O_Menu_De_Config);



        //--Menu de config open ou close--\\
        Exit_Menu_config_Button.onClick.AddListener(Fechar_O_Menu_De_Config);
        Botao_Opcoes.onClick.AddListener(Abrir_O_Menu_De_Config);

        //--Button CameraFOV--\\
        CameraFovMais.onClick.AddListener(cameraFov_Mais_button);
        CameraFovMenos.onClick.AddListener(cameraFov_Menos_button);
    }


    private void Update()
    {
        Visor_Camera_FOV.text = Variaveis_Globais.CameraFOV.ToString();
        Coins_TXT.text = "Coins: " + Variaveis_Globais.Coins.ToString();
        XP_TXT.text = "XP: " + Variaveis_Globais.XP.ToString();
        Contador_de_kills_TXT.text = "KILLS: " + Variaveis_Globais.Contador_de_kills.ToString();
        Vidas_do_player_TXT.text = "Vida: " + Variaveis_Globais.Player_Life.ToString() + "%";
        Best_Kills.text = "Best Kills: " + Variaveis_Globais.Best_Kills.ToString();

        //Vai Verificar os numeros aleatorios\\
        if (RandomNunber == 0)
        {
            Abrir_Pane1();
            Fechar_Panel2();
        }
        if (RandomNunber == 1)
        {
            Abrir_Panel2();
            Fechar_Pane1();
            if (Variaveis_Globais.Player_Life == 100)
            {
                Panel2_Button3.gameObject.SetActive(false);
            }
            if (Machado_Obj.gameObject.activeSelf == true)
            {
                Panel2_Button2.gameObject.SetActive(false);
            }
            if (Machado_Obj.gameObject.activeSelf == false)
            {
                Panel2_Button1.gameObject.SetActive(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            int contadordekills = createnewfile.lerarquivo();
            Variaveis_Globais.Contador_de_kills = contadordekills;
        }

        //Vai verificar as variaveis da cameraFOV\\
        if (Variaveis_Globais.CameraFOV < 3.5f)
        {
            Variaveis_Globais.CameraFOV = 3.5f;
        }
        if (Variaveis_Globais.CameraFOV > 5f)
        {
            Variaveis_Globais.CameraFOV = 5f;
        }

        //Vai verificar se a tecla "escape(ESC)" foi apertada e se a variavel Esta_aberta e verdadeira\\

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Esta_aberta)
            {
                Abrir_o_menu_de_pausa();
            }
            else
            {
                Fechar_o_menu_de_pausa();
            }
        }
        

        if (Variaveis_Globais.XP == Variaveis_Globais.XP_para_a_Loja)
        {
            abrirloja();
            Variaveis_Globais.XP_para_a_Loja += 5f;
        }

        if (Hud_da_loja.gameObject.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Hud_da_loja.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    private void Abrir_o_menu_de_pausa()
    {
        Menu_de_pausa.gameObject.SetActive(true);
        Variaveis_Globais.PodeRotacionarAfaca = false;
        Esta_aberta = true;
        Time.timeScale = 0;
    }

    private void Fechar_o_menu_de_pausa()
    {
        Menu_de_pausa.gameObject.SetActive(false);
        Variaveis_Globais.PodeRotacionarAfaca = true;
        Esta_aberta = false;
        Time.timeScale = 1;
    }

    //Button para o Player_Speed\\
    private void Painel1_Button1()
    {
        Variaveis_Globais.Player_Speed += 0.5f;
        Time.timeScale = 1;
        Fechar_Pane1();
        Fechar_Panel2();
        Hud_da_loja.gameObject.SetActive(false);
    }

    //Button para Ainda sem Adicionar algo\\
    private void Painel1_Button2()
    {
        //Ainda sem Adicionar algo\\
    }

    //Button para o Dano\\
    private void Painel1_Button3()
    {
        Variaveis_Globais.Dano_da_Faca += 0.5f;
        Time.timeScale = 1;
        Fechar_Pane1();
        Fechar_Panel2();
        Hud_da_loja.gameObject.SetActive(false);
    }

    //Voids para o painel2\\
    private void Painel2_Button1()//Aumentar o dano do machado
    {
        Variaveis_Globais.Dano_do_Machado += 1;
        Time.timeScale = 1;
        Fechar_Panel2();
        Hud_da_loja.gameObject.SetActive(false);
    }
    private void Painel2_Button2()//Trocar de arma para o machado
    {
        Faca_Obj.gameObject.SetActive(false);
        Machado_Obj.gameObject.SetActive(true);
        Variaveis_Globais.armas[0] = false;
        Variaveis_Globais.armas[1] = true;
        Variaveis_Globais.armas[2] = false;
        Time.timeScale = 1;
        Fechar_Panel2();
        Hud_da_loja.gameObject.SetActive(false);
    }
    private void Painel2_Button3()//Curar o player em 25%
    {
        if (Variaveis_Globais.Player_Life > 100)
        {
            Variaveis_Globais.Player_Life = 100;
        }
        Variaveis_Globais.Player_Life += 25;
        Time.timeScale = 1;
        Fechar_Panel2();
        Hud_da_loja.gameObject.SetActive(false);
    }

    //Void para abrir o menu de Config\\
    private void Abrir_O_Menu_De_Config()
    {
        Menu_de_Config.gameObject.SetActive(true);
    }

    //Void para fechar o menu de Config\\
    private void Fechar_O_Menu_De_Config()
    {
        Menu_de_Config.gameObject.SetActive(false);
    }

    public void Preview_Area_de_Ataque_Das_Armas (bool newvalue)
    {
        Preview_area_de_ataque_das_armas_SPRITE_RENDERER.enabled = newvalue;
    }

    private void abrirloja()
    {
        RandomNunber = Random.Range(0, 2);//Adicionar mais ao passa do tempo
        print(RandomNunber + "esse Numero aleatorio");
        Hud_da_loja.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    //Voids para a Loja\\
    private void Abrir_Pane1()
    {
        Panel1.gameObject.SetActive(true);
    }
    private void Abrir_Panel2()
    {
        Panel2.gameObject.SetActive(true);
    }
    private void Fechar_Pane1()
    {
        Panel1.gameObject.SetActive(false);
    }
    private void Fechar_Panel2()
    {
        Panel2.gameObject.SetActive(false);
    }


    //Menu Inicial\\
    private void Play_Now()
    {
        Menu_Inicial.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    //CameraFOV\\
    private void cameraFov_Mais_button()
    {
        Variaveis_Globais.CameraFOV += 0.5f;
    }
    private void cameraFov_Menos_button()
    {
        Variaveis_Globais.CameraFOV -= 0.5f;
    }
}
