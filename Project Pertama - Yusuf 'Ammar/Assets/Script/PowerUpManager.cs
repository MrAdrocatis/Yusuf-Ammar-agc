using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform SpawnArea;
    public int Max_Power_Up_Amount;
    public int SpawnInterval;
    public float DelayTime;
    public Vector2 Power_Up_Area_Min;
    public Vector2 Power_Up_Area_Max;
    public List<GameObject> PowerUpTemplateList;
    public Transform leftPaddle;
    public Transform rightPaddle;
   
    private List<GameObject> PowerUpList;

    private float timer;

    private void Start()
    {
        PowerUpList = new List<GameObject>();
        timer = 0;
        

    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > SpawnInterval)
        {
            GenerateRandomPowerUp();
            Debug.Log("Test");
            timer -= SpawnInterval;
        }

       





    }
    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(Power_Up_Area_Min.x, Power_Up_Area_Max.x), Random.Range(Power_Up_Area_Min.y, Power_Up_Area_Max.y)));
    }
    public void GenerateRandomPowerUp(Vector2 position)
    {
        

        if (position.x < Power_Up_Area_Min.x ||
            position.x > Power_Up_Area_Max.x ||
            position.y < Power_Up_Area_Min.y ||
            position.y > Power_Up_Area_Max.y)
        {
            return;
        }

        if (PowerUpList.Count >= Max_Power_Up_Amount)
        {
            return;
        }

        int randomIndex = Random.Range(0, PowerUpTemplateList.Count);
        GameObject PowerUp = Instantiate(PowerUpTemplateList[randomIndex], new Vector3(position.x, position.y, PowerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, SpawnArea);
        PowerUp.SetActive(true);

        
        PowerUpList.Add(PowerUp);

        StartCoroutine(RemovePowerUpOnCertainOfTime(PowerUp));
    }

    public void RemovePowerUp(GameObject PowerUp)
    {
        PowerUpList.Remove(PowerUp);
        Destroy(PowerUp);
        Debug.Log("test");
    }
    

    public void RemoveAllPowerUp()
    {
        while (PowerUpList.Count > 0)
        {
            RemovePowerUp(PowerUpList[0]);
        }
        
    }

    private IEnumerator RemovePowerUpOnCertainOfTime(GameObject PowerUp)
    {
        yield return new WaitForSeconds(DelayTime);

        RemovePowerUp(PowerUp);
        Destroy(PowerUp);
    }

    

   

}
