function truncate(str, no_words) {
    return str = (str.split(" ").splice(0,no_words).join(" ") + "...");
}

text = document.getElementById("writer-who").innerHTML;
text = truncate(text,100);
document.getElementById("writer-who").innerHTML = text; 