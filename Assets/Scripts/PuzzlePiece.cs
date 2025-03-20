using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PuzzlePiece : MonoBehaviour, IPointerClickHandler
{
    private GameObject _puzzle;
    private Image _changeSprite;

    public void Start()
    {
        _puzzle = GameObject.Find("Puzzle");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_puzzle.GetComponent<Puzzle>().IsCompleted == true)
        {
            return;
        }
        
        // находим кусочки пазла находящиеся рядом по последней цифре в имени объекта
        var puzzlePieces = FindObjectsOfType<PuzzlePiece>();
        foreach (PuzzlePiece puzzlePiece in puzzlePieces)
        {
            //находим кусочки пазла ниже, выше, правее и левее выбранного кусочка пазла
            if (int.Parse(this.gameObject.name.ToString().Substring(this.gameObject.name.Length - 1)) ==
                int.Parse((puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1))) +
                1
                ||
                int.Parse(this.gameObject.name.ToString().Substring(this.gameObject.name.Length - 1)) ==
                int.Parse((puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1))) -
                1
                ||
                int.Parse(this.gameObject.name.ToString().Substring(this.gameObject.name.Length - 1)) ==
                int.Parse((puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1))) +
                3
                ||
                int.Parse(this.gameObject.name.ToString().Substring(this.gameObject.name.Length - 1)) ==
                int.Parse((puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1))) -
                3)
            {
                //если рядом белый кусочек пазла
                if (puzzlePiece.gameObject.GetComponent<Image>().sprite.name == "empty_item8")
                {
                    _changeSprite= puzzlePiece.GetComponent<Image>();
                    ChangeSprites(GetComponent<Image>(), _changeSprite);
                }
            }
                
            
        }
    }

    //меняем местами спрайты кусочков пазла
    void ChangeSprites(Image firstSprite, Image secondSprite)
    {
        Sprite temp = firstSprite.sprite;
        firstSprite.sprite = secondSprite.sprite;
        secondSprite.sprite = temp;
        
    }
}
