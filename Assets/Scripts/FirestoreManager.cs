using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;

namespace App
{
    public class FirestoreManager : MonoBehaviour
    {
        public Action<List<object>> OnDataRetreived;

        private FirebaseFirestore database;

        public IEnumerator LoadTheRequiredData(string collection, string documentPath, string subCollection)
        {
            DocumentReference reference = database.Collection(collection).
                                          Document(documentPath);

            yield return reference.GetSnapshotAsync().ContinueWithOnMainThread(task =>
            {
                Debug.Log("Finding data...");
                DocumentSnapshot snapshot = task.Result;
                
                if (snapshot.Exists)
                {
                    Debug.Log($"Document data for {snapshot.Id} document");
                    List<object> result = snapshot.ToDictionary()[subCollection] as List<object>;

                    OnDataRetreived?.Invoke(result);

                    for (int i = 0; i < result.Count; i++)
                    {
                        var element = result[i] as Dictionary<string, object>;
                        foreach(var pair in element)
                        {
                            Debug.Log($"{pair.Key} : {pair.Value}");
                        }
                    }
                }
                else
                {
                    Debug.LogError($"Document {snapshot.Id} does not exist!");
                }
            });
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if(database == null)
            {
                database = FirebaseFirestore.DefaultInstance;
                StartCoroutine(LoadTheRequiredData("posts_collection",
                                                   "posts_collection_document", "posts"));
            }
        }
    }
}
