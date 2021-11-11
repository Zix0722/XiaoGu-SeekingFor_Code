using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    
        [SerializeField] private Canvas canvas;
        private RectTransform rectTrans;
        private CanvasGroup canvasGroup;
        public bool moveSuc;
        private Vector2 saveOrigin;
        [SerializeField] private GameObject slot;
        private void Start()
        {
            rectTrans = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            saveOrigin = rectTrans.anchoredPosition;
            moveSuc = false;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {

            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0.35f;
        }

        public void OnDrag(PointerEventData eventData)
        {
            
            rectTrans.anchoredPosition += eventData.delta/canvas.scaleFactor;
            
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            if (!moveSuc)
            {
                rectTrans.anchoredPosition = saveOrigin;
            }
        }
        

    // Update is called once per frame
    void Update()
    {
        
    }
}
