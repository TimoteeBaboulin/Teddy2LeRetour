using UnityEngine;
using UnityEngine.UI;

public class FlexibleLayoutGrid : LayoutGroup
{
    public enum CellMode
    {
        Horizontal,
        FlatHorizontalMod,
        HorizontalMod,
        IndHorizontal,
    }

    public enum ScrollMode
    {
        NoScrolling,
        VerticalScrolling
    }

    [Header("Cell Scaling Mode")]
    public CellMode mode = CellMode.Horizontal;
    public ScrollMode scroll = ScrollMode.NoScrolling;

    [Header("Maximum Number of cells")]
    public int columnsMax = 5;
    public int rowsMax = 5;

    [Header("Padding Between Cells")]
    public float paddingHorizontal;
    public float paddingVertical;
    
    [Header("Optional Variables")]
    public float horizontalMod = 0.9f;
    public int flatHorizontalMod = 5;

    private Vector2 _cellSize;
    
    // Start is called before the first frame update
    public override void CalculateLayoutInputVertical()
    {
    }

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        float parentWidth = rectTransform.rect.width;
        float parentHeight;
        if (scroll == ScrollMode.VerticalScrolling)
            parentHeight = rectTransform.parent.GetComponent<RectTransform>().rect.height;
        else
            parentHeight = rectTransform.rect.height;

        switch (mode)
        {
            case CellMode.Horizontal: 
                //Chaque cell a une largeur egale a la place totale divisee par le nombre de colonnes, mais il faut pas oublier de penser au padding
                _cellSize.x = (parentWidth - (paddingHorizontal * (columnsMax - 1) + padding.left + padding.right)) / columnsMax;
                _cellSize.y = _cellSize.x;
                break;
            
            case CellMode.IndHorizontal:
                _cellSize.x = (parentWidth - (paddingHorizontal * (columnsMax - 1) + padding.left + padding.right)) / columnsMax;
                _cellSize.y = (parentHeight - (paddingVertical * (rowsMax - 1) + padding.top + padding.bottom)) / rowsMax;
                break;
            
            case CellMode.HorizontalMod:
                _cellSize.x = (parentWidth - (paddingHorizontal * (columnsMax - 1) + padding.left + padding.right)) / columnsMax;
                _cellSize.y = _cellSize.x * horizontalMod;
                break;
            
            case CellMode.FlatHorizontalMod:
                _cellSize.x = (parentWidth - (paddingHorizontal * (columnsMax - 1) + padding.left + padding.right)) / columnsMax;
                _cellSize.y = _cellSize.x + flatHorizontalMod;
                break;
        }
        
        for (int x = 0; x < rectChildren.Count; x++)
        {
            int horizontalIndex = x % columnsMax;
            int verticalIndex = Mathf.FloorToInt((float) x / columnsMax);

            var child = rectChildren[x];

            SetChildAlongAxis(child, 0,
                (horizontalIndex * _cellSize.x + paddingHorizontal * horizontalIndex + padding.left),
                _cellSize.x);
            SetChildAlongAxis(child, 1,
                (verticalIndex * _cellSize.y + paddingVertical * verticalIndex + padding.top), _cellSize.y);
        }
    }

    public override void SetLayoutHorizontal()
    {
        
    }

    public override void SetLayoutVertical()
    {
        
    }
}
