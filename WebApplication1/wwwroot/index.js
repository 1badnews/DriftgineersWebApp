function scrollToElementWithId(Id) {
  var scrolling = document.getElementById(Id);
  scrolling.scrollIntoView({ behavior: "smooth", block: "center", "inline": "center"});
} 
/* customizations* */
let light = document.querySelector('.light');
let dark = document.querySelector('.dark');
let ControlHeader = document.querySelector('.control');



let inc = document.querySelector('.font-inc');
let reset = document.querySelector('.font-reset');
let dec = document.querySelector('.font-dec');

light.addEventListener('click',function(){
  ControlHeader.classList.add("lighter")
  ControlHeader.classList.remove("darker")
  localStorage.mode='lighter';
  });

dark.addEventListener('click',function(){
  ControlHeader.classList.add("darker")
  ControlHeader.classList.remove("lighter")
  localStorage.mode = 'darker';
  });

  inc.addEventListener('click',function(){
    ControlHeader.classList.add("largefont")
    ControlHeader.classList.remove("normalfont","smallfont")
    localStorage.fontSize = 'larger';
        });

 reset.addEventListener('click',function(){
  ControlHeader.classList.add("normal")
  ControlHeader.classList.remove("largefont","smallfont")
     localStorage.fontSize = 'normal';
      });
            
  dec.addEventListener('click',function(){
  ControlHeader.classList.add("smallfont")
  ControlHeader.classList.remove("largefont","normalfont")
     localStorage.fontSize = 'smaller';
     });

     if (localStorage.fontSize == 'normal')
     {
      ControlHeader.classList.add("normal")
      ControlHeader.classList.remove("largefont","smallfont")
     };
     if (localStorage.fontSize == 'larger')
     {
      ControlHeader.classList.add("largefont")
      ControlHeader.classList.remove("normalfont","smallfont")
     };
     if (localStorage.fontSize == 'smaller')
     {
      ControlHeader.classList.add("smallfont")
      ControlHeader.classList.remove("largefont","normalfont")
     };
   
   
     if (localStorage.mode == 'darker')
     {
      ControlHeader.classList.add("darker")
      ControlHeader.classList.remove('lighter');
     };
     if (localStorage.mode == 'lighter')
     {
      ControlHeader.classList.add("lighter")
      ControlHeader.classList.remove("darker")
     };  




