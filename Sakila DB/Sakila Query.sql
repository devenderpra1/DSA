Select *
from film f
left join film_actor fa on film_id


EXEC sp_help actor;

EXEC sp_help film_actor;


--Linking two schema one to many
Select *
From film f
left Join film_actor fa on f.film_id = fa.film_id
left join actor act on act.actor_id = fa.actor_id



-- Grouping based on Genre
--Select f.release_year COUNT(fa.actor.id)
--From film f
--left Join film_actor fa on f.film_id = fa.film_id
--left join actor act on act.actor_id = fa.actor_id
--Group By f.release_year

SELECT *
FROM film f
LEFT JOIN film_actor fa ON f.film_id = fa.film_id
left join actor act on act.actor_id = fa.actor_id


Select f.film_id , COUNT(actor_id)
From film f
left join film_actor fa ON f.film_id = fa.film_id
Group BY f.film_id