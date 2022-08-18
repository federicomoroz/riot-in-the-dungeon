using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
                      public  static GameManager  instance;
                      private        float        runTime;
                      public         int          playerHpCurrent, playerHpMax;
    [HideInInspector] public         bool         isFullHp;
                      public         int          currentScore, currentCombo, maxCombo = 0;   
                      public         int          foeKilledGhost, foeKilledTroll, foeKilledDragon, foeKilledTotal;
                      private        int          nextScene = 2;
    [SerializeField]  private        int          killsToWin = 15;
         
    [SerializeField]  private        string       lastKilled;
                      private        List<string> killList = new List<string>();
                 
       
    

    private void Awake()
    {
        if(instance == null) {   instance = this; DontDestroyOnLoad(gameObject);  }
        else                 {   Destroy(gameObject);                             }
    }

    void Start()
    { 
      resetValuesTotal();     

    }

    public void resetValuesTotal()
    { resetScore(); resetComboCurrent(); resetComboMax(); resetHpPlayer(); resetKilllist(); }

    private void Update()
    { 
        HPcap(playerHpCurrent, playerHpMax); 
        if(killList.Count >= killsToWin)
        {
            print("Mission Accomplished");
            SceneManager.LoadScene(nextScene);
        }
    }


    private void resetHpPlayer()      { playerHpCurrent = playerHpMax; }
    private void resetScore()         { currentScore    = 0;           }
    public  void resetComboCurrent()  { currentCombo    = 0;           }
    private void resetComboMax()      { maxCombo        = 0;           }
    private void resetKilllist()      { killList.Clear();              }
 
    public void updateScore(string foeName, int scoreGain)
    {
        
        currentScore += scoreGain;
        currentCombo++;      
        print("You've killed a " + foeName);
        foeKilledTotal++;
        switch (foeName)
        {
            case "Ghost":
                foeKilledGhost++;
                break;
            case "Troll":
                foeKilledTroll++;
                break;
            default:
                foeKilledDragon++;
                break;            
        }
        // COMBO MAX:
        if (currentCombo > maxCombo) 
        {
            print("New Max Combo: " + maxCombo);
            maxCombo = currentCombo; 
        }

        // ADD TO KILLLIST:
        killList.Add(foeName);
        lastKilled = foeName;
    }

    private void HPcap(int current, int max)
    {   
        if (current == max)
        {
            isFullHp = true;
        }
        else
        {
            isFullHp = false;
            if (current > max) 
            { 
                current = max;            
            } 
            else if (current < 0) 
            { 
            current = 0; 
            }

        }
        playerHpCurrent = current;
    }




}
