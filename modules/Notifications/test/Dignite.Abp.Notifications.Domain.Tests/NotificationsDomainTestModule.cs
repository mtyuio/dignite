﻿using Dignite.Abp.Notifications.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Dignite.Abp.Notifications
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(NotificationsEntityFrameworkCoreTestModule)
        )]
    public class NotificationsDomainTestModule : AbpModule
    {
        
    }
}
