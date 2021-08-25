
var data = [];
var nam, count;
var x = 1;

$.ajax({
    url: '/Home/Datafromdb'
}).done(function (data1) {
    $.each(data1, function (i, val) {
        $.each(val, function (key, value) {
            if (key.valueOf().match("name")) {
                nam = value.valueOf();
            }
            if (key.valueOf().match("countofsell")) {
                count = value.valueOf();
                
            }
        });
        data.unshift({ name: nam, score: count });
    });
    var margin = { top: 20, right: 20, bottom: 30, left: 40 },
        width = 960 - margin.left - margin.right,
        height = 500 - margin.top - margin.bottom;

    // set the ranges
    var y = d3.scaleBand()
        .range([height, 0])
        .padding(0.1);

    var x = d3.scaleLinear()
        .range([0, width]);

    // append the svg object to the body of the page
    // append a 'group' element to 'svg'
    // moves the 'group' element to the top left margin
    var svg = d3.select(".names").append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g")
        .attr("transform",
            "translate(" + margin.left + "," + margin.top + ")");

    // format the data
    data.forEach(function (d) {
        d.score = +d.score;
    });

    // Scale the range of the data in the domains
    x.domain([0, d3.max(data, function (d) { return d.score; })])
    y.domain(data.map(function (d) { return d.name; }));
    //y.domain([0, d3.max(data, function(d) { return d.sales; })]);

    // append the rectangles for the bar chart
    svg.selectAll(".bar")
        .data(data)
        .enter().append("rect")
        .attr("class", "bar")
        //.attr("x", function(d) { return x(d.sales); })
        .attr("width", function (d) { return x(d.score); })
        .attr("y", function (d) { return y(d.name); })
        .attr("height", y.bandwidth());

    // add the x Axis
    svg.append("g")
        .attr("transform", "translate(0," + height + ")")
        .call(d3.axisBottom(x));

    // add the y Axis
    svg.append("g")
        .call(d3.axisLeft(y));
});


