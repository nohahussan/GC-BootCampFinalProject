
function audioPlay()
{   
    $.post("/Home/English", { Text:$("#Text").val()});
    $("#pop").show();
}
