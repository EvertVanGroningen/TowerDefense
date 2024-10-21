using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject TowerToPlace;
    private GameObject draggedTower;
    private Camera mainCamera;
    public int Money = 50;
    public int cost = 10;
    public Text MoneyText;
    public float WaitForMoney = 2.0f;
    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(IncreaseCounter());
    }

    void Update()
    {
        UpdateMoney();
    }

    IEnumerator IncreaseCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(WaitForMoney);
            Money++;
            Debug.Log("Money: " + Money);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Money >= cost) 
        {
        draggedTower = Instantiate(TowerToPlace, mainCamera.ScreenToWorldPoint(eventData.position), Quaternion.identity);
        draggedTower.transform.position = new Vector3(draggedTower.transform.position.x, draggedTower.transform.position.y, 0);
        }
        else
        {
            Debug.Log("Haha you are broke");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggedTower != null)
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(eventData.position);
            draggedTower.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedTower != null)
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(eventData.position);
            draggedTower.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            Money -= cost;
            UpdateMoney();
            draggedTower = null;
        }
    }

    public void UpdateMoney()
    {
        if(MoneyText != null)
        {
            MoneyText.text = "Money: " + Money;
        }
    } 
}