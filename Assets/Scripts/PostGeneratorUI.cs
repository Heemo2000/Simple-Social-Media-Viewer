using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App
{
    public class PostGeneratorUI : MonoBehaviour
    {
        [SerializeField] private FirestoreManager firestoreManager;
        [SerializeField] private PostSingleUI postSingleUIPrefab;
        [SerializeField] private RectTransform contentParent;
        public void LoadPosts(List<object> data)
        {
            for(int i = 0; i < data.Count; i++)
            {
                var element = data[i] as Dictionary<string, object>;

                var singleUI = Instantiate(postSingleUIPrefab, contentParent.transform);
                singleUI.SetInfo(
                                 null,
                                 element["username"] as string,
                                 element["content"] as string,
                                 Convert.ToInt32(element["likes"]).ToString()
                                );
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            firestoreManager.OnDataRetreived += LoadPosts;        
        }
    }
}
