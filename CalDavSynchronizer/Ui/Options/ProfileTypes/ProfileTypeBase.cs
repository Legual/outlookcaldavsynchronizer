// This file is Part of CalDavSynchronizer (http://outlookcaldavsynchronizer.sourceforge.net/)
// Copyright (c) 2015 Gerhard Zehetbauer
// Copyright (c) 2015 Alexander Nimmervoll
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using CalDavSynchronizer.Contracts;
using CalDavSynchronizer.Implementation;
using CalDavSynchronizer.Ui.Options.BulkOptions.ViewModels;
using CalDavSynchronizer.Ui.Options.Models;
using CalDavSynchronizer.Ui.Options.ViewModels;

namespace CalDavSynchronizer.Ui.Options.ProfileTypes
{
  public abstract class ProfileTypeBase : IProfileType
  {
    public virtual Contracts.Options CreateOptions()
    {
      return new Contracts.Options
      {
        ConflictResolution = ConflictResolution.Automatic,
        DaysToSynchronizeInTheFuture = 365,
        DaysToSynchronizeInThePast = 60,
        SynchronizationIntervalInMinutes = 30,
        SynchronizationMode = SynchronizationMode.MergeInBothDirections,
        Name = "<New Profile>",
        Id = Guid.NewGuid(),
        Inactive = false,
        PreemptiveAuthentication = true,
        ForceBasicAuthentication = false,
        ProxyOptions = new ProxyOptions() { ProxyUseDefault = true },
        IsChunkedSynchronizationEnabled = true,
        ChunkSize = 100,
        ServerAdapterType = ServerAdapterType.WebDavHttpClientBased,
        ProfileTypeOrNull = ProfileTypeRegistry.GetProfileTypeName(this)
      };
    }
    

    public abstract string Name { get; }
    public abstract string ImageUrl { get; }
    public abstract IProfileModelFactory CreateModelFactory(IOptionsViewModelParent optionsViewModelParent, IOutlookAccountPasswordProvider outlookAccountPasswordProvider, IReadOnlyList<string> availableCategories, IOptionTasks optionTasks, ISettingsFaultFinder settingsFaultFinder, GeneralOptions generalOptions, IViewOptions viewOptions, OptionModelSessionData sessionData);
  }

}