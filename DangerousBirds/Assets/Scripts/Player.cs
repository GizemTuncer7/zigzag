using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Vector3 direction;
    public float speed;
    public create_platform creatingPlatform;
    public static bool isAlive;
    public float hardness;
    float score;
    public float increaseScore;
    public Text textScore;
    int highScore;
    
    
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        isAlive = true;
        direction = Vector3.back;//z'si 1 yani ileri hareket ediyor
    }

   
    void Update()
    {
        if (isAlive == false)
        {
           
            return;
        }
        if (Input.GetMouseButtonDown(0)) //Farenin sol tuþuna týklandýysa
        {
            if (direction.x == 0)
            {
                direction = Vector3.right;
            }
            else
            {
                direction=Vector3.back;
            }
           
        }
        if (transform.position.y < 0.1f)
        {
            Dead();
        }
    }
    private void FixedUpdate()
    {
        if (isAlive == false)
        {
            return;//bu þekilde düþünce skor artmaya devam etmeyecek...
        }
        Vector3 movement = direction * Time.deltaTime * speed;
        transform.position += movement;
        
        speed +=hardness*Time.deltaTime;
        score += increaseScore * speed*Time.deltaTime;
        textScore.text=((int)(score)).ToString();
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "platform")
        {
            StartCoroutine(Removing(other.gameObject));
            creatingPlatform.CreatingPlatform();
        }
    }
    void Dead()
    {
        if (highScore < (int)score)
        {
            isAlive= false;
            highScore = (int)score;
            PlayerPrefs.SetInt("highScore", highScore);//Bu þekilde önceden olan bilgiyi playerprefabine kaydeder.
            Debug.Log("yeni yüksek skor...");
                                                       
        }
    }
    IEnumerator Removing(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
