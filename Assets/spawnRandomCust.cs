using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRandomCust : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject table;
    public Animator tablesAnim;
    private int posTable=0;
    private int NUMBTABLE = 4;
    private int numbTableAvailable;
    private float timePassed = 3f;
    private float minTimeSpawn = 2;//15f;
    private float maxTimeSpawn = 3;//20f;
    private int numbCustNeeded = 10;
    private int MaxWave = 6;
    private int waveCust=10;
    private int numbCust=10;
    private float timeRandomSpawn=0;
    private bool isFull=false;
    private bool wait = true;
    
    
    void Start()
    {
        StartCoroutine(MyCoroutine(waveCust));
        tablesAnim = GameObject.Find("Tables").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(numbCust<=0){
            //pause things between 
            MaxWave++;
            waveCust+=5;
            numbCust=waveCust;
            Debug.Log("newww");

            StartCoroutine(MyCoroutine(waveCust));
        }
        
    }
    
    private float RandomTime(){
        timeRandomSpawn = Random.Range(minTimeSpawn, maxTimeSpawn);
        return timeRandomSpawn;
    }
    IEnumerator MyCoroutine(int waveCust){
        while(numbCust>=0){
            if(tablesAnim.GetInteger("availableTable")>0){
                yield return new WaitForSeconds(RandomTime());
                posTable = Random.Range(1,NUMBTABLE+1);
            
                while (IsAvailableSit(posTable)==false){
                    posTable = Random.Range(1,NUMBTABLE+1);
                }
                if(tablesAnim.GetInteger("availableTable")>0){
                    numbCust--;
                }
            }else{
                yield return new WaitForSeconds(1);
            }
            
        }   
    }
    private bool IsAvailableSit(int posTable){
        table = GameObject.Find("/Tables/Table"+posTable+"");

        if(tablesAnim.GetInteger("availableTable")<=0){
            return true;
        }else if(table.GetComponent<Animator>().GetBool("isCustomerP")==false){
            numbTableAvailable = tablesAnim.GetInteger("availableTable");
            numbTableAvailable--;
            tablesAnim.SetInteger("availableTable",numbTableAvailable);

            table.GetComponent<Animator>().SetBool("isCustomerP",true);
            return true;
        }else{
            return false;
        }
    }
}
