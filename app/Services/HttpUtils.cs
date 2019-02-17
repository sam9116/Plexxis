using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.Services
{
    public static class HttpUtils
    {
        public static MobileServiceClient service = new MobileServiceClient(Constants.apiuri);
    }
}
