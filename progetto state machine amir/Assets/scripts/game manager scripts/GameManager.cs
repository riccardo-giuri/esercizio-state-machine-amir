using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GMsingleton;
    Animator GameplaySM;
    public Animator PlayerSM;
    public Animator PistolaSM;
    public pistolabehaviour pistolabehaviour;
    public playerbehaviour Playerbehaviour;
    public maincamerabehaviour Maincamerabehaviour;

    //faccio sigleton del game manager e chiamo il metodo che da le referenze ai vari manager e cose che mi servono
    private void Awake()
    {
        if( GMsingleton == null )
        {
            GMsingleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        Setup();
    }


    //eventi per la state machine del gameplay 
    #region GameSM delegate

    public delegate void GameSMTriggerDelegate();

    public static GameSMTriggerDelegate GoToGameplayState;

    #endregion

    #region playerSM Delegate
    public delegate void playerSMtriggerdelegates();

    public static playerSMtriggerdelegates GoTostandstillState;
    public static playerSMtriggerdelegates GoTowalkingState;
    public static playerSMtriggerdelegates GoTocrouchState;
    public static playerSMtriggerdelegates GoTorunningState;
    public static playerSMtriggerdelegates GoToaimState;
    #endregion

    #region PistolaSM Delegate
    public delegate void pistolaSMtriggerdelegate();

    public static pistolaSMtriggerdelegate GoTononarmedState;
    public static pistolaSMtriggerdelegate GoToarmedState;
    public static pistolaSMtriggerdelegate GoToshootingState;
    public static pistolaSMtriggerdelegate GoToreloadingState;
    #endregion

    #region ON enable-disable
    // all'enanble chiamo: metodo per iscriversi agli eventi
    private void OnEnable()
    {
        EventSetup();
    }

    //al disable chiamo: metodo per disiscriversi agli eventi
    private void OnDisable()
    {
        DisableEventSetup();
    }
    #endregion

    

    //setup dei vari manager al GM
    public static void Setup()
    {
        GMsingleton.GameplaySM = GMsingleton.GetComponent<Animator>();
        GMsingleton.Playerbehaviour = FindObjectOfType<playerbehaviour>();
        GMsingleton.Maincamerabehaviour = FindObjectOfType<maincamerabehaviour>();
    }



    #region EVENT SETUPS
    //metodo che si occupa di iscriversi agli eventi 
    public static void EventSetup()
    {
        GoToGameplayState += GMsingleton.HandleGoToGameplayState;
        GoTowalkingState += GMsingleton.handleGotowalkingState;
        GoTostandstillState += GMsingleton.handleGotostandstillState;
        GoTocrouchState += GMsingleton.handleGotocrouchState;
        GoTorunningState += GMsingleton.handleGotorunningState;
        GoToaimState += GMsingleton.handlegotoaimState;
        GoToarmedState += GMsingleton.handleGotoArmedState;
        GoTononarmedState += GMsingleton.handleGoTononarmedState;
        GoToshootingState += GMsingleton.handlegotoshootingState;
        GoToreloadingState += GMsingleton.handlegotoreloadingState;
    }

    //metodo che si occupa di disiscriversi agli eventi 
    public static void DisableEventSetup()
    {
        GoToGameplayState -= GMsingleton.HandleGoToGameplayState;
        GoTowalkingState -= GMsingleton.handleGotowalkingState;
        GoTostandstillState -= GMsingleton.handleGotostandstillState;
        GoTocrouchState -= GMsingleton.handleGotocrouchState;
        GoTorunningState -= GMsingleton.handleGotorunningState;
        GoToaimState -= GMsingleton.handlegotoaimState;
        GoToarmedState -= GMsingleton.handleGotoArmedState;
        GoTononarmedState -= GMsingleton.handleGoTononarmedState;
        GoToshootingState -= GMsingleton.handlegotoshootingState;
        GoToreloadingState -= GMsingleton.handlegotoreloadingState;
    }
    #endregion


    #region EventHandlegameplaySM
    //handle per l'evento che va al gameplay state dal setup state
    void HandleGoToGameplayState()
    {
        if (!GMsingleton.GameplaySM.GetCurrentAnimatorStateInfo(0).IsName("gameplay_state"))
        {
            GMsingleton.GameplaySM.SetTrigger("GoTogameplay_state");
        }
    }
    #endregion

    #region EventhandleplayerSM
    void handleGotowalkingState()
    {
        GMsingleton.PlayerSM.SetTrigger("GoTowalking_state");

        /*if (GMsingleton.Playerbehaviour.x != 0 | GMsingleton.Playerbehaviour.z != 0)
        {
            
        }*/
    }

    void handleGotostandstillState()
    {
        if(GMsingleton.Playerbehaviour.x == 0 && GMsingleton.Playerbehaviour.z == 0 && GMsingleton.Maincamerabehaviour.transform.localPosition.y == 0.3f)
        {
            GMsingleton.PlayerSM.SetTrigger("GoTostandstill_state");
        }
    }

    void handleGotocrouchState()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GMsingleton.PlayerSM.SetTrigger("GoTocrouch_state");
        }
    }

    void handleGotorunningState()
    {
        GMsingleton.PlayerSM.SetTrigger("GoTorunning_state");
    }

    void handlegotoaimState()
    {
        GMsingleton.PlayerSM.SetTrigger("GoToaim_state");
    }
    #endregion

    #region eventhandlepistolaSM

    void handleGoTononarmedState()
    {
        GMsingleton.PistolaSM.SetTrigger("GoToNonarmed_state");
    }

    void handleGotoArmedState()
    {
        GMsingleton.PistolaSM.SetTrigger("GoToArmed_state");
    }

    void handlegotoshootingState()
    {
        GMsingleton.PistolaSM.SetTrigger("GoToShooting_state");
    }

    void handlegotoreloadingState()
    {
        GMsingleton.PistolaSM.SetTrigger("GoToReloading_state");
    }

    #endregion

    #region LOAD SCENES
    //carica la scena gameplay
    public void Loadgameplayscene() 
    {
        SceneManager.LoadScene(1); //gameplay_state
    }
    #endregion

    #region mainmenuclick
    public void nuovapartitaclick()
    {
        GoToGameplayState();
    }
    #endregion

    public void Equipweapon()
    {
        GoToarmedState();
        GMsingleton.Playerbehaviour.Equipweapon();
        GMsingleton.pistolabehaviour.canshoot = true;
    }

    public void Unequipweapon()
    {
        GoTononarmedState();
        GMsingleton.Playerbehaviour.Unequipweapon();
        GMsingleton.pistolabehaviour.canshoot = false;
    }

    public IEnumerator Reload()
    {
        Debug.Log("sto ricaricando");
        yield return new WaitForSeconds(2f);
        Debug.Log("ho finito di ricaricare");
        GameManager.GoToarmedState();
    }
}
