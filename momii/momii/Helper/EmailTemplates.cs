using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace momii.Helper
{
    public class EmailTemplates
    {  /// <summary>
       /// {0} = UserName
       /// {1} = Email
       /// </summary>
        public string SignUpEmailTemplate = "Welcome <b>{0}</b>,<br><br>" +
            "Your registration is done:<br><br>" +
            "You can login on our website here <a href='http://google.com'> ABC Website</a><br><br>" +
            "Registered Email: <span style='color:red;background-color:yellow;'>{1}</span><br><br>" +
            "Regards,<br>" +
            "ABC";

    }
}