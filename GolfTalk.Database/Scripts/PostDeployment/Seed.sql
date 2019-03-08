-- define roles:
-- super admin, tournament admin, tournament user

merge into dbo.Roles as Target
using ( values

	(N'A0BF1706-A4C7-4E56-92C8-981200C5A823', N'Admin'),
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

	(N'8E94905D-D1BE-4483-84B3-53FCDB3137BF', N'superadmin@golftalk.com', N'APg+c29U2uDDTErDH4a89qPtPWkHfFIY6QrD+Xk5vf5QswkklRQanMIYPBbVwqvSqg==', N'0f7eb5b2-4533-4946-851a-b9a975df6af7', N'superadmin@golftalk.com', 0, 0, 0, 0, 0, 'Super', 'Admin', GETUTCDATE())

) as Source ([Id], [Email], [PasswordHash], [SecurityStamp], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CreatedAtUtc])
on Target.Id = Source.Id
when not matched by Target then
insert ([Id], [Email], [PasswordHash], [SecurityStamp], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CreatedAtUtc])
values ([Id], [Email], [PasswordHash], [SecurityStamp], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [CreatedAtUtc]);

-- set user roles
merge into dbo.UserRoles as Target
using ( values

	(N'8E94905D-D1BE-4483-84B3-53FCDB3137BF', N'A0BF1706-A4C7-4E56-92C8-981200C5A823')

) as Source ([UserId], [RoleId])
on Target.UserId = Source.UserId
when not matched by Target then
insert ([UserId], [RoleId])
values ([UserId], [RoleId]);

-- add a course


merge into dbo.Courses as Target
using ( values

	(N'Thornridge Golf Course', N'Located in Milford, NE', getutcdate())
	
) as Source ([Name], [Description], [CreatedAtUtc])
on Target.[Name]= Source.[Name]
when not matched by Target then
insert ([Name], [Description], [CreatedAtUtc])
values ([Name], [Description], [CreatedAtUtc]);


declare @defaultCourseId int;
select @defaultCourseId = Id from dbo.Courses Where [name] = 'Thornridge Golf Course'

-- create the holes for the course
--http://www.thornridgegolfcourse.com/rates/ (using Regular teebox for yards)

merge into dbo.Holes as Target
using ( values

	(@defaultCourseId, 1, 4, 283, 8),
	(@defaultCourseId, 2, 5, 491, 2),
	(@defaultCourseId, 3, 4, 336, 4),
	(@defaultCourseId, 4, 3, 167, 7),
	(@defaultCourseId, 5, 4, 370, 3),
	(@defaultCourseId, 6, 3, 133, 9),
	(@defaultCourseId, 7, 4, 334, 5),
	(@defaultCourseId, 8, 4, 334, 6),
	(@defaultCourseId, 9, 5, 492, 1),
	(@defaultCourseId, 10, 4, 283, 8),
	(@defaultCourseId, 11, 5, 491, 2),
	(@defaultCourseId, 12, 4, 336, 4),
	(@defaultCourseId, 13, 3, 167, 7),
	(@defaultCourseId, 14, 4, 370, 3),
	(@defaultCourseId, 15, 3, 133, 9),
	(@defaultCourseId, 16, 4, 334, 5),
	(@defaultCourseId, 17, 4, 334, 6),
	(@defaultCourseId, 18, 5, 492, 1)
	
) as Source ([CourseId], [HoleNumber], [Par], [Yards], [Handicap])
on Target.[CourseId]= Source.[CourseId] and Target.[HoleNumber] = Source.[HoleNumber]
when not matched by Target then
insert ([CourseId], [HoleNumber], [Par], [Yards], [Handicap])
values ([CourseId], [HoleNumber], [Par], [Yards], [Handicap]);