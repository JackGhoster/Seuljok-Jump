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


    public int platformSpawnCount = 10;
    public int platformLimit = 50;

    private int lastPlatform = 0;
    private int weakPlatformCounter;
    private int spikePlatformCounter;
    private int dangerousPlatformCounter = 0;
    private int destroyIndex = 0;

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
        //platformPrefabs.Add(spikePlatform);
        platformPrefabs.Add(jumpPad);

        safePlatformPrefabs.Add(basicPlatform);
        safePlatformPrefabs.Add(jumpPad);

        platformsInScene.Add(starterPlatform);
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
        for (int i = 0; i < platformSpawnCount; i++)
        {
            OnSafeSpawnDangerousPlatform();
            //Debug.Log(needSaferPlatforms);
        }
        //Debug.Log(string.Format("Number of objects in Scene: {0}",platformsInScene.Count));
    }


    public void OnSafeSpawnDangerousPlatform()
    {
        if (needSaferPlatforms == true)
        {
            PlatformInstantiator(safePlatformPrefabs[Random.Range(0, safePlatformPrefabs.Count)]);
            weakPlatformCounter = 0;
            spikePlatformCounter = 0;
            dangerousPlatformCounter = 0;
        }
        else
        {
            PlatformInstantiator(platformPrefabs[Random.Range(0, platformPrefabs.Count)]);
        }
    }


    public void PlatformInstantiator(GameObject platform)
    {
        Vector3 spawnPos = new Vector3();

        float minRandY = 0.3f;
        float maxRandY = 1.4f;
        float randX = 0.45f;

        //spawnPos.y += Random.Range(targetTransform.position.y + 0.5f, 1f);
        spawnPos.y += Random.Range(targetFloat + minRandY, targetFloat + maxRandY);
        spawnPos.x = Random.Range(-randX, randX);
        savedPlatform = GameObject.Instantiate(platform, spawnPos, Quaternion.identity) as GameObject;
        platformsInScene.Add(savedPlatform);
        
        PlatformChecker(platformsInScene[lastPlatform], savedPlatform);
        lastPlatform++;
    }

    public void PlatformChecker(GameObject targetPlatform, GameObject currentPlatform)
    {
        int dangerousPlatformLimit = 1;
        string currentPlatformTag = currentPlatform.tag;
        string targetPlatformTag = targetPlatform.tag;


        if (currentPlatformTag == "weakPlatform")
        {
            //Debug.Log("weak");
            weakPlatformCounter++;
        }
        else if (currentPlatformTag == "spikePlatform")
        {
            //Debug.Log("spike");
            spikePlatformCounter++;
        }

        else
        {
            needSaferPlatforms = false;
        }

        dangerousPlatformCounter = weakPlatformCounter + spikePlatformCounter;

        if (dangerousPlatformCounter > dangerousPlatformLimit)
        {
            needSaferPlatforms = true;
        }
    }


    public void DestroyOnPlatformCountLimitExceeded()
    {
        if (platformsInScene.Count > platformLimit)
        {
            for(int i = 0; i < platformsInScene.Count - 10; i++)
            {
                Destroy(platformsInScene[i]);     
                
            }
        }

    }

}
