using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStop : MonoBehaviour
{
    private GameObject angle;   //�v���C���[���i�[�p
    private Vector3 offset;      //���΋����擾�p
   // public float Ypos = 1,Zpos=-10f;

    // Start is called before the first frame update
    void Start()
    {
        //unitychan�̏����擾
        

        // MainCamera(�������g)��player�Ƃ̑��΋��������߂�
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y+Ypos, Zpos);

    }

    // Update is called once per frame
    void Update()
    {
        //�V�����g�����X�t�H�[���̒l��������
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y + Ypos, Zpos); ;

        if (transform.position.y <= -2.5)
        {
            transform.DetachChildren();
        }
    }
}
