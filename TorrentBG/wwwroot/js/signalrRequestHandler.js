$(() => {
    LoadProdData();

    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrserver").build();
    connection.start();

    connection.on("CommentReceive", function () {
        LoadProdData();
    })

    LoadProdData();

    function LoadProdData() {
        var template = '';
        $.ajax({
            url: '/Torrents/GetComments',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) =>
                {
                    template += `
                    <div class="media">
                      <a class="pull-left" href="#"><img class="media-object" src="~/img/${v.userImage}" alt="${v.userName} photo"></a>
                        <div class="media-body">
                            <h4 class="media-heading">${v.userName}</h4>
                            <p>${v.text}</p>
                            <ul class="list-unstyled list-inline media-detail pull-left">
                                  <li><i class="fa fa-calendar"></i>27/02/2014</li>
                                  <li><i class="fa fa-thumbs-up"></i>13</li>
                           </ul>
                          // <ul class="list-unstyled list-inline media-detail pull-right">
                          //        <li class=""><a href="">Like</a></li>
                          //        <li class=""><a href="">Reply</a></li>
                          //</ul>
                       </div>
                  </div>`
                })

                $("#section").html(template);
            },
            error: (error) => {
                console.log(error)
            }
        })
    }
})