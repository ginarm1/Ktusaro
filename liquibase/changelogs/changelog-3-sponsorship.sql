--changeset user:1
--comment: Create sponsorship table
CREATE TABLE public.sponsorship (
	id serial PRIMARY KEY NOT NULL,
	description text NOT NULL,
	quantity int NOT NULL,
	cost decimal NOT NULL,
    sponsor_id int NOT NULL,
    event_id int NOT NULL
);

--changeset user:2
--comment: Sponsorship table realation with sponsor table
ALTER TABLE public.sponsorship
    ADD CONSTRAINT fk_sponsor
        FOREIGN KEY(sponsor_id) 
            REFERENCES "sponsor" (id);

--changeset user:3
--comment: Sponsorship table realation with event table
ALTER TABLE public.sponsorship
    ADD CONSTRAINT fk_event
        FOREIGN KEY(event_id) 
            REFERENCES "event" (id);

--changeset user:4
--comment: Populated sponsorship table
INSERT INTO public.sponsorship
	(description,quantity,cost,sponsor_id,event_id)
VALUES 
	('Dvi dėžės skardinių',200,255.20,1,2);