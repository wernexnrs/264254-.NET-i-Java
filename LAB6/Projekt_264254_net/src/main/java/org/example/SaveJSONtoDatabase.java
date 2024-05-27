package org.example;

import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.net.http.HttpResponse.BodyHandlers;
import java.nio.charset.StandardCharsets;
import java.net.URLEncoder;
import java.util.HashMap;
import java.util.Map;
import com.google.gson.Gson;
import org.hibernate.Session;
import org.hibernate.Transaction;

public class SaveJSONtoDatabase {
    private static Map<String, String[]> cities = new HashMap<>();

    static {
        cities.put("Wrocław", new String[]{"51.107883", "17.038538"});
        cities.put("Warszawa", new String[]{"52.237049", "21.017532"}); // warszawa, warsaw
        cities.put("Berlin", new String[]{"52.520008", "13.404954"}); //mitte
        cities.put("Gdańsk", new String[]{"54.372158", "18.638306"});
    }

    public static String fetchJson(String uri) throws URISyntaxException, IOException, InterruptedException {
        HttpResponse<String> response;
        try (HttpClient client = HttpClient.newHttpClient()) {
            HttpRequest request = HttpRequest.newBuilder().uri(new URI(uri)).build();
            response = client.send(request, BodyHandlers.ofString());
        }

        return response.body();
    }

    private String constructUrl(String latitude, String longitude) {
        String API_KEY = "196db3870975458e76528bce29610b2c";
        String encodedParams = String.format(
                "?lat=%s&lon=%s&lang=PL&&appid=%s",
                URLEncoder.encode(latitude, StandardCharsets.UTF_8),
                URLEncoder.encode(longitude, StandardCharsets.UTF_8),
                URLEncoder.encode(API_KEY, StandardCharsets.UTF_8)
        );
        String BASE_URL = "https://pro.openweathermap.org/data/2.5/forecast/climate";
        return BASE_URL + encodedParams;
    }


    public void saveData() {
        cities.forEach((cityName, coords) -> {
            String finalUrl = constructUrl(coords[0], coords[1]);
            System.out.println("Fetching data for: " + cityName);

            String json = null;
            try {
                json = fetchJson(finalUrl);
            } catch (URISyntaxException | IOException | InterruptedException e) {
                throw new RuntimeException(e);
            }

            Gson gson = new Gson();
            WeatherData weatherData = gson.fromJson(json, WeatherData.class);

            for (DayData dayData : weatherData.getList()) {
                dayData.setWeatherData(weatherData);
            }

            Transaction transaction = null;
            try (Session session = HibernateUtil.getSessionFactory().openSession()) {
                transaction = session.beginTransaction();
                session.save(weatherData);
                transaction.commit();
                System.out.println("Data saved successfully for: " + cityName);
            } catch (Exception e) {
                if (transaction != null) {
                    transaction.rollback();
                }
                e.printStackTrace();
            }
        });
    }
}