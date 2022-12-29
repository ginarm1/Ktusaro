--changeset user:1
--comment: Create user table
CREATE TABLE public.user (
	id serial PRIMARY KEY NOT NULL,
	email varchar(100) UNIQUE NOT NULL,
	password_hash bytea NOT NULL,
	password_salt bytea NOT NULL,
	name varchar(100) NOT NULL,
	surname varchar(100) NOT NULL,
	role int NOT NULL,
	representative int NOT NULL
);

--changeset user:2
--comment: Populated user table
INSERT INTO public.user
	(email,password_hash,password_salt,name,surname,role,representative)
VALUES 
	('gintaras@gmail.com','TruYzhSd8eb7QJsiwCCGoU1trk8Rrjlu/dC6qcrfNOUEjkXZvILyMfV33Om7VdYRgObTsS4bK/Z8yk6rEJ89lw==',
	'qXT2E2+c6aUV4eKJ/FMwx1XjUj9WikA8Ev6ahDdRj0OrlPqRdcYPqx2kJHqB98CyHnvVMpGf+XaZ5AQpba3+RgYgWzgJXt36mEtc484nfHsrT2+n7IQKsue5a5iBW1Khmw+UfqhBWv3zd2JKX8lFqIYUdWpSf1mbDhLgaQKSzWo=',
	'Darius','Darauskas',2,1);

--changeset user:3
--comment: Event table realation with user table
ALTER TABLE public.event
    ADD CONSTRAINT fk_user
        FOREIGN KEY(user_id) 
            REFERENCES "user" (id)
                ON DELETE CASCADE;