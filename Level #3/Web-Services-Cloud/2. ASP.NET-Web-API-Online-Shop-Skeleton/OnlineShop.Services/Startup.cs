﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OnlineShop.Services.Startup))]

namespace OnlineShop.Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}