--changeset user:1
--comment: Create event table
CREATE TABLE public.event (
	id serial PRIMARY KEY NOT NULL,
	title varchar(250) NOT NULL,
	location varchar(100),
	description text NOT NULL,
	has_coordinator boolean NOT NULL,
	coordinatorName varchar(50) NOT NULL,
	coordinatorSurname varchar(50) NOT NULL,
	isCanceled boolean NOT NULL,
	isLive boolean NOT NULL,
	plannedPeopleCount int NOT NULL,
	showedPeopleCount int
);


--changeset user:2
--comment: Populated event table
INSERT INTO public.event 
	(title,location,description,has_coordinator,coordinatorName,coordinatorSurname,isCanceled,isLive,plannedPeopleCount,showedPeopleCount)
VALUES 
	('GrandŽIK 22', 'Guostos sodyba','laisvas tekstas', true, 'Gintaras','Armonaitis',false,true,50,50);