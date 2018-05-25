Develop REST API/GraphQL computing service
Scenario:
1. A user sends a request to the service
2. Service calculates the result, saves it to storage (file,
DB)* and returns result identifier
3. Using the identifier the user gets the result of the operation.
Requirments:
- ASP.NET MVC/ASP.NET Core;
- Implement at least five operations: addition, subtraction,
multiplication, division, exponentiation (+,-,*,/,^);
- Implement operations log with different providers (file, DB)*;
- The solution should be testable (a few written tests will be
a plus)
- The solution should be flexible enough. So requirements changes
in future will not cause additional rework. Possible changes:
added new operations, added new types;
- The solution should be designed with using of best practices:
DRY, SOLID principle.
*Implementation of saving anything to the storage is unnecessary.
Stubs should be used.
