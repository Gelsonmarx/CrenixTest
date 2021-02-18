using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }
    void Awake()
    {
        _instance = this as GameManager;
    }

    [System.Serializable]
    public class AssignObjects
    {
        public List<GameObject> gearsIcon;
        public List<GameObject> gearsNormal;

        public List<Rotator> rotators;

        public List<SlotItem> slots;
        public List<SlotItem> slotsIcons;

        public Text NuggetText;
    }

    public AssignObjects assignObjects;

    public bool isFinished()
    {
        foreach (var item in assignObjects.slots)
        {
            if(item.Filled == false)
            {
                return false;
            }
        }
        return true;
    }

    public void CheckEndGame()
    {
        if(isFinished())
        {
            PhraseAndRotate("Yay, parabéns.\nTask concluída!", true, false);
            
        } else
        {
            PhraseAndRotate("Encaixe as engrenagens\nem qualquer ordem!", false, false);
        }
    }

    public void ResetGame()
    {
        PhraseAndRotate("Encaixe as engrenagens\nem qualquer ordem!", false, true);
    }

    void PhraseAndRotate(string phrase, bool rotate, bool isReset = false)
    {
        foreach (var item in assignObjects.rotators)
        {
            item.ShouldRotate = rotate;
            if(isReset)
                item.gameObject.SetActive(false);
        }
        assignObjects.NuggetText.text = phrase.ToUpper();
        if(isReset)
        {

            foreach (var item in assignObjects.slots)
            {
                item.Filled = false;

            }
            foreach (var item in assignObjects.slotsIcons)
            {
                item.Filled = true;

            }
            foreach (var item in assignObjects.gearsIcon)
            {
                item.SetActive(true);
                item.GetComponent<Image>().color = item.GetComponent<DragItem>().color;
            }
            foreach (var item in assignObjects.gearsNormal)
            {
                item.SetActive(false);
            }
        }
    }
}
