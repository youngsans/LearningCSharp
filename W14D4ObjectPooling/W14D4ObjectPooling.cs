namespace W14D4ObjectPooling
{
    public interface IPoolable
    {
        public void OnSpawn(int currentPosX, int currentPosY, int damage);
        public void OnDespawn();
    }

    public class Bullet : IPoolable
    {
        private int mCurrentPosX;
        private int mCurrentPosY;
        private int mDamage;
        private bool mbIsActivated = false;

        public int CurrentPosX { get { return mCurrentPosX; } }
        public int CurrentPosY { get { return mCurrentPosY; } }
        public int Damage { get { return mDamage; } }
        public bool IsActivated { get { return mbIsActivated; } }

        public void OnSpawn(int currentPosX, int currentPosY, int damage)
        {
            mCurrentPosX = currentPosX;
            mCurrentPosY = currentPosY;
            mDamage = damage;
            mbIsActivated = true;
            Console.WriteLine($"[탄환 꺼냄] 좌표 X: {mCurrentPosX}, Y: {mCurrentPosY} | 데미지: {mDamage} | 활성화 여부: {mbIsActivated}");
        }

        public void OnDespawn()
        {
            mCurrentPosY = 0;
            mCurrentPosY = 0;
            mDamage = 0;
            mbIsActivated = false;
            Console.WriteLine($"[탄환 넣음] 좌표 X: {mCurrentPosX}, Y: {mCurrentPosY} | 데미지: {mDamage} | 활성화 여부: {mbIsActivated}");
        }
    }

    public static class Pool<T> where T : IPoolable
    {
        private static Queue<T> PoolQueue = new Queue<T>();

        //총알 생성
        public static void Register(int amount, T item)
        {
            for (int i = 0; i < amount; i++)
            {
                PoolQueue.Enqueue(item);
            }
        }

        //총알 꺼내기
        public static void Spawn(int posX, int posY, int damage)
        {
            T spawnedItem = PoolQueue.Dequeue();
            spawnedItem.OnSpawn(posX, posY, damage);            
        }

        //총알 집어넣기
        public static void Despawn(T item) 
        {
            item.OnDespawn();
            PoolQueue.Enqueue(item);
        }
    }


    internal class W14D4ObjectPooling
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
