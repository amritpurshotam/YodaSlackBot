using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace API.DI
{
    public class Bootstrapper
    {
        public static IWindsorContainer Init()
        {
            return new WindsorContainer()
                .Install(FromAssembly.This()
                );
        }
    }
}
