using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{

    private AudioSource pop ;
   
     public Text Text2;
     private int count; 

   public Rigidbody _rb; 
   [SerializeField]
   private float _movementX; 
      [SerializeField]

   private float _movementY; 
    [SerializeField]

   private float _speed; 

   public GameObject _panelWin;

   
    // Start is called before the first frame update
    void Start()
    {

//rb = GetComponent<Rigidbody>();
 setCountText();
 pop=GetComponent<AudioSource>();
 //Text2.text="";
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate(){
        Vector3 _rigidbodyVector = new Vector3(_movementX,0, _movementY); 
        _rb.AddForce(_rigidbodyVector * _speed); 

    }
    
    public void OnMove(InputValue _mouvementValue){
        Vector2 _mouvementVector = _mouvementValue.Get<Vector2>(); 
        _movementX=_mouvementVector.x; 
        _movementY=_mouvementVector.y; 
    }


private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("pickup"));
    {
         Destroy(other.gameObject);

          count= count+1;
         pop.Play(); 
          setCountText();
    }
      
    
}


 void setCountText(){
   Text2.text= "count :" +count.ToString();
   if (count>=5){
          _panelWin.SetActive(true);
          Time.timeScale = 0;
   }
 } 

}
