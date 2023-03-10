using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{

    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualsObject;
    private void Start()
    {
        Player.Instance.OnSelectedCounterChange += Player_OnSelectedCounterChange; 
    }

    private void Player_OnSelectedCounterChange(object sender, Player.OnSelectedCounterChangeEventArgs e)
    {
       if(e.selectedCounter == baseCounter)
        {
            Show();
        } else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach(GameObject visualGameObject in visualsObject)
        {
            visualGameObject.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach(GameObject visualGameObject in visualsObject)
        {
            visualGameObject.SetActive(false);
        }
    }
}
