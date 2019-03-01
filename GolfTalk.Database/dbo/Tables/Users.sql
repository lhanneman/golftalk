CREATE TABLE [dbo].[Users] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL DEFAULT 0,
    [TwoFactorEnabled]     BIT            NOT NULL DEFAULT 0,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL DEFAULT 0,
    [AccessFailedCount]    INT            NOT NULL DEFAULT 0,
    [UserName]             NVARCHAR (256) NOT NULL,
    [FirstName]            NVARCHAR (100) NULL,
    [LastName]             NVARCHAR (100) NULL,
    [DeletedAtUtc]         DATETIME2      NULL,
    [CreatedAtUtc]         DATETIME2      NOT NULL DEFAULT(GETUTCDATE()),
    [PasswordChangedAtUtc] DATETIME2      NOT NULL DEFAULT(GETUTCDATE()),

    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[Users]([UserName] ASC);
