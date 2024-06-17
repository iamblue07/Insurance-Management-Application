The application contains:

    Database connection to localdb using SQL Server Object Explorer to store all clients and their insurances.
    Users connection menu: users are also stored in localdb.
    Menu for visualizing all clients and their insurances: their data, as well as insurances, are visualized using a TreeView object.
    Menu for searching a client and visualizing their data using a textbox, as well as buttons to print their data or save it as an XML.
    Menu for modifying a client's data. The following information about a client can be changed: name, salary, email, phone number.
    Using the same menu, the application can also:
        Add a new insurance: the insurance's attributes are as follows: type, description, value, start date, end date.
        Change the following information about a client's insurance: value, start date, end date.
        Delete one of the insurances.
    Menu for adding a new client, whose attributes are: name, age, sex, salary, email, phone number.
    Menu for visualizing different charts. These charts can be saved to clipboard for later use:
        Line chart showing the age-to-salary ratio.
        Pie chart showing the total value of each client's insurance values.
        Bar chart showing the total value of each client's insurance values.
    Menu strip for saving the entire data as a file, as well as loading data from a file.

Other nice-to-have features:

    In the menu for visualizing all clients, using right-click, a menu with different shortcuts appears. These shortcuts are as follows:
        Shortcut to modifying a client's data.
            Using this on a client's name will open the menu for modifying data and autocomplete their name.
            Using this on a client's insurance will open the menu and autocomplete their name and said insurance's data.
        Shortcut to printing a client's data.
        Shortcut to saving a client's data as XML.
        Shortcut for deleting a client's data.
            Using this on a client's name will allow the removal of the client from the database.
            Using this on a client's insurance will delete only the insurance from the database.
    Multiple validations to prevent misinputs such as using letters for age or typing an incorrect email.
    Field checks to prevent inserting NULL data using Error Provider.
    Clear, pleasant-to-the-eye design using vibrant images and colors.
