package org.example;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;
import org.hibernate.query.Query;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.List;

public class HibernateUtil {
    private static final Logger logger = LoggerFactory.getLogger(HibernateUtil.class);
    private static final SessionFactory sessionFactory;

    static {
        Configuration configuration = new Configuration().configure();
        sessionFactory = configuration.buildSessionFactory();
    }

    public static SessionFactory getSessionFactory() {
        return sessionFactory;
    }

    public static List<WeatherData> getAllWeatherDataForCity(String cityName) {
        List<WeatherData> weatherData;

        try (Session session = sessionFactory.openSession()) {
            Query<WeatherData> query = session.createQuery(
                    "select distinct wd from WeatherData wd join fetch wd.list where wd.city.name = :cityName", WeatherData.class);
            query.setParameter("cityName", cityName);
            weatherData = query.getResultList();
            logger.info("Data retrieved for {}: {} records.", cityName, weatherData.size());
        } catch (Exception e) {
            logger.error("Error retrieving data for city: {}", cityName, e);
            weatherData = null;
        }
        return weatherData;
    }
}
