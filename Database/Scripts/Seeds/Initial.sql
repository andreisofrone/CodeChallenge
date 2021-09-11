﻿

--NOTE: I will asume that '100000000000' is the max for a credit

DELETE FROM AppliedAmount
GO

DELETE FROM TotalFutureDebt
GO

INSERT INTO AppliedAmount([LowerBound], [UpperBound], [Decision])
VALUES(0, 2000, 0), (2000, 69000, 1), (69000, 100000000000, 0)

INSERT INTO TotalFutureDebt([LowerBound], [UpperBound], [InterestRate])
VALUES(0, 20000, 3), (2000, 390000, 4), (400000, 590000, 5), (600000, 100000000000, 6)