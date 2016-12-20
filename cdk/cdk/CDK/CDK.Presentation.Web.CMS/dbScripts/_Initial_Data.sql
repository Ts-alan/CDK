INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e3994179-66b6-4c36-a348-4304b8a6d7dd', N'Admin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'73a2472d-ef6b-4dbf-90e9-a1df64e280c7', N'SuperAdmin')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsDefault]) VALUES (N'dcb06aae-c7ed-4912-b474-c54d9e4548d0', NULL, 0, N'ABVPbcRL/jBXRWmF+QzI2AcJlfQ+9W7o8HuzZDlYI4T/vSDLMQd+/AuOilaH2yqghQ==', N'668f2322-ff84-4199-be1d-d166c6fc84e1', NULL, 0, 0, NULL, 0, 0, N'superadmin', 1)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dcb06aae-c7ed-4912-b474-c54d9e4548d0', N'73a2472d-ef6b-4dbf-90e9-a1df64e280c7')
GO