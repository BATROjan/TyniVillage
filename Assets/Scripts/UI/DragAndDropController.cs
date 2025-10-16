using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using DefaultNamespace.Items;

namespace DefaultNamespace.UI
{
    public class DragAndDropController : MonoBehaviour
    {
        [SerializeField] private Transform currentItemTransfom;
        
        private Transform lastItemTransfom;
        private ItemUIView _firstView;
        private ItemUIView _secondView;
        
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_firstView)
            {
                var data = PointerRaycast(Input.mousePosition);
                if (data != null)
                {
                    if (data.Count>0)
                    {
                        _firstView = data[0];
                        lastItemTransfom = _firstView.transform.parent;
                        _firstView.transform.SetParent(currentItemTransfom);
                    }
                }
            }
            if (_firstView && Input.GetMouseButton(0))
            {
                _firstView.transform.position = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (_firstView)
                {
                    var data = PointerRaycast(Input.mousePosition); // пускаем луч
                    if (data != null)
                    {
                        foreach (var item in data)
                        {
                            if (item != _firstView)
                            {
                                _secondView = item;
                            }
                        }
                    }
                    if (_secondView)
                    {
                        if (!_secondView.CheckForShoop())
                        {
                            if (_secondView.CheckForRepaire())
                            {
                                _secondView.OnSetToPepaire?.Invoke(_firstView.GetCellCount());
                            }
                            ChangeCell(_firstView, _secondView);
                        }
                        else
                        {
                            SetFirstCellToLastTransform();
                        }
                    }
                    else
                    {
                        SetFirstCellToLastTransform();
                    }
                    SetNullToBothCells();  
                }
                else
                {
                    SetNullToBothCells();
                }
            }
        }

        private void SetNullToBothCells()
        {
            _firstView = null;
            _secondView = null;
        }

        List<ItemUIView> PointerRaycast(Vector2 position)
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> resultsData = new List<RaycastResult>();
            pointerData.position = position;
            EventSystem.current.RaycastAll(pointerData, resultsData);

            if (resultsData.Count > 0)
            {
                List<ItemUIView> list = new List<ItemUIView>();
                foreach (var item in resultsData)
                {
                    var uiItem = item.gameObject.GetComponent<ItemUIView>();
                    if (uiItem)
                    {
                        list.Add(uiItem);
                    }
                    
                }
                return list;
            }

            return null;
        }

        public void ChangeCell(ItemUIView fistView, ItemUIView secondView)
        {
            var model1 = fistView.GetItemModel();
            var model2 = secondView.GetItemModel();
            
            _firstView.ChangeItem(model2);
            SetFirstCellToLastTransform();
            fistView.OnGetFromShop?.Invoke(model1.ItemType);
            
            _secondView.ChangeItem(model1);
            secondView.transform.localPosition = Vector3.zero;

            SetNullToBothCells();
        }

        private void SetFirstCellToLastTransform()
        {
            _firstView.transform.SetParent(lastItemTransfom);
            _firstView.transform.localPosition = Vector3.zero;

            lastItemTransfom = null;
        }
    }
}