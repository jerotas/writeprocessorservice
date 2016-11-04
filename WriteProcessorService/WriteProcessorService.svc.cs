using System;

namespace WriteProcessorService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WriteProcessorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WriteProcessorService.svc or WriteProcessorService.svc.cs at the Solution Explorer and start debugging.
    public class WriteProcessorService : IWriteProcessorService {
        public string Hello() {
            return "Hello";
        }

        public string GetData(string value) {
            return $"You entered: {value}";
        }

        public string PostStuff(string s) {
            return $"Posted: {s}";
        }
    }
}
