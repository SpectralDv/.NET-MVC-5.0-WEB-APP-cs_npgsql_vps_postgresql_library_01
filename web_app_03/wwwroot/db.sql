

#"insert into book(Name,Author,Price) values('Name1','Author1','10')";
#("INSERT INTO foo(name, description, 1)", db.getConnection());

CREATE TABLE tb(name text,description text,status int);

#CREATE FUNCTION fi(text,text,int) LANGUAGE plpgsql;
#CREATE FUNCTION fi(text,text,int) RETURNS integer AS' BEGIN END LANGUAGE plpgsql;
#CREATE FUNCTION fi(text,text,int) RETURNS integer AS' BEGIN INSERT INTO tb VALUES ($1,$2,$3) END LANGUAGE plpgsql;
#CREATE FUNCTION fi(text,text,int) RETURNS integer AS' INSERT INTO tb VALUES ($1,$2,$3) LANGUAGE plpgsql;
CREATE FUNCTION fi(text,text,int) 
        INSERT INTO tb VALUES ($1,$2,$3)


#$$ LANGUAGE SQL;



