var slideno = 1;


sslides(slideno);

function changecarousel(n) {
  sslides(slideno += n);
}






function sslides(n) {
  var x;
  var carousel = document.getElementsByClassName("carousel");
  if (n > carousel.length) { slideno = 1 }
  if (n < 1) { slideno = carousel.length }
  for (x = 0; x < carousel.length; x++) {
    carousel[x].style.display = "none";
  }
  carousel[slideno - 1].style.display = "block";
}

