// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

j = jQuery.noConflict();

function Positiva(link)
{
    var nid = link.getAttribute("noticiaId");

	if (j("#lnkPositiva" + nid).attr("class").indexOf("btn-success") == -1) {
		j.get('/home/positiva', { id: nid }, function (data) {
			if (data.status == true) {
				j("#lnkPositiva" + nid).removeClass("btn-outline-success");
				j("#lnkPositiva" + nid).removeClass("btn-success");
				j("#lnkPositiva" + nid).addClass("btn-success");

				j("#lnkNegativa" + nid).removeClass("btn-danger");
				j("#lnkNegativa" + nid).removeClass("btn-outline-dange");
				j("#lnkNegativa" + nid).addClass("btn-outline-danger");

				j("#lnkNeutra" + nid).removeClass("btn-warning");
				j("#lnkNeutra" + nid).removeClass("btn-outline-warning");
				j("#lnkNeutra" + nid).addClass("btn-outline-warning");
			}

		}).fail(function (err) {
			alert(err.responseText);
		});
	}
}
function Negativa(link) {
	var nid = link.getAttribute("noticiaId");

	if (j("#lnkNegativa" + nid).attr("class").indexOf("btn-danger") == -1) {
		j.get('/home/negativa', { id: nid }, function (data) {
			if (data.status == true) {
				j("#lnkPositiva" + nid).removeClass("btn-success");
				j("#lnkPositiva" + nid).removeClass("btn-outline-success");
				j("#lnkPositiva" + nid).addClass("btn-outline-success");

				j("#lnkNegativa" + nid).removeClass("btn-danger");
				j("#lnkNegativa" + nid).removeClass("btn-outline-danger");
				j("#lnkNegativa" + nid).addClass("btn-danger");

				j("#lnkNeutra" + nid).removeClass("btn-warning");
				j("#lnkNeutra" + nid).removeClass("btn-outline-warning");
				j("#lnkNeutra" + nid).addClass("btn-outline-warning");
			}

		}).fail(function (err) {
			alert(err.responseText);
		});
	}
}
function Neutra(link) {
	var nid = link.getAttribute("noticiaId");

	if (j("#lnkNeutra" + nid).attr("class").indexOf("btn-warning") == -1) {
		j.get('/home/neutra', { id: nid }, function (data) {
			if (data.status == true) {
				j("#lnkPositiva" + nid).removeClass("btn-success");
				j("#lnkPositiva" + nid).removeClass("btn-outline-success");
				j("#lnkPositiva" + nid).addClass("btn-outline-success");

				j("#lnkNegativa" + nid).removeClass("btn-danger");
				j("#lnkNegativa" + nid).removeClass("btn-outline-danger");
				j("#lnkNegativa" + nid).addClass("btn-outline-danger");

				j("#lnkNeutra" + nid).removeClass("btn-warning");
				j("#lnkNeutra" + nid).removeClass("btn-outline-warning");
				j("#lnkNeutra" + nid).addClass("btn-warning");
			}

		}).fail(function (err) {
			alert(err.responseText);
		});
	}
}