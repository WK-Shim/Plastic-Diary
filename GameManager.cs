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
    public int test;
    // Start is called before the first frame update
    void Start()
    {
        //checking goals
        if (mapnumber == 0)
        {
            mapnumber = 1;
        }
        StringReader streader = new StringReader(gamegoals.text);
        string line = streader.ReadLine();
        mapgoal1 = int.Parse(line.Split(',')[mapnumber - 1]);
        mapgoal2 = int.Parse(line.Split(',')[mapnumber]);

        //main scene startup settings
        trash = GameObject.FindWithTag("trash");
        //fundemental object spawn
        progress = ytrash;
        if (ytrash < mapgoal1)
        {
            for (int i = 0; i < mapgoal1 - ytrash; i++)
            {
                i -= trash_spawn();
            }
        }
        else
        {
            for (int i = 0; i < ytrash - mapgoal1; i++)
            {
                i -= tree_spawn();
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
                destroy_trash();
            }
            else if (time > 0.01 && progress >= mapgoal1 && progress < mapgoal2)
            {
                tree_spawn();
            }
        }
    }
    void destroy_trash()
    {
        Destroy(GameObject.FindWithTag("plastic"));
        progress += 1;
    }
    int tree_spawn()
    {

        Vector3 rdposition = random_position(100);
        gameObject.transform.position = rdposition;
        Debug.DrawRay(transform.position, Vector3.up * -1, Color.green);
        if (Physics.Raycast(transform.position, transform.up * -1, out RaycastHit hit))
        {
            if (hit.collider.gameObject.tag == "antispawn")
            {
                return 1;
            }
            GameObject prefab = Instantiate(GameObject.FindWithTag("tree").transform.GetChild(Random.Range(0, GameObject.FindWithTag("tree").transform.childCount)).gameObject, hit.point, transform.rotation);
            progress += 1;
        }
        return 0;
    }
    int trash_spawn()
    {
        Vector3 rdposition = random_position(100);
        gameObject.transform.position = rdposition;
        if (Physics.Raycast(transform.position, transform.up * -1, out RaycastHit hit))
        {
            if (hit.collider.gameObject.tag != "antispawn")
            {
                GameObject prefab = Instantiate(trash.transform.GetChild(Random.Range(0, 1)).gameObject, hit.point, transform.rotation);
                prefab.tag = "plastic";
                return 0;
            }
        }
        return 1;
    }
    Vector3 random_position(float a)
    {
        return(new Vector3(Random.Range(-a, a + 1), transform.position.y, Random.Range(-a, a + 1)));
    }
}