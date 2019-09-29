	create table public."COMPANY"
	(
		"ID" integer GENERATED ALWAYS AS IDENTITY,
		"Name" character varying(100) NOT NULL,
		"Boss" character varying(100),
		PRIMARY KEY ("ID")
	);

	create table public."DEPARTMENT"
	(
		"ID" integer GENERATED ALWAYS AS IDENTITY,
		"Name" character varying(100) NOT NULL,
		"Boss" character varying(100),
		"Company_ID" integer REFERENCES public."COMPANY"("ID"),
		PRIMARY KEY ("ID")
	);

	create table public."FIELD"
	(
		"ID" integer GENERATED ALWAYS AS IDENTITY,
		"Name" character varying(100) NOT NULL,
		"Company_ID" integer REFERENCES public."COMPANY"("ID") ON DELETE RESTRICT,
		"Reserve" float8,
		PRIMARY KEY ("ID")
	);

	create table public."BOREHOLE"
	(
		"ID" int GENERATED ALWAYS AS IDENTITY,
		"Name" character varying(100) NOT NULL,
		"Company_ID" integer REFERENCES public."COMPANY"("ID") ON DELETE RESTRICT,
		"Department_ID" integer REFERENCES public."COMPANY"("ID") ON DELETE RESTRICT,
		"Field_ID" integer REFERENCES public."COMPANY"("ID") ON DELETE RESTRICT,	
		"Depth" float8,
		PRIMARY KEY ("ID")
	);