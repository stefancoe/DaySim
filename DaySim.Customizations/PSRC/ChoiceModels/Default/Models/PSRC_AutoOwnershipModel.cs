using System;
using DaySim.Framework.ChoiceModels;
using DaySim.Framework.DomainModels.Wrappers;
using DaySim.Framework.Core;

namespace DaySim.ChoiceModels.Default.Models {
  internal class PSRC_AutoOwnershipModel : AutoOwnershipModel {
    protected override void RegionSpecificCustomizations(ChoiceProbabilityCalculator.Alternative alternative, IHouseholdWrapper household) {
      bool Has0To30KIncome = household.Income.IsRightExclusiveBetween(0, 30000);
      bool Has75To125KIncome = household.Income.IsRightExclusiveBetween(75000, 125000);
      bool Has125KPlusIncome = household.Income >= 125000;

      //put on each alternative except 3 (2 vehicles), using the alternative number to number coefficient
      if (alternative.Id != 2) {
        alternative.AddUtilityTerm(100 + alternative.Id, Has0To30KIncome.ToFlag());
        alternative.AddUtilityTerm(110 + alternative.Id, Has75To125KIncome.ToFlag());
        alternative.AddUtilityTerm(120 + alternative.Id, Has125KPlusIncome.ToFlag());
      }
    }
  }
}
