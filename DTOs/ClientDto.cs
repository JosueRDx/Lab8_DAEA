namespace Lab8_RodrigoApaza.DTOs;

// DTO para exponer la información básica y segura de un cliente.
public class ClientDto
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}