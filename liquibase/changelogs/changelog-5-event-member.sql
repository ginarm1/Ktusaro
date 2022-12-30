-- "event member" is short for "event team member"
--changeset user:1
--comment: Create even member table
CREATE TABLE public.event_member (
	id serial PRIMARY KEY NOT NULL,
	is_event_coordinator boolean NOT NULL,
	event_id int NOT NULL,
	user_id int NOT NULL
);

--changeset user:2
--comment: Populated even member table
INSERT INTO public.event_member
	(is_event_coordinator,event_id,user_id)
VALUES 
	(true,1,1);

--changeset user:3
--comment: Even member table realation with event table
ALTER TABLE public.event_member
    ADD CONSTRAINT fk_event
        FOREIGN KEY(event_id) 
            REFERENCES "event" (id)
                ON DELETE CASCADE;

--changeset user:4
--comment: Even member table realation with user table
ALTER TABLE public.event_member
    ADD CONSTRAINT fk_user
        FOREIGN KEY(user_id) 
            REFERENCES "user" (id)
                ON DELETE CASCADE;