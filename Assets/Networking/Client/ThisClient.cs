using Photon.Pun;
public abstract class ThisClient : MonoBehaviourPunCallbacks
{
    public struct Data
    {
        public string name;
        public short tag;
        public long ident;
    }
}
