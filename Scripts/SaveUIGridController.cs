using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveUIGridController : MonoBehaviour
{
    public SaveUIGrid gridPrefab;

    public List<SaveUIGrid> grids = new List<SaveUIGrid>();

    public int gridCount = 3;

    GridLayoutGroup gridLayoutGroup;

    private void Start()
    {
        gridCount = SaveManager.Instance.saves.saves.Count;
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        InitializeGrids();
    }

    void InitializeGrids()
    {
        for (int i = 0; i < gridCount; i++)
        {
            SaveUIGrid grid = Instantiate(gridPrefab, transform);
            grid.gameObject.SetActive(true);
            grids.Add(grid);
            int a = i;
            grid.saveIndex = a;
        }

        //µ÷ÕûRectTransformµÄHeight
        RectTransform rectTransform = GetComponent<RectTransform>();

        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, gridCount * gridPrefab.GetComponent<RectTransform>().rect.height);
    }
}
