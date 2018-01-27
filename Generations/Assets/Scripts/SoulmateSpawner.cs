using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoulmateSpawner : MonoBehaviour {

    public GameObject matePrefab;
    public int mateCount = 4;
    private List<Transform> spawnPositions;

    // Use this for initialization
    void Start() {
        spawnPositions = transform.GetComponentsInChildren<Transform>().ToList();
        Random rng = new Random();
        Debug.Assert(mateCount <= spawnPositions.Count);
        List<int> randomPositions = new List<int>();
        while (randomPositions.Count != mateCount) {
            int randomIndex = Random.Range(0, spawnPositions.Count);
            if (!randomPositions.Contains(randomIndex)) {
                randomPositions.Add(randomIndex);
            }
        }
        foreach (var i in randomPositions) {
            SpawnMate(spawnPositions[i].position);
        }

    }

    private void SpawnMate(Vector2 position) {
        GameObject mate = Instantiate(matePrefab, position, Quaternion.identity);
        var bpc = mate.GetComponent<BodyPartCollection>();
        List<int> bodyPartLevels = new List<int>();
        foreach (PlayerUpgrades.BodyPart partType in Enum.GetValues(typeof(PlayerUpgrades.BodyPart))) {
            SceneLoader sl = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
            int randomLevel = Random.Range(0, sl.currentStage);
            if (randomLevel > 1) {
                bpc.AddPart(partType);
                for (int i = 0; i < randomLevel; ++i) {
                    PlayerUpgrades pu = mate.GetComponent<PlayerUpgrades>();
                    pu.Upgrade(partType);
                }
            }
            bodyPartLevels.Add(randomLevel);
        }
    }

}
