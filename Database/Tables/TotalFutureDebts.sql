CREATE TABLE [dbo].[TotalFutureDebts]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1), 
    [LowerBound] BIGINT NOT NULL, 
    [UpperBound] BIGINT NOT NULL, 
    [InterestRate] INT NOT NULL
)
