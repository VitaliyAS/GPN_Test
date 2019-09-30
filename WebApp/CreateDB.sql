-- Role: "GPN_test"
-- DROP ROLE "GPN_test";

CREATE ROLE "GPN_test" WITH
  LOGIN
  NOSUPERUSER
  INHERIT
  CREATEDB
  NOCREATEROLE
  NOREPLICATION
  CONNECTION LIMIT -1
  PASSWORD '1';

-- Database: GPN_test

-- DROP DATABASE "GPN_test";

CREATE DATABASE "GPN_test"
    WITH 
    OWNER = "GPN_test"
    ENCODING = 'UTF8'
    LC_COLLATE = 'Russian_Russia.1251'
    LC_CTYPE = 'Russian_Russia.1251'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

-- Table: public.company

-- DROP TABLE public.company;

CREATE TABLE public.company
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name character varying(100) COLLATE pg_catalog."default" NOT NULL,
    boss character varying(100) COLLATE pg_catalog."default",
    CONSTRAINT company_pkey PRIMARY KEY ("Id")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.company
    OWNER to "GPN_test";

-- Table: public.department

-- DROP TABLE public.department;

CREATE TABLE public.department
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Name" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "Boss" character varying(100) COLLATE pg_catalog."default",
    "CompanyId" integer,
    CONSTRAINT department_pkey PRIMARY KEY ("Id"),
    CONSTRAINT department_company_id_fkey FOREIGN KEY ("CompanyId")
        REFERENCES public.company ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

-- Table: public.field

-- DROP TABLE public.field;

CREATE TABLE public.field
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Name" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "Company_id" integer,
    "Reserve" double precision,
    CONSTRAINT field_pkey PRIMARY KEY ("Id"),
    CONSTRAINT field_company_id_fkey FOREIGN KEY ("Company_id")
        REFERENCES public.company ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE RESTRICT
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.field
    OWNER to "GPN_test";

-- Table: public.borehole

-- DROP TABLE public.borehole;

CREATE TABLE public.borehole
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Name" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "CompanyId" integer,
    "DepartmentId" integer,
    "FieldId" integer,
    "Depth" double precision,
    CONSTRAINT borehole_pkey PRIMARY KEY ("Id"),
    CONSTRAINT borehole_company_id_fkey FOREIGN KEY ("CompanyId")
        REFERENCES public.company ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE RESTRICT,
    CONSTRAINT borehole_department_id_fkey FOREIGN KEY ("DepartmentId")
        REFERENCES public.company ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE RESTRICT,
    CONSTRAINT borehole_field_id_fkey FOREIGN KEY ("FieldId")
        REFERENCES public.company ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE RESTRICT
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.borehole
    OWNER to "GPN_test";
