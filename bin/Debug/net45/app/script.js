function navigate()
{
    console.log('nav')
    var div = document.createElement('div')
    div.innerHTML = "Hi"
    document.body.appendChild(div)
    window.location.replace('myApp://method/go')
}