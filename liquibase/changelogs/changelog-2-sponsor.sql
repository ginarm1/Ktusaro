--changeset user:1
--comment: Create sponsor table
CREATE TABLE public.sponsor (
	id serial PRIMARY KEY NOT NULL,
	name varchar(250) NOT NULL,
	companyType int NOT NULL
);

--changeset user:2
--comment: Populated sponsor table
INSERT INTO public.sponsor
	(name,companyType)
VALUES 
	('Red Bull', 1);
