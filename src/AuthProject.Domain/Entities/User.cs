namespace AuthProject.Domain.Entities;

/// <summary>
/// Representa a entidade de Usu�rio no sistema.
/// </summary>
public class User
{
    /// <summary>
    /// Identificador �nico do usu�rio.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Nome completo do usu�rio.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Endere�o de e-mail do usu�rio, usado para login.
    /// </summary>
    public string Email { get; private set; } = string.Empty;

    /// <summary>
    /// Hash da senha do usu�rio. A senha nunca � armazenada em texto plano.
    /// </summary>
    public string PasswordHash { get; private set; } = string.Empty;

    /// <summary>
    /// N�mero de telefone do usu�rio, usado para notifica��es via WhatsApp.
    /// </summary>
    public string PhoneNumber { get; private set; } = string.Empty;

    /// <summary>
    /// Indica se o usu�rio est� ativo no sistema (para "fake delete").
    /// </summary>
    public bool IsActive { get; private set; }

    /// <summary>
    /// C�digo de verifica��o para ativa��o de conta.
    /// </summary>
    public string? VerificationCode { get; private set; }

    /// <summary>
    /// Data de expira��o do c�digo de verifica��o.
    /// </summary>
    public DateTime? VerificationCodeExpiresAt { get; private set; }

    /// <summary>
    /// C�digo de recupera��o de senha.
    /// </summary>
    public string? PasswordResetCode { get; private set; }

    /// <summary>
    /// Data de expira��o do c�digo de recupera��o de senha.
    /// </summary>
    public DateTime? PasswordResetCodeExpiresAt { get; private set; }

    /// <summary>
    /// Data de cria��o do registro.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Data da �ltima atualiza��o do registro.
    /// </summary>
    public DateTime UpdatedAt { get; private set; }

    // Construtor privado para o EF Core.
    private User() { }

    /// <summary>
    /// Cria uma nova inst�ncia de usu�rio.
    /// </summary>
    public User(string name, string email, string passwordHash, string phoneNumber)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        PhoneNumber = phoneNumber;
        IsActive = false; // O usu�rio come�a inativo e precisa ser verificado.
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Atualiza os dados do usu�rio.
    /// </summary>
    public void Update(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Desativa o usu�rio (fake delete).
    /// </summary>
    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Ativa o usu�rio ap�s a verifica��o bem-sucedida.
    /// </summary>
    public void Activate()
    {
        IsActive = true;
        VerificationCode = null;
        VerificationCodeExpiresAt = null;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Define um novo c�digo de verifica��o para o usu�rio.
    /// </summary>
    public void SetVerificationCode(string code, int minutesToExpire)
    {
        VerificationCode = code;
        VerificationCodeExpiresAt = DateTime.UtcNow.AddMinutes(minutesToExpire);
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Define um novo c�digo para recupera��o de senha.
    /// </summary>
    public void SetPasswordResetCode(string code, int minutesToExpire)
    {
        PasswordResetCode = code;
        PasswordResetCodeExpiresAt = DateTime.UtcNow.AddMinutes(minutesToExpire);
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Altera a senha do usu�rio.
    /// </summary>
    public void ResetPassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
        PasswordResetCode = null;
        PasswordResetCodeExpiresAt = null;
        UpdatedAt = DateTime.UtcNow;
    }
}
