using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   public static BoxCollider2D Boxcollider;
   public static Animator animator;
   void Start(){
        animator = GetComponent<Animator>();
        Boxcollider = GetComponent<BoxCollider2D>();
   }
}
