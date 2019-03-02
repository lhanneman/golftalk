-- define roles:
-- super admin, tournament admin, tournament user

merge into dbo.Roles as Target
using ( values

	(N'A0BF1706-A4C7-4E56-92C8-981200C5A823', N'SuperAdmin'),
	(N'B5D14D59-0D37-46BE-A7A7-87E421F5431F', N'TournamentAdmin'),
    (N'DB6BE252-567A-428B-9BBF-0604FAD1DFED', N'User')
) as Source ([Id], [Name])
on Target.Id = Source.Id
when not matched by Target then
insert ([Id], [Name])
values ([Id], [Name]);

-- create a test user (super admin)

merge into dbo.Users as Target
using ( values

	(N'60A76928-9EAC-4F16-AEDA-37EB80759931', N'superadmin@golftalk.com', N'ALzO6Agxk0JCEQ3o41cMVuHk+erOCxuPCz0WX0x1ppQVCtb23EOSx5sYl2M+JpA/8w==', N'd0d5108f-a438-4d3b-a0ca-0047619d5468', N'testadmin@fixationco.com', 1, 0, 0, 0, 0, 'Test', 'Admin', GETUTCDATE()),
    (N'7344e550-323d-464e-b079-859c66f590d3', N'testrep@fixationco.com', N'AMKK3ESdQQYseZ4vh1AOeAl13WPU5SWVgdW0fMZA3Liygv0bC4b4KfBZYcpTKr7gng==', N'05059fab-3af3-407d-8905-4e4dc290917a', N'testrep@fixationco.com', 1, 0, 0, 0, 0, 'Test', 'Rep', GETUTCDATE()),
    (N'3c31a05c-fd9c-451d-a0ad-e101b2ccae48', N'testdealeradmin@fixationco.com', N'AAykdmhUB9eZp7VA1Heria7Yvb6BlT8ScbV8TJvdMmaIMsM7UnljvEgE2rB5cEbOFg==', N'564b4150-e02c-4842-8fa0-71b4f0d2d05d', N'testdealeradmin@fixationco.com', 1, 0, 0, 0, 0, 'Test', 'DealerAdmin', GETUTCDATE()),
    (N'a6e8868d-faad-4629-a841-373e3684e948', N'testdealer@fixationco.com', N'ADuJ0M3YqoWYC0AYopzqFFDTtKBHmnS58NdCBtzpCxjkfBHILe05SIUCoDhhLaZdKg==', N'dc286df0-c75a-4c36-8824-e001a46033f5', N'testdealer@fixationco.com', 1, 0, 0, 0, 0, 'Test', 'Dealer', GETUTCDATE())

) as Source ([Id], [Email], [PasswordHash], [SecurityStamp], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CreatedAtUtc])
on Target.Id = Source.Id
when not matched by Target then
insert ([Id], [Email], [PasswordHash], [SecurityStamp], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CreatedAtUtc])
values ([Id], [Email], [PasswordHash], [SecurityStamp], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CreatedAtUtc]);

-- add 18 holes

