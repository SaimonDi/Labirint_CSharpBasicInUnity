using System.Collections;
using UnityEngine;

namespace LabirintSpace
    {
    public interface IInteractable : IAction
        {
        bool IsInteractable { get; }
        }
    }