using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PopulationManager : MonoBehaviour
{

    public GameObject personPrefab;
    public int populationSize = 10;
    List<GameObject> population = new List<GameObject>();
    public static float elapsed = 0;
    int trialTime = 10;
    int generation = 1;

    GUIStyle guiStyle = new GUIStyle();
    private void OnGUI()
    {
        guiStyle.fontSize = 50;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 180, 28), "Generation:" + generation, guiStyle);
        GUI.Label(new Rect(10, 60, 180, 28), "Trial Time:" +(int)elapsed, guiStyle);
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < populationSize; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-30.2f, 30.2f), Random.Range(-11.5f, 11.5f), 0);
            GameObject go = Instantiate(personPrefab, pos, Quaternion.identity);
            go.GetComponent<DNA>().r = Random.Range(0.0f, 1.0f);
            go.GetComponent<DNA>().g = Random.Range(0.0f, 1.0f);
            go.GetComponent<DNA>().b = Random.Range(0.0f, 1.0f);
            population.Add(go);

        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsed = Time.deltaTime;
        if(elapsed == trialTime)
        {
            BreedNewPopulation();
            elapsed = 0;
        }
    }

    void BreedNewPopulation()
    {
        List<GameObject> newPopulation = new List<GameObject> ();

        List<GameObject> sortedPopulation = population.OrderBy(x => x.GetComponent<DNA>().timeToDie).ToList();

        population.Clear();

        for(int i = (int)(sortedPopulation.Count/2.0f)-1; i< sortedPopulation.Count; i++)
        {
            population.Add(Breed(sortedPopulation[i], sortedPopulation[i+1]));
            population.Add(Breed(sortedPopulation[i+1], sortedPopulation[i ]));
        }
        generation++;

    }

    GameObject Breed(GameObject one, GameObject two)
    {
        return new GameObject();
    }
}
