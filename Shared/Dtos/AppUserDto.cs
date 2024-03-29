﻿namespace LexiconLMSBlazor.Shared.Dtos
{
    public class AppUserDto
    {
        public string? Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; } = string.Empty;

        public int UserRole { get; set; }

        // Foreign Key
        public int CourseId { get; set; }
    }
}
