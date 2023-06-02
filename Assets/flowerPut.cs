using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class flowerPut : MonoBehaviour
{
    public GameObject startObject;
    public GameObject endObject;
    public GameObject objectToCopy;
    public GameObject flowerController;

    private float ineerTimer = 0;
    private bool ineerTimerRunning = false;
    private float timeOfFirstAnimation = .8f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ineerTimerRunning)
        {
            ineerTimer += Time.deltaTime;
        }

        if (ineerTimer >= timeOfFirstAnimation)
        {
            ineerTimerRunning = false;
            ineerTimer = 0;
            flowerController.GetComponent<FlowerCounter>().player.GetComponent<Animator>().SetBool("PickingFromGround", false);

            int count = 0;
            int.TryParse(flowerController.GetComponent<FlowerCounter>().flowerCanvasText.GetComponent<TMP_Text>().text, out count);

            CopyObjectsAlongLine(count);

            // disable self
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }

    private void CopyObjectsAlongLine(int numberOfCopies)
    {
        Vector3 startPosition = startObject.transform.position;
        Vector3 endPosition = endObject.transform.position;
        Vector3 direction = (endPosition - startPosition).normalized;

        float distance = Vector3.Distance(startPosition, endPosition);
        float spacing = distance / (numberOfCopies + 1);

        for (int i = 0; i < numberOfCopies; i++)
        {
            Vector3 spawnPosition = startPosition + direction * spacing * (i + 1);
            GameObject newObject = Instantiate(objectToCopy, spawnPosition, Quaternion.identity);
            newObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ineerTimerRunning = true;
        flowerController.GetComponent<FlowerCounter>().player.GetComponent<Animator>().SetBool("PickingFromGround", true);
    }
}