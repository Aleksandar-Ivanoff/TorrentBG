"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/commentHub").build();

connection.on("CommentIsCreated", function (user, message)
{
    const comment = ` <div class="media" >
                            <a class="pull-left" href="#"><img class="media-object" src="https://bootdey.com/img/Content/avatar/avatar1.png" alt=""></a>
                            <div class="media-body">
                                <h4 class="media-heading">${user}</h4>
                                <p>${message}</p>
                                <ul class="list-unstyled list-inline media-detail pull-left">
                                    <li><i class="fa fa-calendar"></i>27/02/2014</li>
                                    <li><i class="fa fa-thumbs-up"></i>13</li>
                                </ul>
                                <ul class="list-unstyled list-inline media-detail pull-right">
                                    <li class=""><a href="">Like</a></li>
                                    <li class=""><a href="">Reply</a></li>
                                </ul>
                            </div>
                        </div>`;

    let commentParentElement = document.getElementById("section")
    commentParentElement.innerHTML += comment;
 
});

connection.start().then(() => {
    document.getElementById('sendButton').disabled = false;
}).catch((error) => {
    return console.error(error.toString());
});


document.getElementById('sendButton').addEventListener("click", (event) => {
    let user = document.getElementById('userInput').textContent;
    let torrent = document.getElementById('torrentName').textContent;
    let message = document.getElementById('message').value;
    console.log(user);

    connection.invoke("SendComment", user, message, torrent).then(() => {

        console.log("comment is created")

       
        
    }).catch((error) => console.error(error.toString()));

    event.preventDefault();


});


function Show() {
    const section = document.getElementById('comments');

    section.style.display === 'none' ? section.style.display = 'block' : section.style.display = 'none'
}