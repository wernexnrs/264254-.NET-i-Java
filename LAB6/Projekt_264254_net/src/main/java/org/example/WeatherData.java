package org.example;

import javax.persistence.*;
import java.util.List;

@Entity
@Table(name = "weather_data")
public class WeatherData {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Embedded
    private City city;

    @OneToMany(mappedBy = "weatherData", cascade = CascadeType.ALL, fetch = FetchType.LAZY, orphanRemoval = true)
    private List<DayData> list;

    public int getId() { return id; }
    public List<DayData> getList() { return list; }
    public City getCity() { return city; }
}


@Embeddable
class City {
    @Column(name = "city_name", nullable = false)
    private String name;

    public String getName() { return name; }
}

@Entity
@Table(name = "day_data")
class DayData {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Column(name = "timestamp")
    private long dt;

    @Embedded
    private Temp temp;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "weather_data_id")
    private WeatherData weatherData;
    public long getDt() { return dt; }
    public Temp getTemp() { return temp; }
    public void setWeatherData(WeatherData weatherData) { this.weatherData = weatherData; }
}

@Embeddable
class Temp {
    @Column(name = "temperature_day")
    private double day;
    @Column(name = "temperature_min")
    private double min;
    @Column(name = "temperature_max")
    private double max;
    @Column(name = "temperature_night")
    private double night;
    @Column(name = "temperature_eve")
    private double eve;
    @Column(name = "temperature_morn")
    private double morn;

    public double getDay() { return day-273.15; }
    public double getMin() { return min-273.15; }
    public double getMax() { return max-273.15; }
    public double getNight() { return night-273.15; }
    public double getEve() { return eve-273.15; }
    public double getMorn() { return morn-273.15; }
}
