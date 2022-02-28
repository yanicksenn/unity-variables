using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Variables.Tests
{
    public abstract class AbstractVariableTest<T>
    {
        protected abstract AbstractVariable<T> CreateVariable();
        protected abstract T GetValue();
        
        [UnityTest]
        public IEnumerator AssertTypeActsLikeVariable()
        {
            var variable = CreateVariable();
            var value = GetValue();
            
            variable.Value = value;
            Assert.AreEqual(value, variable.Value);
            yield return null;
        }
        
        [TearDown]
        public void TearDown()
        {
            var gameObjects = Object.FindObjectsOfType<GameObject>();
            foreach (var gameObject in gameObjects)
                Object.Destroy(gameObject);
        }
    }
}