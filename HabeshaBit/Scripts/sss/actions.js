var http = false;

if(navigator.appName == "Microsoft Internet Explorer") {
	http = new ActiveXObject("Microsoft.XMLHTTP");
} else {
	http = new XMLHttpRequest();
}

function addtolist(elementID, song, action) {

  var audio_id = "audio_"+song;

  http.abort();
  http.open("GET", "/action/playlist.php?un=" + song+ "&ar=" + action, true);

  http.onreadystatechange=function() {
    if(http.readyState == 4) {
      document.getElementById(audio_id).innerHTML = http.responseText;
    }
  }

  http.send(null);
}

function popitup(url) {
  newwindow=window.open(url,'name','scrollbars=yes,toolbar=no, bar=no,status=no,height=600,width=600');
  if (window.focus) { newwindow.focus(); }
  return false;
}

function addToCart(id){

  var q = document.getElementById("quantity_"+id).value;

  $.ajax({
    type:'post',
    url:'/action/addtocart.php',
    data:{
      quantity: q,
      album: id,
    },
    success:function(response) {
      document.getElementById("response_"+id).innerHTML=response;
    }
  });

}

function checkout(){

  var checkout_form = $('#my_awesome_form');

  $.ajax({
    type:'post',
    url:'/action/checkout.php',
    data: checkout_form.serialize(),
    success:function(response) {
      console.log( response );
      // document.getElementById("response_"+id).innerHTML=response;
    }
  });

}

// --- Submit
$(function(){

  $("#submit_comment").click(function(event){
  	event.preventDefault();
    $('#comment_status').html("Please wait ....");
  	$.post( 
        "/action/comments.php",
        $("#comment_form").serializeArray(),
        function(data) {
          $('#comment_status').html(data);
        }
     );
  });



  $("#submit_registration").click(function(event){
    	event.preventDefault();
      $('#registration_status').html("Please wait ....");
     	$.post( 
        "/action/register.php",
        $("#registration_form").serializeArray(),
        function(data) {
          if (data == 'redirecting...'){
            window.location.replace("/login.php");
          } else {
            $('#registration_status').html(data);	
          }
        }
     );
  });

  $("#submit_search_form").click(function(event){
      event.preventDefault();
      $('#search_results').html("Please wait ....");
      $.post( 
        "/action/search.php",
        $("#search_form").serializeArray(),
        function(data) {
          $('#search_results').html(data); 
        }
     );
  });

  $("#submit_login").click(function(event){
    	event.preventDefault();
      $('#login_status').html("Please wait ....");
     	$.post( 
        "/action/authentication.php",
        $("#login_form").serializeArray(),
        function(data) {

        	if (data == 'redirecting...'){
        		window.location.replace("/genres.php");
        	} else {
        		$('#login_status').html(data);	
        	}
        }
     );
  });

  $("#submit_reset").click(function(event){
      event.preventDefault();
      $('#reset_status').html("Please wait ....");
     	$.post( 
        "/action/reset.php",
        $("#reset_form").serializeArray(),
        function(data) {
        	if (data == 'redirecting...'){
        		window.location.replace("/login.php");
        	} else {
        		$('#reset_status').html(data);	
        	}
        }
     );
  });
	
  $("#submit_update").click(function(event){
      event.preventDefault();
      $('#update_status').html("Please wait ....");
     	$.post( 
        "/action/update.php",
        $("#update_form").serializeArray(),
        function(data) {
        	if (data == 'redirecting...'){
        		window.location.replace("/login.php");
        	} else {
        		$('#update_status').html(data);	
        	}
        }
     );
  });

  $("#submit_contact").click(function(event){
      event.preventDefault();
      $('#contact_status').html("Please wait ....");
      $.post( 
        "/action/contact.php",
        $("#contact_form").serializeArray(),
        function(data) {
            $('#contact_status').html(data);
            $("#submit_contact").prop("disabled",true);
        }
     );
  });

	$("#logout, #logoutside").click(function(event){
      event.preventDefault();
      $.post( 
      "/action/logout.php",
      function(data) {
      	if (data == 'redirecting...'){
      		window.location.replace("/index.php");
      	}
      }
      );
  });

});