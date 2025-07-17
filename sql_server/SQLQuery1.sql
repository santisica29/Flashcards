create database FlashcardsDb
use FlashcardsDb;

create table Stacks (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) UNIQUE NOT NULL,
	)

CREATE TABLE FLASHCARDS(
	Id int primary key identity(1,1) not null,
	Front varchar(100),
	Back varchar(100),
	StackId int,

	CONSTRAINT FK_Flashcards_Stacks Foreign key (StackID) 
		REFERENCES Stacks(Id) 
		ON DELETE CASCADE
)
