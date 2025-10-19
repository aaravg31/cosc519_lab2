using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

public class TaskPhoneManager : MonoBehaviour
{
    [SerializeField] private UIDocument phoneUI;

    private VisualElement _root;
    private VisualElement _taskGrid;     // My Tasks grid (4 slots)
    private VisualElement _newTaskGrid;  // New Tasks grid (2 slots)
    private bool _isVisible;

    private void Start()
    {
        _root = phoneUI.rootVisualElement;
        _taskGrid = _root.Q<VisualElement>("TaskGrid");
        _newTaskGrid = _root.Q<VisualElement>("NewTaskGrid");
        _root.style.display = DisplayStyle.None;

        // Register drag handlers for existing tasks inside TaskGrid
        foreach (var slot in _taskGrid.Children())
        {
            var taskBox = slot.Q<VisualElement>(className: "task-box");
            if (taskBox != null)
                RegisterDragHandlers(taskBox);
        }
    }

    public void TogglePhone()
    {
        _isVisible = !_isVisible;
        _root.style.display = _isVisible ? DisplayStyle.Flex : DisplayStyle.None;

        if (_isVisible)
            TryAddNewTask();
        else
            ClearNewTasks();
    }

    private void TryAddNewTask()
    {
        // Look for the first empty slot in NewTaskGrid
        foreach (var slot in _newTaskGrid.Children())
        {
            if (SlotIsEmpty(slot))
            {
                var newTask = CreateTaskBox("Task 5");
                slot.Add(newTask);
                return;
            }
        }

        Debug.Log("No empty slot in NewTaskGrid!");
    }

    private void ClearNewTasks()
    {
        foreach (var slot in _newTaskGrid.Children())
            slot.Clear();
    }

    private VisualElement CreateTaskBox(string label)
    {
        var box = new VisualElement();
        box.AddToClassList("task-box");

        var lbl = new Label(label);
        lbl.style.unityTextAlign = TextAnchor.MiddleCenter;
        box.Add(lbl);

        RegisterDragHandlers(box);
        return box;
    }

    // Check if a slot contains a task box
    private static bool SlotIsEmpty(VisualElement slot)
    {
        return slot.Q<VisualElement>(className: "task-box") == null;
    }

    private void RegisterDragHandlers(VisualElement task)
    {
        bool isDragging = false;
        Vector2 startPos = Vector2.zero;
        VisualElement originalSlot = null;

        task.RegisterCallback<PointerDownEvent>(evt =>
        {
            isDragging = true;
            startPos = evt.position;
            originalSlot = task.parent; // Remember current slot
            task.CapturePointer(evt.pointerId);

            // Scale up and fade slightly while dragging
            task.style.scale = new Scale(new Vector3(1.08f, 1.08f, 1f));
            task.experimental.animation.Start(new StyleValues { opacity = 0.8f }, 120);
        });

        task.RegisterCallback<PointerMoveEvent>(evt =>
        {
            if (!isDragging) return;

            Vector2 delta = (Vector2)evt.position - startPos;
            var tr = task.resolvedStyle.translate;
            task.style.translate = new StyleTranslate(new Translate(tr.x + delta.x, tr.y + delta.y));
            startPos = evt.position;
        });

        task.RegisterCallback<PointerUpEvent>(evt =>
        {
            if (!isDragging) return;
            isDragging = false;
            task.ReleasePointer(evt.pointerId);

            // Reset visuals
            task.style.scale = new Scale(Vector3.one);
            task.experimental.animation.Start(new StyleValues { opacity = 1f }, 120);

            Vector2 pointerPos = evt.position;

            // Determine which grid the pointer is over
            VisualElement targetGrid = null;
            if (_taskGrid.worldBound.Contains(pointerPos))
                targetGrid = _taskGrid;
            else if (_newTaskGrid.worldBound.Contains(pointerPos))
                targetGrid = _newTaskGrid;

            if (targetGrid == null)
            {
                // Not dropped on any grid → revert
                originalSlot?.Add(task);
                ResetTranslation(task);
                return;
            }

            // Find first empty slot in the target grid
            VisualElement targetSlot = null;
            foreach (var slot in targetGrid.Children())
            {
                if (SlotIsEmpty(slot))
                {
                    targetSlot = slot;
                    break;
                }
            }

            if (targetSlot != null)
            {
                // Move to the new slot (Unity auto-removes from old parent)
                targetSlot.Add(task);
            }
            else
            {
                // No room in that grid → revert to original
                Debug.Log("Target grid full, reverting.");
                originalSlot?.Add(task);
            }

            ResetTranslation(task);
        });
    }

    private static void ResetTranslation(VisualElement task)
    {
        task.style.translate = new StyleTranslate(new Translate(0, 0));
    }
}
