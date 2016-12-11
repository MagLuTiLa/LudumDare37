using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] prefabs;

    [SerializeField]
    float minDistance;
    [SerializeField]
    float maxDistance;

    [SerializeField]
    int numberOfTrees;

    [SerializeField]
    float minScale = 0.7f;

    [SerializeField]
    float maxScale = 1.5f;

    void SpawnTree()
    {

        float distance = minDistance + Random.Range(0, maxDistance - minDistance);
        Vector2 suggestion = Random.insideUnitCircle.normalized * distance;
        Vector3 position = new Vector3(suggestion.x, 0, suggestion.y);

        GameObject tree = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform);
        tree.transform.localPosition = position;

        Vector3 scale = new Vector3(Random.Range(minScale, maxScale), Random.Range(minScale, maxScale), Random.Range(minScale, maxScale));
        scale.Scale(tree.transform.localScale);
        tree.transform.localScale = scale;
    }

	// Use this for initialization
	void Start () {
        for (int i = 0; i < numberOfTrees; ++i)
            SpawnTree();
	}
}
