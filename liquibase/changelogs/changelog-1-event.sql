--changeset user:1
--comment: Create event table
CREATE TABLE public.event (
	id serial PRIMARY KEY NOT NULL,
	name varchar(250) NOT NULL,
	start_date DATE NOT NULL,
	end_date DATE NOT NULL,
	location varchar(100),
	description text NOT NULL,
	has_coordinator boolean NOT NULL,
	coordinator_name varchar(50) NOT NULL,
	coordinator_surname varchar(50) NOT NULL,
	is_canceled boolean NOT NULL,
	is_live boolean NOT NULL,
	planned_people_count int NOT NULL,
	showed_people_count int,
	event_type int NOT NULL
);

--changeset user:2
--comment: Populated event table
INSERT INTO public.event
	(name,start_date,end_date,location,description,has_coordinator,coordinator_name,coordinator_surname,is_canceled,is_live,planned_people_count,showed_people_count,event_type)
VALUES 
	('GrandŽIK 22', '2022-02-25','2022-02-26','Guostos sodyba','laisvas tekstas', true, 'Gintaras','Armonaitis',false,true,50,50,1),
    ('Laisvėje augam!', '2022-01-13', '2022-01-13', 'KTU Santakos slėnis', 'Renginys skirtas paminėti Laisvės Gynėjų dieną ir skatinti studentus įsitraukti į pilietišką veiklą. ', true, 'Mindaugas ', 'Rimskis',false, true,300, 200,2);
