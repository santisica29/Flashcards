using Flashcards.Data;
using Flashcards.View;

var db = new DatabaseManager();
db.ConnectToDatabase();

var ui = new UserInterface();
ui.MainMenu();
