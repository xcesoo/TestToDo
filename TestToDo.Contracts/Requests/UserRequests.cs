namespace TestToDo.Contracts.Requests;

public readonly record struct RegisterUserRequest(string Email, string Password, string Name);
public readonly record struct LoginUserRequest(string Email, string Password);
public readonly record struct RefreshTokenUserRequest(string RefreshToken);
public readonly record struct ChangeEmailUserRequest(string Email);
public readonly record struct ChangePasswordUserRequest(string CurrentPassword, string NewPassword);
public readonly record struct ChangeNameUserRequest(string Name);
public readonly record struct LogoutUserRequest(string RefreshToken);