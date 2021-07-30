function getAjax(url, data) {    return $.ajax(url, {        method: "GET",        data: data    });}async function getmatchingames(matchingStr) {    var matchinGames = await getAjax('/Games/Gamesfilter', { matchingStr: matchingStr });    return matchinGames;}

$("#serachbtn").click(function () {    var matchingStr = $("#query").val();    getmatchingames(matchingStr);
});