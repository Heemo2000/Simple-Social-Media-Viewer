using UnityEngine;
using Firebase.Firestore;

namespace App
{
    [FirestoreData]
    public struct SinglePost
    {
        [FirestoreProperty]
        public string username { get; set; }
        [FirestoreProperty]
        public string profilePic { get; set; }
        [FirestoreProperty]
        public string content { get; set; }
        [FirestoreProperty]
        public int likes { get; set; }
    }
}
