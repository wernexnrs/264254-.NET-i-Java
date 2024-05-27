package org.example;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.axis.*;
import javax.swing.*;
import java.awt.*;
import java.text.SimpleDateFormat;
import java.util.List;
import org.jfree.chart.plot.XYPlot;
import org.jfree.chart.ui.RectangleInsets;
import org.jfree.data.time.TimeSeries;
import org.jfree.data.time.TimeSeriesCollection;
import org.jfree.chart.axis.DateAxis;
import org.jfree.data.time.Hour;

public class GUI {
    private static final Font TITLE_FONT = new Font("Serif", Font.BOLD, 24);
    private static final Font LABEL_FONT = new Font("Serif", Font.PLAIN, 16);
    private static final Font TICK_LABEL_FONT = new Font("Serif", Font.PLAIN, 14);

    private JLabel title;
    private JList<String> cityList;
    private JList<String> tempTypeList;
    private ChartPanel chartPanel;
    private JFrame frame;

    public GUI() {
        frame = new JFrame("Weather Data");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(1920, 1080);
        frame.setLayout(new BorderLayout());

        //Tytuł
        title = new JLabel("City: Wrocław", SwingConstants.CENTER);
        title.setFont(TITLE_FONT);
        frame.add(title, BorderLayout.NORTH);

        //Wykres
        List<WeatherData> weatherData = HibernateUtil.getAllWeatherDataForCity("Wrocław");
        JFreeChart lineChart = createChart(weatherData,"Day");
        chartPanel = new ChartPanel(lineChart);
        frame.add(chartPanel, BorderLayout.CENTER);

        initializeSidePanel();

        frame.setVisible(true);
    }

    private void initializeSidePanel() {
        JPanel sidePanel = new JPanel(new FlowLayout(FlowLayout.RIGHT));
        DefaultListModel<String> listModel = new DefaultListModel<>();

        listModel.addElement("Wrocław");
        listModel.addElement("Berlin");
        listModel.addElement("Gdańsk");
        listModel.addElement("Warszawa");

        cityList = new JList<>(listModel);
        cityList.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        cityList.setSelectedIndex(0);
        cityList.setVisibleRowCount(4);
        cityList.addListSelectionListener(e -> {
            if (!e.getValueIsAdjusting()) {
                String selectedCity = cityList.getSelectedValue();
                updateWeatherData(selectedCity,"Day");
            }
        });

        JScrollPane listScrollPane = new JScrollPane(cityList);
        listScrollPane.setPreferredSize(new Dimension(200, 100));
        sidePanel.add(listScrollPane);
        frame.add(sidePanel, BorderLayout.EAST);

        DefaultListModel<String> tempTypeListModel = new DefaultListModel<>();
        tempTypeListModel.addElement("Day");
        tempTypeListModel.addElement("Min");
        tempTypeListModel.addElement("Max");
        tempTypeListModel.addElement("Night");
        tempTypeListModel.addElement("Eve");
        tempTypeListModel.addElement("Morn");

        tempTypeList = new JList<>(tempTypeListModel);
        tempTypeList.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        tempTypeList.setSelectedIndex(0);
        tempTypeList.setVisibleRowCount(5);
        tempTypeList.addListSelectionListener(e -> {
            if (!e.getValueIsAdjusting()) {
                updateWeatherData(cityList.getSelectedValue(), tempTypeList.getSelectedValue());
            }
        });

        JScrollPane tempTypeListScrollPane = new JScrollPane(tempTypeList);
        tempTypeListScrollPane.setPreferredSize(new Dimension(200, 100));
        sidePanel.add(tempTypeListScrollPane);
        frame.add(sidePanel, BorderLayout.EAST);
    }

    private void updateWeatherData(String cityName, String tempType) {
        title.setText("City: " + cityName);

        if (cityName == "Berlin") {
            cityName = "Mitte";
        }
        List<WeatherData> weatherData = HibernateUtil.getAllWeatherDataForCity(cityName);
        JFreeChart newChart = createChart(weatherData,tempType);
        chartPanel.setChart(newChart);
    }

    private JFreeChart createChart(List<WeatherData> weatherData, String tempType) {
        TimeSeriesCollection dataset = getTimeSeriesCollection(weatherData, tempType);

        String title = "Temperature ("+tempType+") Over Time";

        JFreeChart lineChart = ChartFactory.createTimeSeriesChart(
                title, "Date", "Temperature (Celsius)",
                dataset, true, true, false);
        configurePlot(lineChart);
        return lineChart;
    }

    private TimeSeriesCollection getTimeSeriesCollection(List<WeatherData> weatherData, String tempType) {
        TimeSeries series = new TimeSeries("Temperature");
        for (WeatherData data : weatherData) {
            for (DayData day : data.getList()) {
                double tempCelsius = switch (tempType) {
                    case "Min" -> day.getTemp().getMin();
                    case "Max" -> day.getTemp().getMax();
                    case "Night" -> day.getTemp().getNight();
                    case "Eve" -> day.getTemp().getEve();
                    case "Morn" -> day.getTemp().getMorn();
                    default -> day.getTemp().getDay();
                };
                java.util.Date time = new java.util.Date((long) day.getDt() * 1000);
                Hour chartHour = new Hour(time);
                series.addOrUpdate(chartHour, tempCelsius);
            }
        }
        TimeSeriesCollection dataset = new TimeSeriesCollection();
        dataset.addSeries(series);
        return dataset;
    }

    private void configurePlot(JFreeChart chart) {
        XYPlot plot = chart.getXYPlot();
        DateAxis domainAxis = new DateAxis("Date");
        domainAxis.setDateFormatOverride(new SimpleDateFormat("dd-MM"));
        domainAxis.setTickUnit(new DateTickUnit(DateTickUnitType.DAY, 1));
        domainAxis.setVerticalTickLabels(false);
        domainAxis.setLabelFont(LABEL_FONT);
        domainAxis.setTickLabelFont(TICK_LABEL_FONT);
        domainAxis.setTickLabelPaint(Color.BLACK);

        domainAxis.setTickLabelInsets(new RectangleInsets(5, 5, 5, 5));

        plot.setDomainAxis(domainAxis);

        ValueAxis rangeAxis = plot.getRangeAxis();
        rangeAxis.setLabelFont(LABEL_FONT);
        rangeAxis.setTickLabelFont(TICK_LABEL_FONT);

        chart.getTitle().setFont(TITLE_FONT);

        plot.setDomainGridlinesVisible(true);
        plot.setDomainGridlinePaint(Color.GRAY);
    }

    public static void main(String[] args) {
        SaveJSONtoDatabase SaveJSONtoDatabase = new SaveJSONtoDatabase();
        SaveJSONtoDatabase.saveData();
        SwingUtilities.invokeLater(GUI::new);
    }
}
