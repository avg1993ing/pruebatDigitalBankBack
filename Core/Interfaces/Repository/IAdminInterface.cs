namespace Core.Interfaces.Repository
{
    public interface IAdminInterface : IDisposable
    {
        IUsuariosRepository usuariosRepository { get; }
    }
}
