using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sossProcessors
{
    public class FileLocker
    {
        private string locker = "";
        public FileLocker(string Locker) {
            locker = Locker;
        }

        public bool Lock() {
            if (System.IO.File.Exists(locker + ".jam"))
            {
                return false;
            }
            System.IO.File.Create(locker + ".jam").Close();
            return true;
        }

        public bool Release() {
            if (System.IO.File.Exists(locker + ".jam"))
            {
                System.IO.File.Delete(locker + ".jam");
                return true;
            }
            return false;
        }

    }
}
