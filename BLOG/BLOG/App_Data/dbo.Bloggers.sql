CREATE TABLE [dbo].[Bloggers] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [NickName]   NVARCHAR (MAX) NOT NULL,
    [password]   NVARCHAR (MAX) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [SocialNet1] NVARCHAR (MAX) NULL,
    [SocialNet2] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Bloggers] PRIMARY KEY CLUSTERED ([ID] ASC)
);

