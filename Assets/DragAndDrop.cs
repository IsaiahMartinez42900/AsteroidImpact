using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class DragAndDrop : MonoBehaviour
{


    Vector3 defaultPos;
    Vector3 targetPos;
    //Vector3 characterMove;
    //Vector3 mousePosition;
    public float speed = 1f;
    float timeElapsed = 0f;
    float cycle = 2.5f;
    int direction = 1;
    public GameManager manager;
    
   // private bool isLocked = false;
    private void Start()
    {
        defaultPos = transform.position;
        targetPos = defaultPos;
        
    }
    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    void OnMouseDrag()
    {
        if (manager.GameOver == true)
        {
            return;
        }
        transform.position = GetMouseWorldPosition();
        Debug.Log("Drag");
       /* if (isLocked)
        {
            Debug.Log("It's Locked");
            return;
            
        }*/
        
        //Debug.Log("drag");
       /* if (targetPos != defaultPos)
        {
            
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string myTag = this.tag;

        if ((myTag == "GreenCharacter" && collision.CompareTag("GreenBunker")) ||
            (myTag == "RedCharacter" && collision.CompareTag("RedBunker")) ||
            (myTag == "BlueCharacter" && collision.CompareTag("BlueBunker")))
        {
            //isLocked = true;
            targetPos = collision.transform.position;
            manager.score++;
            Destroy(gameObject);
            
            Debug.Log("it works");
        }
   

       // transform.position = defaultPos;
    }
    private void OnMouseUp()
    {
        transform.position = targetPos;
        if (targetPos != defaultPos)
        {
            speed = 0;
            
        }
            //speed = 0f;


        //Debug.Log("drag ended"); 
        // if (Collider2d

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GreenBunker"))
        {
            targetPos = defaultPos;
        }
        if (collision.CompareTag("BlueBunker"))
        {
            targetPos = defaultPos;
        }
        if (collision.CompareTag("RedBunker"))
        {
            targetPos = defaultPos;
        }
        
    }
    private void Update()
    {
        if (manager.GameOver == true)
        {
            return;
        }
        //characterMove = transform.position;
        transform.Translate(speed * Time.deltaTime * direction, 0, 0);
        if (timeElapsed < cycle)
        {
            timeElapsed += Time.deltaTime;
        }
        else
        {
            timeElapsed = 0;
            direction *= -1;
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * direction;
            transform.localScale = scale;
           
        }

    }
}