using Exiled.API.Features;
using System.Collections.Generic;

namespace BetterHandCuff
{

    public static class DataSystem
    {
        private static Dictionary<Ragdoll, int> DataDic = new Dictionary<Ragdoll, int>();

        public static void SaveData(Ragdoll rag, int handcuffamount)
        {
            if (!DataDic.ContainsKey(rag))
            {
                DataDic.Add(rag, handcuffamount);
            }
        }
        public static void RemoveData(Ragdoll rag)
        {
            DataDic.Remove(rag);
        }
        public static bool GetPos(Ragdoll rag)
        {

            if (!DataDic.ContainsKey(rag))
            {
                return false;
            }
            return true;
        }
        public static int RagdollHandCuffAmount(Ragdoll rag)
        {
            if (DataDic.TryGetValue(rag, out int handcuff))
            {

                return handcuff;
            }
            else
            {
                return 0;
            }
        }
        public static void RagdollRemoveHandCuff(Ragdoll rag, int amount)
        {
            if (DataDic.ContainsKey(rag))
            {
                DataDic[rag] -= amount;


            }

        }




    }
}

