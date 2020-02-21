CREATE TABLE [dbo].[LoadLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[RunDate] [datetime] NOT NULL,
	[CCI_Institutional] [int] NOT NULL,
	[CCI_Professional] [int] NOT NULL,
	[CMC_Institutional] [int] NOT NULL,
	[CMC_Professional] [int] NOT NULL,
	[DHCS_Institutional] [int] NOT NULL,
	[DHCS_Professional] [int] NOT NULL,
	[LoadedBy] [varchar](100) NOT NULL,
	[LoadStatus] [varchar](1) NOT NULL,
 CONSTRAINT [PK_LoadLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

