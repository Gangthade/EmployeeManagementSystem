CREATE PROCEDURE InsertEmployee
    @Id INT,
    @Name VARCHAR(255),
    @Age INT,
    @Salary DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO Employee (Id, Name, Age, Salary) VALUES (@Id, @Name, @Age, @Salary)
END

CREATE PROCEDURE UpdateEmployee
    @Id INT,
    @Name VARCHAR(255),
    @Age INT,
    @Salary DECIMAL(18, 2)
AS
BEGIN
    UPDATE Employee SET Name = @Name, Age = @Age, Salary = @Salary WHERE Id = @Id
END
