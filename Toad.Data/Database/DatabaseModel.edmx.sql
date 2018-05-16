
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/12/2017 15:25:35
-- Generated from EDMX file: D:\Projects\change\working copy\Toad\Toad.Data\Database\DatabaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ChangeBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ChangeChangeTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChangeTags] DROP CONSTRAINT [FK_ChangeChangeTag];
GO
IF OBJECT_ID(N'[dbo].[FK_ChangeChangeCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChangeCategories] DROP CONSTRAINT [FK_ChangeChangeCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ChangeUserChange]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserChanges] DROP CONSTRAINT [FK_ChangeUserChange];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryChangeCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChangeCategories] DROP CONSTRAINT [FK_CategoryChangeCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserChange]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserChanges] DROP CONSTRAINT [FK_UserUserChange];
GO
IF OBJECT_ID(N'[dbo].[FK_TagsChangeTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChangeTags] DROP CONSTRAINT [FK_TagsChangeTag];
GO
IF OBJECT_ID(N'[dbo].[FK_ChangeComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_ChangeComment];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserComments] DROP CONSTRAINT [FK_UserUserComment];
GO
IF OBJECT_ID(N'[dbo].[FK_CommentUserComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserComments] DROP CONSTRAINT [FK_CommentUserComment];
GO
IF OBJECT_ID(N'[dbo].[FK_UserBlog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Blogs] DROP CONSTRAINT [FK_UserBlog];
GO
IF OBJECT_ID(N'[dbo].[FK_CommentProposalVote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProposalVotes] DROP CONSTRAINT [FK_CommentProposalVote];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProposalVote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProposalVotes] DROP CONSTRAINT [FK_UserProposalVote];
GO
IF OBJECT_ID(N'[dbo].[FK_ChangeChangePrecursor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChangePrecursors] DROP CONSTRAINT [FK_ChangeChangePrecursor];
GO
IF OBJECT_ID(N'[dbo].[FK_UserChangePrecursor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChangePrecursors] DROP CONSTRAINT [FK_UserChangePrecursor];
GO
IF OBJECT_ID(N'[dbo].[FK_ChangeChangePrecursor1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChangePrecursors] DROP CONSTRAINT [FK_ChangeChangePrecursor1];
GO
IF OBJECT_ID(N'[dbo].[FK_ChangeConstraint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Constraints] DROP CONSTRAINT [FK_ChangeConstraint];
GO
IF OBJECT_ID(N'[dbo].[FK_UserConstraint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Constraints] DROP CONSTRAINT [FK_UserConstraint];
GO
IF OBJECT_ID(N'[dbo].[FK_ChangeChangeFollow]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChangeFollowers] DROP CONSTRAINT [FK_ChangeChangeFollow];
GO
IF OBJECT_ID(N'[dbo].[FK_UserChangeFollow]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChangeFollowers] DROP CONSTRAINT [FK_UserChangeFollow];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserFollower]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserFollowers] DROP CONSTRAINT [FK_UserUserFollower];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserFollower1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserFollowers] DROP CONSTRAINT [FK_UserUserFollower1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Changes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Changes];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Tags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tags];
GO
IF OBJECT_ID(N'[dbo].[ChangeTags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChangeTags];
GO
IF OBJECT_ID(N'[dbo].[ChangeCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChangeCategories];
GO
IF OBJECT_ID(N'[dbo].[UserChanges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserChanges];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[UserComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserComments];
GO
IF OBJECT_ID(N'[dbo].[Blogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Blogs];
GO
IF OBJECT_ID(N'[dbo].[ProposalVotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProposalVotes];
GO
IF OBJECT_ID(N'[dbo].[ChangePrecursors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChangePrecursors];
GO
IF OBJECT_ID(N'[dbo].[Constraints]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Constraints];
GO
IF OBJECT_ID(N'[dbo].[ChangeFollowers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChangeFollowers];
GO
IF OBJECT_ID(N'[dbo].[UserFollowers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserFollowers];
GO
IF OBJECT_ID(N'[dbo].[FreeComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FreeComments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Changes'
CREATE TABLE [dbo].[Changes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Details] nvarchar(max)  NOT NULL,
    [IsPoll] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [SearchTitle] nvarchar(max)  NOT NULL,
    [ViewCounter] int  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [AspNetUserId] nvarchar(max)  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [TagLine] nvarchar(max)  NOT NULL,
    [ShortDescription] nvarchar(max)  NOT NULL,
    [LongDescription] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tags'
CREATE TABLE [dbo].[Tags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ChangeTags'
CREATE TABLE [dbo].[ChangeTags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ChangeId] int  NOT NULL,
    [TagsId] int  NOT NULL
);
GO

-- Creating table 'ChangeCategories'
CREATE TABLE [dbo].[ChangeCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ChangeId] int  NOT NULL,
    [CategoryId] int  NOT NULL
);
GO

-- Creating table 'UserChanges'
CREATE TABLE [dbo].[UserChanges] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [ChangeId] int  NOT NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [IPAddress] nvarchar(max)  NOT NULL,
    [ChangeId] int  NOT NULL,
    [TotalVote] int  NOT NULL
);
GO

-- Creating table 'UserComments'
CREATE TABLE [dbo].[UserComments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [CommentId] int  NOT NULL
);
GO

-- Creating table 'Blogs'
CREATE TABLE [dbo].[Blogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [BaseImage] nvarchar(max)  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [UserId] int  NOT NULL,
    [SmallDescription] nvarchar(max)  NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProposalVotes'
CREATE TABLE [dbo].[ProposalVotes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CommentId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [VoteStatus] bit  NOT NULL
);
GO

-- Creating table 'ChangePrecursors'
CREATE TABLE [dbo].[ChangePrecursors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ChangeId] int  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [UserId] int  NOT NULL,
    [MainChangeId] int  NOT NULL
);
GO

-- Creating table 'Constraints'
CREATE TABLE [dbo].[Constraints] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [ChangeId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'ChangeFollowers'
CREATE TABLE [dbo].[ChangeFollowers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ChangeId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [TimeStamp] datetime  NOT NULL
);
GO

-- Creating table 'UserFollowers'
CREATE TABLE [dbo].[UserFollowers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [MainUserId] int  NOT NULL,
    [FollowingUserId] int  NOT NULL
);
GO

-- Creating table 'FreeComments'
CREATE TABLE [dbo].[FreeComments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [DateTime] datetime  NOT NULL,
    [ChangeId] int  NULL,
    [BlogId] int  NULL,
    [IP] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Changes'
ALTER TABLE [dbo].[Changes]
ADD CONSTRAINT [PK_Changes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tags'
ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [PK_Tags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChangeTags'
ALTER TABLE [dbo].[ChangeTags]
ADD CONSTRAINT [PK_ChangeTags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChangeCategories'
ALTER TABLE [dbo].[ChangeCategories]
ADD CONSTRAINT [PK_ChangeCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserChanges'
ALTER TABLE [dbo].[UserChanges]
ADD CONSTRAINT [PK_UserChanges]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserComments'
ALTER TABLE [dbo].[UserComments]
ADD CONSTRAINT [PK_UserComments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [PK_Blogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProposalVotes'
ALTER TABLE [dbo].[ProposalVotes]
ADD CONSTRAINT [PK_ProposalVotes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChangePrecursors'
ALTER TABLE [dbo].[ChangePrecursors]
ADD CONSTRAINT [PK_ChangePrecursors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Constraints'
ALTER TABLE [dbo].[Constraints]
ADD CONSTRAINT [PK_Constraints]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChangeFollowers'
ALTER TABLE [dbo].[ChangeFollowers]
ADD CONSTRAINT [PK_ChangeFollowers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserFollowers'
ALTER TABLE [dbo].[UserFollowers]
ADD CONSTRAINT [PK_UserFollowers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FreeComments'
ALTER TABLE [dbo].[FreeComments]
ADD CONSTRAINT [PK_FreeComments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ChangeId] in table 'ChangeTags'
ALTER TABLE [dbo].[ChangeTags]
ADD CONSTRAINT [FK_ChangeChangeTag]
    FOREIGN KEY ([ChangeId])
    REFERENCES [dbo].[Changes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChangeChangeTag'
CREATE INDEX [IX_FK_ChangeChangeTag]
ON [dbo].[ChangeTags]
    ([ChangeId]);
GO

-- Creating foreign key on [ChangeId] in table 'ChangeCategories'
ALTER TABLE [dbo].[ChangeCategories]
ADD CONSTRAINT [FK_ChangeChangeCategory]
    FOREIGN KEY ([ChangeId])
    REFERENCES [dbo].[Changes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChangeChangeCategory'
CREATE INDEX [IX_FK_ChangeChangeCategory]
ON [dbo].[ChangeCategories]
    ([ChangeId]);
GO

-- Creating foreign key on [ChangeId] in table 'UserChanges'
ALTER TABLE [dbo].[UserChanges]
ADD CONSTRAINT [FK_ChangeUserChange]
    FOREIGN KEY ([ChangeId])
    REFERENCES [dbo].[Changes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChangeUserChange'
CREATE INDEX [IX_FK_ChangeUserChange]
ON [dbo].[UserChanges]
    ([ChangeId]);
GO

-- Creating foreign key on [CategoryId] in table 'ChangeCategories'
ALTER TABLE [dbo].[ChangeCategories]
ADD CONSTRAINT [FK_CategoryChangeCategory]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryChangeCategory'
CREATE INDEX [IX_FK_CategoryChangeCategory]
ON [dbo].[ChangeCategories]
    ([CategoryId]);
GO

-- Creating foreign key on [UserId] in table 'UserChanges'
ALTER TABLE [dbo].[UserChanges]
ADD CONSTRAINT [FK_UserUserChange]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserChange'
CREATE INDEX [IX_FK_UserUserChange]
ON [dbo].[UserChanges]
    ([UserId]);
GO

-- Creating foreign key on [TagsId] in table 'ChangeTags'
ALTER TABLE [dbo].[ChangeTags]
ADD CONSTRAINT [FK_TagsChangeTag]
    FOREIGN KEY ([TagsId])
    REFERENCES [dbo].[Tags]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TagsChangeTag'
CREATE INDEX [IX_FK_TagsChangeTag]
ON [dbo].[ChangeTags]
    ([TagsId]);
GO

-- Creating foreign key on [ChangeId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_ChangeComment]
    FOREIGN KEY ([ChangeId])
    REFERENCES [dbo].[Changes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChangeComment'
CREATE INDEX [IX_FK_ChangeComment]
ON [dbo].[Comments]
    ([ChangeId]);
GO

-- Creating foreign key on [UserId] in table 'UserComments'
ALTER TABLE [dbo].[UserComments]
ADD CONSTRAINT [FK_UserUserComment]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserComment'
CREATE INDEX [IX_FK_UserUserComment]
ON [dbo].[UserComments]
    ([UserId]);
GO

-- Creating foreign key on [CommentId] in table 'UserComments'
ALTER TABLE [dbo].[UserComments]
ADD CONSTRAINT [FK_CommentUserComment]
    FOREIGN KEY ([CommentId])
    REFERENCES [dbo].[Comments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentUserComment'
CREATE INDEX [IX_FK_CommentUserComment]
ON [dbo].[UserComments]
    ([CommentId]);
GO

-- Creating foreign key on [UserId] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [FK_UserBlog]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBlog'
CREATE INDEX [IX_FK_UserBlog]
ON [dbo].[Blogs]
    ([UserId]);
GO

-- Creating foreign key on [CommentId] in table 'ProposalVotes'
ALTER TABLE [dbo].[ProposalVotes]
ADD CONSTRAINT [FK_CommentProposalVote]
    FOREIGN KEY ([CommentId])
    REFERENCES [dbo].[Comments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentProposalVote'
CREATE INDEX [IX_FK_CommentProposalVote]
ON [dbo].[ProposalVotes]
    ([CommentId]);
GO

-- Creating foreign key on [UserId] in table 'ProposalVotes'
ALTER TABLE [dbo].[ProposalVotes]
ADD CONSTRAINT [FK_UserProposalVote]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProposalVote'
CREATE INDEX [IX_FK_UserProposalVote]
ON [dbo].[ProposalVotes]
    ([UserId]);
GO

-- Creating foreign key on [ChangeId] in table 'ChangePrecursors'
ALTER TABLE [dbo].[ChangePrecursors]
ADD CONSTRAINT [FK_ChangeChangePrecursor]
    FOREIGN KEY ([ChangeId])
    REFERENCES [dbo].[Changes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChangeChangePrecursor'
CREATE INDEX [IX_FK_ChangeChangePrecursor]
ON [dbo].[ChangePrecursors]
    ([ChangeId]);
GO

-- Creating foreign key on [UserId] in table 'ChangePrecursors'
ALTER TABLE [dbo].[ChangePrecursors]
ADD CONSTRAINT [FK_UserChangePrecursor]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserChangePrecursor'
CREATE INDEX [IX_FK_UserChangePrecursor]
ON [dbo].[ChangePrecursors]
    ([UserId]);
GO

-- Creating foreign key on [MainChangeId] in table 'ChangePrecursors'
ALTER TABLE [dbo].[ChangePrecursors]
ADD CONSTRAINT [FK_ChangeChangePrecursor1]
    FOREIGN KEY ([MainChangeId])
    REFERENCES [dbo].[Changes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChangeChangePrecursor1'
CREATE INDEX [IX_FK_ChangeChangePrecursor1]
ON [dbo].[ChangePrecursors]
    ([MainChangeId]);
GO

-- Creating foreign key on [ChangeId] in table 'Constraints'
ALTER TABLE [dbo].[Constraints]
ADD CONSTRAINT [FK_ChangeConstraint]
    FOREIGN KEY ([ChangeId])
    REFERENCES [dbo].[Changes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChangeConstraint'
CREATE INDEX [IX_FK_ChangeConstraint]
ON [dbo].[Constraints]
    ([ChangeId]);
GO

-- Creating foreign key on [UserId] in table 'Constraints'
ALTER TABLE [dbo].[Constraints]
ADD CONSTRAINT [FK_UserConstraint]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserConstraint'
CREATE INDEX [IX_FK_UserConstraint]
ON [dbo].[Constraints]
    ([UserId]);
GO

-- Creating foreign key on [ChangeId] in table 'ChangeFollowers'
ALTER TABLE [dbo].[ChangeFollowers]
ADD CONSTRAINT [FK_ChangeChangeFollow]
    FOREIGN KEY ([ChangeId])
    REFERENCES [dbo].[Changes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChangeChangeFollow'
CREATE INDEX [IX_FK_ChangeChangeFollow]
ON [dbo].[ChangeFollowers]
    ([ChangeId]);
GO

-- Creating foreign key on [UserId] in table 'ChangeFollowers'
ALTER TABLE [dbo].[ChangeFollowers]
ADD CONSTRAINT [FK_UserChangeFollow]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserChangeFollow'
CREATE INDEX [IX_FK_UserChangeFollow]
ON [dbo].[ChangeFollowers]
    ([UserId]);
GO

-- Creating foreign key on [MainUserId] in table 'UserFollowers'
ALTER TABLE [dbo].[UserFollowers]
ADD CONSTRAINT [FK_UserUserFollower]
    FOREIGN KEY ([MainUserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserFollower'
CREATE INDEX [IX_FK_UserUserFollower]
ON [dbo].[UserFollowers]
    ([MainUserId]);
GO

-- Creating foreign key on [FollowingUserId] in table 'UserFollowers'
ALTER TABLE [dbo].[UserFollowers]
ADD CONSTRAINT [FK_UserUserFollower1]
    FOREIGN KEY ([FollowingUserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserFollower1'
CREATE INDEX [IX_FK_UserUserFollower1]
ON [dbo].[UserFollowers]
    ([FollowingUserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------