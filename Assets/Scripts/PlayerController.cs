using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
public float speed;
public Bullet bullet;
public float bulletCD;
public GameManager gameManager;
    void Update()
    {
      bulletCD -= Time.deltaTime;
      float x = Input.GetAxisRaw("Horizontal");  
      float y = Input.GetAxisRaw("Vertical"); 
      Vector2 direction = new Vector2(x, y).normalized;    
      Move(direction);

      if(Input.GetKeyDown(KeyCode.Space) && bulletCD <= 0)
      {
       Shoot();
      }      
    }

    void Move(Vector2 direction)
    {
      Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));  
      Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1)); 

      max.x = max.x - 2f;
      min.x = min.x + 0.20f;

      max.y = max.y - 0.20f;
      min.y = min.y + 0.20f;

      Vector2 pos = transform.position;
      pos += direction * speed * Time.deltaTime;

      pos.x = Mathf.Clamp(pos.x,min.x, max.x);
      pos.y = Mathf.Clamp(pos.y,min.y, max.y);

      transform.position = pos;
    }

    public void Shoot()
    {
      GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
      bulletCD = 0.6f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.CompareTag("Enemy"))
      {
        Destroy(gameObject);
        gameManager.GameOver();
      }
    }
}
