var kwvideo = document.querySelector(".kwvideo")
var video = document.querySelector("video")
function popup()
{
    kwvideo.classList.toggle("watching", true)
}
function exit()
{
    kwvideo.classList.toggle("watching", false)
    video.pause();
}