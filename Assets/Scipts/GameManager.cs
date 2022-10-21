using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject basicPlatform;
    public GameObject weakPlatform;
    public GameObject spikePlatform;
    public GameObject jumpPad;
    public GameObject starterPlatform;
    public Transform targetTransform;


    public float targetFloat;
    private float lastSpawnPos;


    public int platformMaxCount = 10;

    private int lastPlatform = 0;
    private int maxOfWeakPlatforms;
    private int maxOfSpikePlatforms;
    private int maxOfDangerousPlatforms;

    List<GameObject> platformPrefabs = new List<GameObject>();
    List<GameObject> safePlatformPrefabs = new List<GameObject>();
    List<GameObject> platformsInScene = new List<GameObject>();

    private GameObject savedPlatform;

    private bool needSaferPlatforms = false;
    private bool coroutineStarted = false;

    void Start()
    {

        platformPrefabs.Add(basicPlatform);
        platformPrefabs.Add(weakPlatform);
        platformPrefabs.Add(spikePlatform);
        platformPrefabs.Add(jumpPad);

        safePlatformPrefabs.Add(basicPlatform);
        safePlatformPrefabs.Add(jumpPad);

        platformsInScene.Add(starterPlatform);

        PlatformInstantiator(safePlatformPrefabs[Random.Range(0, platformPrefabs.Count)]);
        for (int i = 0; i < platformMaxCount; i++)
        {
    
        }

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void FixedUpdate()
    {
    }


    public void SpawnPlatforms()
    {
        for (int i = 0; i < platformMaxCount; i++)
        {
            OnSafeSpawnDangerousPlatform();
            Debug.Log(needSaferPlatforms);
        }
    }


    public void OnSafeSpawnDangerousPlatform()
    {
        if (needSaferPlatforms == true)
        {
            PlatformInstantiator(safePlatformPrefabs[Random.Range(0, safePlatformPrefabs.Count)]);
        }
        else
        {
            PlatformInstantiator(platformPrefabs[Random.Range(0, platformPrefabs.Count)]);
        }
    }


    public void PlatformInstantiator(GameObject platform)
    {
        Vector3 spawnPos = new Vector3();

        float minRandY = 0.2f;
        float maxRandY = 2f;
        float randX = 0.5f;

        //spawnPos.y += Random.Range(targetTransform.position.y + 0.5f, 1f);
        spawnPos.y += Random.Range(targetFloat + minRandY, targetFloat + maxRandY);
        spawnPos.x = Random.Range(-randX, randX);
        savedPlatform = GameObject.Instantiate(platform, spawnPos, Quaternion.identity) as GameObject;       
        platformsInScene.Add(savedPlatform);
        ClosestPlatformChecker(platformsInScene[lastPlatform], savedPlatform);
        lastPlatform++;      
    }

    public void ClosestPlatformChecker(GameObject targetPlatform, GameObject currentPlatform)
    {
        maxOfDangerousPlatforms = maxOfWeakPlatforms + maxOfSpikePlatforms;
        int dangerousPlatformLimit = 3;
        string currentPlatformTag = currentPlatform.tag;
        string targetPlatformTag = targetPlatform.tag;

        Debug.Log(maxOfDangerousPlatforms);
        if (currentPlatformTag != targetPlatformTag && maxOfDangerousPlatforms <= dangerousPlatformLimit)
        {
            maxOfDangerousPlatforms--;
            needSaferPlatforms = false;
        }

        else
        {           
            if (currentPlatformTag == "weakPlatform")
            {
                maxOfWeakPlatforms++;
            }
            else if (currentPlatformTag == "spikePlatform")
            {
                maxOfSpikePlatforms++;
            }
            needSaferPlatforms = true;
            maxOfDangerousPlatforms--;
        }
    }

}
