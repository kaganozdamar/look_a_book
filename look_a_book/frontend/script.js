function truncate(str, no_words) {
    return str = (str.split(" ").splice(0,no_words).join(" ") + "...");
}

for (let i = 1; i < 9; i++) {
    i = i.toString();
    var text_id = "writer-short-info-" + i;
    text = document.getElementById(text_id).innerHTML;
    text = truncate(text,15);
    document.getElementById(text_id).innerHTML = text;
}













