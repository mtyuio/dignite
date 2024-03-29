﻿using Volo.Abp;
using Volo.Abp.Testing;

namespace Dignite.Abp.BlobStoring.FileSystem
{
    public abstract class AbpBlobStoringFileSystemTestBase : AbpIntegratedTest<AbpBlobStoringFileSystemTestModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}