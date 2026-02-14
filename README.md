
---

## Test Coverage

The automated test suite covers:

- User Login
- Create task (positive scenario)
- Create task without name (negative validation scenario)
- Edit existing task
- Move task between states
- Delete task

---

## Design Principles

- Separation of concerns  
- Page Object Model  
- Reusable components  
- Clean test methods  
- Randomized test data  
- Maintainable architecture  

---

## How to Run

1. Clone the repository
2. Open the solution in Visual Studio
3. Restore NuGet packages
4. Build the project
5. Run tests via Test Explorer

---

## Notes

- The test environment is a public demo application.
- If the application returns HTTP 502, it indicates an environment availability issue, not a test failure.
- The project was originally based on a practical automation exam assignment and later refactored to demonstrate production-ready automation structure.

---

## Author

Automation QA portfolio project  
Built to demonstrate UI test automation best practices.
