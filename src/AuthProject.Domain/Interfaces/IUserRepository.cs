using AuthProject.Domain.Entities;

namespace AuthProject.Domain.Interfaces;

/// <summary>
/// Define o contrato para o repositório de usuários, abstraindo as operações de acesso a dados.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Busca um usuário pelo seu identificador único.
    /// </summary>
    /// <param name="id">O ID do usuário.</param>
    /// <param name="cancellationToken">O token para cancelamento da operação.</param>
    /// <returns>O usuário encontrado ou nulo.</returns>
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Busca um usuário pelo seu endereço de e-mail.
    /// </summary>
    /// <param name="email">O e-mail do usuário.</param>
    /// <param name="cancellationToken">O token para cancelamento da operação.</param>
    /// <returns>O usuário encontrado ou nulo.</returns>
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adiciona um novo usuário ao repositório.
    /// </summary>
    /// <param name="user">A entidade do usuário a ser adicionada.</param>
    /// <param name="cancellationToken">O token para cancelamento da operação.</param>
    Task AddAsync(User user, CancellationToken cancellationToken = default);

    /// <summary>
    /// Atualiza um usuário existente no repositório.
    /// </summary>
    /// <param name="user">A entidade do usuário a ser atualizada.</param>
    void Update(User user);
}
