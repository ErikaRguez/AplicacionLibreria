CREATE DATABASE Libreria

USE Libreria 
CREATE TABLE Autor (
    id INT  PRIMARY KEY,
    name VARCHAR(255) NOT NULL
    );

CREATE TABLE Libros (
    id INT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    chapters INT NOT NULL,
    pages INT NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    author_id int NOT NULL,
    FOREIGN KEY (author_id) REFERENCES Autor(id)
);

INSERT INTO Autor (id, name) VALUES
(1, 'J.K. Rolling'),
(2, 'J.R.R. Tolkien'),
(3, 'Agatha Christie');


INSERT INTO Libros (id, title, chapters, pages, price, author_id) VALUES
(1, 'Harry Potter', 3, 260, 450, 1),
(2, 'El señor de los Anillos', 5, 320, 650, 2),
(3, 'Murder on the Orient Express', 12, 256, 19.99, 3);