INSERT INTO [Jedis] ([Id], [Nom], [IsSith], [Image]) VALUES 
(1, 'Obi Wan Kenobi', 0, 'img/default.png'),
(2, 'Yoda', 0, 'img/default.png'),
(3, 'Mace Windu', 0, 'img/default.png'),
(4, 'Aayla Secura', 0, 'img/default.png'),
(5, 'Shaak Ti', 0, 'img/default.png'),
(6, 'Plo Koon', 0, 'img/default.png'),
(7, 'Kit Fist', 0, 'img/default.png'),
(8, 'Qui Gon Jinn', 0, 'img/default.png'),
(9, 'Luke Skywalker', 0, 'img/default.png'),
(10, 'Anakin Skywalker', 1, 'img/default.png'),
(11, 'Rey Skywalker', 0, 'img/default.png'),
(12, 'Dark Sidious', 1, 'img/default.png'),
(13, 'Dark Vador', 1, 'img/default.png'),
(14, 'Grivious', 1, 'img/default.png'),
(15, 'Dark Maul', 1, 'img/default.png'),
(16, 'Dooku', 1, 'img/default.png'),
(17, 'Kylo Ren', 1, 'img/default.png'),
(18, 'Dark Revan', 1, 'img/default.png')

INSERT INTO [Stades] ([Id], [Nom], [NbPlaces], [Image]) VALUES 
(1, 'Coruscant', 1000000,'img/planet.png'),
(2, 'Kamino',100000,'img/planet.png'),
(3, 'Naboo',10000,'img/planet.png'),
(4, 'Tatooine',666,'img/planet.png'),
(5, 'Dagobah',4,'img/planet.png')

INSERT INTO [Caracteristiques] ([Id], [Nom], [Def], [Type], [Valeur]) VALUES
(1, 'Le réveil de la force', 'Perception', 'Jedi', 30),
(2, 'Esprit obscurci', 'Perception', 'Jedi', 40)

INSERT INTO [JediCarac] ([IdJedi], [IdCarac]) VALUES
(1, 30),
(1, 35)