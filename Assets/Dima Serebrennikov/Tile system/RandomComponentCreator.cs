using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
namespace Serebrennikov {
    public class RandomComponentCreator : MonoBehaviour {
        public List<FigureStyle> History = new();
        [SerializeField] Component[] _components;
        public Component Get(int id) {
            for (int i = 0; i < History.Count; i++) { /*Сначало проверяет не создан ли уже такой объект.*/
                FigureStyle figureStyle = History[i];
                if (id == figureStyle.Id) {
                    return _components[figureStyle.Style];
                }
            }
            int randomValue = Random.Range(0, _components.Length);
            FigureStyle n = new(id, randomValue);
            History.Add(n);
            return _components[randomValue];
        }
    }
}
