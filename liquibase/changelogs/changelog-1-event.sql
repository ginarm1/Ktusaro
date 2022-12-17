--changeset user:1
--comment: Create event table
CREATE TABLE public.event (
	id serial PRIMARY KEY NOT NULL,
	name varchar(250) NOT NULL,
	startDate DATE NOT NULL,
	endDate DATE NOT NULL,
	location varchar(100),
	description text NOT NULL,
	has_coordinator boolean NOT NULL,
	coordinatorName varchar(50) NOT NULL,
	coordinatorSurname varchar(50) NOT NULL,
	isCanceled boolean NOT NULL,
	isLive boolean NOT NULL,
	plannedPeopleCount int NOT NULL,
	showedPeopleCount int,
	eventType int NOT NULL
);

--changeset user:2
--comment: Populated event table
INSERT INTO public.event
	(name,startDate,endDate,location,description,has_coordinator,coordinatorName,coordinatorSurname,isCanceled,isLive,plannedPeopleCount,showedPeopleCount,eventType)
VALUES 
	('GrandŽIK 22', '2022-02-25','2022-02-26','Guostos sodyba','laisvas tekstas', true, 'Gintaras','Armonaitis',false,true,50,50,1),
    ('Laisvėje augam!', '2022-01-13', '2022-01-13', 'KTU Santakos slėnis', 'Renginys skirtas paminėti Laisvės Gynėjų dieną ir skatinti studentus įsitraukti į pilietišką veiklą. ', true, 'Mindaugas ', 'Rimskis',false, true,300, 200,2);
