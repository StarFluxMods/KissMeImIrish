using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;

namespace StPatricksDay.Customs.Processes
{
    public class ChocolateSet : CustomProcess
    {
        public override string UniqueNameID => "ChocolateSet";

        public override GameDataObject BasicEnablingAppliance => GDOUtils.GetExistingGDO(ApplianceReferences.Countertop);

        public override bool CanObfuscateProgress => true;

        public override List<(Locale, ProcessInfo)> InfoList => new List<(Locale, ProcessInfo)>
        {
            (Locale.English, new ProcessInfo
            {
                Name = "Chocolate Set",
                Icon = "<sprite name=\"clock\">"
            })
        };
    }
}