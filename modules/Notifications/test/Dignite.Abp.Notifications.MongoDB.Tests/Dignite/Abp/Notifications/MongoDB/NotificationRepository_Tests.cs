﻿using Dignite.Abp.Notifications;
using Xunit;

namespace Dignite.Abp.Notifications.MongoDB
{
    [Collection(MongoTestCollection.Name)]
    public class NotificationRepository_Tests : NotificationRepository_Tests<NotificationsMongoDbTestModule>
    {
        /* Don't write custom repository tests here, instead write to
         * the base class.
         * One exception can be some specific tests related to MongoDB.
         */
    }
}
