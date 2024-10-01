--                  QUESTION 2

--              1.      Entity Requirements

--              1.1     Clients Table

CREATE TABLE Clients (
    client_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL,
    phone_number VARCHAR(15) NOT NULL,
    date_of_birth DATE NOT NULL,
    residential_address VARCHAR(255) NOT NULL,
    risk_profile VARCHAR(10) CHECK (risk_profile IN ('Low', 'Moderate', 'High')) NOT NULL,
    total_investment_value DECIMAL(15, 2) NOT NULL
);


--              1.2     Accounts Table

CREATE TABLE Accounts (
    account_id INT PRIMARY KEY IDENTITY(1,1),
    client_id INT NOT NULL,
    account_type VARCHAR(10) CHECK (account_type IN ('Cash', 'Margin', 'Retirement')) NOT NULL,
    account_balance DECIMAL(15, 2) NOT NULL,
    open_date DATE NOT NULL,
    status VARCHAR(10) CHECK (status IN ('Active', 'Closed', 'Frozen')) NOT NULL,
    FOREIGN KEY (client_id) REFERENCES Clients(client_id)
);


--              1.3     Assets Table

CREATE TABLE Assets (
    asset_id INT PRIMARY KEY IDENTITY(1,1),
    asset_name VARCHAR(100) NOT NULL,
    asset_type VARCHAR(20) CHECK (asset_type IN ('Stock', 'Bond', 'Mutual Fund', 'ETF')) NOT NULL,
    ticker_symbol VARCHAR(10) NOT NULL,
    market_price DECIMAL(10, 2) NOT NULL,
    sector VARCHAR(50) NOT NULL,
    risk_level VARCHAR(10) CHECK (risk_level IN ('Low', 'Moderate', 'High')) NOT NULL
);

--              1.4     Portfolios Table

CREATE TABLE Portfolios (
    portfolio_id INT PRIMARY KEY IDENTITY(1,1),
    account_id INT NOT NULL,
    total_value DECIMAL(15, 2) NOT NULL,
    risk_profile VARCHAR(10) CHECK (risk_profile IN ('Low', 'Moderate', 'High')) NOT NULL,
    FOREIGN KEY (account_id) REFERENCES Accounts(account_id)
);


--              1.5     Portfolio_Holdings Table

CREATE TABLE Portfolio_Holdings (
    holding_id INT PRIMARY KEY IDENTITY(1,1),
    portfolio_id INT NOT NULL,
    asset_id INT NOT NULL,
    quantity INT NOT NULL,
    purchase_price DECIMAL(10, 2) NOT NULL,
    purchase_date DATE NOT NULL,
    FOREIGN KEY (portfolio_id) REFERENCES Portfolios(portfolio_id),
    FOREIGN KEY (asset_id) REFERENCES Assets(asset_id)
);


--              1.6     Trades Table

CREATE TABLE Trades (
    trade_id INT PRIMARY KEY IDENTITY(1,1),
    account_id INT NOT NULL,
    asset_id INT NOT NULL,
    trade_type VARCHAR(10) CHECK (trade_type IN ('Buy', 'Sell')) NOT NULL,
    quantity INT NOT NULL,
    trade_price DECIMAL(10, 2) NOT NULL,
    trade_date DATE NOT NULL,
    total_value DECIMAL(15, 2) NOT NULL,
    trade_status VARCHAR(10) CHECK (trade_status IN ('Pending', 'Executed', 'Cancelled')) NOT NULL,
    FOREIGN KEY (account_id) REFERENCES Accounts(account_id),
    FOREIGN KEY (asset_id) REFERENCES Assets(asset_id)
);


--              1.7     Transactions Table

CREATE TABLE Transactions (
    transaction_id INT PRIMARY KEY IDENTITY(1,1),
    account_id INT NOT NULL,
    transaction_type VARCHAR(10) CHECK (transaction_type IN ('Deposit', 'Withdrawal', 'Trade', 'Dividend')) NOT NULL,
    amount DECIMAL(15, 2) NOT NULL,
    transaction_date DATE NOT NULL,
    related_trade_id INT,
    FOREIGN KEY (account_id) REFERENCES Accounts(account_id),
    FOREIGN KEY (related_trade_id) REFERENCES Trades(trade_id)
);


--              1.8     Dividends Table

CREATE TABLE Dividends (
    dividend_id INT PRIMARY KEY IDENTITY(1,1),
    asset_id INT NOT NULL,
    dividend_amount_per_share DECIMAL(10, 2) NOT NULL,
    payment_date DATE NOT NULL,
    FOREIGN KEY (asset_id) REFERENCES Assets(asset_id)
);


--              1.9     Market_Data Table

CREATE TABLE Market_Data (
    market_data_id INT PRIMARY KEY IDENTITY(1,1),
    asset_id INT NOT NULL,
    market_price DECIMAL(10, 2) NOT NULL,
    price_timestamp DATETIME NOT NULL,
    FOREIGN KEY (asset_id) REFERENCES Assets(asset_id)
);


--                      INSERTIONS

INSERT INTO Clients (first_name, last_name, email, phone_number, date_of_birth, residential_address, risk_profile, total_investment_value) VALUES
('John', 'Doe', 'john.doe@example.com', '1234567890', '1980-01-01', '123 Main St', 'Moderate', 100000.00),
('Jane', 'Smith', 'jane.smith@example.com', '0987654321', '1985-02-02', '456 Elm St', 'High', 200000.00),
('Alice', 'Johnson', 'alice.johnson@example.com', '1112223333', '1990-03-03', '789 Oak St', 'Low', 50000.00),
('Bob', 'Brown', 'bob.brown@example.com', '4445556666', '1975-04-04', '101 Pine St', 'Moderate', 150000.00),
('Charlie', 'Davis', 'charlie.davis@example.com', '7778889999', '1982-05-05', '202 Maple St', 'High', 250000.00),
('Diana', 'Miller', 'diana.miller@example.com', '1231231234', '1995-06-06', '303 Birch St', 'Low', 75000.00),
('Eve', 'Wilson', 'eve.wilson@example.com', '3213214321', '1988-07-07', '404 Cedar St', 'Moderate', 120000.00),
('Frank', 'Moore', 'frank.moore@example.com', '5556667777', '1979-08-08', '505 Spruce St', 'High', 300000.00),
('Grace', 'Taylor', 'grace.taylor@example.com', '8889990000', '1992-09-09', '606 Willow St', 'Low', 60000.00),
('Hank', 'Anderson', 'hank.anderson@example.com', '9998887777', '1983-10-10', '707 Ash St', 'Moderate', 180000.00);

INSERT INTO Accounts (client_id, account_type, account_balance, open_date, status) VALUES
(1, 'Cash', 50000.00, '2023-01-01', 'Active'),
(2, 'Margin', 100000.00, '2023-02-01', 'Active'),
(3, 'Retirement', 25000.00, '2023-03-01', 'Active'),
(4, 'Cash', 75000.00, '2023-04-01', 'Active'),
(5, 'Margin', 125000.00, '2023-05-01', 'Active'),
(6, 'Retirement', 30000.00, '2023-06-01', 'Active'),
(7, 'Cash', 60000.00, '2023-07-01', 'Active'),
(8, 'Margin', 150000.00, '2023-08-01', 'Active'),
(9, 'Retirement', 35000.00, '2023-09-01', 'Active'),
(10, 'Cash', 90000.00, '2023-10-01', 'Active');

INSERT INTO Assets (asset_name, asset_type, ticker_symbol, market_price, sector, risk_level) VALUES
('Apple Inc.', 'Stock', 'AAPL', 150.00, 'Technology', 'Moderate'),
('Tesla Inc.', 'Stock', 'TSLA', 700.00, 'Automotive', 'High'),
('Vanguard 500 Index Fund', 'Mutual Fund', 'VFIAX', 350.00, 'Finance', 'Low'),
('US Treasury Bond', 'Bond', 'USTB', 1000.00, 'Government', 'Low'),
('SPDR S&P 500 ETF', 'ETF', 'SPY', 400.00, 'Finance', 'Moderate'),
('Microsoft Corp.', 'Stock', 'MSFT', 250.00, 'Technology', 'Moderate'),
('Amazon.com Inc.', 'Stock', 'AMZN', 3300.00, 'E-commerce', 'High'),
('Alphabet Inc.', 'Stock', 'GOOGL', 2800.00, 'Technology', 'Moderate'),
('Johnson & Johnson', 'Stock', 'JNJ', 160.00, 'Healthcare', 'Low'),
('Procter & Gamble Co.', 'Stock', 'PG', 140.00, 'Consumer Goods', 'Low');

INSERT INTO Portfolios (account_id, total_value, risk_profile) VALUES
(1, 50000.00, 'Moderate'),
(2, 100000.00, 'High'),
(3, 25000.00, 'Low'),
(4, 75000.00, 'Moderate'),
(5, 125000.00, 'High'),
(6, 30000.00, 'Low'),
(7, 60000.00, 'Moderate'),
(8, 150000.00, 'High'),
(9, 35000.00, 'Low'),
(10, 90000.00, 'Moderate');

INSERT INTO Portfolio_Holdings (portfolio_id, asset_id, quantity, purchase_price, purchase_date) VALUES
(1, 1, 100, 150.00, '2023-01-01'),
(2, 2, 50, 700.00, '2023-02-01'),
(3, 3, 30, 350.00, '2023-03-01'),
(4, 4, 10, 1000.00, '2023-04-01'),
(5, 5, 25, 400.00, '2023-05-01'),
(6, 6, 40, 250.00, '2023-06-01'),
(7, 7, 20, 3300.00, '2023-07-01'),
(8, 8, 15, 2800.00, '2023-08-01'),
(9, 9, 50, 160.00, '2023-09-01'),
(10, 10, 60, 140.00, '2023-10-01');

INSERT INTO Trades (account_id, asset_id, trade_type, quantity, trade_price, trade_date, total_value, trade_status) VALUES
(1, 1, 'Buy', 100, 150.00, '2023-01-01', 15000.00, 'Executed'),
(2, 2, 'Buy', 50, 700.00, '2023-02-01', 35000.00, 'Executed'),
(3, 3, 'Buy', 30, 350.00, '2023-03-01', 10500.00, 'Executed'),
(4, 4, 'Buy', 10, 1000.00, '2023-04-01', 10000.00, 'Executed'),
(5, 5, 'Buy', 25, 400.00, '2023-05-01', 10000.00, 'Executed'),
(6, 6, 'Buy', 40, 250.00, '2023-06-01', 10000.00, 'Executed'),
(7, 7, 'Buy', 20, 3300.00, '2023-07-01', 66000.00, 'Executed'),
(8, 8, 'Buy', 15, 2800.00, '2023-08-01', 42000.00, 'Executed'),
(9, 9, 'Buy', 50, 160.00, '2023-09-01', 8000.00, 'Executed'),
(10, 10, 'Buy', 60, 140.00, '2023-10-01', 8400.00, 'Executed');

INSERT INTO Transactions (account_id, transaction_type, amount, transaction_date, related_trade_id) VALUES
(1, 'Deposit', 50000.00, '2023-01-01', NULL),
(2, 'Deposit', 100000.00, '2023-02-01', NULL),
(3, 'Deposit', 25000.00, '2023-03-01', NULL),
(4, 'Deposit', 75000.00, '2023-04-01', NULL),
(5, 'Deposit', 125000.00, '2023-05-01', NULL),
(6, 'Deposit', 30000.00, '2023-06-01', NULL),
(7, 'Deposit', 60000.00, '2023-07-01', NULL),
(8, 'Deposit', 150000.00, '2023-08-01', NULL),
(9, 'Deposit', 35000.00, '2023-09-01', NULL),
(10, 'Deposit', 90000.00, '2023-10-01', NULL);

INSERT INTO Dividends (asset_id, dividend_amount_per_share, payment_date) VALUES
(1, 1.50, '2023-01-15'),
(2, 2.00, '2023-02-15'),
(3, 1.75, '2023-03-15'),
(4, 3.00, '2023-04-15'),
(5, 2.50, '2023-05-15'),
(6, 1.25, '2023-06-15'),
(7, 2.75, '2023-07-15'),
(8, 3.50, '2023-08-15'),
(9, 1.00, '2023-09-15'),
(10, 1.20, '2023-10-15');

INSERT INTO Market_Data (asset_id, market_price, price_timestamp) VALUES
(1, 150.00, '2023-01-01 10:00:00'),
(2, 700.00, '2023-02-01 10:00:00'),
(3, 350.00, '2023-03-01 10:00:00'),
(4, 1000.00, '2023-04-01 10:00:00'),
(5, 400.00, '2023-05-01 10:00:00'),
(6, 250.00, '2023-06-01 10:00:00'),
(7, 3300.00, '2023-07-01 10:00:00'),
(8, 2800.00, '2023-08-01 10:00:00'),
(9, 160.00, '2023-09-01 10:00:00'),
(10, 140.00, '2023-10-01 10:00:00');


--              2.0

--  I wasn't 100% sure how I should approach these, but through
--  a lot of research and trial and error, these seem to be
--  in working order. I hope they're what you're looking for.

--              2.1     Real-Time Pricing and Trades



--              2.2a     Compliance Constraints - Margin Trading

CREATE TRIGGER check_margin_leverage
ON Trades
AFTER INSERT
AS
BEGIN
    DECLARE @debt_to_equity_ratio DECIMAL(5, 2);
    DECLARE @account_balance DECIMAL(15, 2);
    DECLARE @total_investment_value DECIMAL(15, 2);
    DECLARE @account_id INT;
    DECLARE @client_id INT;

    SELECT @account_id = account_id FROM inserted;
    SELECT @account_balance = account_balance, @client_id = client_id 
    FROM Accounts 
    WHERE account_id = @account_id;
    SELECT @total_investment_value = total_investment_value 
    FROM Clients 
    WHERE client_id = @client_id;

    SET @debt_to_equity_ratio = (@total_investment_value - @account_balance) / @account_balance;

    IF @debt_to_equity_ratio > 2
    BEGIN
        RAISERROR ('Leverage exceeds allowed limit', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;


--              2.2b     Compliance Constraints - Risk Profile

CREATE TRIGGER check_risk_profile
ON Trades
AFTER INSERT
AS
BEGIN
    DECLARE @client_risk_profile VARCHAR(10);
    DECLARE @asset_risk_level VARCHAR(10);
    DECLARE @account_id INT;
    DECLARE @asset_id INT;
    DECLARE @client_id INT;
    SELECT @account_id = account_id, @asset_id = asset_id FROM inserted;
    SELECT @client_id = client_id 
    FROM Accounts 
    WHERE account_id = @account_id;
    SELECT @client_risk_profile = risk_profile 
    FROM Clients 
    WHERE client_id = @client_id;
    SELECT @asset_risk_level = risk_level 
    FROM Assets 
    WHERE asset_id = @asset_id;

    IF @client_risk_profile = 'Low' AND @asset_risk_level = 'High'
    BEGIN
        RAISERROR ('Low-risk clients cannot invest in high-risk assets', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;

--              2.3
-- To create a History, we're going to make a few new tables.

CREATE TABLE Trades_Audit (
    audit_id INT PRIMARY KEY IDENTITY(1,1),
    trade_id INT,
    account_id INT,
    asset_id INT,
    trade_type VARCHAR(10),
    quantity INT,
    trade_price DECIMAL(10, 2),
    trade_date DATE,
    total_value DECIMAL(15, 2),
    trade_status VARCHAR(10),
    operation_type VARCHAR(10), -- 'INSERT', 'UPDATE', 'DELETE'
    operation_timestamp DATETIME DEFAULT GETDATE()
);

CREATE TABLE Transactions_Audit (
    audit_id INT PRIMARY KEY IDENTITY(1,1),
    transaction_id INT,
    account_id INT,
    transaction_type VARCHAR(10),
    amount DECIMAL(15, 2),
    transaction_date DATE,
    related_trade_id INT,
    operation_type VARCHAR(10), -- 'INSERT', 'UPDATE', 'DELETE'
    operation_timestamp DATETIME DEFAULT GETDATE()
);

--  Then, we're going to add the triggers to add items to the history.

CREATE TRIGGER trg_trades_insert
ON Trades
AFTER INSERT
AS
BEGIN
    INSERT INTO Trades_Audit (trade_id, account_id, asset_id, trade_type, quantity, trade_price, trade_date, total_value, trade_status, operation_type)
    SELECT trade_id, account_id, asset_id, trade_type, quantity, trade_price, trade_date, total_value, trade_status, 'INSERT'
    FROM inserted;
END;

CREATE TRIGGER trg_trades_update
ON Trades
AFTER UPDATE
AS
BEGIN
    INSERT INTO Trades_Audit (trade_id, account_id, asset_id, trade_type, quantity, trade_price, trade_date, total_value, trade_status, operation_type)
    SELECT trade_id, account_id, asset_id, trade_type, quantity, trade_price, trade_date, total_value, trade_status, 'UPDATE'
    FROM inserted;
END;

CREATE TRIGGER trg_trades_delete
ON Trades
AFTER DELETE
AS
BEGIN
    INSERT INTO Trades_Audit (trade_id, account_id, asset_id, trade_type, quantity, trade_price, trade_date, total_value, trade_status, operation_type)
    SELECT trade_id, account_id, asset_id, trade_type, quantity, trade_price, trade_date, total_value, trade_status, 'DELETE'
    FROM deleted;
END;

CREATE TRIGGER trg_transactions_insert
ON Transactions
AFTER INSERT
AS
BEGIN
    INSERT INTO Transactions_Audit (transaction_id, account_id, transaction_type, amount, transaction_date, related_trade_id, operation_type)
    SELECT transaction_id, account_id, transaction_type, amount, transaction_date, related_trade_id, 'INSERT'
    FROM inserted;
END;

CREATE TRIGGER trg_transactions_update
ON Transactions
AFTER UPDATE
AS
BEGIN
    INSERT INTO Transactions_Audit (transaction_id, account_id, transaction_type, amount, transaction_date, related_trade_id, operation_type)
    SELECT transaction_id, account_id, transaction_type, amount, transaction_date, related_trade_id, 'UPDATE'
    FROM inserted;
END;

CREATE TRIGGER trg_transactions_delete
ON Transactions
AFTER DELETE
AS
BEGIN
    INSERT INTO Transactions_Audit (transaction_id, account_id, transaction_type, amount, transaction_date, related_trade_id, operation_type)
    SELECT transaction_id, account_id, transaction_type, amount, transaction_date, related_trade_id, 'DELETE'
    FROM deleted;
END;


--              2.4     Risk Profile Calculation

CREATE FUNCTION dbo.GetRiskLevelValue(@risk_level VARCHAR(10))
RETURNS INT
AS
BEGIN
    RETURN CASE @risk_level
               WHEN 'Low' THEN 1
               WHEN 'Moderate' THEN 2
               WHEN 'High' THEN 3
               ELSE 0
           END;
END;

CREATE PROCEDURE dbo.UpdatePortfolioRiskProfile
AS
BEGIN
    DECLARE @portfolio_id INT;
    DECLARE @weighted_risk DECIMAL(15, 2);

    DECLARE portfolio_cursor CURSOR FOR
    SELECT portfolio_id
    FROM Portfolios;

    OPEN portfolio_cursor;
    FETCH NEXT FROM portfolio_cursor INTO @portfolio_id;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @weighted_risk = SUM(dbo.GetRiskLevelValue(a.risk_level) * ph.quantity * md.market_price) / SUM(ph.quantity * md.market_price)
        FROM Portfolio_Holdings ph
        JOIN Assets a ON ph.asset_id = a.asset_id
        JOIN Market_Data md ON ph.asset_id = md.asset_id
        WHERE ph.portfolio_id = @portfolio_id;

        UPDATE Portfolios
        SET risk_profile = CASE 
                              WHEN @weighted_risk < 1.5 THEN 'Low'
                              WHEN @weighted_risk < 2.5 THEN 'Moderate'
                              ELSE 'High'
                           END
        WHERE portfolio_id = @portfolio_id;

        FETCH NEXT FROM portfolio_cursor INTO @portfolio_id;
    END;

    CLOSE portfolio_cursor;
    DEALLOCATE portfolio_cursor;
END;

CREATE TRIGGER trg_UpdatePortfolioRiskProfile
ON Portfolio_Holdings
AFTER INSERT
AS
BEGIN
    EXEC dbo.UpdatePortfolioRiskProfile;
END;


--              2.5     Dividend Management
-- This was a massive headache to get working, but it should
-- automatically distribute dividends when a new dividend is inserted.

CREATE TRIGGER distribute_dividends
ON Dividends
AFTER INSERT
AS
BEGIN
    DECLARE @asset_id INT;
    DECLARE @dividend_amount_per_share DECIMAL(10, 2);
    DECLARE @payment_date DATE;

    DECLARE inserted_cur CURSOR FOR
    SELECT asset_id, dividend_amount_per_share, payment_date
    FROM inserted;

    OPEN inserted_cur;
    FETCH NEXT FROM inserted_cur INTO @asset_id, @dividend_amount_per_share, @payment_date;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        INSERT INTO Transactions (account_id, transaction_type, amount, transaction_date)
        SELECT p.account_id, 'Dividend', ph.quantity * @dividend_amount_per_share, @payment_date
        FROM Portfolio_Holdings ph
        JOIN Portfolios p ON ph.portfolio_id = p.portfolio_id
        WHERE ph.asset_id = @asset_id;

        UPDATE a
        SET account_balance = account_balance + ph.quantity * @dividend_amount_per_share
        FROM Accounts a
        JOIN Portfolios p ON a.account_id = p.account_id
        JOIN Portfolio_Holdings ph ON p.portfolio_id = ph.portfolio_id
        WHERE ph.asset_id = @asset_id;

        FETCH NEXT FROM inserted_cur INTO @asset_id, @dividend_amount_per_share, @payment_date;
    END;

    CLOSE inserted_cur;
    DEALLOCATE inserted_cur;
END;
GO


--              3.0     Queries

--              3.1     All assets in client's portfolio based on recent market price

SELECT 
    c.client_id,
    c.first_name,
    c.last_name,
    SUM(ph.quantity * md.market_price) AS total_current_value
FROM 
    Clients c
JOIN 
    Accounts a ON c.client_id = a.client_id
JOIN 
    Portfolios p ON a.account_id = p.account_id
JOIN 
    Portfolio_Holdings ph ON p.portfolio_id = ph.portfolio_id
JOIN 
    Market_Data md ON ph.asset_id = md.asset_id
WHERE 
    md.price_timestamp = (SELECT MAX(price_timestamp) FROM Market_Data WHERE asset_id = md.asset_id)
GROUP BY 
    c.client_id, c.first_name, c.last_name;


--              3.2     Weighted risk profile based on types of assets
--  1 is low, 2 is moderate, 3 is high.
-- the "GetRiskLevelValue" function needs to be present.

SELECT 
    p.portfolio_id,
    SUM(dbo.GetRiskLevelValue(a.risk_level) * ph.quantity * md.market_price) / SUM(ph.quantity * md.market_price) AS weighted_risk_profile
FROM 
    Portfolios p
JOIN 
    Portfolio_Holdings ph ON p.portfolio_id = ph.portfolio_id
JOIN 
    Assets a ON ph.asset_id = a.asset_id
JOIN 
    Market_Data md ON ph.asset_id = md.asset_id
WHERE 
    md.price_timestamp = (SELECT MAX(price_timestamp) FROM Market_Data WHERE asset_id = md.asset_id)
GROUP BY 
    p.portfolio_id;


--              3.3     Margin accounts where total debt exceets allowed leverage ratio

SELECT 
    a.account_id,
    a.account_balance,
    SUM(t.total_value) AS total_debt,
    SUM(t.total_value) / a.account_balance AS leverage_ratio
FROM 
    Accounts a
JOIN 
    Trades t ON a.account_id = t.account_id
WHERE 
    a.account_type = 'Margin' AND
    t.trade_status = 'Pending'
GROUP BY 
    a.account_id, a.account_balance
HAVING 
    SUM(t.total_value) / a.account_balance > 2;


--              3.4     Clients where portfolio risk exceeds personal risk

SELECT 
    c.client_id,
    c.first_name,
    c.last_name,
    c.risk_profile AS client_risk_profile,
    p.portfolio_id,
    p.risk_profile AS portfolio_risk_profile
FROM 
    Clients c
JOIN 
    Accounts a ON c.client_id = a.client_id
JOIN 
    Portfolios p ON a.account_id = p.account_id
WHERE 
    dbo.GetRiskLevelValue(p.risk_profile) > dbo.GetRiskLevelValue(c.risk_profile);
