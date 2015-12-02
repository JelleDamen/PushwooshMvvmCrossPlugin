using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore;

namespace SoToGo.Plugins.Pushwoosh.Sample.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.FirstViewModel>();

        }

    }
}