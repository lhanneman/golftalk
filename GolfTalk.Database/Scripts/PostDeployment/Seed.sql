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
-- superadmin@golftalk.com/admin123

merge into dbo.Users as Target
using ( values

	(N'60A76928-9EAC-4F16-AEDA-37EB80759931', N'superadmin@golftalk.com', N'AMo0QcghRuxw26dh5X4NeOKLYBNNJzNGIExKWvlH4o+2Qffx5p6uqincA1qQSZZ55A==', N'24993fbe-bf41-4d47-b958-633e827d3e19', N'superadmin', 1, 0, 0, 0, 0, 'Super', 'Admin', GETUTCDATE())

) as Source ([Id], [Email], [PasswordHash], [SecurityStamp], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CreatedAtUtc])
on Target.Id = Source.Id
when not matched by Target then
insert ([Id], [Email], [PasswordHash], [SecurityStamp], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CreatedAtUtc])
values ([Id], [Email], [PasswordHash], [SecurityStamp], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CreatedAtUtc]);

-- add 18 holes

