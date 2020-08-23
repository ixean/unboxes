
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonSharp.Tests
{
    [AddComponentMenu("Udon Sharp/Tests/DefaultHeapValueTest")]
    public class DefaultHeapValueTest : UdonSharpBehaviour
    {
        [System.NonSerialized]
        public IntegrationTestSuite tester;

        public void ExecuteTests()
        {
            TestPublicArray();
            TestPublicString();
            TestSyncedString();
            TestPrivateArr();
            TestPrivateStr();
        }

        [HideInInspector]
        public string[] defaultPublicArr;

        [SerializeField]
        public readonly string readonlyStr = "aaa";

        [SerializeField]
        public const string constStr = "bbb";

        void TestPublicArray()
        {
            tester.TestAssertion("Default Public Array Initialized", defaultPublicArr != null && defaultPublicArr.Length == 0);
        }

        [HideInInspector]
        public string defaultString;

        void TestPublicString()
        {
            tester.TestAssertion("Default String Value", defaultString == "");
        }

        [UdonSynced]
        string networkSyncedString;

        [UdonSynced]
        string networkSyncedStringDefaultEmpty = "";

        [UdonSynced]
        string networkSyncedStringDefaultValue = "hello";

        [UdonSynced, HideInInspector]
        public string publicNetworkSyncedString;

        [UdonSynced, HideInInspector]
        public string publicNetworkSyncedStringDefaultEmpty = "";

        [UdonSynced, HideInInspector]
        public string publicNetworkSyncedStringDefaultValue = "hello";

        void TestSyncedString()
        {
            tester.TestAssertion("Uninitialized Synced String", networkSyncedString == "");
            tester.TestAssertion("Empty Synced String Value", networkSyncedStringDefaultEmpty == "");
            tester.TestAssertion("Default Synced String Value", networkSyncedStringDefaultValue == "hello");
            
            tester.TestAssertion("Uninitialized Public Synced String", publicNetworkSyncedString == "");
            tester.TestAssertion("Empty Public Synced String Value", publicNetworkSyncedStringDefaultEmpty == "");
            tester.TestAssertion("Default Public Synced String Value", publicNetworkSyncedStringDefaultValue == "hello");
        }

        string[] privateStrArr;

        void TestPrivateArr()
        {
            tester.TestAssertion("Private Array Default Null", privateStrArr == null);
        }

        string privateStr;
        string privateNullInitializedString = null;
        string privateInitializedString = "Test";

        void TestPrivateStr()
        {
            tester.TestAssertion("Private String Default Null", privateStr == null);
            tester.TestAssertion("Private null initialized String", privateNullInitializedString == null);
            tester.TestAssertion("Private initialized String", privateInitializedString == "Test");
        }
    }
}
