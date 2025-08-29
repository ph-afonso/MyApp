using AuthProject.Domain.Entities;

namespace AuthProject.Domain.Interfaces;

/// <summary>
/// Define o contrato para o reposit�rio de usu�rios, abstraindo as opera��es de acesso a dados.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Busca um usu�rio pelo seu identificador �nico.
    /// </summary>
    /// <param name="id">O ID do usu�rio.</param>
    /// <param name="cancellationToken">O token para cancelamento da opera��o.</param>
    /// <returns>O usu�rio encontrado ou nulo.</returns>
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Busca um usu�rio pelo seu endere�o de e-mail.
    /// </summary>
    /// <param name="email">O e-mail do usu�rio.</param>
    /// <param name="cancellationToken">O token para cancelamento da opera��o.</param>
    /// <returns>O usu�rio encontrado ou nulo.</returns>
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adiciona um novo usu�rio ao reposit�rio.
    /// </summary>
    /// <param name="user">A entidade do usu�rio a ser adicionada.</param>
    /// <param name="cancellationToken">O token para cancelamento da opera��o.</param>
    Task AddAsync(User user, CancellationToken cancellationToken = default);

    /// <summary>
    /// Atualiza um usu�rio existente no reposit�rio.
    /// </summary>
    /// <param name="user">A entidade do usu�rio a ser atualizada.</param>
    void Update(User user);
}
