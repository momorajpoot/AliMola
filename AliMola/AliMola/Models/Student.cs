using System;
using System.Text;
using System.Collections.Generic;


namespace AliMola {
    
    public class Student {
        public virtual int Studentid { get; set; }
        public virtual string Studentname { get; set; }
        public virtual string Studentemail { get; set; }
        public Student UniqueResult { get; internal set; }

        internal static Student CreatCriteria(Type type)
        {
            throw new NotImplementedException();
        }

        internal Student Add(object p)
        {
            throw new NotImplementedException();
        }
    }
}
