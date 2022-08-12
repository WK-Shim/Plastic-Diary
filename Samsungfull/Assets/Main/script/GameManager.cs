using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public int ytrash;
    public int ttrash;
    public float fps;
    public float progress;
    public GameObject effect;
    public float mapgoal1;
    public float mapgoal2;
    float time = 0;
    GameObject trash;
    public int mapnumber;
    public TextAsset gamegoals;
    // Start is called before the first frame update
    void Start()
    {
        //checking goals
        if (mapnumber == null || mapnumber == 0)
        {
            mapnumber = 1;
        }
        StringReader streader = new StringReader(gamegoals.text);
        string line = streader.ReadLine();
        mapgoal1 = int.Parse(line.Split(',')[mapnumber - 1]);
        mapgoal2 = int.Parse(line.Split(',')[mapnumber]);

        //main scene startup settings

        trash = GameObject.FindWithTag("trash");
        if (ytrash == null || ytrash == 0)
        {
            print("sd");
            ytrash = 60;
        }
        progress = ytrash;
        for (int i = 0; i < mapgoal1 - ytrash; i++)
        {
            Vector3 rdposition = new Vector3(Random.Range(-100, 101), transform.position.y, Random.Range(-100, 101));
            gameObject.transform.position = rdposition;
            if (Physics.Raycast(transform.position, transform.up * -1, out RaycastHit hit))
            {

                GameObject prefab = Instantiate(trash.transform.GetChild(Random.Range(0, 2)).gameObject, hit.point, transform.rotation);
                prefab.tag = "plastic";

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        fps = 1 / Time.deltaTime;
        time += Time.deltaTime;
        if (ttrash > progress)
        {
            if (time > 0.01 && progress < mapgoal1)
            {
                Instantiate(effect, GameObject.FindWithTag("plastic").transform.position, GameObject.FindWithTag("plastic").transform.rotation);
                destroytrash();
                print("ii");
            }
            else if (time > 0.01 && progress >= mapgoal1 && progress < mapgoal2)
            {
                print("f");
                planttree();
            }
        }
    }
    void destroytrash()
    {
        Destroy(GameObject.FindWithTag("plastic"));
        progress += 1;
    }
    void planttree()
    {
        
       

        Vector3 rdposition = new Vector3(Random.Range(-50, 101), transform.position.y, Random.Range(-100, 101));
        gameObject.transform.position = rdposition;
        if (Physics.Raycast(transform.position, transform.up * -1, out RaycastHit hit))
        {
            print("1");
            GameObject prefab = Instantiate(GameObject.FindWithTag("treehaven").transform.GetChild(Random.Range(0, GameObject.FindWithTag("treehaven").transform.childCount)).gameObject, hit.point, transform.rotation);
            progress += 1;
        }
    }
}
