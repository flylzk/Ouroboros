using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;

public enum Direction
{
    Left,Right,Up,Down,NULL,
}
public class CharacterMove : MonoBehaviour
{
    [SerializeField]private bool moveable = false;
    [SerializeField]private bool isMoving = false;
    [SerializeField]private Direction LastDirection = Direction.NULL;
    [SerializeField]private Direction CurDirection = Direction.NULL;
    [SerializeField]private float Fluency = 0.02f;
    [SerializeField] private int speed = 1;
    [SerializeField] private int BodyColor = 0;
    [SerializeField] GameObject BlackBody;
    [SerializeField] GameObject WhiteBody;
    public bool Moveable { get { return moveable; } set { moveable = value; } }
    public bool IsMoving
    {
        get { return isMoving; }
    }

    void Move()
    {
        Vector3 MoveDir = (CurDirection == Direction.Left)? Vector3.left : (CurDirection == Direction.Right)? Vector3.right:(CurDirection == Direction.Up)?Vector3.forward:Vector3.back;
        transform.position += MoveDir * Fluency*speed;
        GameObject temp = (BodyColor == 0)?BlackBody : WhiteBody;
        Vector3 Pos = transform.position;
        Pos -= transform.localScale.x/2 * MoveDir;
        for (int i = 0; i < speed; i++)
        {
            GameObject t = Instantiate(temp, Pos-MoveDir*Fluency*(2*i+1)/2,Quaternion.identity ) as GameObject;
            t.transform.localScale = new Vector3((MoveDir.x==0)?transform.localScale.x:Mathf.Abs(MoveDir.x)*Fluency,transform.localScale.y, (MoveDir.z == 0) ? transform.localScale.z : Mathf.Abs(MoveDir.z) * Fluency);
            if(BodyColor == 0)
            {
                GameObject p = GameObject.Find("WhiteBodyCollection");
                if (p==null)
                {
                    p = new GameObject("WhiteBodyCollection");
                }
                t.transform.SetParent(p.transform);
            }
            else
            {
                GameObject p = GameObject.Find("BlackBodyCollection");
                if (p == null)
                {
                    p = new GameObject("BlackBodyCollection");
                }
                t.transform.SetParent(p.transform);
            }
        }
    }
    void Died()
    {
        isMoving = false ;
        moveable = false ;
    }
    Direction GetDirection()
    {
        Direction direction = Direction.NULL;
        if (Input.GetKeyDown(GameManager.Up)) { direction = Direction.Up; }
        if (Input.GetKeyDown(GameManager.Down)) { direction = Direction.Down; }
        if (Input.GetKeyDown(GameManager.Left)) { direction = Direction.Left; }
        if (Input.GetKeyDown(GameManager.Right)) { direction = Direction.Right; }
        return direction;
    }
    Direction GetBackDir(Direction d)
    {
        Direction dir = Direction.NULL;
        if(d == Direction.Left) { dir = Direction.Right;}
        if(d == Direction.Right) { dir = Direction.Left; }
        if(d == Direction.Up) {dir = Direction.Down;}
        if(d == Direction.Down) {dir = Direction.Up;}
        return dir;
    }
    private void Start()
    {
        BlackBody = Resources.Load<GameObject>("Pre/BlackBody");
        WhiteBody = Resources.Load<GameObject>("Pre/WhiteBody");
    }
    private void Update()
    {
        if (moveable&&!isMoving)
        {
            CurDirection = GetDirection();
            if(CurDirection!=Direction.NULL&&CurDirection != GetBackDir(LastDirection)&&CurDirection != LastDirection&&!isMoving)
            {
                isMoving = true;
                LastDirection = CurDirection;
            }
        }
    }
    private void FixedUpdate()
    {
        if (moveable && isMoving)
        {
            Move();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Untouchable")
        {
            Died();
        }
        if(other.tag == "Barrier")
        {
            isMoving = false;
        }
    }
}
