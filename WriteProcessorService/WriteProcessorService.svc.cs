using System;
using SharedModels;
using WriteProcessorService.Interfaces;

namespace WriteProcessorService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WriteProcessorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WriteProcessorService.svc or WriteProcessorService.svc.cs at the Solution Explorer and start debugging.
    public class WriteProcessorService : IWriteProcessorService {
        private const string CachePrefixForMember = "MemberSearchResult_";

        private readonly ICacheUpdater _cacheUpdater;

        public WriteProcessorService() {
            _cacheUpdater = new CacheUpdater();
        }

        public string Hello() {
            return "Hello";
        }

        public string GetData(string value) {
            return $"You entered: {value}";
        }

        public string PostMemberChange(Member memberChangeEvent) {
            try {
                var cacheKey = CachePrefixForMember + memberChangeEvent.FirstName;
                _cacheUpdater.StoreObjectInCache(cacheKey, memberChangeEvent);

                return $"Post cached! First Name: {memberChangeEvent.FirstName}";
            }
            catch (Exception ex) {
                return $"Error occured: {ex}";
            }
        }
    }
}
