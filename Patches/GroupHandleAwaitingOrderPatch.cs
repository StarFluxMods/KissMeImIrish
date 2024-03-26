using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using Kitchen;

namespace StPatricksDay.Patches
{
    /*
     * This patch adds a check if the Customer is seated at a Clover Table, if so, it will calculate the Lucky Income
     */
    [HarmonyPatch]
    public class GroupHandleAwaitingOrderPatch
    {
        private static MethodBase TargetMethod()
        {
            Type type = AccessTools.FirstInner(typeof(GroupHandleAwaitingOrder), t => t.Name.Contains("c__DisplayClass_OnUpdate_LambdaJob0"));
            return AccessTools.FirstMethod(type, method => method.Name.Contains("OriginalLambdaBody"));
        }

        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            CodeMatcher matcher = new(instructions);

            matcher.MatchForward(false, new CodeMatch(OpCodes.Ldarg_0), new CodeMatch(OpCodes.Ldflda), new CodeMatch(OpCodes.Call), new CodeMatch(OpCodes.Stloc_S), new CodeMatch(OpCodes.Ldarg_0))
                .Advance(4)
                .Insert(new CodeInstruction(OpCodes.Nop))
                .Insert(new CodeInstruction(OpCodes.Nop))
                .Insert(new CodeInstruction(OpCodes.Stobj, typeof(CGroupReward)))
                .Insert(new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(StPatricksDay.Util.Utility), "CalculateLuckyIncome")))
                .Insert(new CodeInstruction(OpCodes.Ldobj, typeof(CGroupReward)))
                .Insert(new CodeInstruction(OpCodes.Ldarg_S, 4))
                .Insert(new CodeInstruction(OpCodes.Ldarg_1))
                .Insert(new CodeInstruction(OpCodes.Ldarg_S, 4));
            
            return matcher.InstructionEnumeration();
        }
    }
}