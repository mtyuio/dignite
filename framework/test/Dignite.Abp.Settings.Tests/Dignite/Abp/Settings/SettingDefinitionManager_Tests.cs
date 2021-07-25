﻿using Dignite.Abp.FieldCustomizing;
using Dignite.Abp.FieldCustomizing.TextboxForm;
using Shouldly;
using System.Linq;
using Xunit;

namespace Dignite.Abp.Settings
{
    public class SettingDefinitionManager_Tests : SettingsTestBase
    {
        private readonly IDigniteSettingDefinitionManager _settingDefinitionManager;
        private readonly IFormProviderSelector _formProviderSelector;

        public SettingDefinitionManager_Tests()
        {
            _settingDefinitionManager = GetRequiredService<IDigniteSettingDefinitionManager>();
            _formProviderSelector = GetRequiredService<IFormProviderSelector>();
        }

        [Fact]
        public void Should_Get_Test_Setting_Definition_Provider()
        {
            var navigations = _settingDefinitionManager.GetNavigations();
            navigations.ShouldNotBeEmpty();
        }

        [Fact]
        public void Should_Get_Test_Settings_Of_Navigation()
        {
            var navigation = _settingDefinitionManager.GetNavigationOrNull(TestSettingNames.TestSettingNavigationName);
            navigation.ShouldNotBeNull();
        }

        [Fact]
        public void Should_Get_Test_Setting_Definition_Form()
        {
            var navigation = _settingDefinitionManager.GetNavigation(TestSettingNames.TestSettingNavigationName);
            var setting1 = navigation.SettingDefinitions.Single(sf => sf.Name == TestSettingNames.TestSettingWithDefaultValue);
            var formConfig = setting1.GetFormOrNull();
            var formProvider = _formProviderSelector.Get(TextboxFormProvider.ProviderName);
            var textboxFormConfig = (TextboxFormConfiguration)formProvider.GetConfiguration(formConfig);
            textboxFormConfig.Placeholder.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void Should_Get_Test_Setting_Definition2_Form()
        {
            var navigation = _settingDefinitionManager.GetNavigation(TestSettingNames.TestSettingNavigationName2);
            var setting1 = navigation.SettingDefinitions.Single(sf => sf.Name == TestSettingNames.TestSettingPackager);
            var formConfig = setting1.GetFormOrNull();
            var formProvider = _formProviderSelector.Get(TextboxFormProvider.ProviderName);
            var textboxFormConfig = (TextboxFormConfiguration)formProvider.GetConfiguration(formConfig);
            textboxFormConfig.Placeholder.ShouldNotBeNullOrEmpty();
        }
    }
}
