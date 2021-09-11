

--NOTE: I will asume that '1000000000' is the max for a credit

--NOTE: In a real application a check for existing data must be implemented and apply a sql merge if so.. but for the speed of the exercise
-- I will just remove them always before publish, it won't affect.

DELETE FROM AppliedAmounts
GO

DELETE FROM TotalFutureDebts
GO

INSERT INTO AppliedAmounts([LowerBound], [UpperBound], [Decision])
VALUES(0, 2000, 0), (2000, 69000, 1), (69000, 1000000000, 0)

INSERT INTO TotalFutureDebts([LowerBound], [UpperBound], [InterestRate])
VALUES(0, 20000, 3), (20000, 39000, 4), (40000, 59000, 5), (60000, 1000000000, 6)