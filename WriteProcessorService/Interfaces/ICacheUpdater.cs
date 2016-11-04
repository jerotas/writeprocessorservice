namespace WriteProcessorService.Interfaces {
    public interface ICacheUpdater {
        void StoreObjectInCache(string key, object o);
    }
}