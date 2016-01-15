using System.Runtime.InteropServices;

namespace EntitiesLayer
{
    public abstract class EntityObject
    {
        protected static int ID=0 ;

        public EntityObject()
        {
            ++ID;
        }


    }
}