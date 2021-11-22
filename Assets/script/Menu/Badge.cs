using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Badge : MonoBehaviour
{
    Choice c;

    [SerializeField]
    Sprite gold, silver;
    void Start()
    {
        c = GameObject.FindGameObjectWithTag("choicemanager").GetComponent<Choice>();

        if (this.transform.parent.gameObject.name == "Stage1") stage1();
        if (this.transform.parent.gameObject.name == "Stage2") stage2();
        if (this.transform.parent.gameObject.name == "Stage3") stage3();

    }

    private void stage1()
    {
        if (Choice.ClearFlag[0] == true || c.clearget() >= 1)
        {
            gameObject.SetActive(true);
            this.GetComponent<Image>().sprite = gold;
        }
        else if (Choice.ReleaseFlag[0] == true || c.releaseget() >= 1)
        {
            gameObject.SetActive(true);
            this.GetComponent<Image>().sprite = silver;
        }
    }

    private void stage2()
    {
        if (Choice.ClearFlag[1] == true || c.clearget() >= 2)
        {
            gameObject.SetActive(true);
            this.GetComponent<Image>().sprite = gold;
        }
        else if (Choice.ReleaseFlag[1] == true || c.releaseget() >= 2)
        {
            gameObject.SetActive(true);
            this.GetComponent<Image>().sprite = silver;
        }
    }

    private void stage3()
    {
        if (Choice.ClearFlag[2] == true || c.clearget() >= 3)
        {
            gameObject.SetActive(true);
            this.GetComponent<Image>().sprite = gold;
        }
        else if (Choice.ReleaseFlag[2] == true || c.releaseget() >= 3)
        {
            gameObject.SetActive(true);
            this.GetComponent<Image>().sprite = silver;
        }
    }

    private void stage4()
    {
        if (Choice.ClearFlag[3] == true || c.clearget() >= 4)
        {
            gameObject.SetActive(true);
            this.GetComponent<Image>().sprite = gold;
        }
        else if (Choice.ReleaseFlag[3] == true || c.releaseget() >= 4)
        {
            gameObject.SetActive(true);
            this.GetComponent<Image>().sprite = silver;
        }
    }

    private void stage5()
    {
        if (Choice.ClearFlag[4] == true || c.clearget() >= 5)
        {
            gameObject.SetActive(true);
            this.GetComponent<Image>().sprite = gold;
        }
        else if (Choice.ReleaseFlag[4] == true || c.releaseget() >= 5)
        {
            gameObject.SetActive(true);
            this.GetComponent<Image>().sprite = silver;
        }
    }

}
