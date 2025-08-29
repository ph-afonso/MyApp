namespace AuthProject.Domain.Entities;

/// <summary>
/// Representa a entidade de Usuário no sistema.
/// </summary>
public class User
{
    /// <summary>
    /// Identificador único do usuário.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Nome completo do usuário.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Endereço de e-mail do usuário, usado para login.
    /// </summary>
    public string Email { get; private set; } = string.Empty;

    /// <summary>
    /// Hash da senha do usuário. A senha nunca é armazenada em texto plano.
    /// </summary>
    public string PasswordHash { get; private set; } = string.Empty;

    /// <summary>
    /// Número de telefone do usuário, usado para notificações via WhatsApp.
    /// </summary>
    public string PhoneNumber { get; private set; } = string.Empty;

    /// <summary>
    /// Indica se o usuário está ativo no sistema (para "fake delete").
    /// </summary>
    public bool IsActive { get; private set; }

    /// <summary>
    /// Código de verificação para ativação de conta.
    /// </summary>
    public string? VerificationCode { get; private set; }

    /// <summary>
    /// Data de expiração do código de verificação.
    /// </summary>
    public DateTime? VerificationCodeExpiresAt { get; private set; }

    /// <summary>
    /// Código de recuperação de senha.
    /// </summary>
    public string? PasswordResetCode { get; private set; }

    /// <summary>
    /// Data de expiração do código de recuperação de senha.
    /// </summary>
    public DateTime? PasswordResetCodeExpiresAt { get; private set; }

    /// <summary>
    /// Data de criação do registro.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Data da última atualização do registro.
    /// </summary>
    public DateTime UpdatedAt { get; private set; }

    // Construtor privado para o EF Core.
    private User() { }

    /// <summary>
    /// Cria uma nova instância de usuário.
    /// </summary>
    public User(string name, string email, string passwordHash, string phoneNumber)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        PhoneNumber = phoneNumber;
        IsActive = false; // O usuário começa inativo e precisa ser verificado.
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Atualiza os dados do usuário.
    /// </summary>
    public void Update(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Desativa o usuário (fake delete).
    /// </summary>
    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Ativa o usuário após a verificação bem-sucedida.
    /// </summary>
    public void Activate()
    {
        IsActive = true;
        VerificationCode = null;
        VerificationCodeExpiresAt = null;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Define um novo código de verificação para o usuário.
    /// </summary>
    public void SetVerificationCode(string code, int minutesToExpire)
    {
        VerificationCode = code;
        VerificationCodeExpiresAt = DateTime.UtcNow.AddMinutes(minutesToExpire);
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Define um novo código para recuperação de senha.
    /// </summary>
    public void SetPasswordResetCode(string code, int minutesToExpire)
    {
        PasswordResetCode = code;
        PasswordResetCodeExpiresAt = DateTime.UtcNow.AddMinutes(minutesToExpire);
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Altera a senha do usuário.
    /// </summary>
    public void ResetPassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
        PasswordResetCode = null;
        PasswordResetCodeExpiresAt = null;
        UpdatedAt = DateTime.UtcNow;
    }
}
