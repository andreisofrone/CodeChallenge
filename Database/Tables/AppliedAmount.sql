﻿CREATE TABLE [dbo].[AppliedAmount]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1), 
    [LowerBound] BIGINT NOT NULL, 
    [UpperBound] BIGINT NOT NULL, 
    [Decision] BIT NOT NULL
)
