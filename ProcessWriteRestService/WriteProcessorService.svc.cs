﻿using System;

namespace ProcessWriteRestService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WriteProcessorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WriteProcessorService.svc or WriteProcessorService.svc.cs at the Solution Explorer and start debugging.
    public class WriteProcessorService : IWriteProcessorService {
        public string Hello() {
            return "Hello!";
        }

        public string GetData(string value) {
            return $"You entered: {value}";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException(nameof(composite));
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void PostStuff()
        {
            throw new NotImplementedException();
        }
    }
}
