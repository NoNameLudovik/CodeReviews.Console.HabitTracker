# Habit Logger

**Habit Logger** is a simple console application built with **C#** and **SQLite** to help you track your daily water intake.  
It lets you add, view, update, and delete your records easily from the terminal.

---

## Features

- **Automatic Database Setup**  
  - Creates a `habit-Logger.db` SQLite database on the first run (if it doesn’t exist).  
  - Initializes a `drinking_water` table to store all records.  

- **CRUD Operations**  
  - **View All Records** — Displays all saved entries with ID, date, and quantity.  
  - **Add Record** — Insert a new entry with a date and amount of water.  
  - **Edit Record** — Edit the date or quantity of an existing entry.  
  - **Delete Record** — Remove a record by its ID.  

- **Error Handling & Validation**  
  - Validates date format (`dd-MM-yy`) and ensures quantity is a whole number.  
  - Handles invalid IDs when updating or deleting records.  
  - Uses `try/catch` blocks to prevent the app from crashing. 

---

## How to Use

1. **Run the Application**  
   Launch the console app — it will automatically create the database and table if need.  

2. **Main Menu**

	You will see the following option:

		1. Add Record

		2. Edit Record

		3. Delete Record

		4. All Records

		5. Exit 

3. **Add a Record**  
- Select option `1`.  
- Enter the date (`dd-MM-yy`).  
- Enter the number of glasses (integer).  

4.  **Update a Record**  
- Select `2`.  
- Enter the record `Id`.  
- Provide a new date and/or quantity.

5.   

6.  **View All Records**  
- Select `4` to see all entries.  

7. **Exit**  
- Enter `5` to quit the application.  



